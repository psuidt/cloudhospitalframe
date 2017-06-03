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
    public partial class FrmAddDept : BaseFormBusiness, IFrmDept
    {
        public FrmAddDept()
        {
            InitializeComponent();
        }

        private BaseDept _currentDept;
        public BaseDept CurrentDept
        {
            get
            {
                frmForm1.GetValue<BaseDept>(_currentDept);
                return _currentDept;
            }
            set
            {
                _currentDept = value;
                frmForm1.Load<BaseDept>(_currentDept);
            }
        }

        private BaseDeptLayer _currentDeptLayer;
        public BaseDeptLayer CurrentDeptLayer
        {
            get
            {
                frmForm1.GetValue<BaseDeptLayer>(_currentDeptLayer);
                return _currentDeptLayer;
            }
            set
            {
                _currentDeptLayer = value;
                frmForm1.Load<BaseDeptLayer>(_currentDeptLayer);
            }
        }
    }
}
