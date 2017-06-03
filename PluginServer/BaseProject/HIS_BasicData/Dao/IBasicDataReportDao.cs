using System;
using System.Data;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 报表数据访问接口
    /// </summary>
    public interface IBasicDataReportDao
    {
        /// <summary>
        /// 获取业务系统
        /// </summary>
        /// <returns>业务系统列表</returns>
        DataTable GetSystemTypeData();

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="sysType">报表类型</param>
        /// <param name="searchKey">检索条件</param>
        /// <returns>报表列表</returns>
        DataTable GetReportData(int workID, int sysType, string searchKey);

        /// <summary>
        /// 验证报表编号是否重复
        /// </summary>
        /// <param name="enumValue">编号</param>
        /// <param name="workID">机构ID</param>
        /// <returns>true：重复</returns>
        bool ExistReport(int enumValue, int workID);

        /// <summary>
        /// 获取报表文件
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <returns>报表文件</returns>
        byte[] GetReportFile(int id);

        /// <summary>
        /// 上传报表文件
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="buffur">报表内容</param>
        /// <param name="fileName">报表文件名</param>
        /// <param name="modifyer">操作员</param>
        /// <param name="updateTime">上传时间</param>
        void UploadReportFile(int id, byte[] buffur, string fileName, int modifyer, DateTime updateTime);

        /// <summary>
        /// 保存报表数据
        /// </summary>
        /// <param name="report">报表数据</param>
        /// <returns>true：保存成功</returns>
        bool SaveReport(Basic_ReportConfig report);

        /// <summary>
        /// 删除报表
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="val">删除标志</param>
        /// <returns>true：删除成功</returns>
        bool SwitchReport(int id, int val);

        /// <summary>
        /// 获取报表基础数据
        /// </summary>
        /// <returns>报表基础数据列表</returns>
        DataTable GetReportBasicData();
    }
}
