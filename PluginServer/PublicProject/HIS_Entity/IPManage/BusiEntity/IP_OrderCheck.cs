using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.IPManage
{
    /// <summary>
    /// 发送入口类
    /// </summary>
    public class IP_OrderCheck
    {
        private string _bedNo;
        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo
        {
            get { return _bedNo; }
            set { _bedNo = value; }
        }

        private int _groupId;
        /// <summary>
        /// 医嘱组号ID
        /// </summary>
        public int GroupID
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private int _orderCategory;
        /// <summary>
        /// 医嘱类别　０长期医嘱　１临时医嘱
        /// </summary>
        public int OrderCategory
        {
            get { return _orderCategory; }
            set { _orderCategory = value; }
        }

        private int _channelID;
        /// <summary>
        /// 用法ID
        /// </summary>
        public int ChannelID
        {
            get { return _channelID; }
            set { _channelID = value; }
        }

        private int _frenquencyID;
        /// <summary>
        /// 频次ID
        /// </summary>
        public int FrenquencyID
        {
            get { return _frenquencyID; }
            set { _frenquencyID = value; }
        }

        private string _frenquency;
        /// <summary>
        /// 频次
        /// </summary>
        public string Frenquency
        {
            get { return _frenquency; }
            set { _frenquency = value; }
        }

        private int _orderType;
        /// <summary>
        /// 医嘱类型 1=交病人临嘱 2=自备医嘱 3=出院带药临嘱 4=说明性医嘱5=出院医嘱6=死亡医嘱7=转科医嘱
        /// </summary>
        public int OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        private int _zcyFlag;
        /// <summary>
        ///大项目ID 100 西药费 101 中成 102 中草药 107治疗费  106 检查费 110 化验费------改为中草药标志：1是中草药 0 非中草药
        /// </summary>
        public int ZCYFlag
        {
            get { return _zcyFlag; }
            set { _zcyFlag = value; }
        }

        private int _itemType;
        /// <summary>
        /// 医嘱类别 1=药品  2=物资   3=收费项目  4=组合项目  5＝说明性医嘱
        /// </summary>
        public int ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }        

        private int _orderStatus;
        /// <summary>
        /// 医嘱状态 0=医生保存   1=医生确认  2=已经转抄  3=医生停嘱  4=转抄停嘱 5=执行完毕
        /// </summary>
        public int OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; }
        }

        private int _execFlag;
        /// <summary>
        /// 执行标志 0未执行 1已执行
        /// </summary>
        public int ExecFlag
        {
            get { return _execFlag; }
            set { _execFlag = value; }
        }


        private int _firstNum;
        /// <summary>
        /// 首次
        /// </summary>
        public int FirstNum
        {
            get { return _firstNum; }
            set { _firstNum = value; }
        }

        private int _teminalNum;
        /// <summary>
        /// 末次
        /// </summary>
        public int TeminalNum
        {
            get { return _teminalNum; }
            set { _teminalNum = value; }
        }

        private DateTime _bCheckTime;
        /// <summary>
        /// 开始时间
        /// ExecFlag=1发送过:上次结束时间 ExecDate+1s;
        /// ExecFlag=0新医嘱:OrderBdate+1s
        /// </summary>
        public DateTime BCheckTime
        {
            get { return _bCheckTime; }
            set { _bCheckTime = value; }
        }

        private DateTime _eCheckTime;
        /// <summary>
        /// 结束时间
        /// OrderStatus=4-转抄停嘱:停嘱时间EOrderDate;
        /// OrderStatus=2-已经转抄:结束发送时间-界面选择
        /// </summary>
        public DateTime ECheckTime
        {
            get { return _eCheckTime; }
            set { _eCheckTime = value; }
        }
    }
}
