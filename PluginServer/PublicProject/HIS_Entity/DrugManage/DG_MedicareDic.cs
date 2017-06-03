using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_MedicareDic", EntityType = EntityType.Table, IsGB = false)]
    public class DG_MedicareDic:AbstractEntity
    {
        private int  _medicareid;
        /// <summary>
        /// 医保类型典标识ID
        /// </summary>
        [Column(FieldName = "MedicareID", DataKey = true, Match = "", IsInsert = false)]
        public int MedicareID
        {
            get { return  _medicareid; }
            set {  _medicareid = value; }
        }

        private string  _medicarename;
        /// <summary>
        /// 医保类型名称
        /// </summary>
        [Column(FieldName = "MedicareName", DataKey = false, Match = "", IsInsert = true)]
        public string MedicareName
        {
            get { return  _medicarename; }
            set {  _medicarename = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private string  _remark;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

    }
}
