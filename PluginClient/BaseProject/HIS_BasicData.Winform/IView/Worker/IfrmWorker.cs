using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.Worker
{
    /// <summary>
    /// 机构维护接口
    /// </summary>
    public interface IFrmWorker : IBaseView
    {
        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="dtWorkers">机构列表</param>
        void LoadWorkers(List<BaseWorkers> dtWorkers);

        /// <summary>
        /// 加载机构详情
        /// </summary>
        /// <param name="workerDetail">机构详情</param>
        void LoadWorkerDetail(BaseWorkesDetails workerDetail);

        /// <summary>
        /// 获取机构等级数据源
        /// </summary>
        /// <param name="dtWorkerGrade">机构等级数据源</param>
        void LoadBasicDataForGrade(DataTable dtWorkerGrade);

        /// <summary>
        /// 获取机构级别数据源
        /// </summary>
        /// <param name="dtWorkerClass">机构级别数据源</param>
        void LoadBasicDataForClass(DataTable dtWorkerClass);
    }
}
