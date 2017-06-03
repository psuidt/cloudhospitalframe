using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.Frequency;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.ViewForm.Frequency
{
    /// <summary>
    /// 频次维护
    /// </summary>
    public partial class FrmFrequency : BaseFormBusiness, IFrmFrequency
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmFrequency()
        {
            InitializeComponent();
            bindGridSelectIndex(dgFrequency);
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
        /// 频次ID
        /// </summary>
        private int id;

        /// <summary>
        /// 频次ID
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
        }

        /// <summary>
        /// 绑定频次列表
        /// </summary>
        /// <param name="dtFrequency">频次列表</param>
        public void BindFrequencyInfo(DataTable dtFrequency)
        {
            dgFrequency.DataSource = dtFrequency;

            if (dtFrequency != null)
            {
                if (dtFrequency.Rows.Count > 0)
                {
                    dgFrequency.CurrentCellChanged -= dgFrequency_CurrentCellChanged;
                    for (int i = 0; i < dtFrequency.Rows.Count; i++)
                    {
                        if (dtFrequency.Rows[i]["DelFlag"] + string.Empty == "1")
                        {
                            dgFrequency.SetRowColor(i, Color.Red, true);
                        }
                    }

                    dgFrequency.CurrentCellChanged += dgFrequency_CurrentCellChanged;
                    dgFrequency.CurrentCell = dgFrequency[1, 0];
                }
            }
        }

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmFrequency_OpenWindowBefore(object sender, EventArgs e)
        {
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

            cbbWork.SelectedValue = (InvokeController("this") as AbstractController).LoginUserInfo.WorkId;
        }

        /// <summary>
        /// 选中频次显示频次详细信息
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgFrequency_CurrentCellChanged(object sender, EventArgs e)
        {
            txtExecCode.Text = string.Empty;
            txtTimeCode.Text = string.Empty;
            txtDayTimeCode.Text = string.Empty;
            if (dgFrequency.CurrentCell == null)
            {
                return;
            }

            InitExceCode();
            RowIndex = dgFrequency.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgFrequency.DataSource;
            ID = Convert.ToInt32(dt.Rows[RowIndex]["FrequencyID"]);
            txtFrequencyName.Text = Convert.ToString(dt.Rows[RowIndex]["FrequencyName"]);
            txtCName.Text = Convert.ToString(dt.Rows[RowIndex]["CName"]);
            txtEName.Text = Convert.ToString(dt.Rows[RowIndex]["EName"]);
            chbWestDrug.Checked = (Convert.ToInt32(dt.Rows[RowIndex]["WestDrug"]) == 1) ? true : false;
            chbMidDrug.Checked = (Convert.ToInt32(dt.Rows[RowIndex]["MidDrug"]) == 1) ? true : false;
            intOrder.Value = Convert.ToInt32(dt.Rows[RowIndex]["SortOrder"]);
            txtExecCode.Text = dt.Rows[RowIndex]["ExecuteCode"].ToString();
            if (string.IsNullOrEmpty(txtExecCode.Text) == false)
            {
                ExplainExecCode(txtExecCode.Text, Convert.ToInt32(dt.Rows[RowIndex]["ExecuteType"]));
            }

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
        /// 解释ExceCode
        /// </summary>
        /// <param name="execCode">执行代码</param>
        /// <param name="execType">执行类型</param>
        public void ExplainExecCode(string execCode, int execType)
        {
            string[] splitStr = execCode.Split('@');
            switch (execType)
            {
                case 1: 
                    //间隔多少分钟执行（M@20）
                    chbMinute.Checked = true;
                    intMinute.Value = Convert.ToInt32(splitStr[1]);
                    break;
                case 2:
                    //间隔多少小时执行(H@2)
                    chbHour.Checked = true;
                    intHour.Value = Convert.ToInt32(splitStr[1]);
                    break;
                case 3:
                    //间隔多少天执行(D@1)
                    chbDay.Checked = true;
                    intDay.Value = Convert.ToInt32(splitStr[1]);
                    break;
                case 4: 
                    //1天几次，每次时间点(D@1@3@1|10:30#1|12:30#1|20:00 一天三次)
                    chkTime.Checked = true;
                    intTime.Value = Convert.ToInt32(splitStr[2]);
                    txtExecCode.Text = splitStr[3];
                    txtTimeCode.Text = splitStr[3];
                    break;
                case 5: 
                    //几天几次，每次时间点(D@2@3@1|10:30#1|20:00#2|12:00 两天三次)   (D@5@3@1|20:00#3|12:00#5|16:00 三天两次)
                    chbDayTime.Checked = true;
                    intDays.Value = Convert.ToInt32(splitStr[1]);
                    intTimes.Value = Convert.ToInt32(splitStr[2]);
                    txtDayTimeCode.Text = splitStr[3];
                    txtExecCode.Text = splitStr[3];
                    break;
                case 6:  
                    //立即执行，1次（S@1  立即执行一次）
                    chbOnce.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            RowIndex = 0;
            ID = 0;
            InitExceCode();
            FreqInfo.Enabled = true;
            ExceCodeInfo.Enabled = true;
            dgFrequency.Enabled = false;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnStop.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnQuery.Enabled = false;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgFrequency.CurrentCell == null)
            {
                return;
            }

            InitExceCode();
            RowIndex = dgFrequency.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgFrequency.DataSource;
            ID = Convert.ToInt32(dt.Rows[RowIndex]["FrequencyID"]);
            txtFrequencyName.Text = Convert.ToString(dt.Rows[RowIndex]["FrequencyName"]);
            txtCName.Text = Convert.ToString(dt.Rows[RowIndex]["CName"]);
            txtEName.Text = Convert.ToString(dt.Rows[RowIndex]["EName"]);
            chbWestDrug.Checked = (Convert.ToInt32(dt.Rows[RowIndex]["WestDrug"]) == 1) ? true : false;
            chbMidDrug.Checked = (Convert.ToInt32(dt.Rows[RowIndex]["MidDrug"]) == 1) ? true : false;
            intOrder.Value = Convert.ToInt32(dt.Rows[RowIndex]["SortOrder"]);
            txtExecCode.Text = Convert.ToString(dt.Rows[RowIndex]["ExecuteCode"]);
            if (string.IsNullOrEmpty(txtExecCode.Text) == false)
            {
                ExplainExecCode(txtExecCode.Text, Convert.ToInt32(dt.Rows[RowIndex]["ExecuteType"]));
            }

            FreqInfo.Enabled = true;
            ExceCodeInfo.Enabled = true;
            dgFrequency.Enabled = false;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnStop.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnQuery.Enabled = false;
        }

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dgFrequency.CurrentCell == null)
            {
                return;
            }

            RowIndex = dgFrequency.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgFrequency.DataSource;
            Basic_Frequency frequencyEntity = new Basic_Frequency();
            frequencyEntity = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_Frequency>(dt, RowIndex);

            if (btnStop.Text == "启用(&U)")
            {
                frequencyEntity.DelFlag = 0;
            }
            else
            {
                frequencyEntity.DelFlag = 1;
            }

            if (Convert.ToInt32(InvokeController("SaveFrequencyInfo", frequencyEntity, Convert.ToInt32(cbbWork.SelectedValue))) > 0)
            {
                InvokeController("BindFrequencyInfo", txtQuery.Text, txtQuery.Text, txtQuery.Text, Convert.ToInt32(cbbWork.SelectedValue));
                setGridSelectIndex(dgFrequency);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            InvokeController("BindFrequencyInfo", txtQuery.Text, txtQuery.Text, txtQuery.Text, Convert.ToInt32(cbbWork.SelectedValue));
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cbbWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvokeController("BindFrequencyInfo", txtQuery.Text, txtQuery.Text, txtQuery.Text, Convert.ToInt32(cbbWork.SelectedValue));
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrequencyName.Text) == true)
            {
                MessageBoxEx.Show("频次名称不能为空！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToBoolean(InvokeController("CheckFrequencyName", txtFrequencyName.Text, cbbWork.SelectedValue, ID)) == false)
            {
                MessageBoxEx.Show("频次名称重复，请修改！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string msg = string.Empty;
            string exceCode = string.Empty;
            int freqType = 0;
            if (CheckExceCode(out msg, out freqType, out exceCode) == false)
            {
                MessageBoxEx.Show(msg, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int saveFlag = ID;
            Basic_Frequency frequency = new Basic_Frequency();
            frequency.FrequencyID = ID;
            frequency.FrequencyName = txtFrequencyName.Text;
            frequency.CName = txtCName.Text;
            frequency.EName = txtEName.Text;
            frequency.PYCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(txtFrequencyName.Text);
            frequency.WBCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetWBCode(txtFrequencyName.Text);
            frequency.WestDrug = Convert.ToInt32(chbWestDrug.Checked);
            frequency.MidDrug = Convert.ToInt32(chbMidDrug.Checked);
            frequency.ExecuteType = freqType;
            frequency.ExecuteCode = exceCode;
            frequency.SortOrder = intOrder.Value;
            if (saveFlag == 0)
            {
                frequency.DelFlag = 0;
            }

            if (Convert.ToInt32(InvokeController("SaveFrequencyInfo", frequency, cbbWork.SelectedValue)) > 0)
            {
                InvokeController("BindFrequencyInfo", txtQuery.Text, txtQuery.Text, txtQuery.Text, Convert.ToInt32(cbbWork.SelectedValue));
                if (saveFlag == 0)
                {
                    setGridSelectIndex(dgFrequency, dgFrequency.Rows.Count - 1);
                }
                else
                {
                    setGridSelectIndex(dgFrequency);
                }

                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnStop.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnQuery.Enabled = true;
                dgFrequency.Enabled = true;
            }
        }

        /// <summary>
        /// 检查频次执行公式是否生成
        /// </summary>
        /// <param name="msg">检查结果</param>
        /// <param name="freqType">类型</param>
        /// <param name="exceCode">代码</param>
        /// <returns>true：生成</returns>
        private bool CheckExceCode(out string msg, out int freqType, out string exceCode)
        {
            int chgFlag = 0;
            msg = string.Empty;
            exceCode = string.Empty;
            freqType = 0;
            bool resFlag = true;
            foreach (Control ctl in ExceCodeInfo.Controls)
            {
                if (ctl.GetType().Name == "CheckBoxX")
                {
                    if (((CheckBoxX)ctl).Checked == true)
                    {
                        switch (ctl.Name)
                        {
                            case "chbMinute":
                                msg = "间隔分钟数不能小于零!";
                                resFlag = (intMinute.Value > 0) ? true : false;
                                exceCode = "M@" + intMinute.Value;
                                freqType = 1;
                                break;
                            case "chbHour":
                                msg = "间隔小时数不能小于零!";
                                resFlag = (intHour.Value > 0) ? true : false;
                                exceCode = "H@" + intHour.Value;
                                freqType = 2;
                                break;
                            case "chbDay":
                                msg = "间隔天数不能小于零!";
                                resFlag = (intDay.Value > 0) ? true : false;
                                exceCode = "D@" + intDay.Value;
                                freqType = 3;
                                break;
                            case "chkTime":
                                msg = string.Empty;
                                string timeMsg = "每天执行次数不能小于零!";
                                bool timeFlag = (intTime.Value > 0) ? true : false;
                                string codeMsg = "执行时间点不能为空或格式不正确!";
                                exceCode = "D@1@" + intTime.Value + "@" + txtTimeCode.Text;
                                bool codeFlag = (CheckExceCodeFormat(exceCode, 1, intTime.Value) == true) ? true : false;
                                msg = (timeFlag == false) ? msg + timeMsg : msg;
                                msg = (codeFlag == false) ? msg + codeMsg : msg;
                                resFlag = ((timeFlag == true) && (codeFlag == true)) ? true : false;

                                freqType = 4;
                                break;
                            case "chbDayTime":
                                msg = string.Empty;
                                string daysMsg = "执行天数不能小于零!";
                                bool daysFlag = (intDays.Value > 0) ? true : false;
                                string timesMsg = "执行次数不能小于零!";
                                bool timesFlag = (intTimes.Value > 0) ? true : false;
                                string codesMsg = "执行时间点不能为空或格式不正确!";
                                exceCode = "D@" + intDays.Value + "@" + intTimes.Value + "@" + txtDayTimeCode.Text;
                                bool codesFlag = (CheckExceCodeFormat(exceCode, intDays.Value, intTimes.Value) == true) ? true : false;
                                msg = (daysFlag == false) ? msg + daysMsg : msg;
                                msg = (timesFlag == false) ? msg + timesMsg : msg;
                                msg = (codesFlag == false) ? msg + codesMsg : msg;
                                resFlag = ((timesFlag == true) && (codesFlag == true) && (daysFlag == true)) ? true : false;
                                freqType = 5;
                                break;
                            case "chbOnce":
                                msg = string.Empty;
                                exceCode = "S@1";
                                resFlag = true;
                                freqType = 6;
                                break;
                        }
                    }
                    else
                    {
                        chgFlag = chgFlag + 1;
                    }
                }
            }

            if (chgFlag == 6)
            {
                msg = "请选择频次的执行频率!";
                resFlag = false;
            }

            return resFlag;
        }

        /// <summary>
        /// 检查时间点格式是否全法
        /// </summary>
        /// <param name="code">格式</param>
        /// <param name="days">天数</param>
        /// <param name="times">时间</param>
        /// <returns>true：合法</returns>
        private bool CheckExceCodeFormat(string code, int days, int times)
        {
            //1|10:30#1|12:30#1|20:00 
            bool res = true;
            if (code.Contains("#") == false)
            {
                if (code.Contains("|"))
                {
                    string[] time = code.Split('|');
                    if (Regex.IsMatch(time[1], @"^((20|21|22|23|[0-1]?\d):[0-5]?\d)$") == false)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                   return false;
                }
            }
            else
            {
                string[] checkStr = code.Split('@');
                string[] strTime = checkStr[3].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);

                if (strTime.Length != times)
                {
                    return false;
                }

                for (int i = 0; i < strTime.Length; i++)
                {
                    if (strTime[i] == string.Empty)
                    {
                        break;
                    }

                    if (strTime[i].Contains("|") == false)
                    {
                        res = false;
                        break;
                    }
                    else
                    {
                        string[] time = strTime[i].Split('|');
                        res = (time.Length > 0) ? true : false;
                        if (res == false)
                        {
                            break;
                        }
                        else
                        {
                            if (time[1].Contains(")"))
                            {
                                time[1] = time[1].Replace(")", string.Empty);
                            }

                            //检验时间点格式
                            if (Regex.IsMatch(time[1], @"^((20|21|22|23|[0-1]?\d):[0-5]?\d)$") == false)
                            {
                                res = false;
                                break;
                            }
                        }
                    }
                }

                return res;
            }
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnStop.Enabled = true;
            btnSave.Enabled = false;
            btnQuery.Enabled = true;
            FreqInfo.Enabled = false;
            ExceCodeInfo.Enabled = false;
            dgFrequency.Enabled = true;
        }

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        public void InitExceCode()
        {
            txtFrequencyName.Text = string.Empty;
            txtCName.Text = string.Empty;
            txtEName.Text = string.Empty;
            chbWestDrug.Checked = false;
            chbMidDrug.Checked = false;
            intOrder.Value = 999;
            txtExecCode.Text = string.Empty;
            chbMinute.Checked = false;
            intMinute.Value = 0;
            chbHour.Checked = false;
            intHour.Value = 0;
            chbDay.Checked = false;
            intDay.Value = 0;
            chkTime.Checked = false;
            intTime.Value = 0;
            txtExecCode.Text = string.Empty;
            chbDayTime.Checked = false;
            intDays.Value = 0;
            intTimes.Value = 0;
            txtDayTimeCode.Text = string.Empty;
            chbOnce.Checked = false;
        }
    }
}
