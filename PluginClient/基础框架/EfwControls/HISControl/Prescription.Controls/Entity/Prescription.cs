using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EfwControls.Common;

namespace EfwControls.HISControl.Prescription.Controls.Entity
{
    public class Prescription : PresDetail,ICloneable
    {
        private int _presNo;                 //处方号
        private int _dept_id;                //执行科室代码
        private string _dept_name = "";      //执行科室名称
        private PresStatus _status = PresStatus.编辑状态; //处方明细状态
        private DateTime _pres_date;         //处方时间

        private string _usage_name = "";     //用法名称
        private string _frequency_name = ""; //频次名称
        private int _frequency_ExecNum = 1;  //频次对应的执行次数
        private int _frequency_CycleDay = 1; //频次对应的执行周期
        private string _frequency_Caption = ""; //频次说明


        private bool _selected;              //是否选中
        private bool _isFloat;               //是否是按含量取整的药品


        #region 处方头属性
        /// <summary>
        /// 医保类型
        /// </summary>
        public int MedicareID
        {
            get;
            set;
        }
        /// <summary>
        /// 附加
        /// </summary>
        public string Additional
        {
            get;
            set;
        }
        /// <summary>
        /// 处方号
        /// </summary>
        public int PresNo
        {
            get { return _presNo; }
            set { _presNo = value; }
        }
        /// <summary>
        /// 行号
        /// </summary>
        public string TmpNo
        {
            get { return base.OrderNo == 1 ? this.PresNo.ToString() : ""; }
            set { }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public int Dept_Id
        {
            get { return _dept_id; }
            set { _dept_id = value; }

        }
        //开方科室
        public int Pres_Dept { get; set; }
        public string Pres_DeptName { get; set; }
        //开方医生
        public int Pres_Doc { get; set; }
        public string Pres_DocName { get; set; }
        //精毒标志
        public int IsLunacyPosion { get; set; }
        //本院执行次数
        public int ExecNum { get; set; }
        public string DropSpec { get; set; }
        public int GroupSortNO { get; set; }
        public string Memo { get; set; }
        /// <summary>
        /// 处方状态
        /// </summary>
        public PresStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 处方时间
        /// </summary>
        public DateTime Pres_Date
        {
            get { return _pres_date; }
            set { _pres_date = value; }
        }
        #endregion

        #region 扩展的string属性
        /// <summary>
        /// 项目ID
        /// </summary>
        public string Item_Id_S
        {
            get
            {
                return base.Item_Id <= 0 ? "" : base.Item_Id.ToString();
            }
            set
            {
                try
                {
                    _item_id = Convert.ToInt32(value);
                }
                catch
                {
                    _item_id = -1;
                }
            }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Item_Name_S
        {
            get
            {
                try
                {
                    string name = base.Item_Name;
                    if (this.FootNote != null && this.FootNote != "")
                    {
                        name += "【" + this.FootNote + "】";
                    }
                    //string usageId = OP_ReadBaseData.GetConfigValue("002");
                    //if (base.Usage_Id != (usageId == "" ? 0 : Convert.ToInt32(usageId)))
                    //{
                        switch (this.SkinTest_Flag)
                        {
                            case 1:
                                name += "(皮试)";
                                break;
                            case 2:
                                name += "(-)";
                                break;
                            case 3:
                                name += "(+)";
                                break;
                            case 4:
                                name += "(免试)";
                                break;
                            default:
                                break;
                        }
                    //}
                    if (this.IsDrug && this.SelfDrug_Flag == 1)
                    {
                        name += "【自备】";
                    }
                    if (this.IsDrug && this.IsReimbursement == 1)
                    {
                        name += "【保外用】";
                    }
                    return name;
                }
                catch
                {
                    return base.Item_Name;
                }
            }
            set
            {
                _item_name = value;
            }
        }
        /// <summary>
        /// 项目单价
        /// </summary>
        public string Item_Price_S
        {
            get
            {
                return this.Item_Price == 0 ? "" : base.Item_Price.ToString("0.0000");
            }
            set
            {
            }
        }
        /// <summary>
        /// 每次用量
        /// </summary>
        public string Usage_Amount_S
        {
            get
            {
                return base.Usage_Amount == 0 ? "" : base.Usage_Amount.ToString();
            }
            set
            {
                try
                {
                    _usage_amount = Convert.ToDecimal(value);
                    if (_usage_amount <= 0)
                    {
                        _usage_amount = 0;
                    }
                }
                catch
                {
                    _usage_amount = 0;
                }
            }
        }
        /// <summary>
        /// 用量单位
        /// </summary>
        public string Usage_Unit_S
        {
            get
            {
                return base.Usage_Unit;
            }
            set
            {
            }
        }
        /// <summary>
        /// 剂数
        /// </summary>
        public string Dosage_S
        {
            get
            {
                return base.Dosage == 0 ? "" : base.Dosage.ToString();
            }
            set
            {
                try
                {
                    _dosage = Convert.ToInt32(value);
                }
                catch
                {
                    _dosage = 1;
                }
            }
        }
        /// <summary>
        /// 开药天数
        /// </summary>
        public string Days_S
        {
            get
            {
                return base.Days == 0 ? "" : base.Days.ToString();
            }
            set
            {
                try
                {
                    _days = Convert.ToInt32(value);
                }
                catch
                {
                    _days = 1;
                }
            }
        }
        /// <summary>
        /// 开药数量
        /// </summary>
        public string Item_Amount_S
        {
            get
            {
                return base.Item_Amount == 0 ? "" : (this.Item_Amount).ToString();
            }
            set
            {
                try
                {
                    _item_amount = Convert.ToInt32(value);
                    if (_item_amount <= 0)
                    {
                        _item_amount = 1;
                    }
                }
                catch
                {
                    _item_amount = 1;
                }
            }
        }
        /// <summary>
        /// 用量单位
        /// </summary>
        public string Item_Unit_S
        {
            get
            {
                return base.Item_Unit;
            }
            set
            {
            }
        }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 处方明细金额
        /// </summary>
        public string Item_Money
        {
            get
            {
                return _item_money;
            }
            set
            {
                _item_money = value;
            }
        }
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string Dept_Name
        {
            get { return _dept_name; }
            set { _dept_name = value; }
        }
        /// <summary>
        /// 用法名称
        /// </summary>
        public string Usage_Name
        {
            get { return _usage_name; }
            set { _usage_name = value; }
        }
        /// <summary>
        /// 频次名称
        /// </summary>
        public string Frequency_Name
        {
            get { return _frequency_name; }
            set { _frequency_name = value; }
        }
        /// <summary>
        /// 频次对应的执行次数
        /// </summary>
        public int Frequency_ExecNum
        {
            get { return _frequency_ExecNum; }
            set { _frequency_ExecNum = value; }
        }
        /// <summary>
        /// 频次对应的执行周期
        /// </summary>
        public int Frequency_CycleDay
        {
            get { return _frequency_CycleDay; }
            set { _frequency_CycleDay = value; }
        }
        /// <summary>
        /// 频次说明
        /// </summary>
        public string Frequency_Caption
        {
            get { return _frequency_Caption; }
            set { _frequency_Caption = value; }
        }
        /// <summary>
        /// 药品标志
        /// </summary>
        public bool IsDrug
        {
            get
            {
                return this.Item_Type == 1 || this.Item_Type == 2;
            }
            set
            {
            }
        }
        /// <summary>
        /// 中药标志
        /// </summary>
        public bool IsHerb
        {
            get
            {
                return this.Item_Type == 2;
            }
            set
            {
            }
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        /// <summary>
        /// 是否是按含量取整的药品 true按包装 false按含量
        /// </summary>
        public bool IsFloat
        {
            get { return _isFloat; }
            set { _isFloat = value; }
        }
        #endregion

        #region 门诊处方费用计算接口属性
        /// <summary>
        /// 大项目代码
        /// </summary>
        public string BigItemCode
        {
            get
            {
                return this.StatItem_Code;
            }
            set
            {
                this.StatItem_Code = value;
            }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money
        {
            get
            {
                return Convert.ToDecimal(this.Item_Money);
            }
            set
            {
                this.Item_Money = value.ToString("0.00");
            }
        }
        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
        /// <summary>
        /// 计算开药总量
        /// </summary>
        public void CalculateAmount(string unitName)
        {
            if (this.IsDrug)//药品
            {              
                if (this.IsHerb)//中药
                {
                    this.Dosage = this.Dosage == 0 ? 1 : this.Dosage;
                    this.Days = this.Dosage;
                    this.Item_Amount = Convert.ToInt32(this.Usage_Amount) * this.Dosage;//剂量*付数
                }
                else
                {
                    if (this.MedicareID == 1)
                    {
                        //如里甲类药品，只反算天数
                        return;
                    }
                    if (IsFloat)//按包装 //数量 = (用量*频次*天数/剂量转换率)/开药转换系数
                    {
                        this.Item_Amount = Convert.ToInt32(Math.Ceiling(Math.Ceiling(this.Usage_Amount * this.Frequency_ExecNum / this.Frequency_CycleDay * this.Days / this.Usage_Rate) / this.Item_Rate));
                    }
                    else//按含量  //数量 = (用量/剂量转换率)*频次*天数/开药转换系数
                    {
                        this.Item_Amount = Convert.ToInt32(Math.Ceiling(Math.Ceiling(this.Usage_Amount / this.Usage_Rate) * (this.Frequency_ExecNum / this.Frequency_CycleDay) * this.Days / this.Item_Rate));
                    }
                }
            }
            else//除药品外的 项目、材料
            {
                this.Usage_Amount = (int)this.Usage_Amount;
                this.Usage_Amount = this.Usage_Amount <= 0 ? 1 : this.Usage_Amount;
                this.Item_Amount = (int)this.Usage_Amount;
            }

            this.Amount = this.Item_Amount * this.Item_Rate;

            if (unitName != null)
            {
                this.Item_Unit = unitName;
                //this.Unit = unitName;
            }

            CalculateItemMoney();
        }

        public void CalculateDays()
        {
            if (this.IsDrug)//药品
            {
                //if (this.MedicareID==1)
                //{
                    if (this.Usage_Amount == 0)
                        return;
                    if (IsFloat)//按包装 //数量 = (用量*频次*天数/剂量转换率)/开药转换系数
                    {
                        //this.Item_Amount = Convert.ToInt32(Math.Ceiling(Math.Ceiling(this.Usage_Amount * this.Frequency_ExecNum / this.Frequency_CycleDay * this.Days / this.Usage_Rate) / this.Item_Rate));
                        this.Days = Convert.ToInt32(Math.Ceiling((this.Item_Amount * this.Item_Rate * this.Usage_Rate *Convert.ToDecimal(this.Frequency_CycleDay) / this.Frequency_ExecNum) / this.Usage_Amount));
                    }
                    else//按含量  //数量 = (用量/剂量转换率)*频次*天数/开药转换系数
                    {
                        //this.Item_Amount = Convert.ToInt32(Math.Ceiling(Math.Ceiling(this.Usage_Amount / this.Usage_Rate) * (this.Frequency_ExecNum / this.Frequency_CycleDay) * this.Days / this.Item_Rate));
                        this.Days = Convert.ToInt32(Math.Ceiling((this.Item_Amount * this.Item_Rate) / (this.Usage_Amount / this.Usage_Rate * (Math.Ceiling(Convert.ToDecimal(this.Frequency_ExecNum) / this.Frequency_CycleDay)))));
                    }
                //}
            }
           
            this.Amount = this.Item_Amount * this.Item_Rate;
        }

        /// <summary>
        /// 计算处方金额
        /// </summary>
        public void CalculateItemMoney()
        {
            if (this.SelfDrug_Flag == 1 && this.IsDrug)
            {
                this.Item_Money = "0.00";
            }
            else
            {
                this.Amount = this.Item_Amount * this.Item_Rate;
                this.Item_Money = (this.Item_Price * this.Amount).ToString("0.00");
            }
        }

        public static IPrescripttionDbHelper PrescripttionDataSource;//数据
        /// <summary>
        /// //计算新行的处方号与分组号
        /// </summary>
        /// <param name="listPres"></param>
        /// <param name="rowIndex"></param>
        /// <param name="PresNo"></param>
        /// <param name="GroupNo"></param>
        /// <param name="OrderNO"></param>
        public static void CalculateNewNo(List<Prescription> listPres, int rowIndex, out int PresNo, out int GroupNo, out int OrderNO)
        {
            if (listPres.Count == 0 || listPres.Count - 1 == rowIndex)//新行
            {
                if (rowIndex == 0)//没有处方记录
                {
                    PresNo = 1;
                    GroupNo = 1;
                    OrderNO = 1;
                }
                else if (listPres[rowIndex].Item_Name == "小计：")//处方最后一行为小计
                {
                    PresNo = listPres[rowIndex - 1].PresNo + 1;
                    GroupNo = 1;
                    OrderNO = 1;
                }
                else//处方最后一行
                {
                    PresNo = listPres[rowIndex].PresNo;
                    GroupNo = listPres[rowIndex].Group_Id + 1;
                    OrderNO = listPres[rowIndex].OrderNo + 1;
                }
            }
            else//插入
            {
                if (rowIndex == 0)//第一行插入
                {
                    PresNo = 1;
                    GroupNo = listPres.FindAll(x => x.PresNo == 1).Max(x => x.Group_Id) + 1;
                    OrderNO = 1;
                }
                else if (listPres[rowIndex].Item_Name == "小计：")//小计行插入新行
                {
                    int _presNo = PresNo = listPres[rowIndex - 1].PresNo + 1;
                    GroupNo = listPres.FindAll(x => x.PresNo == _presNo).Max(x => x.Group_Id) + 1;
                    OrderNO = 1;
                }
                else//处方中间插入新行
                {
                    int _presNo = PresNo = listPres[rowIndex].PresNo;
                    int _groupNo = listPres[rowIndex].Group_Id;

                    bool isGroup = listPres.FindAll(x => x.PresNo == _presNo && x.Group_Id == _groupNo).Count > 1;
                    if (isGroup)
                        GroupNo = _groupNo;
                    else
                        GroupNo = listPres.FindAll(x => x.PresNo == _presNo).Max(x => x.Group_Id) + 1;
                    OrderNO = listPres[rowIndex].OrderNo + 1;
                }
            }
        }

        /// <summary>
        /// 计算所有处方方号和组号
        /// </summary>
        /// <param name="listPres"></param>
        public static void CalculateAllNo(List<Prescription> listPres)
        {
            //清除多余小计行
            List<Entity.Prescription> _list1 = listPres.FindAll(x => x.Item_Name == "小计：");
            for (int i = 0; i < _list1.Count; i++)
            {
                if (listPres.FindAll(x => x.PresNo == _list1[i].PresNo).Count == 1)
                {
                    listPres.Remove(_list1[i]);
                }
            }
            //循环更新方号和组号
            int _presNo = 0;
            int _oldpresNo = 0;
            int _groupNo = 0;
            int _oldgroupNo = 0;
            int _orderNo = 0;
            for (int i = 0; i < listPres.Count; i++)
            {
                if (listPres[i].PresNo != _oldpresNo)
                {
                    _presNo += 1;
                    _groupNo = 0;
                    _orderNo = 0;
                }
                _oldpresNo = listPres[i].PresNo;
                listPres[i].PresNo = _presNo;

                _orderNo += 1;
                if (listPres[i].Group_Id != _oldgroupNo)
                {
                    _groupNo += 1;
                }

                _oldgroupNo = listPres[i].Group_Id;
                if (listPres[i].Item_Name == "小计：")
                    listPres[i].Group_Id = 0;
                else
                    listPres[i].Group_Id = _groupNo;
                listPres[i].OrderNo = _orderNo;
            }
            //更新到数据库
            Entity.Prescription.UpdatePresNoAndGroupId(listPres.FindAll(x => x.PresListId > 0));
        }

        /// <summary>
        /// 计算小计
        /// </summary>
        /// <param name="listPres"></param>
        public static void CalculateSubtotal(ref List<Prescription> listPres)
        {
            List<Prescription> _listPrescription = listPres.FindAll(x => x.Item_Name != "小计：");

            List<PresHead> presHead = new List<PresHead>();
            for (int i = 0; i < _listPrescription.Count; i++)
            {
                if (presHead.FindIndex(x => x.PresNo == _listPrescription[i].PresNo) == -1)
                {
                    PresHead head = new PresHead();
                    head.PresHeadId = _listPrescription[i].PresHeadId;
                    head.PresNo = _listPrescription[i].PresNo;
                    head.Pres_Flag = _listPrescription[i].Status;
                    presHead.Add(head);
                }
            }

            List<Prescription> list_Prescription = new List<Prescription>();

            for (int m = 0; m < presHead.Count; m++)
            {
                List<Prescription> m_listP = _listPrescription.FindAll(x => x.PresNo == presHead[m].PresNo);
                for (int i = 0; i < m_listP.Count; i++)
                {
                    m_listP[i].OrderNo = i + 1;
                    list_Prescription.Add(m_listP[i]);
                }
                //添加小计
                Prescription prescription0 = new Prescription();
                //prescription0.PresHeadId = presHead[m].PresHeadId;
                //prescription0.Dept_Id = presHead[index].Pres_ExeDept;
                prescription0.Item_Name = "小计：";
                prescription0.PresNo = presHead[m].PresNo;
                prescription0.OrderNo = m_listP.Count + 1;
                //2009-12-22 统一医生站和收费系统的处方费用合计
                prescription0.Item_Money = m_listP.Sum(x => x.Money).ToString("0.00");
                prescription0.Status = presHead[m].Pres_Flag;
                list_Prescription.Add(prescription0);
            }

            listPres = list_Prescription;
        }

        /// <summary>
        /// 判断是否分组
        /// </summary>
        /// <param name="listPres"></param>
        /// <param name="presNo"></param>
        /// <param name="GroupNo"></param>
        /// <returns></returns>
        public static bool IsGroup(List<Prescription> listPres, int presNo, int GroupNo, out List<Prescription> _list)
        {
            _list = listPres.FindAll(x => x.PresNo == presNo && x.Group_Id == GroupNo);

            return _list.Count > 1;
        }

        /// <summary>
        /// 判断是否分组
        /// </summary>
        /// <param name="listPres"></param>
        /// <param name="presNo"></param>
        /// <param name="GroupNo"></param>
        /// <returns></returns>
        public static bool IsGroup(DataTable dt, int presNo, int GroupNo, out DataRow[] _drs)
        {
            _drs = dt.Select("PresNo=" + presNo + " and Group_Id=" + GroupNo);
            return _drs.Length > 1;
        }

        /// <summary>
        /// 添加小计行
        /// </summary>
        /// <param name="listPres"></param>
        public static Prescription AddPresSubtotal(int PresNo,int OrderNo,string money,PresStatus status)
        {
            //添加小计
            Prescription prescription0 = new Prescription();
            //prescription0.PresHeadId = presHead[m].PresHeadId;
            //prescription0.Dept_Id = presHead[index].Pres_ExeDept;
            prescription0.Item_Name = "小计：";
            prescription0.PresNo = PresNo;
            prescription0.OrderNo =OrderNo;
            //2009-12-22 统一医生站和收费系统的处方费用合计

            prescription0.Item_Money = money;
            prescription0.Status =status;

            return prescription0;
        }

        /// <summary>
        /// 添加新行
        /// </summary>
        /// <param name="listPres"></param>
        public static Prescription AddPresNewRow(int PresNo, int Group_Id, int OrderNo, int PresDoctorId, string PresDoctorName, int PresDeptCode, string PresDeptName)
        {
            Entity.Prescription prescriptionNew = new Entity.Prescription();
            prescriptionNew.PresHeadId = 0;
            prescriptionNew.PresNo = PresNo;
            prescriptionNew.OrderNo = OrderNo;
            prescriptionNew.Group_Id = Group_Id;
            prescriptionNew.Pres_Doc = PresDoctorId;
            prescriptionNew.Pres_DocName = PresDoctorName;
            prescriptionNew.Pres_Dept = PresDeptCode;
            prescriptionNew.Pres_DeptName = PresDeptName;
            prescriptionNew.Status = PresStatus.编辑状态;

            return prescriptionNew;
        }

        //获取西药处方数据
        public static DataTable GetPrescriptionData(int type,int patListId)
        {
            List<Prescription> _listPrescription = PrescripttionDataSource.GetPrescriptionData(patListId, type);
            CalculateSubtotal(ref _listPrescription);
            return ConvertDataExtend.ToDataTableS<Prescription>(_listPrescription);
        }

        //保存处方
        public static bool SavePrescriptionData(int type,int patListId, List<Prescription> data)
        {
            return PrescripttionDataSource.SavePrescriptionData(patListId, data, type);
        }

        //删除一条处方记录
        public static bool DeletePrescriptionData(int presListId)
        {
            PrescripttionDataSource.DeletePrescriptionData(presListId);
            return true;
        }
        //删除一张处方
        public static bool DeletePrescriptionData(int type, int patListId, int PresNo)
        {
            PrescripttionDataSource.DeletePrescriptionData(patListId, type, PresNo);
            return true;
        }

        //更新处方号和组号
        public static bool UpdatePresNoAndGroupId(List<Prescription> data)
        {
            if (data.Count == 0) return true;
            PrescripttionDataSource.UpdatePresNoAndGroupId(data);
            return true;
        }

        public static bool UpdatePresSelfDrugFlag(int presListId, int SelfDrug_Flag)
        {
            PrescripttionDataSource.UpdatePresSelfDrugFlag(presListId, SelfDrug_Flag);
            return true;
        }

        public static bool UpdatePresReimbursement(List<Prescription> data, int reimbursement)
        {
            if (data.Count == 0) return true;
            PrescripttionDataSource.UpdatePresReimbursementFlag(data, reimbursement);
            return true;
        }

        public static bool UpdatePresInjectTimes(int presListId, string menuText, int execTimes)
        {
            PrescripttionDataSource.UpdatePresInjectTimes(presListId, menuText, execTimes);
            return true;
        }
    }
}
