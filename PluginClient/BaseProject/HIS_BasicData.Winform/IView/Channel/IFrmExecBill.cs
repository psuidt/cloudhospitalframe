using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.IView.Channel
{
    /// <summary>
    /// 执行单配置接口
    /// </summary>
    public interface IFrmExecBill : IBaseView
    {
        /// <summary>
        /// 执行单网格当前选中行
        /// </summary>
        int RowIndex { get; set; }

        /// <summary>
        /// 执行单ID
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 绑定执行单数据
        /// </summary>
        /// <param name="dt">执行单列表</param>
        void BingExecBillInfo(DataTable dt);

        /// <summary>
        /// 绑定执行单数据
        /// </summary>
        /// <param name="dt">执行单列表</param>
        void BindChannelInfo(DataTable dt);

        /// <summary>
        /// 执行单关联用法列表
        /// </summary>
        List<Basic_ExecuteBillChannel> DeleteList { get; set; }
    }
}
