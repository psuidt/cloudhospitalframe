using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace EfwControls.Common
{
    public class SqlDbHelper
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private SqlDataAdapter adapter;
        private string connectionString = @"Data Source=.;Initial Catalog=EFWDB;User ID=sa;pwd=1;";

        public string ConnectionString
        {
            get { return this.connectionString; }
            set { this.connectionString = value; }
        }

        /// <summary>
        /// 获取一个未打开连接的SqlConnection对象
        /// </summary>
        /// <returns>SqlConnection对象</returns>
        public SqlConnection GetConnection()
        {
            if (conn != null)
                return this.conn;
            return this.conn = new SqlConnection(connectionString);
        }

        /// <summary>
        /// 使用连接字符串获取未打开连接SqlConnection对象
        /// </summary>
        /// <param name="_connStr">连接字符串</param>
        /// <returns>SqlConnection对象</returns>
        public SqlConnection GetConnection(string _connStr)
        {
            if (this.conn != null)
                this.conn.ConnectionString = _connStr;
            else
                this.conn = new SqlConnection(_connStr);
            return this.conn;
        }

        /// <summary>
        /// 使用指定的Sql语句创建SqlCommand对象
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <returns>SqlCommand对象</returns>
        private SqlCommand GetCommand(string sqlStr)
        {
            if (this.conn == null)
                this.conn = GetConnection();
            if (this.cmd == null)
                this.cmd = this.GetCommand(sqlStr, CommandType.Text, null);
            else
            {
                this.cmd.CommandType = CommandType.Text;
                this.cmd.Parameters.Clear();
            }
            this.cmd.CommandText = sqlStr;
            return this.cmd;
        }

        /// <summary>
        /// 使用指定的Sql语句,CommandType,SqlParameter数组创建SqlCommand对象
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <param name="type">命令类型</param>
        /// <param name="paras">SqlParameter数组</param>
        /// <returns>SqlCommand对象</returns>
        public SqlCommand GetCommand(string sqlStr, CommandType type, SqlParameter[] paras)
        {
            if (conn == null)
                this.conn = this.GetConnection();
            if (cmd == null)
                this.cmd = conn.CreateCommand();
            this.cmd.CommandType = type;
            this.cmd.CommandText = sqlStr;
            this.cmd.Parameters.Clear();
            if (paras != null)
                this.cmd.Parameters.AddRange(paras);
            return this.cmd;
        }

        /// <summary>
        /// 执行Sql语句返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <returns>受影响的行数,失败则返回-1</returns>
        public int ExecuteNoQuery(string sqlStr)
        {
            int line = -1;
            CheckArgs(sqlStr);
            try { OpenConn(); line = this.ExecuteNonQuery(sqlStr, CommandType.Text, null); }
            catch (SqlException e) { throw e; }
            return line;
        }

        /// <summary>
        /// 使用指定的Sql语句,CommandType,SqlParameter数组执行Sql语句,返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <param name="type">命令类型</param>
        /// <param name="paras">SqlParameter数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sqlStr, CommandType type, SqlParameter[] paras)
        {
            int line = -1;
            CheckArgs(sqlStr);
            if (this.cmd == null)
                GetCommand(sqlStr, type, paras);
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sqlStr;
            this.cmd.CommandType = type;
            if (paras != null)
                this.cmd.Parameters.AddRange(paras);
            try { OpenConn(); line = this.cmd.ExecuteNonQuery(); }
            catch (SqlException e) { throw e; }
            return line;
        }

        /// <summary>
        /// 使用指定Sql语句获取dataTable
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <returns>DataTable对象</returns>
        public DataTable GetDataTable(string sqlStr)
        {
            CheckArgs(sqlStr);
            if (this.conn == null)
                this.conn = GetConnection();
            this.adapter = new SqlDataAdapter(sqlStr, this.conn);
            DataTable table = new DataTable();
            try { adapter.Fill(table); }
            catch (SqlException e) { throw e; }
            return table;
        }

        public DataTable GetDataTable(string procname, params object[] paras)
        {
            CheckArgs(procname);
            if (this.conn == null)
                this.conn = GetConnection();

            if (cmd == null)
                this.cmd = conn.CreateCommand();
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = procname;
            this.cmd.Parameters.Clear();
            if (paras != null)
            {
                foreach (object v in paras)
                {
                    //this.cmd.Parameters.AddRange(paras);
                    this.cmd.Parameters.Add(v);
                }
            }
            this.adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            try { adapter.Fill(table); }
            catch (SqlException e) { throw e; }
            return table;
        }

        /// <summary>
        /// 使用指定的Sql语句获取SqlDataReader
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <returns>SqlDataReader对象</returns>
        public SqlDataReader GetSqlDataReader(string sqlStr)
        {
            CheckArgs(sqlStr);
            if (cmd == null)
                GetCommand(sqlStr);
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sqlStr;
            this.cmd.Parameters.Clear();

            if (reader != null)
                reader.Dispose();
            try { OpenConn(); this.reader = this.cmd.ExecuteReader(); }
            catch (SqlException e) { throw e; }
            return this.reader;
        }

        /// <summary>
        /// 使用事务执行多条Sql语句
        /// </summary>
        /// <param name="sqlCommands">sql语句数组</param>
        /// <returns>全部成功则返回true否则返回false</returns>
        public bool ExecuteSqls(string[] sqlCommands)
        {
            if (sqlCommands == null)
                throw new ArgumentNullException();
            if (this.cmd == null)
                GetCommand(null);
            SqlTransaction tran = null;
            try
            {
                OpenConn();
                tran = this.conn.BeginTransaction();
                this.cmd.Transaction = tran;
                foreach (string sql in sqlCommands)
                {
                    if (ExecuteNoQuery(sql) == 0)
                    { tran.Rollback(); return false; }
                }
            }
            catch (SqlException e)
            {
                if (tran != null)
                    tran.Rollback();
                throw e;
            }
            tran.Commit();
            return true;
        }

        public int InsertSql(string sqlStr)
        {
            sqlStr += ";SELECT @@IDENTITY";
            int IDENTITY = 0;
            SqlDataReader sdr = GetSqlDataReader(sqlStr);
            if (sdr.Read())
            {
                IDENTITY = Convert.ToInt32(sdr.GetValue(0));
            }
            sdr.Close();
            return IDENTITY;
        }

        public object GetDataResult(string sqlStr)
        {
            object obj = null;
            SqlDataReader sdr = GetSqlDataReader(sqlStr);
            if (sdr.Read())
            {
                obj = (Object)sdr.GetValue(0);
            }
            sdr.Close();
            return obj;
        }

        public byte[] GetBlobData(string sqlStr)
        {
            Byte[] blob = null;

            SqlDataReader sdr = GetSqlDataReader(sqlStr);
            if (sdr.Read())
            {
                //blob = new Byte[(sdr.GetBytes(0, 0, null, 0, int.MaxValue))];
                //sdr.GetBytes(0, 0, blob, 0, blob.Length);
                object obj = sdr.GetValue(0);
                if (obj != System.DBNull.Value)
                    blob = (byte[])obj;
            }
            sdr.Close();
            return blob;
        }
        //UPDATE emrdb..EMR_MedicalRecord SET Word=@blob WHERE ID=1
        public bool SaveBlobData(string sqlStr, byte[] blob)
        {
            byte[] buffer = blob;
            SqlCommand cmd = GetCommand(sqlStr);
            cmd.Parameters.Add("@blob", SqlDbType.Image).Value = buffer;
            OpenConn(); 
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool SaveBlobData(string sqlStr, byte[] blob, out int IDENTITY)
        {
            sqlStr += ";SELECT @@IDENTITY";
            byte[] buffer = blob;
            SqlCommand cmd = GetCommand(sqlStr);
            cmd.Parameters.Add("@blob", SqlDbType.Image).Value = buffer;
            IDENTITY = 0;
            if (reader != null)
                reader.Dispose();
            try { OpenConn(); this.reader = this.cmd.ExecuteReader(); }
            catch (SqlException e) { throw e; }
            if (reader.Read())
            {
                IDENTITY = Convert.ToInt32(reader.GetValue(0));
            }
            reader.Close();
            return true;
        }

        private void OpenConn()
        {
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch (SqlException e) { throw e; }
        }

        private void CheckArgs(string sqlStr)
        {
            if (sqlStr == null)
                throw new ArgumentNullException();
            if (sqlStr.Length == 0)
                throw new ArgumentOutOfRangeException();
        }

    }
}