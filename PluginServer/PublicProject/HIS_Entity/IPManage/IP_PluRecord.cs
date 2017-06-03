using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    //[Serializable]
    [Table(TableName = "IP_PluRecord", EntityType = EntityType.Table, IsGB = false)]
    public class IP_PluRecord : AbstractEntity
    {
        private int _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _patlistid;
        /// <summary>
        /// 病人ID
        /// </summary>
        [Column(FieldName = "PatlistID", DataKey = false, Match = "", IsInsert = true)]
        public int PatlistID
        {
            get { return _patlistid; }
            set { _patlistid = value; }
        }

        private DateTime _opreratordate;
        /// <summary>
        /// 测量时间
        /// </summary>
        [Column(FieldName = "OpreratorDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime OpreratorDate
        {
            get { return _opreratordate; }
            set { _opreratordate = value; }
        }

        private int _datetype;
        /// <summary>
        /// 时间类型 1早餐前　2早餐后 3午餐前　4午餐后　5晚餐前　６晚餐后　7睡前  8夜间  9随机
        /// </summary>
        [Column(FieldName = "DateType", DataKey = false, Match = "", IsInsert = true)]
        public int DateType
        {
            get { return _datetype; }
            set { _datetype = value; }
        }

        private string _pluvalue;
        /// <summary>
        /// 血糖测量值
        /// </summary>
        [Column(FieldName = "PluValue", DataKey = false, Match = "", IsInsert = true)]
        public string PluValue
        {
            get { return _pluvalue; }
            set { _pluvalue = value; }
        }

        private string _plurange;
        /// <summary>
        /// 血糖正常范围
        /// </summary>
        [Column(FieldName = "PluRange", DataKey = false, Match = "", IsInsert = true)]
        public string PluRange
        {
            get { return _plurange; }
            set { _plurange = value; }
        }

        private int _highlow;
        /// <summary>
        /// 0 正常 -1偏低  1偏高
        /// </summary>
        [Column(FieldName = "HighLow", DataKey = false, Match = "", IsInsert = true)]
        public int HighLow
        {
            get { return _highlow; }
            set { _highlow = value; }
        }

        private int _opreratorempid;
        /// <summary>
        /// 测量人员ＩＤ
        /// </summary>
        [Column(FieldName = "OpreratorEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int OpreratorEmpID
        {
            get { return _opreratorempid; }
            set { _opreratorempid = value; }
        }

        private string _memo;
        /// <summary>
        /// 备注，例如值偏高
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        private int _bloodID;
        /// <summary>
        /// 血糖系统唯一ID
        /// </summary>
        [Column(FieldName = "BloodID", DataKey = false, Match = "", IsInsert = true)]
        public int BloodID
        {
            get { return _bloodID; }
            set { _bloodID = value; }
        }
        private int _bloodTimes;
        /// <summary>
        /// 血糖测量次数
        /// </summary>
        [Column(FieldName = "BloodTimes", DataKey = false, Match = "", IsInsert = true)]
        public int BloodTimes
        {
            get { return _bloodTimes; }
            set { _bloodTimes = value; }
        }

        private int _delFlag;
        /// <summary>
        ///删除标志 0未删除1已删除
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return _delFlag; }
            set { _delFlag = value; }
        }
    }
}
