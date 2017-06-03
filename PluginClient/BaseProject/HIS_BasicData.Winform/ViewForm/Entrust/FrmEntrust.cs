using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.Entrust;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.ViewForm.Entrust
{
    /// <summary>
    /// 嘱托维护
    /// </summary>
    public partial class FrmEntrust : BaseFormBusiness, IFrmEntrust
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmEntrust()
        {
            InitializeComponent();
            bindGridSelectIndex(dgEntrust);
        }

        /// <summary>
        /// 当前选中的嘱托
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// 当前选中的嘱托
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
        /// 嘱托ID
        /// </summary>
        private int entrustID;

        /// <summary>
        /// 嘱托ID
        /// </summary>
        public int Entrust
        {
            get
            {
                return entrustID;
            }

            set
            {
                entrustID = value;
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
        /// 绑定嘱托列表
        /// </summary>
        /// <param name="dtEntrust">嘱托列表</param>
        public void BindEntrust(DataTable dtEntrust)
        {
            if (dtEntrust != null)
            {
                if (dtEntrust.Rows.Count > 0)
                {
                    dgEntrust.CurrentCellChanged -= dgEntrust_CurrentCellChanged;
                    dgEntrust.DataSource = dtEntrust;
                    for (int i = 0; i < dtEntrust.Rows.Count; i++)
                    {
                        if (dtEntrust.Rows[i]["DelFlag"] + string.Empty == "1")
                        {
                            dgEntrust.SetRowColor(i, Color.Red, true);
                        }
                    }

                    dgEntrust.CurrentCellChanged += dgEntrust_CurrentCellChanged;
                    dgEntrust.CurrentCell = dgEntrust[1, 0];
                }
            }
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmEntrust_OpenWindowBefore(object sender, EventArgs e)
        {
            RowIndex = 0;
            InvokeController("LoadBasicWorkers");
            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cbbWork.Enabled = true;
            }
            else
            {
                cbbWork.Enabled = false;
            }

            InvokeController("LoadEntrustInfo", cbbWork.SelectedValue, txtQueryName.Text);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            RowIndex = 0;
            InvokeController("LoadEntrustInfo", cbbWork.SelectedValue, txtQueryName.Text);
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
            setGridSelectIndex(dgEntrust, 0);
            btnQuery.Enabled = true;
        }

        /// <summary>
        /// 验证嘱托名格式
        /// </summary>
        /// <param name="txt">手机号码</param>
        /// <returns>true：正确</returns>
        public bool RegexTelPhone(string txt)
        {
            return new Regex(@"[`~!@#$%^&*()+=|{}':;',\[\].<>/?~！@#￥%……&*（）——+|{}【】‘；：”“’。，、？]+").IsMatch(txt);
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
                MessageBoxEx.Show("嘱托名称不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RegexTelPhone(txtName.Text) == true)
            {
                MessageBoxEx.Show("嘱托名称不能包含特殊字符，请删除！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToBoolean(InvokeController("CheckEntrustName", Entrust, txtName.Text, Convert.ToInt32(cbbWork.SelectedValue))) == false)
            {
                MessageBoxEx.Show("嘱托名称已存在！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flag = Entrust;   //是新增0或修改
            Basic_Entrust entEntrust = new Basic_Entrust();
            entEntrust.EntrustID = Entrust;
            entEntrust.PYCode = txtPY.Text;
            entEntrust.EntrustName = txtName.Text;
            entEntrust.WBCode = txtWB.Text;
            if (flag == 0)
            {
                entEntrust.DelFlag = 0;
            }

            if (Convert.ToInt32(InvokeController("SaveEntrust", entEntrust, Convert.ToInt32(cbbWork.SelectedValue))) > 0)
            {
                InvokeController("LoadEntrustInfo", cbbWork.SelectedValue, txtQueryName.Text);
                if (flag > 0)
                {
                    setGridSelectIndex(dgEntrust);
                }
                else
                {
                    setGridSelectIndex(dgEntrust, ((DataTable)dgEntrust.DataSource).Rows.Count - 1);
                }

                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                btnStop.Enabled = true;
                btnQuery.Enabled = true;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnStop.Enabled = false;
            txtName.Enabled = true;
            btnQuery.Enabled = false;
            txtPY.Enabled = true;
            txtWB.Enabled = true;
            txtName.Text = string.Empty;
            txtPY.Text = string.Empty;
            txtWB.Text = string.Empty;
            RowIndex = 0;
            Entrust = 0;
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
            Basic_Entrust entEntrust = new Basic_Entrust();
            entEntrust = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_Entrust>(dt, RowIndex);
            if (btnStop.Text == "启用(&U)")
            {
                entEntrust.DelFlag = 0;
            }
            else
            {
                entEntrust.DelFlag = 1;
            }

            if (Convert.ToInt32(InvokeController("SaveEntrust", entEntrust, Convert.ToInt32(cbbWork.SelectedValue))) > 0)
            {
                InvokeController("LoadEntrustInfo", cbbWork.SelectedValue, txtQueryName.Text);
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                btnStop.Enabled = true;
                setGridSelectIndex(dgEntrust);
            }
        }

        /// <summary>
        /// 选中嘱托
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
            //0为启用,1为停用
            if (Convert.ToInt32(dt.Rows[RowIndex]["DelFlag"]) == 1)
            {
                btnStop.Text = "启用(&U)";
            }
            else
            {
                btnStop.Text = "停用(&U)";
            }

            txtName.Text = Convert.ToString(dt.Rows[RowIndex]["EntrustName"]);
            txtPY.Text = Convert.ToString(dt.Rows[RowIndex]["PYCode"]);
            txtWB.Text = Convert.ToString(dt.Rows[RowIndex]["WBCode"]);
        }

        /// <summary>
        /// 编辑
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
            txtName.Text = Convert.ToString(dt.Rows[RowIndex]["EntrustName"]);
            txtPY.Text = Convert.ToString(dt.Rows[RowIndex]["PYCode"]);
            txtWB.Text = Convert.ToString(dt.Rows[RowIndex]["WBCode"]);
            Entrust = Convert.ToInt32(dt.Rows[RowIndex]["EntrustID"]);
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnStop.Enabled = false;
            txtName.Enabled = true;
            txtPY.Enabled = true;
            txtWB.Enabled = true;
            btnEdit.Enabled = false;
            btnQuery.Enabled = false;
        }

        /// <summary>
        /// 输入名称自动过滤数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPY.Text = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(txtName.Text);
            txtWB.Text = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetWBCode(txtName.Text);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RowIndex = 0;
            InvokeController("LoadEntrustInfo", cbbWork.SelectedValue, txtQueryName.Text);
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
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cbbWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            RowIndex = 0;
            InvokeController("LoadEntrustInfo", cbbWork.SelectedValue, txtQueryName.Text);
        }
    }
}
