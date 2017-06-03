using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EFWCoreLib.WinformFrame.Controller;
using base_businessremind.winform.IView;
using base_businessremind.Entity;

namespace base_businessremind.winform.Viewform
{
    public partial class frmLookMessage : BaseForm,IfrmLookMessage
    {
        public frmLookMessage()
        {
            InitializeComponent();
            dataGrid1.AutoGenerateColumns = false;
        }

        int type = 0;

        #region IfrmLookMessage 成员

        public void loadMessageList(List<BaseMessage> messageList)
        {
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = messageList;
        }

        #endregion

        private void frmLookMessage_Load(object sender, EventArgs e)
        {
            dateTimeInput1.Value = DateTime.Now;
            InvokeController("LoadMessageList", type, dateTimeInput1.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                type = 0;
                dateTimeInput1.Enabled = false;
                buttonX1.Enabled = true;
            }
            else if (radioButton2.Checked)
            {
                type = 1;
                dateTimeInput1.Enabled = true;
                buttonX1.Enabled = false;
            }
            else if (radioButton3.Checked)
            {
                type = 2;
                dateTimeInput1.Enabled = true;
                buttonX1.Enabled = false;
            }

            InvokeController("LoadMessageList", type, dateTimeInput1.Value);
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                //int Id = Convert.ToInt32(dataGrid1["Id", dataGrid1.CurrentCell.RowIndex].Value);
                int rowindex=dataGrid1.CurrentCell.RowIndex;
                textBoxX1.Text = dataGrid1["MessageTitle", rowindex].Value.ToString();
                textBoxX2.Text = dataGrid1["SendUser", rowindex].Value.ToString();
                richTextBox1.Text = dataGrid1["MessageContent", rowindex].Value.ToString();
            }
        }

        private void dateTimeInput1_ValueChanged(object sender, EventArgs e)
        {
            InvokeController("LoadMessageList", type, dateTimeInput1.Value);
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                int rowindex=dataGrid1.CurrentCell.RowIndex;
                if (Convert.ToBoolean(dataGrid1["ck", rowindex].Value))
                    dataGrid1["ck", rowindex].Value = false;
                else
                    dataGrid1["ck", rowindex].Value = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dataGrid1.RowCount > 0)
            {
                
                List<int> messageIdlist = new List<int>();
                for (int i = 0; i < dataGrid1.RowCount; i++)
                {
                    if (Convert.ToBoolean(dataGrid1["ck", i].Value))
                        messageIdlist.Add(Convert.ToInt32(dataGrid1["Id", i].Value));
                }
                if (messageIdlist.Count > 0)
                {
                    InvokeController("SetMessageRead", messageIdlist.ToArray());
                    InvokeController("LoadMessageList", type, dateTimeInput1.Value);
                }
            }
        }
    }
}
