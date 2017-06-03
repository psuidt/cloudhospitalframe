using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_DeptRelation", EntityType = EntityType.Table, IsGB = false)]
    public class MW_DeptRelation:AbstractEntity
    {
        private int  _药剂科室id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "药剂科室ID", DataKey = false, Match = "", IsInsert = true)]
        public int 药剂科室ID
        {
            get { return  _药剂科室id; }
            set {  _药剂科室id = value; }
        }

        private int  _往来科室id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "往来科室ID", DataKey = false, Match = "", IsInsert = true)]
        public int 往来科室ID
        {
            get { return  _往来科室id; }
            set {  _往来科室id = value; }
        }

        private string  _往来科室名称;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "往来科室名称", DataKey = false, Match = "", IsInsert = true)]
        public string 往来科室名称
        {
            get { return  _往来科室名称; }
            set {  _往来科室名称 = value; }
        }

        private int  _删除标识;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "删除标识", DataKey = false, Match = "", IsInsert = true)]
        public int 删除标识
        {
            get { return  _删除标识; }
            set {  _删除标识 = value; }
        }

        private string  _备注;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "备注", DataKey = false, Match = "", IsInsert = true)]
        public string 备注
        {
            get { return  _备注; }
            set {  _备注 = value; }
        }

        private DateTime  _更新时间;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "更新时间", DataKey = false, Match = "", IsInsert = true)]
        public DateTime 更新时间
        {
            get { return  _更新时间; }
            set {  _更新时间 = value; }
        }

        private int  _记录员id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "记录员ID", DataKey = false, Match = "", IsInsert = true)]
        public int 记录员ID
        {
            get { return  _记录员id; }
            set {  _记录员id = value; }
        }

        private int  _医疗机构id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "医疗机构ID", DataKey = false, Match = "", IsInsert = true)]
        public int 医疗机构ID
        {
            get { return  _医疗机构id; }
            set {  _医疗机构id = value; }
        }

    }
}
