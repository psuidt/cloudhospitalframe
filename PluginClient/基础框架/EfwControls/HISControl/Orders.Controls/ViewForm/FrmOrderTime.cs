using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfwControls.HISControl.Orders.Controls.ViewForm
{
    public partial class FrmOrderTime : Form
    {
        public bool Ok;
        public DateTime alterDate;
        private DateTime _mindate;
        public FrmOrderTime(DateTime orderdate,DateTime mindate)
        {         
            InitializeComponent();
            dtpOrderTime.Value = orderdate;
            dtpOrderTime.MinDate = mindate;
            _mindate = mindate;
            Ok = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Ok = false;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Ok = true;
            if (dtpOrderTime.Value < _mindate)
            {
                MessageBoxEx.Show("所选时间不能小于入院时间"+dtpOrderTime.Value.ToString("yyyy-MM-dd HH:mm:ss")+"");
                dtpOrderTime.Focus();
            }
            alterDate = dtpOrderTime.Value;
            this.Close();
        }
    }
}
