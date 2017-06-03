using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 支付方式数据访问对象
    /// </summary>
    public class SqlBasicDataPaymentDao : AbstractDao, IBasicDataPaymentDao
    {
        /// <summary>
        /// 删除本院支付方式
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>true：删除成功</returns>
        public bool DeleteHostPaymentData(int id)
        {
            string strsql = @"DELETE FROM Basic_PatTypePayment WHERE ID=" + id;
            oleDb.DoCommand(strsql);
            return true;
        }

        /// <summary>
        /// 获取中心支付方式，不包含停用的
        /// </summary>
        /// <returns>中心支付方式</returns>
        public DataTable GetCenterPaymentData()
        {
            string strsql = @"SELECT PaymentID,PayName FROM Basic_Payment WHERE DelFlag=0";
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取本院支付方式
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="patTypeId">支付方式类型</param>
        /// <returns>本院支付方式</returns>
        public DataTable GetHostPaymentData(int workId, int userType, int patTypeId)
        {
            string strsql = @"SELECT b.ID,a.*
                                ,(SELECT TOP 1 Name FROM View_GetPayInputFrom WHERE ID=a.InputFrom) InputFromName
                                ,b.PayOrder
                                ,(SELECT TOP 1 Name FROM View_GetPayUserType WHERE ID=b.UseType) UserTypeName
                                ,(SELECT TOP 1 PatTypeName FROM Basic_PatType WHERE PatTypeID={2}) PatTypeName
                                ,(SELECT TOP 1 Name FROM View_GetStopFlag WHERE ID=a.DelFlag) StopState
                                 FROM dbo.Basic_Payment a
                                INNER JOIN Basic_PatTypePayment b ON a.PaymentID=b.PaymentID
                                WHERE b.WorkID={0} AND b.UseType={1} AND b.PatTypeID={2}
                                ORDER BY a.DelFlag,b.PayOrder
                                ";
            strsql = string.Format(strsql, workId, userType, patTypeId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取支付方式计算方式
        /// </summary>
        /// <returns>支付方式计算方式</returns>
        public DataTable GetPayInputFrom()
        {
            return oleDb.GetDataTable(@"SELECT * FROM View_GetPayInputFrom");
        }

        /// <summary>
        /// 获取支付方式列表
        /// </summary>
        /// <returns>支付方式列表</returns>
        public DataTable GetPaymentData()
        {
            string strsql = @"SELECT 0 CK
                ,a.*
                ,(SELECT TOP 1 Name FROM View_GetPayInputFrom WHERE ID=a.InputFrom) InputFromName
                ,(SELECT TOP 1 Name FROM View_GetStopFlag WHERE ID=a.DelFlag) StopState FROM dbo.Basic_Payment a
                ORDER BY a.DelFlag,a.SortOrder,a.PaymentID";
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取支付方式类型列表
        /// </summary>
        /// <returns>支付方式类型列表</returns>
        public DataTable GetPayTypeData()
        {
            return oleDb.GetDataTable(@"SELECT * FROM View_GetPayUserType");
        }

        /// <summary>
        /// 删除支付方式
        /// </summary>
        /// <param name="paymentId">支付方式ID</param>
        /// <param name="val">删除标志</param>
        /// <returns>true：删除成功</returns>
        public bool SwitchPayment(int paymentId, int val)
        {
            string strsql = @"UPDATE Basic_Payment SET DelFlag={1} WHERE PaymentID={0}";
            strsql = string.Format(strsql, paymentId, val);
            oleDb.DoCommand(strsql);
            return true;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="dtPayment">支付记录表</param>
        public void SortPayment(DataTable dtPayment)
        {
            for (int i = 0; i < dtPayment.Rows.Count; i++)
            {
                string sql = "UPDATE Basic_PatTypePayment SET PayOrder={0} WHERE PaymentID={1}";
                int sortNo = (i + 1);
                sql = string.Format(sql, sortNo, dtPayment.Rows[i]["PaymentID"].ToString());
                oleDb.DoCommand(sql);
            }
        }

        /// <summary>
        /// 添加本院支付方式
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="patTypeId">支付方式类型ID</param>
        /// <param name="paymentId">支付方式ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="payorder">排序</param>
        /// <returns>true：保存成功</returns>
        public bool AddHospPayment(int workId, int patTypeId, int paymentId, int userType, int payorder)
        {
            string strsql = @"SELECT COUNT(1) FROM Basic_PatTypePayment
                                WHERE WorkID={0} AND UseType={1} AND PatTypeID={2} AND PaymentID={3}";
            strsql = string.Format(strsql, workId, userType, patTypeId, paymentId);
            if (Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0)
            {
                throw new Exception("该支付方式已经存在，不能重复添加！");
            }

            strsql = @"INSERT INTO Basic_PatTypePayment VALUES(
                        {0},{1},{2},{3},{4})";
            strsql = string.Format(strsql, patTypeId, paymentId, userType, payorder, workId);
            oleDb.DoCommand(strsql);
            return true;
        }
    }
}
