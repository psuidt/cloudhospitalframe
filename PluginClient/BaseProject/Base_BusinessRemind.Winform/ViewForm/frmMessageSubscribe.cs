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
    //消息订阅
    public partial class frmMessageSubscribe : BaseForm, IfrmMessageSubscribe
    {
        public frmMessageSubscribe()
        {
            InitializeComponent();
            gridMessageType.AutoGenerateColumns = false;
        }

        #region IfrmMessageSubscribe 成员

        public void loadMessageTypeDt(DataTable dt)
        {
            gridMessageType.DataSource = dt;
        }

        public void loadTime(DataTable dt)
        {
            gridTime.DataSource = dt;
        }

        #endregion

        private void gridMessageType_Click(object sender, EventArgs e)
        {
            if (gridMessageType.CurrentCell != null)
            {
                int rowindex = gridMessageType.CurrentCell.RowIndex;
                int mstypeId = Convert.ToInt32(((DataTable)gridMessageType.DataSource).Rows[rowindex]["Id"]);
                InvokeController("GetUserTime", mstypeId);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridTime.DataSource;
            dt.Rows.Add("00:00", "23:59");
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (gridTime.CurrentCell != null)
            {
                gridTime.Rows.RemoveAt(gridTime.CurrentCell.RowIndex);
            }
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            if (gridMessageType.CurrentCell != null)
            {
                int rowindex = gridMessageType.CurrentCell.RowIndex;
                int mstypeId = Convert.ToInt32(((DataTable)gridMessageType.DataSource).Rows[rowindex]["Id"]);

                DataTable timedt = (DataTable)gridTime.DataSource;

                InvokeController("Subscribe",mstypeId, timedt);
            }
        }

        private void btnCancelSubscribe_Click(object sender, EventArgs e)
        {
            if (gridMessageType.CurrentCell != null)
            {
                int rowindex = gridMessageType.CurrentCell.RowIndex;
                int mstypeId = Convert.ToInt32(((DataTable)gridMessageType.DataSource).Rows[rowindex]["Id"]);

                InvokeController("CancelSubscribe", mstypeId);
            }
        }

        private void frmMessageSubscribe_Load(object sender, EventArgs e)
        {
            InvokeController("GetMessageTypeData");
            gridMessageType_Click(null, null);
        }
    }
}
