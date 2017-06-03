using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.OPManage
{
    public class Prescription
    {
        private int _presdetailid;
        public int PresDetailID
        {
            get { return _presdetailid; }
            set { _presdetailid = value; }
        }

        private int _feeitemheadid;
        /// <summary>
        /// 处方头ID
        /// </summary>       
        public int FeeItemHeadID
        {
            get { return _feeitemheadid; }
            set { _feeitemheadid = value; }
        }

        private int _memberid;
        /// <summary>
        /// 会员ＩＤ
        /// </summary>   
        public int MemberID
        {
            get { return _memberid; }
            set { _memberid = value; }
        }

        private int _patlistid;
        /// <summary>
        /// 就诊ID号
        /// </summary>     
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private int _itemid;
        /// <summary>
        /// 项目编号
        /// </summary>       
        public int ItemID
        {
            get { return _itemid; }
            set { _itemid = value; }
        }

        private string _itemtype;
        /// <summary>
        /// 项目类型 
        /// </summary>      
        public string ItemType
        {
            get { return _itemtype; }
            set { _itemtype = value; }
        }

        private int _statid;
        /// <summary>
        /// 大项目代码
        /// </summary>      
        public int StatID
        {
            get { return _statid; }
            set { _statid = value; }
        }

        private string _itemname;
        /// <summary>
        /// 项目名称
        /// </summary>       
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        private string _spec;
        /// <summary>
        /// 规格
        /// </summary>     
        public string Spec
        {
            get { return _spec; }
            set { _spec = value; }
        }

        private string _packUnit;
        /// <summary>
        /// 包装单位
        /// </summary>       
        public string PackUnit
        {
            get { return _packUnit; }
            set { _packUnit = value; }
        }

        private string _miniUnit;
        /// <summary>
        /// 基本单位
        /// </summary>       
        public string MiniUnit
        {
            get { return _miniUnit; }
            set { _miniUnit = value; }
        }

        private Decimal _unitno;
        /// <summary>
        /// 包装系数
        /// </summary>       
        public Decimal UnitNO
        {
            get { return _unitno; }
            set { _unitno = value; }
        }

        private Decimal _stockprice;
        /// <summary>
        /// 进价
        /// </summary>      
        public Decimal StockPrice
        {
            get { return _stockprice; }
            set { _stockprice = value; }
        }

        private Decimal _retailprice;
        /// <summary>
        /// 零售价
        /// </summary>    
        public Decimal RetailPrice
        {
            get { return _retailprice; }
            set { _retailprice = value; }
        }

        private Decimal _amount;
        /// <summary>
        /// 数量
        /// </summary>      
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private int _presamount;
        /// <summary>
        /// 处方贴数
        /// </summary>       
        public int PresAmount
        {
            get { return _presamount; }
            set { _presamount = value; }
        }

        private Decimal _totalfee;
        /// <summary>
        /// 合计费用
        /// </summary>       
        public Decimal TotalFee
        {
            get { return _totalfee; }
            set { _totalfee = value; }
        }

        private int _examitemid;
        /// <summary>
        /// 套餐ID
        /// </summary>     
        public int ExamItemID
        {
            get { return _examitemid; }
            set { _examitemid = value; }
        }

        private int _docpresdetailid;
        /// <summary>
        /// 医生处方明细ＩＤ
        /// </summary>       
        public int DocPresDetailID
        {
            get { return _docpresdetailid; }
            set { _docpresdetailid = value; }
        }


        private Decimal _packamount;
        /// <summary>
        /// 包装数量
        /// </summary>    
        public Decimal PackAmount
        {
            get { return _packamount; }
            set { _packamount = value; }
        }



        private Decimal _miniamount;
        /// <summary>
        /// 基本数量
        /// </summary>    
        public Decimal MiniAmount
        {
            get { return _miniamount; }
            set { _miniamount = value; }
        }

        private string  _execDetpName;
        /// <summary>
        /// 执行科室
        /// </summary>
        public string  ExecDetpName
        {
            get { return _execDetpName; }
            set { _execDetpName = value; }
        }

        private string _presDocName;
        /// <summary>
        /// 开方医生
        /// </summary>
        public string PresDocName
        {
            get { return _presDocName; }
            set { _presDocName = value; }
        }

        private string _prestype;
        /// <summary>
        /// 处方类型
        /// </summary>     
        public string PresType
        {
            get { return _prestype; }
            set { _prestype = value; }
        }

        private string _memo;
        /// <summary>
        /// 备注
        /// </summary>     
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }


        private int _presempid;
        /// <summary>
        /// 开方医生代码
        /// </summary>       
        public int PresEmpID
        {
            get { return _presempid; }
            set { _presempid = value; }
        }

        private int _presdeptid;
        /// <summary>
        /// 开方科室代码
        /// </summary>
      
        public int PresDeptID
        {
            get { return _presdeptid; }
            set { _presdeptid = value; }
        }

        private int _execdeptid;
        /// <summary>
        /// 执行科室代码
        /// </summary>     
        public int ExecDeptID
        {
            get { return _execdeptid; }
            set { _execdeptid = value; }
        }
        private int _presno;
        /// <summary>
        /// 处方排序号
        /// </summary>
        public int presNO
        {
            get { return _presno; }
            set { _presno = value; }
        }

        private int _subtotalflag;
        /// <summary>
        /// 处方小计标志位
        /// </summary>
        public int SubTotalFlag
        {
            get { return _subtotalflag; }
            set { _subtotalflag = value; }
        }

        private int _prescGroupID;
        /// <summary>
        /// 一张处方序号标志
        /// </summary>
        public int PrescGroupID
        {
            get { return _prescGroupID; }
            set { _prescGroupID = value; }
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        private int _selected;
        public int Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        private int _docpresheadid;
        /// <summary>
        /// 医生处方ID
        /// </summary>      
        public int DocPresHeadID
        {
            get { return _docpresheadid; }
            set { _docpresheadid = value; }
        }

        private Decimal _feeno;
        /// <summary>
        /// 费用流水号
        /// </summary>        
        public Decimal FeeNo
        {
            get { return _feeno; }
            set { _feeno = value; }
        }


        private int _modifyFlag;
        /// <summary>
        /// 是否修改状态
        /// </summary>        
        public int ModifyFlag
        {
            get { return _modifyFlag; }
            set { _modifyFlag = value; }
        }

        private Decimal _refundpackamount;
        /// <summary>
        /// 退包装数量
        /// </summary>    
        public Decimal RefundPackAmount
        {
            get { return _refundpackamount; }
            set { _refundpackamount = value; }
        }
        private Decimal _refundminiamount;
        /// <summary>
        /// 退基本数量
        /// </summary>    
        public Decimal RefundMiniAmount
        {
            get { return _refundminiamount; }
            set { _refundminiamount = value; }
        }
        private Decimal _refundamount;
        /// <summary>
        /// 退数量
        /// </summary>    
        public Decimal Refundamount
        {
            get { return _refundamount; }
            set { _refundamount = value; }
        }
        private Decimal _refundfee;
        /// <summary>
        /// 退数量
        /// </summary>    
        public Decimal Refundfee
        {
            get { return _refundfee; }
            set { _refundfee = value; }
        }

        private int _costheadid;
        /// <summary>
        /// 结算ID
        /// </summary>    
        public int CostHeadID
        {
            get { return _costheadid; }
            set { _costheadid = value; }
        }
        private int _docpresno;
        /// <summary>
        /// 医生处方号
        /// </summary>
        public int DocPresNO
        {
            get { return _docpresno; }
            set { _docpresno = value; }
        }
        private DateTime _docPresDate;
        /// <summary>
        /// 医生开方时间
        /// </summary>     
        public DateTime DocPresDate
        {
            get { return _docPresDate; }
            set { _docPresDate = value; }
        }
        #region 医保需用到字段
        private string _drugapprovalnumber;
        /// <summary>
        /// 药品准字号,医保需要用到
        /// </summary>
        public string DrugApprovalnumber
        {
            get { return _drugapprovalnumber; }
            set { _drugapprovalnumber = value; }
        }
        private int _isReimbursement;
        /// <summary>
        /// 医保是否报销 0不报销 1可报销
        /// </summary>
        public int IsReimbursement
        {
            get { return _isReimbursement; }
            set { _isReimbursement = value; }
        }
        private string _dosage;
        /// <summary>
        /// 单次用量
        /// </summary>
        public string Dosage
        {
            get { return _dosage; }
            set { _dosage = value; }
        }
        private int _days;
        /// <summary>
        /// 开药天数
        /// </summary>
        public int Days
        {
            get { return _days; }
            set { _days = value; }
        }
        private string _frequencyName;
        /// <summary>
        /// 频次
        /// </summary>
        public string FrequencyName
        {
            get { return _frequencyName; }
            set { _frequencyName = value; }
        }
        private string _dosageName;
        /// <summary>
        /// 剂型
        /// </summary>
        public string DosageName
        {
            get { return _dosageName; }
            set { _dosageName = value; }
        }

        private int _dosageId;
        /// <summary>
        /// 剂型ID
        /// </summary>
        public int DosageId
        {
            get { return _dosageId; }
            set { _dosageId = value; }
        }

        private int _frequencyId;
        /// <summary>
        /// 频次ID
        /// </summary>
        public int FrequencyID
        {
            get { return _frequencyId; }
            set { _frequencyId = value; }
        }
        #endregion
    }
}
