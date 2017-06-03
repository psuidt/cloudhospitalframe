using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.Entrust;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.ViewForm.Entrust
{
    /// <summary>
    /// 说明性医嘱维护
    /// </summary>
    public partial class FrmAttachAdvice : BaseFormBusiness, IFrmAttachAdvice
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmAttachAdvice()
        {
            InitializeComponent();
            bindGridSelectIndex(dgEntrust);
        }

        /// <summary>
        /// 当前选中行
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// 当前选中行
        /// </summary>
        public int RowIndex
        {
            get
            {
                return rowIndex;
            }

            set
            {
                rowIndex = value;
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        private int id;

        /// <summary>
        /// 说明性医嘱ID
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="workers">机构列表</param>
        public void LoadBasicWorkers(List<BaseWorkers> workers)
        {
            cbbWork.DataSource = workers;
            cbbWork.SelectedValue = (InvokeController("this") as AbstractController).LoginUserInfo.WorkId;
        }

        /// <summary>
        /// 绑定单位列表
        /// </summary>
        /// <param name="dt">单位列表</param>
        public void LoadUnitInfo(DataTable dt)
        {
            tbUnit.DisplayField = "unitname";
            tbUnit.MemberField = "UNITID";
            tbUnit.CardColumn = "UNITID|编码|40,unitname|单位|auto";
            tbUnit.QueryFieldsString = "unitname,PYCode,WBCode";
            tbUnit.ShowCardWidth = 100;
            tbUnit.ShowCardDataSource = dt;
        }

        /// <summary>
        /// 关闭当前界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnStop.Enabled = true;
            btnEdit.Enabled = true;
            btnRefresh.Enabled = true;
            setGridSelectIndex(dgEntrust);
            txtName.Enabled = false;
            txtPY.Enabled = false;
            txtWB.Enabled = false;
            txtSpec.Enabled = false;
            txtCode.Enabled = false;
            tbUnit.Enabled = false;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnNew.Enabled = false;
            btnStop.Enabled = false;
            btnRefresh.Enabled = false;
            txtName.Enabled = true;
            txtPY.Enabled = true;
            txtWB.Enabled = true;
            txtSpec.Enabled = true;
            txtCode.Enabled = true;
            tbUnit.Enabled = true;
            txtCode.Text = string.Empty;
            txtCode.Focus();
            txtName.Text = string.Empty;
            txtPY.Text = string.Empty;
            txtWB.Text = string.Empty;
            txtSpec.Text = string.Empty;
            tbUnit.Text = string.Empty;
            RowIndex = 0;
            ID = 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgEntrust.CurrentCell == null)
            {
                return;
            }

            RowIndex = dgEntrust.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgEntrust.DataSource;
            txtCode.Text = Convert.ToString(dt.Rows[RowIndex]["ItemCode"]);
            txtName.Text = Convert.ToString(dt.Rows[RowIndex]["ItemName"]);
            txtPY.Text = Convert.ToString(dt.Rows[RowIndex]["PYCode"]);
            txtWB.Text = Convert.ToString(dt.Rows[RowIndex]["WBCode"]);
            tbUnit.Text = Convert.ToString(dt.Rows[RowIndex]["UnitName"]);
            ID = Convert.ToInt32(dt.Rows[RowIndex]["ID"]);
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnStop.Enabled = false;
            btnRefresh.Enabled = false;
            txtName.Enabled = true;
            txtPY.Enabled = true;
            txtWB.Enabled = true;
            txtCode.Enabled = true;
            txtSpec.Enabled = true;
            txtSpec.Enabled = true;
            tbUnit.Enabled = true;
        }

        /// <summary>
        /// 界面打开加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmAttachAdvice_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("LoadBasicWorkers");
            InvokeController("LoadUnitInfo");
            //  InvokeController("BindAttachAdvice",cbbWork.SelectedValue,txtQueryName.Text);

            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cbbWork.Enabled = true;
            }
            else
            {
                cbbWork.Enabled = false;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) == true)
            {
                MessageBoxEx.Show("医嘱名称不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToBoolean(InvokeController("CheckInfo", ID, txtName.Text, Convert.ToInt32(cbbWork.SelectedValue))) == false)
            {
                MessageBoxEx.Show("医嘱名称重复，请修改！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flag = ID;  //是新增或修改
            Basic_AttachAdvice enti = new Basic_AttachAdvice();
            enti.ID = ID;
            enti.ItemCode = txtCode.Text;
            enti.ItemName = txtName.Text;
            enti.ItemSpec = txtSpec.Text;
            if (tbUnit.MemberValue != null)
            {
                enti.Unit = tbUnit.MemberValue.ToString();
            }

            enti.PYCode = txtPY.Text;
            enti.WBCode = txtWB.Text;

            if (flag == 0)
            {
                enti.DelFlag = 0;
            }

            if (Convert.ToInt32(InvokeController("SaveAttachAdviceInfo", enti, Convert.ToInt32(cbbWork.SelectedValue))) > 0)
            {
                InvokeController("BindAttachAdvice", cbbWork.SelectedValue, txtQueryName.Text);
                if (flag > 0)
                {
                    setGridSelectIndex(dgEntrust);
                }
                else
                {
                    setGridSelectIndex(dgEntrust, ((DataTable)dgEntrust.DataSource).Rows.Count - 1);
                }

                tbUnit.Enabled = false;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                btnStop.Enabled = true;
                btnEdit.Enabled = true;
                btnRefresh.Enabled = true;
                txtName.Enabled = false;
                txtPY.Enabled = false;
                txtWB.Enabled = false;
                txtSpec.Enabled = false;
                txtCode.Enabled = false;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            InvokeController("BindAttachAdvice", cbbWork.SelectedValue, txtQueryName.Text);
        }

        /// <summary>
        /// 绑定网格内容
        /// </summary>
        /// <param name="dtAttachAdvice">嘱托列表</param>
        public void BindAttachAdvice(DataTable dtAttachAdvice)
        {
            dgEntrust.DataSource = dtAttachAdvice;
            if (dtAttachAdvice != null)
            {
                if (dtAttachAdvice.Rows.Count > 0)
                {
                    dgEntrust.CurrentCellChanged -= dgEntrust_CurrentCellChanged;
                    dgEntrust.DataSource = dtAttachAdvice;
                    for (int i = 0; i < dtAttachAdvice.Rows.Count; i++)
                    {
                        if (dtAttachAdvice.Rows[i]["DelFlag"] + string.Empty == "1")
                        {
                            dgEntrust.SetRowColor(i, Color.Red, true);
                        }
                    }

                    dgEntrust.CurrentCellChanged += dgEntrust_CurrentCellChanged;
                    dgEntrust.CurrentCell = dgEntrust[1, 0];
                }
                else
                {
                    dgEntrust.DataSource = dtAttachAdvice;
                }
            }
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cbbWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvokeController("BindAttachAdvice", cbbWork.SelectedValue, txtQueryName.Text);
        }

        /// <summary>
        /// 选中说明性医嘱
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgEntrust_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgEntrust.CurrentCell == null)
            {
                return;
            }

            RowIndex = dgEntrust.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgEntrust.DataSource;
            txtCode.Text = Convert.ToString(dt.Rows[RowIndex]["ItemCode"]);
            txtName.Text = Convert.ToString(dt.Rows[RowIndex]["ItemName"]);
            txtPY.Text = Convert.ToString(dt.Rows[RowIndex]["PYCode"]);
            txtWB.Text = Convert.ToString(dt.Rows[RowIndex]["WBCode"]);
            tbUnit.Text = Convert.ToString(dt.Rows[RowIndex]["UnitName"]);
            ID = Convert.ToInt32(dt.Rows[RowIndex]["ID"]);

            //0为启用,1为停用
            if (Convert.ToInt32(dt.Rows[RowIndex]["DelFlag"]) == 1)
            {
                btnStop.Text = "启用(&U)";
            }
            else
            {
                btnStop.Text = "停用(&U)";
            }
        }

        /// <summary>
        /// 刷新网格
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InvokeController("BindAttachAdvice", cbbWork.SelectedValue, txtQueryName.Text);
        }

        /// <summary>
        /// 停用或启用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dgEntrust.CurrentCell == null)
            {
                return;
            }

            RowIndex = dgEntrust.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgEntrust.DataSource;
            Basic_AttachAdvice enti = new Basic_AttachAdvice();
            enti = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_AttachAdvice>(dt, RowIndex);

            if (btnStop.Text == "启用(&U)")
            {
                enti.DelFlag = 0;
            }
            else
            {
                enti.DelFlag = 1;
            }

            if (Convert.ToInt32(InvokeController("SaveAttachAdviceInfo", enti, Convert.ToInt32(cbbWork.SelectedValue))) > 0)
            {
                InvokeController("BindAttachAdvice", cbbWork.SelectedValue, txtQueryName.Text);
                setGridSelectIndex(dgEntrust);
            }
        }

        /// <summary>
        /// 输入名称自动检索
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPY.Text = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(txtName.Text);
            txtWB.Text = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetWBCode(txtName.Text);
        }
    }
}
