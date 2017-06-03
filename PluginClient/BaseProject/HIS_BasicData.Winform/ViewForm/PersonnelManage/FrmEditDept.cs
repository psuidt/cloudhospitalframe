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
    public partial class FrmEditDept : BaseFormBusiness, IFrmDept
    {
        public FrmEditDept()
        {
            InitializeComponent();
        }

        public BaseDept CurrentDept
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public BaseDeptLayer CurrentDeptLayer
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
