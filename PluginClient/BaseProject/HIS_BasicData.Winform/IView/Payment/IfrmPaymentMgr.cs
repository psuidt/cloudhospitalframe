using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.Payment
{
    /// <summary>
    /// 支付方式维护接口
    /// </summary>
    public interface IfrmPaymentMgr : IBaseView
    {
        /// <summary>
        /// 绑定计算方式列表
        /// </summary>
        /// <param name="dt">计算方式列表</param>
        void loadInputFromBox(DataTable dt);

        /// <summary>
        /// 绑定支付方式列表
        /// </summary>
        /// <param name="dt">支付方式列表</param>
        void loadPaymentGrid(DataTable dt);

        /// <summary>
        /// 选中的支付方式
        /// </summary>
        Basic_Payment CurrPayment { get; set; }
    }
}
