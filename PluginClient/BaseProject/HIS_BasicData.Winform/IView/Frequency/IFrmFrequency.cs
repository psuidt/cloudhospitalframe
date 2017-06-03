using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.Frequency
{
    /// <summary>
    /// 频次维护接口
    /// </summary>
    public interface IFrmFrequency : IBaseView
    {
        /// <summary>
        /// 当前选中行
        /// </summary>
        int RowIndex { get; set; }

        /// <summary>
        /// 频次ID
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 绑定频次列表
        /// </summary>
        /// <param name="dt">频次列表</param>
        void BindFrequencyInfo(DataTable dt);
    }
}
