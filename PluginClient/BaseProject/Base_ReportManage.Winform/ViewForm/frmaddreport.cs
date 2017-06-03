using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using base_reportmanage.winform.IView;
using EFWCoreLib.WinformFrame.Controller;
using DevComponents.DotNetBar;
using base_reportmanage.Entity;
using EfwControls.CustomControl;

namespace base_reportmanage.winform.ViewForm
{
    public partial class frmAddReport : DialogForm, IfrmAddReport
    {
        public frmAddReport()
        {
            InitializeComponent();
            frmForm1.AddItem(textBoxX1,  "Name", "请输入名称");
            frmForm1.AddItem(comboBoxEx1, "ProName", "请选择一个存储过程");
            frmForm1.AddItem(textBoxX3, "RptFileName", "请输入报表名称");
            frmForm1.AddItem(comboBoxEx2, "Type", "请选择报表类型");
            frmForm1.AddItem(textBoxX5, "Memo");
        }

        #region IfrmAddReport 成员
        private BaseReportTitle _currTitle;
        public BaseReportTitle currTitle
        {
            get
            {
                frmForm1.GetValue<BaseReportTitle>(_currTitle);
                return _currTitle;
            }
            set
            {
                _currTitle = value;
                frmForm1.Load<BaseReportTitle>(_currTitle);
            }
        }

        public void loadsp(DataTable dt)
        {
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "spname";
            comboBoxEx1.ValueMember = "spname";
        }

        public void loadreporttype(DataTable dt)
        {
            comboBoxEx2.DataSource = dt;
            comboBoxEx2.DisplayMember = "name";
            comboBoxEx2.ValueMember = "id";
        }

        #endregion

        private void frmAddReport_SaveEventHandler(object sender, EventArgs e)
        {
            InvokeController("SaveTitle");
        }
    }
}
