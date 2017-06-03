using Books_Wcf.Winform.Controller;
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

namespace Books_Wcf.Winform.ViewForm
{
    public partial class FrmIPDOrder : BaseFormBusiness
    {
        public FrmIPDOrder()
        {
            InitializeComponent();
        }

        private void FrmIPDOrder_Load(object sender, EventArgs e)
        {
            //初始化处方控件并加载病人处方数据
            ITestIPDOrderDbHelper presHelper = new Controller.ITestIPDOrderDbHelper();
            ordersControl1.InitDbHelper(presHelper);
            ordersControl1.LoadPatData(1, -1, 101,"儿科", 201, "李医生",1,"-1","2016-06-01",false);
        }
    }
}
