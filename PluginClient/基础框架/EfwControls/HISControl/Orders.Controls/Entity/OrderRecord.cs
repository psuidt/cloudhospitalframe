using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.HISControl.Orders.Controls.Entity
{
    public class OrderRecord
    {
        private int _orderid;
        /// <summary>
        /// 医嘱ID
        /// </summary>       
        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private int _patlistid;
        /// <summary>
        /// 病人ID
        /// </summary>        
        public int PatListID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private int _babyid;
        /// <summary>
        /// 婴儿ID
        /// </summary>    
        public int BabyID
        {
            get { return _babyid; }
            set { _babyid = value; }
        }

        private int _wardid;
        /// <summary>
        /// 病区ID
        /// </summary>      
        public int WardID
        {
            get { return _wardid; }
            set { _wardid = value; }
        }

        private int _patdeptid;
        /// <summary>
        /// 病人所在科室
        /// </summary>      
        public int PatDeptID
        {
            get { return _patdeptid; }
            set { _patdeptid = value; }
        }

        private int _presdeptid;
        /// <summary>
        /// 开单科室
        /// </summary>       
        public int PresDeptID
        {
            get { return _presdeptid; }
            set { _presdeptid = value; }
        }

        private int _ordercategory;
        /// <summary>
        /// 医嘱类别　０长期医嘱　１临时医嘱
        /// </summary>      
        public int OrderCategory
        {
            get { return _ordercategory; }
            set { _ordercategory = value; }
        }

        private int _ordertype;
        /// <summary>
        /// 医嘱类型 1=交病人临嘱 2=自备医嘱 3=出院带药临嘱4=说明性医嘱5=出院医嘱6=死亡医嘱7=转科医嘱
        /// </summary>     
        public int OrderType
        {
            get { return _ordertype; }
            set { _ordertype = value; }
        }

        private int _orderdoc;
        /// <summary>
        /// 下嘱医生
        /// </summary>    
        public int OrderDoc
        {
            get { return _orderdoc; }
            set { _orderdoc = value; }
        }

        private DateTime _orderbdate;
        /// <summary>
        /// 开始日期
        /// </summary>     
        public DateTime OrderBdate
        {
            get { return _orderbdate; }
            set { _orderbdate = value; }
        }

        private int _itemtype;
        /// <summary>
        /// 医嘱类别 医嘱类别 1=药品  2=物资   3=收费项目  4=组合项目  5＝说明性医嘱 
        /// </summary>      
        public int ItemType
        {
            get { return _itemtype; }
            set { _itemtype = value; }
        }

        private int _groupid;
        /// <summary>
        /// 医嘱组号
        /// </summary>       
        public int GroupID
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

        private int _groupserailid;
        /// <summary>
        /// 医嘱顺序号
        /// </summary>      
        public int GroupSerailID
        {
            get { return _groupserailid; }
            set { _groupserailid = value; }
        }

        private int _itemid;
        /// <summary>
        /// 医嘱项目ID
        /// </summary>      
        public int ItemID
        {
            get { return _itemid; }
            set { _itemid = value; }
        }

        private string _itemname;
        /// <summary>
        /// 医嘱内容
        /// </summary>       
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        private int _statid;
        /// <summary>
        /// 大项目ID
        /// </summary>     
        public int StatID
        {
            get { return _statid; }
            set { _statid = value; }
        }

        private Decimal _dosage;
        /// <summary>
        /// 数量
        /// </summary>     
        public Decimal Dosage
        {
            get { return _dosage; }
            set { _dosage = value; }
        }

        private string _dosageunit;
        /// <summary>
        /// 单位
        /// </summary>     
        public string DosageUnit
        {
            get { return _dosageunit; }
            set { _dosageunit = value; }
        }

        private Decimal _factor;
        /// <summary>
        /// 剂量单位与基本单位系数
        /// </summary>   
        public Decimal Factor
        {
            get { return _factor; }
            set { _factor = value; }
        }

        private Decimal _dosenum;
        /// <summary>
        /// 中药剂数
        /// </summary>      
        public Decimal DoseNum
        {
            get { return _dosenum; }
            set { _dosenum = value; }
        }

        private string _spec;
        /// <summary>
        /// 药品规格
        /// </summary>    
        public string Spec
        {
            get { return _spec; }
            set { _spec = value; }
        }

        private string _entrust;
        /// <summary>
        /// 嘱托
        /// </summary>     
        public string Entrust
        {
            get { return _entrust; }
            set { _entrust = value; }
        }

        private int _channelid;
        /// <summary>
        /// 用法ＩＤ
        /// </summary>     
        public int ChannelID
        {
            get { return _channelid; }
            set { _channelid = value; }
        }

        private string _channelname;
        /// <summary>
        /// 用法
        /// </summary>  
        public string ChannelName
        {
            get { return _channelname; }
            set { _channelname = value; }
        }

        private string _frequency;
        /// <summary>
        /// 频次
        /// </summary>    
        public string Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        private int _frenquencyid;
        /// <summary>
        /// 频次ＩＤ
        /// </summary>   
        public int FrenquencyID
        {
            get { return _frenquencyid; }
            set { _frenquencyid = value; }
        }

        private string _dropspec;
        /// <summary>
        /// 滴速
        /// </summary>    
        public string DropSpec
        {
            get { return _dropspec; }
            set { _dropspec = value; }
        }

        private int _execdeptid;
        /// <summary>
        /// 执行科室
        /// </summary>      
        public int ExecDeptID
        {
            get { return _execdeptid; }
            set { _execdeptid = value; }
        }

        private int _firstnum;
        /// <summary>
        /// 首次
        /// </summary>     
        public int FirstNum
        {
            get { return _firstnum; }
            set { _firstnum = value; }
        }

        private int _teminalnum;
        /// <summary>
        /// 末次
        /// </summary>      
        public int TeminalNum
        {
            get { return _teminalnum; }
            set { _teminalnum = value; }
        }

        private int _transnurse;
        /// <summary>
        /// 转抄护士
        /// </summary>    
        public int TransNurse
        {
            get { return _transnurse; }
            set { _transnurse = value; }
        }

        private DateTime _transdate;
        /// <summary>
        /// 转抄日期
        /// </summary>   
        public DateTime TransDate
        {
            get { return _transdate; }
            set { _transdate = value; }
        }

        private int _execnurse;
        /// <summary>
        /// 核对护士
        /// </summary>      
        public int ExecNurse
        {
            get { return _execnurse; }
            set { _execnurse = value; }
        }

        private DateTime _execdate;
        /// <summary>
        /// 核对日期
        /// </summary>     
        public DateTime ExecDate
        {
            get { return _execdate; }
            set { _execdate = value; }
        }

        private DateTime _eorderdate;
        /// <summary>
        /// 结束日期
        /// </summary>      
        public DateTime EOrderDate
        {
            get { return _eorderdate; }
            set { _eorderdate = value; }
        }

        private int _eorderdoc;
        /// <summary>
        /// 停嘱医生
        /// </summary>       
        public int EOrderDoc
        {
            get { return _eorderdoc; }
            set { _eorderdoc = value; }
        }

        private int _eordertsnurse;
        /// <summary>
        /// 停嘱转抄护士
        /// </summary>      
        public int EOrderTsNurse
        {
            get { return _eordertsnurse; }
            set { _eordertsnurse = value; }
        }

        private DateTime _eordertsdate;
        /// <summary>
        /// 停嘱转抄时间
        /// </summary>      
        public DateTime EOrderTsDate
        {
            get { return _eordertsdate; }
            set { _eordertsdate = value; }
        }

        private int _orderstatus;
        /// <summary>
        /// 医嘱状态 0=医生保存   1=医生确认  2=已经转抄  3=医生停嘱  4=转抄停嘱 5=执行完毕
        /// </summary>    
        public int OrderStatus
        {
            get { return _orderstatus; }
            set { _orderstatus = value; }
        }

        private int _deleteflag;
        /// <summary>
        /// 删除标志
        /// </summary>    
        public int DeleteFlag
        {
            get { return _deleteflag; }
            set { _deleteflag = value; }
        }

        private int _astflag;
        /// <summary>
        /// 皮试标志 -1=不要皮试 0=要皮试,还没出结果  1=皮试结果为阴性  2=皮试结果为阳性  3=免试
        /// </summary>     
        public int AstFlag
        {
            get { return _astflag; }
            set { _astflag = value; }
        }

        private decimal _astorderid;
        /// <summary>
        /// 皮试对应医嘱ID
        /// </summary>     
        public decimal AstOrderID
        {
            get { return _astorderid; }
            set { _astorderid = value; }
        }

        private int _execflag;
        /// <summary>
        /// 未执行标志 0=未执行 1=已执行
        /// </summary>    
        public int ExecFlag
        {
            get { return _execflag; }
            set { _execflag = value; }
        }

        private int _chargeflag;
        /// <summary>
        /// 是否直接记账 0=直接记账
        /// </summary>    
        public int ChargeFlag
        {
            get { return _chargeflag; }
            set { _chargeflag = value; }
        }

        private Decimal _itemprice;
        /// <summary>
        /// 医嘱价格
        /// </summary>      
        public Decimal ItemPrice
        {
            get { return _itemprice; }
            set { _itemprice = value; }
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

        private int _examitemid;
        /// <summary>
        /// 套餐ID
        /// </summary>      
        public int ExamItemID
        {
            get { return _examitemid; }
            set { _examitemid = value; }
        }

        private Decimal _amount;
        /// <summary>
        /// 开药数量
        /// </summary>     
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private string _unit;
        /// <summary>
        /// 数量单位
        /// </summary>     
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private int _unitno;
        /// <summary>
        /// 数量系数
        /// </summary>      
        public int UnitNO
        {
            get { return _unitno; }
            set { _unitno = value; }
        }

        private int _autoendflag;
        /// <summary>
        /// 自动停标志 1=自动停
        /// </summary>     
        public int AutoEndFlag
        {
            get { return _autoendflag; }
            set { _autoendflag = value; }
        }

        private int _cancelflag;
        /// <summary>
        /// 作废标志　0未作废　１作废
        /// </summary>      
        public int CancelFlag
        {
            get { return _cancelflag; }
            set { _cancelflag = value; }
        }
        #region 扩长字段
        private string _orderDocName;
        /// <summary>
        /// ????
        /// </summary>
        public string OrderDocName
        {
            get { return _orderDocName; }
            set { _orderDocName = value; }
        }

        private string _execNurseName;
        /// <summary>
        /// ????
        /// </summary>
        public string ExecNurseName
        {
            get { return _execNurseName; }
            set { _execNurseName = value; }
        }

        private int _modifyFlag;
        public int ModifyFlag
        {
            get { return _modifyFlag; }
            set { _modifyFlag = value; }
        }

        private string _eorderDocname;
        public string EOrderDocName
        {
            get { return _eorderDocname; }
            set { _eorderDocname = value; }
        }
        private int _groupflag;
        public int GroupFlag
        {
            get { return _groupflag; }
            set { _groupflag = value; }
        }
        private DateTime _showOrderBdate;
        public DateTime ShowOrderBdate
        {
            get { return _showOrderBdate; }
            set { _showOrderBdate = value; }
        }
        private string _showChannel;
        public string ShowChannel
        {
            get { return _showChannel; }
            set { _showChannel = value; }
        }
        private string _showFrency;
        public string ShowFrency
        {
            get { return _showFrency; }
            set { _showFrency = value; }
        }
        private int _showFirstNum;
        public int ShowFirstNum
        {
            get { return _showFirstNum; }
            set { _showFirstNum = value; }
        }
        private int _showTeminalNum;
        public int ShowTeminalNum
        {
            get { return _showTeminalNum; }
            set { _showTeminalNum = value; }
        }
        private decimal _showDoseNum;
        public decimal ShowDoseNum
        {
            get { return _showDoseNum; }
            set { _showDoseNum = value; }
        }
        //执行科室
        private string _execDeptName;
        public string ExecDeptName
        {
            get { return _execDeptName; }
            set { _execDeptName = value; }
        }
        #endregion
        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
