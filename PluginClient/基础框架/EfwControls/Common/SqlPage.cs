using System;


namespace EfwControls.Common
{
    /// <summary>
    /// SQL语句进行分页包装
    /// </summary>
    public class SqlPage
    {
        /// <summary>
        /// 格式化SQL语句
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="pageInfo"></param>
        /// <param name="oleDb"></param>
        /// <returns></returns>
        public static string FormatSql(string strsql, PageInfo pageInfo, Func<string,int> funcGetTotal)
        {
            return Sql2005FormatSql(strsql, pageInfo, funcGetTotal);
        }

        private static string Db2FormatSql(string strsql, PageInfo pageInfo, Func<string, int> funcGetTotal)
        {
            
            if (pageInfo.KeyName == null || pageInfo.KeyName == "")
                throw new Exception("分页KeyName属性不能为空，如：pageInfo.KeyName==\"Id\" 或 pageInfo.KeyName==\"Id|Desc\"");

            int starRecordNum = pageInfo.startNum;
            int endRecordNum = pageInfo.endNum;
            //int index = strsql.ToLower().LastIndexOf("order by");
            //string _strsql = null;
            //if (index != -1)
            //    _strsql = strsql.Remove(index);
            //else
            //    _strsql = strsql;

            string _strsql = strsql;


            string sql_totalRecord = "select count(*) from (" + _strsql + ") A";
            //Object obj = oleDb.GetDataResult(sql_totalRecord);
            pageInfo.totalRecord = funcGetTotal(sql_totalRecord);

            string _sql = _strsql;
            string[] orderbys = pageInfo.KeyName.Split(new char[] { '|' });
            string orderbyname, orderby;
            if (orderbys.Length != 2)
            {
                orderbyname = orderbys[0];
                orderby = "desc";
            }
            else
            {
                orderbyname = orderbys[0];
                orderby = orderbys[1];
            }

            strsql = @"select * from (
                                select rownumber() over(order by {3} {4}) as rowid,  t.* from ({0}) t
                            )as a where a.rowid >= {1} AND  a.rowid < {2}";

            strsql = String.Format(strsql, _sql, starRecordNum, endRecordNum, orderbyname, orderby);
            return strsql;
        }
        private static string Sql2000FormatSql(string strsql, PageInfo pageInfo, Func<string, int> funcGetTotal)
        {
            return null;
        }
        private static string Sql2005FormatSql(string strsql, PageInfo pageInfo, Func<string, int> funcGetTotal)
        {
            if (pageInfo.KeyName == null || pageInfo.KeyName == "")
                throw new Exception("分页KeyName属性不能为空，如：pageInfo.KeyName==\"Id\" 或 pageInfo.KeyName==\"Id|Desc\"");

            int starRecordNum = pageInfo.startNum;
            int endRecordNum = pageInfo.endNum;
            int index = strsql.ToLower().LastIndexOf("order by");
            string _strsql = null;
            if (index != -1)
                _strsql = strsql.Remove(index);
            else
                _strsql = strsql;


            string sql_totalRecord = "select TOP 1 count(*) from (" + _strsql + ") A";
            //Object obj = oleDb.GetDataResult(sql_totalRecord);
            pageInfo.totalRecord = funcGetTotal(sql_totalRecord);

            string _sql = _strsql;
            string[] orderbys = pageInfo.KeyName.Split(new char[] { '|' });
            string orderbyname, orderby;
            if (orderbys.Length != 2)
            {
                orderbyname = orderbys[0];
                orderby = "desc";
            }
            else
            {
                orderbyname = orderbys[0];
                orderby = orderbys[1];
            }

            strsql = @"select * from
                        (
                        select row_number() over(order by {3} {4}) as rownum,t.* from ({0}) t
                        ) as a where rownum between {1} and {2}";

            strsql = String.Format(strsql, _sql, starRecordNum, endRecordNum, orderbyname, orderby);
            return strsql;
        }
        private static string MsAccessFormatSql(string strsql, PageInfo pageInfo, Func<string, int> funcGetTotal)
        {
            return null;
        }
        private static string MySQLFormatSql(string strsql, PageInfo pageInfo, Func<string, int> funcGetTotal)
        {
            if (pageInfo.KeyName == null || pageInfo.KeyName == "")
                throw new Exception("分页KeyName属性不能为空，如：pageInfo.KeyName==\"Id\" 或 pageInfo.KeyName==\"Id|Desc\"");

            int starRecordNum = pageInfo.startNum;
            int endRecordNum = pageInfo.endNum;
            //int index = strsql.ToLower().LastIndexOf("order by");
            //string _strsql = null;
            //if (index != -1)
            //    _strsql = strsql.Remove(index);
            //else
            //    _strsql = strsql;

            string _strsql = strsql;


            string sql_totalRecord = "select count(*) from (" + _strsql + ") A";
            //Object obj = oleDb.GetDataResult(sql_totalRecord);
            pageInfo.totalRecord = funcGetTotal(sql_totalRecord);

            string _sql = _strsql;
            string[] orderbys = pageInfo.KeyName.Split(new char[] { '|' });
            string orderbyname, orderby;
            if (orderbys.Length != 2)
            {
                orderbyname = orderbys[0];
                orderby = "desc";
            }
            else
            {
                orderbyname = orderbys[0];
                orderby = orderbys[1];
            }

            strsql = @"select * from (
                                select rownumber() over(order by {3} {4}) as rowid,  t.* from ({0}) t
                            )as a where a.rowid >= {1} AND  a.rowid < {2}";

            strsql = String.Format(strsql, _sql, starRecordNum, endRecordNum, orderbyname, orderby);
            return strsql;
        }
        private static string OracleFormatSql(string strsql, PageInfo pageInfo, Func<string, int> funcGetTotal)
        {
            int starRecordNum = pageInfo.startNum;
            int endRecordNum = pageInfo.endNum;

            string sql_totalRecord = "select count(*) from (" + strsql + ") A";
            //Object obj = oleDb.GetDataResult(sql_totalRecord);
            pageInfo.totalRecord = funcGetTotal(sql_totalRecord);

            strsql = " select * from( select a.*,rownum rn from ( " + strsql + " ) a )  where rn between " + starRecordNum.ToString() + " and " + endRecordNum.ToString();
           
            return strsql;
        }
    }
}
