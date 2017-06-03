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
    public partial class FrmOutHospital : Form
    {
        public bool isOk;
        public DataTable _dtDisease;
        public DataTable _dtOutSituation;

        public DateTime outDate;
        public string outDiseaseName;
        public string outDiseaseCode;
        public string outSituationCode;
        public FrmOutHospital(int patlistid, string cureno, string patname, string bedno, string diagnose)
        {
            InitializeComponent();
            txtCureNO.Text = cureno;
            txtPatName.Text = patname;
            txtBedNO.Text = bedno;
            txtDialoge.Text = diagnose;
            dtpOutDate.Value = DateTime.Now;
            dtpOutDate.MinDate = DateTime.Now.Date;
            dtpOutDate.MaxDate = DateTime.Now.AddDays(7);
            isOk = false;
        }

        private void FrmOutHospital_Load(object sender, EventArgs e)
        {
            txtOutDialog.DisplayField = "Name";
            txtOutDialog.MemberField = "ICDCode";
            txtOutDialog.CardColumn = "Name|名称|auto";
            txtOutDialog.QueryFieldsString = "Name,pycode,wbcode";
            txtOutDialog.ShowCardHeight = 160;
            txtOutDialog.ShowCardWidth = 140;
            txtOutDialog.ShowCardDataSource = _dtDisease;

            cmbOutSituation.DisplayMember = "Name";
            cmbOutSituation.ValueMember = "Code";
            cmbOutSituation.DataSource = _dtOutSituation;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtOutDialog.Text.Trim() == "")
            {
                MessageBox.Show("请输入出院诊断");
                txtOutDialog.Focus();
                return;
            }
            isOk = true;
            outDate = dtpOutDate.Value;
            outDiseaseName = txtOutDialog.Text.Trim();
            outDiseaseCode = txtOutDialog.MemberValue.ToString();
            outSituationCode = cmbOutSituation.SelectedValue.ToString();
            this.Close();
        }

        private void txtOutDialog_AfterSelectedRow(object sender, object SelectedValue)
        {

        }
    }
}
