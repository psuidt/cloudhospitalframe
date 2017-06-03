using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using grproLib;
using DevComponents.DotNetBar;
using EFWCoreLib.WinformFrame.Controller;
using base_reportmanage.winform.IView;

namespace base_reportmanage.winform.ViewForm
{
    public partial class FrmReportDesigner : BaseForm, IFrmReportDesigner
    {
        public FrmReportDesigner()
        {
            InitializeComponent();
        }

        #region IFrmReportDesigner 成员

        public void loadreportfile(string reportfile)
        {
            GridppReport Report = new GridppReport();
            if (Report.LoadFromFile(reportfile))
            {
                this.axGRDesigner1.Report = Report;
                
            }
            else
            {
                MessageBoxEx.Show("此报表文件有误，无法进行设计！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
