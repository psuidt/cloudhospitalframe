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
    public partial class Form1 : BaseFormBusiness
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            //textBoxX2.Focus();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            doubleInput1.Focus();
            buttonItem1.Checked = true;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            buttonItem1.Checked = false;
            textBoxX1.Text = "click btn1";
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            doubleInput1.TabStop = false;
            buttonItem1.Checked = true;

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            doubleInput1.TabStop = true;
            buttonItem2.Checked = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && buttonItem1.Checked)
            {
                buttonItem1_Click(null, null);
            }
        }
    }
}
