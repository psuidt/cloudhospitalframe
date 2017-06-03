using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView;

namespace HIS_BasicData.Winform.ViewForm
{
    /// <summary>
    /// 打印机配置管理
    /// </summary>
    public partial class FrmReportConfigure : BaseFormBusiness, IFrmReportConfigure
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmReportConfigure()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 读取报表数据
        /// </summary>
        /// <param name="dt">数据集</param>
        public void LoadReportGrid(DataTable dt)
        {
            gridReport.DataSource = dt;
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmReportConfigure_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("GetReportData");
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmReportConfigure_Load(object sender, EventArgs e)
        {
            InvokeController("GetReportData");
        }
    }
}
