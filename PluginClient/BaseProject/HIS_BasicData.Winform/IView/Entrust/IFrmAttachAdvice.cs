using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.Entrust
{
    /// <summary>
    /// 说明性医嘱维护接口
    /// </summary>
    public interface IFrmAttachAdvice : IBaseView
    {
        /// <summary>
        /// 当前选中行
        /// </summary>
        int RowIndex { get; set; }

        /// <summary>
        /// 说明性医嘱ID
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 绑定单位列表
        /// </summary>
        /// <param name="dt">单位列表</param>
        void LoadUnitInfo(DataTable dt);

        /// <summary>
        /// 绑定网格内容
        /// </summary>
        /// <param name="dt">嘱托列表</param>
        void BindAttachAdvice(DataTable dt);
    }
}
