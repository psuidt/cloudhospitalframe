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
    public partial class FrmStopOrder : Form
    {
        public bool isOk;
        public DateTime stopDate;
        public int stopNum;
        private DateTime orderBdate;
        private int defaultFirstNum;
        private int defaultNum;

        public FrmStopOrder(DateTime defaultDate,int defaultNums,int maxNums,int firstNums)
        {
            InitializeComponent();
            isOk = false;
            dtpStopDate.Value = defaultDate;
           // dtpStopDate.MinDate = defaultDate.Date;
            lblDefaultNum.Text = defaultNums.ToString();
           // txtUpdateNum.Maximum = maxNums;//不限制最大次数
            radDefault.Checked = true;
            txtUpdateNum.Enabled = false;
            orderBdate = defaultDate;
            defaultFirstNum = firstNums;
            defaultNum = defaultNums;
        }

        private void radDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (radDefault.Checked)
            {
                txtUpdateNum.Enabled = false;
            }
            else
            {
                txtUpdateNum.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isOk = false;
            this.Close();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dtpStopDate.Value.Date < DateTime.Now.Date)
            {
                MessageBoxEx.Show("停医嘱日期不能小于当前日期");
                return;
            }
            if (MessageBoxEx.Show(this, "您确认停止医嘱吗?", "停医嘱", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (radDefault.Checked)
            {
                stopNum = Convert.ToInt32(lblDefaultNum.Text);
            }
            else
            {
                stopNum = Convert.ToInt32(txtUpdateNum.Value);
            }
            stopDate = dtpStopDate.Value;
            isOk = true;
            this.Close();
        }

        private void dtpStopDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStopDate.Value.Date == orderBdate.Date)
            {
                lblDefaultNum.Text = defaultFirstNum.ToString();
                radDefault.Checked = true;
            }
            else
            {
                lblDefaultNum.Text = defaultNum.ToString();

            }
        }
    }
}
