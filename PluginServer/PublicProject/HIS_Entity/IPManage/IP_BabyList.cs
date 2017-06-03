using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_BabyList", EntityType = EntityType.Table, IsGB = false)]
    public class IP_BabyList:AbstractEntity
    {
        private int  _babyid;
        /// <summary>
        /// 婴儿ID
        /// </summary>
        [Column(FieldName = "BabyID", DataKey = true, Match = "", IsInsert = false)]
        public int BabyID
        {
            get { return  _babyid; }
            set {  _babyid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人登记ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private string  _patname;
        /// <summary>
        /// 病人名称
        /// </summary>
        [Column(FieldName = "PatName", DataKey = false, Match = "", IsInsert = true)]
        public string PatName
        {
            get { return  _patname; }
            set {  _patname = value; }
        }

        private string  _babyname;
        /// <summary>
        /// 婴儿名称
        /// </summary>
        [Column(FieldName = "BabyName", DataKey = false, Match = "", IsInsert = true)]
        public string BabyName
        {
            get { return  _babyname; }
            set {  _babyname = value; }
        }

        private DateTime  _birthday;
        /// <summary>
        /// 出生日期
        /// </summary>
        [Column(FieldName = "BirthDay", DataKey = false, Match = "", IsInsert = true)]
        public DateTime BirthDay
        {
            get { return  _birthday; }
            set {  _birthday = value; }
        }

        private string  _sex;
        /// <summary>
        /// 婴儿性别
        /// </summary>
        [Column(FieldName = "Sex", DataKey = false, Match = "", IsInsert = true)]
        public string Sex
        {
            get { return  _sex; }
            set {  _sex = value; }
        }

        private int  _parturition;
        /// <summary>
        /// 分娩结果 1.活产 2.死产 3.死胎
        /// </summary>
        [Column(FieldName = "Parturition", DataKey = false, Match = "", IsInsert = true)]
        public int Parturition
        {
            get { return  _parturition; }
            set {  _parturition = value; }
        }

        private int  _direction;
        /// <summary>
        /// 婴儿转归 1.死亡 2.转科 3.出院
        /// </summary>
        [Column(FieldName = "Direction", DataKey = false, Match = "", IsInsert = true)]
        public int Direction
        {
            get { return  _direction; }
            set {  _direction = value; }
        }

        private int  _breath;
        /// <summary>
        /// 呼吸 1.自然 2.I度窒息 2.II度窒息
        /// </summary>
        [Column(FieldName = "Breath", DataKey = false, Match = "", IsInsert = true)]
        public int Breath
        {
            get { return  _breath; }
            set {  _breath = value; }
        }

        private int  _infectiontimes;
        /// <summary>
        /// 医院感染次数
        /// </summary>
        [Column(FieldName = "InfectionTimes", DataKey = false, Match = "", IsInsert = true)]
        public int InfectionTimes
        {
            get { return  _infectiontimes; }
            set {  _infectiontimes = value; }
        }

        private string  _infectionname;
        /// <summary>
        /// 主要医院感染名称
        /// </summary>
        [Column(FieldName = "InfectionName", DataKey = false, Match = "", IsInsert = true)]
        public string InfectionName
        {
            get { return  _infectionname; }
            set {  _infectionname = value; }
        }

        private int  _rescuetimes;
        /// <summary>
        /// 抢救次数
        /// </summary>
        [Column(FieldName = "RescueTimes", DataKey = false, Match = "", IsInsert = true)]
        public int RescueTimes
        {
            get { return  _rescuetimes; }
            set {  _rescuetimes = value; }
        }

        private int  _rescuesucceedtimes;
        /// <summary>
        /// 抢救成功次数
        /// </summary>
        [Column(FieldName = "RescueSucceedTimes", DataKey = false, Match = "", IsInsert = true)]
        public int RescueSucceedTimes
        {
            get { return  _rescuesucceedtimes; }
            set {  _rescuesucceedtimes = value; }
        }

        private int  _birthway;
        /// <summary>
        /// 1.顺产 2.剖腹产
        /// </summary>
        [Column(FieldName = "BirthWay", DataKey = false, Match = "", IsInsert = true)]
        public int BirthWay
        {
            get { return  _birthway; }
            set {  _birthway = value; }
        }

        private Decimal  _weight;
        /// <summary>
        /// 婴儿体重(g)
        /// </summary>
        [Column(FieldName = "Weight", DataKey = false, Match = "", IsInsert = true)]
        public Decimal Weight
        {
            get { return  _weight; }
            set {  _weight = value; }
        }

    }
}
