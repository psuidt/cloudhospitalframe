using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace EfwControls.HISControl.PrescriptionTmp.Controls
{
    public partial class SaveSetMeal : Office2007Form
    {
        public int MealType
        {
            get { return cbUser.Checked == true ? 3 : 2; }
        }

        public string MealName
        {
            get { return txtSetMealName.Text; }
        }

        public bool IsOK = false;

        public SaveSetMeal()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSetMealName.Text.Trim() != "")
            {
               // String strParam = String.Format("{0},{1},{2},\'{3}\',{4},\'{5}\',{6},{7},{8},{9},{10}",
               //                    Common.CurrentHospital.HospitalID,
               //                    cbDept.Checked ? 2 : 3,                                                    //父节点
               //                    0,                                                                          //组套分类类型
               //                    txtSetMealName.Text.Trim(),                                                 //组套分类名称
               //                    0,                                                                          //1文件夹，0文件
               //                    EMRCommon.CurrentOutDeptCode,                                               //组套分类科室
               //                    Common.CurrentSysUser.Who_Using,                                            //组套分类创建者
               //                    3,                                                                          //深度
               //                    0,//叶子标识
               //                    2,
               //                    m_iMark
               //);
               //SetMealID = EMRCommon.ProcExcuteAndRetIdentify("xpAddMealNode", strParam);

               //if (SetMealID > 0)
               //     this.Close();
                IsOK = true;
                this.Close();
            }
            else
            {
                txtSetMealName.Focus();
                return;
            }
        }
    }
}
