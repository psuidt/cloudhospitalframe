using System.Data;
using EFWCoreLib.WinformFrame.Controller;

namespace HIS_BasicData.Winform.IView.Payment
{
    /// <summary>
    /// 支付方式组合维护
    /// </summary>
    public interface IfrmPaymentRel : IBaseView
    {
        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构ID</param>
        void loadWorkerDataBox(DataTable dt, int defaultWorkID);

        /// <summary>
        /// 绑定业务系统列表
        /// </summary>
        /// <param name="dt">业务系统列表</param>
        void loadSystemTypeBox(DataTable dt);

        /// <summary>
        /// 绑定病人类型列表
        /// </summary>
        /// <param name="dt">病人类型列表</param>
        void loadPatTypeBox(DataTable dt);

        /// <summary>
        /// 绑定支付方式
        /// </summary>
        /// <param name="dt">支付方式</param>
        void loadPaymentBox(DataTable dt);

        /// <summary>
        /// 绑定本院支付方式
        /// </summary>
        /// <param name="dt">本院支付方式</param>
        void loadHospPaymentGrid(DataTable dt);
    }
}
