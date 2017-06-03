using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 报表数据访问对象
    /// </summary>
    public class SqlBasicDataReportDao : AbstractDao, IBasicDataReportDao
    {
        /// <summary>
        /// 获取业务系统
        /// </summary>
        /// <returns>业务系统列表</returns>
        public DataTable GetSystemTypeData()
        {
            return oleDb.GetDataTable(@"SELECT * FROM View_GetSystemType");
        }

        /// <summary>
        /// 获取报表文件
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <returns>报表文件</returns>
        public byte[] GetReportFile(int id)
        {
            string strsql = @"SELECT Format FROM Basic_ReportConfig WHERE ID={0}";
            return oleDb.GetBlobData(string.Format(strsql, id));
        }

        /// <summary>
        /// 上传报表文件
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="buffur">报表内容</param>
        /// <param name="fileName">报表文件名</param>
        /// <param name="modifyer">操作员</param>
        /// <param name="updateTime">上传时间</param>
        public void UploadReportFile(int id, byte[] buffur, string fileName, int modifyer, DateTime updateTime)
        {
            string strsql = @"UPDATE Basic_ReportConfig SET Format=@blob WHERE ID={0}";
            oleDb.SaveBlobData(string.Format(strsql, id), buffur);
            strsql = @"UPDATE Basic_ReportConfig SET FileName='{0}',UpdateTime='{1}',Modifyer={2} WHERE ID={3}";
            strsql = string.Format(strsql, fileName, updateTime, modifyer, id);
            oleDb.DoCommand(strsql);
        }

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="sysType">报表类型</param>
        /// <param name="searchKey">检索条件</param>
        /// <returns>报表列表</returns>
        public DataTable GetReportData(int workID, int sysType, string searchKey)
        {
            string strsql = @" SELECT 0 CK,a.ID,a.ReportType,a.EnumValue,a.ReportTitle,a.FileName,a.UpdateTime,a.Modifyer,a.DelFlag
                                ,(dbo.fnGetEmpName(a.Modifyer)) EmpName
                                ,(CASE ReportType WHEN 0 THEN '基础' WHEN 1 THEN '门诊' WHEN 2 THEN '住院' WHEN 3 THEN '药品' WHEN 4 THEN '物资' END) TypeName
                                ,(CASE Delflag WHEN 1 THEN '已停用' ELSE '已启用' END) StopState
                                FROM Basic_ReportConfig a 
                                WHERE WorkID={0} AND a.ReportType={1} AND (Convert(VARCHAR(10),a.EnumValue) LIKE '%{2}%' OR a.ReportTitle LIKE '%{2}%')
                                ORDER BY DelFlag,EnumValue";
            strsql = string.Format(strsql, workID, sysType, searchKey);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取报表基础数据
        /// </summary>
        /// <returns>报表基础数据列表</returns>
        public DataTable GetReportBasicData()
        {
            string strSql = @" SELECT ID,FileName as ReportTitle,EnumValue FROM Basic_ReportConfig WHERE WorkID={0} ORDER BY EnumValue";
            strSql = string.Format(strSql, oleDb.WorkId);
            return oleDb.GetDataTable(strSql);
        }

        /// <summary>
        /// 验证报表编号是否重复
        /// </summary>
        /// <param name="enumValue">编号</param>
        /// <param name="workID">机构ID</param>
        /// <returns>true：重复</returns>
        public bool ExistReport(int enumValue, int workID)
        {
            string strsql = @"SELECT COUNT(ID) FROM Basic_ReportConfig WHERE EnumValue={0} AND WorkID={1}";
            strsql = string.Format(strsql, enumValue, workID);
            return Convert.ToInt32(oleDb.GetDataResult(strsql)) > 0;
        }

        /// <summary>
        /// 删除报表
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="val">删除标志</param>
        /// <returns>true：删除成功</returns>
        public bool SwitchReport(int id, int val)
        {
            string strsql = @"UPDATE Basic_ReportConfig SET Delflag={1} WHERE ID={0}";
            strsql = string.Format(strsql, id, val);
            oleDb.DoCommand(strsql);
            return true;
        }

        /// <summary>
        /// 保存报表数据
        /// </summary>
        /// <param name="report">报表数据</param>
        /// <returns>true：保存成功</returns>
        public bool SaveReport(Basic_ReportConfig report)
        {
            string strsql = string.Empty;
            //新增
            if (report.ID == 0)
            {
                strsql = @"INSERT INTO Basic_ReportConfig
                                        ( ReportType ,EnumValue ,ReportTitle ,WBCode ,PYCode,FileName ,UpdateTime , Modifyer ,DelFlag ,WorkID)
                                VALUES  ({0},{1},'{2}','{3}','{4}','',GETDATE(),{5},{6},{7})";
                strsql = string.Format(strsql, report.ReportType, report.EnumValue, report.ReportTitle, report.PYCode, report.WBCode, report.Modifyer, report.DelFlag, oleDb.WorkId);
                report.ID = oleDb.InsertRecord(strsql);
            }
            else
            {
                //修改
                strsql = @"UPDATE Basic_ReportConfig SET ReportTitle='{1}',WBCode='{2}',PYCode='{3}',Modifyer={4} WHERE ID={0}";
                strsql = string.Format(strsql, report.ID, report.ReportTitle, report.PYCode, report.WBCode, report.Modifyer);
                oleDb.DoCommand(strsql);
            }

            return true;
        }
    }
}
