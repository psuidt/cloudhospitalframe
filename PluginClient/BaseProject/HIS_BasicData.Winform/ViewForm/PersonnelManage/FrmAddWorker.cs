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
    public partial class FrmAddWorker : BaseFormBusiness, IfrmWorker
    {
        public FrmAddWorker()
        {
            InitializeComponent();
        }

        private BaseWorkers _currWorker;
        public BaseWorkers currWorker
        {
            get
            {
               frmForm1.GetValue<BaseWorkers>(_currWorker);
                return _currWorker;
            }
            set
            {
                _currWorker = value;
                frmForm1.Load<BaseWorkers>(_currWorker);
            }
        }

        public void loadWorkerGrid(List<BaseWorkers> workerList)
        {
            // Method intentionally left empty.
        }
    }
}
