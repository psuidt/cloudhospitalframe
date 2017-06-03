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
    public partial class FrmDeathOrder : Form
    {
        public bool isOk;
        public DataTable _dtDisease;
       

        public DateTime outDate;
        public string outDiseaseName;
        public string outDiseaseCode;
        public string outSituationCode;
        public FrmDeathOrder(int patlistid, string cureno, string patname, string bedno, string diagnose,DateTime enterDate)
        {
            InitializeComponent();
            txtCureNO.Text = cureno;
            txtPatName.Text = patname;
            txtBedNO.Text = bedno;
            txtDialoge.Text = diagnose;
            dtpOutDate.Value = DateTime.Now;
            dtpOutDate.MinDate = enterDate;
            dtpOutDate.MaxDate = DateTime.Now.Date;
            isOk = false;
        }

        private void FrmDeathOrder_Load(object sender, EventArgs e)
        {
            txtOutDialog.DisplayField = "Name";
            txtOutDialog.MemberField = "ICDCode";
            txtOutDialog.CardColumn = "Name|名称|auto";
            txtOutDialog.QueryFieldsString = "Name,pycode,wbcode";
            txtOutDialog.ShowCardHeight = 160;
            txtOutDialog.ShowCardWidth = 140;
            txtOutDialog.ShowCardDataSource = _dtDisease;          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtOutDialog.Text.Trim() == "")
            {
                MessageBox.Show("请输入死亡诊断");
                txtOutDialog.Focus();
                return;
            }
            isOk = true;
            outDate = dtpOutDate.Value;
            outDiseaseName = txtOutDialog.Text.Trim();
            outDiseaseCode = txtOutDialog.MemberValue.ToString();
            outSituationCode = "5";
            this.Close();
        }
    }
}
