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
    public partial class FrmUpdateTerminalNum : Form
    {
        public bool isOk;
        public DataTable dtUpdateNums;
       private  DataTable dtCopy;
        public FrmUpdateTerminalNum(DataTable dt)
        {
            InitializeComponent();
            dataGrid1.DataSource = dt;
            isOk = false;
            dtCopy = dt.Copy();
            radDefault.Checked = true;
            NumInput.Enabled = false;
        }

        private void radDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (radDefault.Checked)
            {
                dataGrid1.DataSource = dtCopy;
                dtCopy = dtCopy.Copy();
            }
            else
            {
                int num = Convert.ToInt32(NumInput.Value);
                DataTable dtt = (DataTable)dataGrid1.DataSource;
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    dtt.Rows[i]["TeminalNum"] = num;
                }
            }
            NumInput.Enabled = !radDefault.Checked;
        }

        private void NumInput_ValueChanged(object sender, EventArgs e)
        {
            int num =Convert.ToInt32( NumInput.Value);
            DataTable dtt = (DataTable)dataGrid1.DataSource;
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                dtt.Rows[i]["TeminalNum"] = num;
            }
        }

        private void dataGrid1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);//组线画笔
            int x1, y1, x2, y2, y3, y4;//y1为组头横线位置，y2为组线底位置，y3为组线顶位置，y4为组尾横线位置
            x1 = y1 = x2 = y2 = 0;
            for (int i = 0; i < dataGrid1.Rows.Count; i++)
            {
                int beginNum = 0;
                int endNum = 0;

                this.FindBeginEnd(i, (DataTable)dataGrid1.DataSource, ref beginNum, ref endNum);

                if (beginNum != endNum)
                {
                    for (int j = beginNum; j < endNum + 1; j++)
                    {
                        x1 = dataGrid1.GetCellDisplayRectangle(0, j, false).Right - 5;
                        x2 = dataGrid1.GetCellDisplayRectangle(0, j, false).Right;
                        y1 = dataGrid1.GetCellDisplayRectangle(0, j, false).Top + dataGrid1.GetCellDisplayRectangle(0, j, false).Height * 1 / 5;
                        y2 = dataGrid1.GetCellDisplayRectangle(0, j, false).Bottom;
                        y3 = dataGrid1.GetCellDisplayRectangle(0, j, false).Top;
                        y4 = dataGrid1.GetCellDisplayRectangle(0, j, false).Bottom - dataGrid1.GetCellDisplayRectangle(0, j, false).Height * 1 / 5;
                        if (j == beginNum)
                        {
                            e.Graphics.DrawLine(pen, x1, y1, x2, y1);
                            e.Graphics.DrawLine(pen, x1, y1, x1, y2);
                        }
                        else if (j == endNum)
                        {
                            e.Graphics.DrawLine(pen, x1, y3, x1, y4);
                            e.Graphics.DrawLine(pen, x1, y4, x2, y4);
                        }
                        else
                        {
                            e.Graphics.DrawLine(pen, x1, y3, x1, y2);
                        }
                    }
                }
                i = endNum;
            }
        }
        private void FindBeginEnd(int nrow, DataTable myTb, ref int beginNum, ref int endNum)
        {
            if (myTb.Rows.Count > 0)
            {
                int groupid = Convert.ToInt32(myTb.Rows[nrow]["GroupID"] == DBNull.Value ? -1 : myTb.Rows[nrow]["GroupID"]);
                int i = 0;
                beginNum = nrow;
                endNum = nrow;
                for (i = nrow; i <= myTb.Rows.Count - 1; i++)
                {
                    if (i + 1 == myTb.Rows.Count)
                    {
                        endNum = i;
                        break;
                    }
                    if (myTb.Rows[i + 1]["GroupID"].ToString() == groupid.ToString() && Convert.ToInt32(myTb.Rows[i + 1]["GroupFlag"]) == 0)
                    {
                        endNum = i + 1;
                    }
                    else break;
                }
                for (i = nrow; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        beginNum = i;
                        break;
                    }
                    if (myTb.Rows[i]["GroupID"].ToString() == groupid.ToString() && Convert.ToInt32(myTb.Rows[i]["GroupFlag"]) == 1)
                    {
                        beginNum = i;
                        break;
                    }

                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dtUpdateNums = (DataTable)dataGrid1.DataSource;
            isOk = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isOk = false;
            this.Close();
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGrid1.CurrentCell == null)
            {
                return;
            }
      

            DataTable dt = (DataTable)dataGrid1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["GroupFlag"]) == 1)
                {
                    dataGrid1.ReadOnly = false;                    
                    TeminalNum.ReadOnly = false;                               
                }
                else
                {
                    TeminalNum.ReadOnly = true;

                }
            }
            ShowOrderBdate.ReadOnly = true;
            Dosage.ReadOnly = true;
            DosageUnit.ReadOnly = true;
            Frequency.ReadOnly = true;
            ChannelName.ReadOnly = true;
            FirstNum.ReadOnly = true;
            DropSpec.ReadOnly = true;
            Entrust.ReadOnly = true;
            ExecNurseName.ReadOnly = true;
            ExecDate.ReadOnly = true;
            ItemName.ReadOnly = true;
        }

        private void dataGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid1.CurrentCell != null)
            {
                if (e.ColumnIndex == dataGrid1.Columns[TeminalNum.Name].Index)
                {
                    ChangeValue((DataTable)dataGrid1.DataSource, dataGrid1.CurrentCell.RowIndex);
                    dataGrid1.Refresh();
                }
            }
        }
        private void ChangeValue(DataTable dt, int rowindex)
        {
            for (int i = rowindex + 1; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["GroupFlag"].ToString().Trim() == "0")
                {
                    dt.Rows[i]["TeminalNum"] = dt.Rows[rowindex]["TeminalNum"];                   
                }
                if (dt.Rows[i]["GroupFlag"].ToString().Trim() == "1")
                {
                    break;
                }
            }
        }
    }
}
