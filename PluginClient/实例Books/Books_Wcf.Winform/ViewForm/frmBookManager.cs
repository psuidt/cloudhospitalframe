using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Books_Wcf.Winform.IView;
using Books_Wcf.Entity;
using EFWCoreLib.WinformFrame.Controller;

namespace Books_Wcf.Winform.Viewform
{
    //Wcf界面的代码和Winform界面的代码是一模一样的
    public partial class frmBookManager : BaseForm, IfrmBookManager
    {
        public frmBookManager()
        {
            InitializeComponent();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        

        //新增
        private void button1_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            book.BuyPrice = 10;
            book.BuyDate = DateTime.Now;
            currBook = book;
            button2.Enabled = true;
        }
        //保存
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("书籍名称不能为空！");
                textBox1.Focus();
                return;
            }

            InvokeController("bookSave");
        }

        //点击网格
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;

            int rowindex = dataGridView1.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dataGridView1.DataSource;

            Books book = new Books();
            book.Id = Convert.ToInt32(dt.Rows[rowindex]["Id"]);
            book.BookName = dt.Rows[rowindex]["BookName"].ToString();
            book.BuyPrice = Convert.ToDecimal(dt.Rows[rowindex]["BuyPrice"]);
            book.BuyDate = Convert.ToDateTime(dt.Rows[rowindex]["BuyDate"]);
            book.Flag = Convert.ToInt32(dt.Rows[rowindex]["Flag"]);


            currBook = book;

        }

        #region IfrmBookManager

        public void loadbooks(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        private Books _book;
        public Books currBook
        {
            get
            {
                _book.BookName = textBox1.Text;
                _book.BuyPrice = Convert.ToDecimal(textBox2.Text);
                _book.BuyDate = dateTimePicker1.Value;
                _book.Flag = checkBox1.Checked ? 1 : 0;
                return _book;
            }
            set
            {
                _book = value;
                textBox1.Text = _book.BookName;
                textBox2.Text = _book.BuyPrice.ToString();
                dateTimePicker1.Value = _book.BuyDate;
                checkBox1.Checked = _book.Flag == 0 ? false : true;
            }
        }
        #endregion

        private void frmBookManager_Load(object sender, EventArgs e)
        {
            InvokeController("GetBooks");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //关闭界面
            InvokeController("Close", this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //打开一个新界面在框架Tab中
            InvokeController("Show", "FrmEfwControlDemo");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //弹窗窗体可以用这个方法
            if ((DialogResult)(InvokeController("ShowDialog", "FrmEfwControlDemo")) == DialogResult.OK)
            {
                
            }
        }
    }
}
