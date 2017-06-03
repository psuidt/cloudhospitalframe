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
    public partial class FrmTransDept : Form
    {
        public DataTable dtDept;
        public bool isOk;
        

        public DateTime transDeptDate;
        public int transDeptId;
        public string transDeptName;

        private int _curDeptId;
        public FrmTransDept(int patlistid,string cureno,string patname,string bedno,string diagnose,int curDeptId)
        {
            InitializeComponent();
            txtCureNO.Text = cureno;
            txtPatName.Text = patname;
            txtBedNO.Text = bedno;
            txtDialoge.Text = diagnose;
            _curDeptId = curDeptId;
            isOk = false;
        }

        private void FrmTransDept_Load(object sender, EventArgs e)
        {
            dtpTransDate.MinDate = DateTime.Now.Date;
            dtpTransDate.MaxDate = DateTime.Now.AddDays(7);
            dtpTransDate.Value = DateTime.Now;
            cmbTransDept.DisplayMember = "Name";
            cmbTransDept.ValueMember = "deptID";
            cmbTransDept.DataSource = dtDept;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_curDeptId == Convert.ToInt64(this.cmbTransDept.SelectedValue))
            {
                MessageBox.Show("不允许本科室转本科室！请重新选择科室。");
                return;
            }
            transDeptDate = dtpTransDate.Value;
            transDeptId = Convert.ToInt32(cmbTransDept.SelectedValue);
            transDeptName = cmbTransDept.Text.Trim();
            isOk = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isOk = false;
            this.Close();
        }
    }
}
