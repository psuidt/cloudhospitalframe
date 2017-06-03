using EFWCoreLib.CoreFrame.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMainUIFrame.Winform.IView.EmpUserManager;
using WinMainUIFrame.Entity;

namespace WinMainUIFrame.Winform.ViewForm.EmpUserManager
{
    public partial class FrmEmp : BaseFormBusiness, IFrmEmp
    {
        public FrmEmp()
        {
            InitializeComponent();
        }

        private BaseEmployee _currentEmp;
        public BaseEmployee CurrentEmp
        {
            get
            {
                frmForm1.GetValue<BaseEmployee>(_currentEmp);
                return _currentEmp;
            }
            set
            {
                _currentEmp = value;
                frmForm1.Load<BaseEmployee>(_currentEmp);
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            InvokeController("NewEmp");
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            InvokeController("EmpRelDept", 1);
        }
    }
}
