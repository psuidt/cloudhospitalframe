using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.Entrust
{
    /// <summary>
    /// 嘱托维护接口
    /// </summary>
    public interface IFrmEntrust : IBaseView
    {
        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 当前选中的嘱托
        /// </summary>
        int RowIndex { get; set; }

        /// <summary>
        /// 绑定嘱托列表
        /// </summary>
        /// <param name="dtEntrust">嘱托列表</param>
        void BindEntrust(DataTable dtEntrust);

        /// <summary>
        /// 嘱托ID
        /// </summary>
        int Entrust { get; set; }
    }
}
