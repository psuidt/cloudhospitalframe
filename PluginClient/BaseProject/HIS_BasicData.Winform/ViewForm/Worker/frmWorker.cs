using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView.Worker;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm.Worker
{
    /// <summary>
    /// 机构维护
    /// </summary>
    public partial class FrmWorker : BaseFormBusiness, IFrmWorker
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmWorker()
        {
            InitializeComponent();

            frmWorkerForm.AddItem(tbWorkerName, "WorkName", "机构名称必须输入", InvalidType.Empty, null);//机构名称
            frmWorkerForm.AddItem(tbWorkerNo, "WorkNo", "机构编码必须输入", InvalidType.Empty, null);//机构编码
            frmWorkerForm.AddItem(tbPropCode, "Property_Code");//机构属性代码
            frmWorkerForm.AddItem(tbWorkerShortName, "ShortName");//机构简称
            frmWorkerForm.AddItem(cboWorkerGrade, "Grade_Code");//机构等级
            frmWorkerForm.AddItem(cboMerFlag, "Mercantile_Flag");//营利标志
            frmWorkerForm.AddItem(tbClassCode, "Class_Code");//机构类别代码
            frmWorkerForm.AddItem(dtpLicenseStart, "Licence_Begin", "许可证有效期限(起)", InvalidType.Empty, null);//许可证期限
            frmWorkerForm.AddItem(dtpLicenseEnd, "Licence_End", "许可证有效期限(止)", InvalidType.Empty, null);//许可证期限
            frmWorkerForm.AddItem(tbLicense, "Licence_No");//许可证编号
            frmWorkerForm.AddItem(tbCorporation, "Corporation");//法人代表
            frmWorkerForm.AddItem(tbCorporationTel, "Corporate_Phone", "法人联系电话格式不正确", InvalidType.Custom, @"^[1][358]\d{9}$|^(0\d{2,3}-)?(\d{7,8})(-(\d{1,3}))?$");//法人联系电话
            frmWorkerForm.AddItem(tbDealScale, "Deal_Scale");//经营范围
            frmWorkerForm.AddItem(tbAddress, "Address");//医疗机构地址
            frmWorkerForm.AddItem(tbPostalCode, "PostalCode", "邮政编码格式不正确", InvalidType.Custom, @"^[1-9]\d{5}(?!\d)$");//邮政编码
            frmWorkerForm.AddItem(tbChargeName, "Charge_Name");//主管单位名称
            frmWorkerForm.AddItem(tbFax, "Fax", "传真格式不正确(固话中间请加-)", InvalidType.Custom, @"^[1][358]\d{9}$|^(0\d{2,3}-)?(\d{7,8})(-(\d{1,3}))?$");//传真
            frmWorkerForm.AddItem(tbEmail, "Email", "邮箱格式不正确", InvalidType.Custom, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");//邮箱
            frmWorkerForm.AddItem(tbAccountBank, "Account_Bank");//开户银行
            frmWorkerForm.AddItem(tbAccountName, "Account_Name");//开户户名
            frmWorkerForm.AddItem(tbAccountNo, "Account_Num", "银行帐号格式不正确", InvalidType.Custom, @"[0-9]{19}");//银行帐号
            frmWorkerForm.AddItem(cboLevel, "Level");//医疗机构级别
            frmWorkerForm.AddItem(tbMemo, "Memo");//机构备注
            frmWorkerForm.AddItem(cboMedicarePromise, "Medicare_Promise");//医保约定状态
            frmWorkerForm.AddItem(tbMedicareScale, "Medicare_Scale");//医保批准经营范围
            frmWorkerForm.AddItem(tbMedicareApanage, "Medicare_Apanage");//管理属地
            frmWorkerForm.AddItem(cboWoundPromise, "Wound_Promise");//工伤约定状态
            frmWorkerForm.AddItem(cboBirthPromise, "Birth_Promise");//生育约定状态
            frmWorkerForm.AddItem(tbSARNo, "SARNo");//行政区域代码
            frmWorkerForm.AddItem(tbProvince, "Province");//省
            frmWorkerForm.AddItem(tbCity, "City");//市
            frmWorkerForm.AddItem(tbDistrict, "District");//县
            frmWorkerForm.AddItem(tbTownshipCode, "TownshipCode");//地区
            frmWorkerForm.AddItem(iiCheckBeds, "Check_Beds", "核定床位数格式不正确", InvalidType.Custom, @"^[0-9]\d*$");//核定床位数
            frmWorkerForm.AddItem(iiOpenBeds, "Open_Beds", "开放床位数格式不正确", InvalidType.Custom, @"^[0-9]\d*$");//开放床位数
            frmWorkerForm.AddItem(iiPeoples, "Peoples", "居民人口总数格式不正确", InvalidType.Custom, @"^[0-9]\d*$");//居民人口总数
            frmWorkerForm.AddItem(iiFPeoples, "FPeoples", "流动人口总数格式不正确", InvalidType.Custom, @"^[0-9]\d*$");//流动人口总数
            frmWorkerForm.AddItem(iiFamilys, "Familys", "家庭数格式不正确", InvalidType.Custom, @"^[0-9]\d*$");//家庭数
            frmWorkerForm.AddItem(tbLandArea, "Land_Area");//医疗面积
            frmWorkerForm.AddItem(tbMedicalArea, "Medical_Area");//总占面积
            frmWorkerForm.AddItem(tbBusinessArea, "Business_Area");//办公面积
            frmWorkerForm.AddItem(iiEmployers, "Employers", "聘用在职人数格式不正确", InvalidType.Custom, @"^[0-9]\d*$");//聘用在职人数
            frmWorkerForm.AddItem(iiRegulars, "Regulars", "编制在职人数格式不正确", InvalidType.Custom, @"^[0-9]\d*$");//编制在职人数
            frmWorkerForm.AddItem(tbServicePhone, "ServicePhone", "服务电话格式不正确(固话中间请加-)", InvalidType.Custom, @"^[1][358]\d{9}$|^(0\d{2,3}-)?(\d{7,8})(-(\d{1,3}))?$");//服务电话
            frmWorkerForm.AddItem(tbCardPrefix, "CardPrefix");//会员卡前缀
            frmWorkerForm.AddItem(iiCardLength, "CardLength", string.Empty, InvalidType.Custom, @"^[0-9]\d*$");//会员卡长度
            frmWorkerForm.Load(InitBaseWorker);
            frmWorkerForm.Load(InitBaseWorkeDetail);
        }

        /// <summary>
        /// 当前选中的机构
        /// </summary>
        private BaseWorkers currentWorkers;

        /// <summary>
        /// 当前选中的机构
        /// </summary>
        public BaseWorkers CurrentWorkers
        {
            get
            {
                return currentWorkers;
            }

            set
            {
                currentWorkers = value;
                InvokeController("LoadWorkerDetail", currentWorkers.WorkId);

                frmWorkerForm.Load(currentWorkers);

                //0为启用,1为停用
                if (currentWorkers.DelFlag == 1)
                {
                    toolbarFlag.Text = "启用(F3)";
                }
                else
                {
                    toolbarFlag.Text = "停用(F3)";
                }
            }
        }

        /// <summary>
        /// 机构详情
        /// </summary>
        public BaseWorkesDetails CurrentWorkerDetail { get; set; }

        #region IFrmWorker

        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="dtWorkers">机构列表</param>
        public void LoadWorkers(List<BaseWorkers> dtWorkers)
        {
            this.dgWorkers.DataSource = dtWorkers;
            setGridSelectIndex(dgWorkers);
            if (dtWorkers.Count > 0)
            {
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                dgWorkers.Enabled = true;
                barWorker.Refresh();
            }
            else
            {
                toolbarAdd_Click(null, null);
                toolbarFlag.Enabled = false;
                barWorker.Refresh();
            }
        }

        /// <summary>
        /// 加载机构详情
        /// </summary>
        /// <param name="workerDetail">机构详情</param>
        public void LoadWorkerDetail(BaseWorkesDetails workerDetail)
        {
            if (null == workerDetail)
            {
                workerDetail = InitBaseWorkeDetail;
            }

            CurrentWorkerDetail = workerDetail;
            frmWorkerForm.Load(workerDetail);
        }

        /// <summary>
        /// 获取机构等级数据源
        /// </summary>
        /// <param name="dtWorkerGrade">机构等级数据源</param>
        public void LoadBasicDataForGrade(DataTable dtWorkerGrade)
        {
            cboWorkerGrade.DataSource = dtWorkerGrade;
        }

        /// <summary>
        /// 获取机构级别数据源
        /// </summary>
        /// <param name="dtWorkerClass">机构级别数据源</param>
        public void LoadBasicDataForClass(DataTable dtWorkerClass)
        {
            cboLevel.DataSource = dtWorkerClass;
        }

        #endregion

        /// <summary>
        /// 打开界面加载数据
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmWorker_OpenWindowBefore(object sender, EventArgs e)
        {
            bindGridSelectIndex(dgWorkers);
            InvokeController("LoadBasicData", 0);
            InvokeController("LoadBasicData", 1);
            InitComboboxExData();
            InvokeController("LoadWorkerList");
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarAdd_Click(object sender, EventArgs e)
        {
            dgWorkers.ClearSelection();
            CurrentWorkers = InitBaseWorker;

            toolbarAdd.Enabled = false;
            toolbarFlag.Enabled = false;
            dgWorkers.Enabled = false;
            barWorker.Refresh();

            tbWorkerName.Focus();
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            frmWorkerForm.Load(CurrentWorkers);
            InvokeController("LoadWorkerDetail", CurrentWorkers.WorkId);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frmWorkerForm.Validate())
            {
                frmWorkerForm.GetValue(CurrentWorkers);

                frmWorkerForm.GetValue(CurrentWorkerDetail);

                if (CurrentWorkerDetail.Licence_Begin > CurrentWorkerDetail.Licence_End)
                {
                    MessageBoxEx.Show("许可证有效期限(起)不能大于许可证有效期限(止)");
                    return;
                }

                var ret = InvokeController("SaveWorkerAndDetail", CurrentWorkers, CurrentWorkerDetail);
                if (!string.IsNullOrEmpty(ret + string.Empty))
                {
                    MessageBoxEx.Show("保存成功");
                    toolbarRefresh_Click(sender, e);
                }
                else
                {
                    MessageBoxEx.Show("保存失败,请重试");
                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarRefresh_Click(object sender, EventArgs e)
        {
            InvokeController("LoadWorkerList");
            setGridSelectIndex(dgWorkers);

            if (dgWorkers.Rows.Count > 0)
            {
                toolbarAdd.Enabled = true;
                toolbarFlag.Enabled = true;
                dgWorkers.Enabled = true;
                barWorker.Refresh();
            }
        }

        /// <summary>
        /// 启用或停用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void toolbarFlag_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(string.Format("确定{0}吗？", CurrentWorkers.DelFlag == 0 ? "停用" : "启用"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            InvokeController("FlagWorkerAndDetail", CurrentWorkers.WorkId, CurrentWorkers.DelFlag);
            toolbarRefresh_Click(sender, e);
        }

        /// <summary>
        /// 初始化机构
        /// </summary>
        private BaseWorkers InitBaseWorker
        {
            get
            {
                return new BaseWorkers
                {
                    DelFlag = 1
                };
            }
        }

        /// <summary>
        /// 初始化机构详情
        /// </summary>
        private BaseWorkesDetails InitBaseWorkeDetail
        {
            get
            {
                return new BaseWorkesDetails
                {
                    Licence_Begin = DateTime.Now,
                    Licence_End = DateTime.Now,
                    Grade_Code = "01",
                    Level = 3,
                    Mercantile_Flag = "非营利",
                    Medicare_Promise = "非约定",
                    Wound_Promise = "非约定",
                    Birth_Promise = "非约定"
                };
            }
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitComboboxExData()
        {
            var datasource = new[]
            {
                new
                {
                    Text = "非营利",
                    Value = "非营利"
                },
                new
                {
                    Text = "营利",
                    Value = "营利"
                },
                new
                {
                    Text = "其它卫生机构",
                    Value = "其它卫生机构"
                }
            };

            cboMerFlag.DataSource = datasource;
            datasource = new[]
            {
                new
                {
                    Text = "非约定",
                    Value = "非约定"
                },
                new
                {
                    Text = "正常",
                    Value = "正常"
                },
                new
                {
                    Text = "暂停",
                    Value = "暂停"
                },
                new
                {
                    Text = "取消",
                    Value = "取消"
                }
            };

            cboMedicarePromise.DataSource = datasource;
            datasource = new[]
            {
                new
                {
                    Text = "非约定",
                    Value = "非约定"
                },
                new
                {
                    Text = "正常",
                    Value = "正常"
                },
                new
                {
                    Text = "暂停",
                    Value = "暂停"
                },
                new
                {
                    Text = "取消",
                    Value = "取消"
                }
            };

            cboWoundPromise.DataSource = datasource;
            datasource = new[]
            {
                new
                {
                    Text = "非约定",
                    Value = "非约定"
                },
                new
                {
                    Text = "正常",
                    Value = "正常"
                },
                new
                {
                    Text = "暂停",
                    Value = "暂停"
                },
                new
                {
                    Text = "取消",
                    Value = "取消"
                }
            };

            cboBirthPromise.DataSource = datasource;
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmWorker_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    toolbarAdd_Click(null, null);
                    break;
                case Keys.F4:
                    toolbarFlag_Click(null, null);
                    break;
                case Keys.F5:
                    toolbarRefresh_Click(null, null);
                    break;
                case Keys.F6:
                    btnReset_Click(null, null);
                    break;
                case Keys.F7:
                    btnQuit_Click(null, null);
                    break;
                case Keys.F8:
                    btnSave_Click(null, null);
                    break;
            }
        }

        /// <summary>
        /// 选中机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgWorkers_CurrentCellChanged(object sender, EventArgs e)
        {
            if (null == dgWorkers.CurrentRow)
            {
                return;
            }

            var rowIndex = dgWorkers.CurrentRow.Index;
            var dataSource = dgWorkers.DataSource as List<BaseWorkers>;
            CurrentWorkers = dataSource[rowIndex];
        }

        /// <summary>
        /// 设置选中机构显示颜色
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void dgWorkers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var dataSource = dgWorkers.DataSource as List<BaseWorkers>;
            if (e.RowIndex > 0)
            {
                if (dataSource[e.RowIndex].DelFlag == 1)
                {
                    dgWorkers.SetRowColor(e.RowIndex, Color.Red, true);
                }
            }
        }
    }
}
