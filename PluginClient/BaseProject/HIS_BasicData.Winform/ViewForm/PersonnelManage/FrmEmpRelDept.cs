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

namespace WinMainUIFrame.Winform.ViewForm.EmpUserManager
{
    public partial class FrmEmpRelDept : BaseFormBusiness
    {
        public FrmEmpRelDept()
        {
            InitializeComponent();

            this.dataGrid1.DataSource = new List<Tuple<int, string, bool>> {
                 new Tuple<int, string,bool>(1,"科室1",false),
                new Tuple<int, string,bool>(2,"科室2",false),
                new Tuple<int, string,bool>(3,"科室3",false),
                new Tuple<int, string,bool>(4,"科室4",false),
                new Tuple<int, string,bool>(5,"科室5",true),
            };
        }
    }
}
