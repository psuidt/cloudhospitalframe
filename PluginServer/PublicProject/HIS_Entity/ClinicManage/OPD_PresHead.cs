using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_PresHead", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_PresHead:AbstractEntity
    {
        private int _presheadid;
        /// <summary>
        /// 处方头表ID
        /// </summary>
        [Column(FieldName = "PresHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int PresHeadID
        {
            get { return  _presheadid; }
            set {  _presheadid = value; }
        }

        private int  _memberid;
        /// <summary>
        /// 会员ID
        /// </summary>
        [Column(FieldName = "MemberID", DataKey = false, Match = "", IsInsert = true)]
        public int MemberID
        {
            get { return  _memberid; }
            set {  _memberid = value; }
        }

        private int  _patlistid;
        /// <summary>
        /// 病人就诊ID
        /// </summary>
        [Column(FieldName = "PatListID", DataKey = false, Match = "", IsInsert = true)]
        public int PatListID
        {
            get { return  _patlistid; }
            set {  _patlistid = value; }
        }

        private int  _prestype;
        /// <summary>
        /// 处方类型:1=西成药处方 2=中草药处方3=费用 4=检验检查
        /// </summary>
        [Column(FieldName = "PresType", DataKey = false, Match = "", IsInsert = true)]
        public int PresType
        {
            get { return  _prestype; }
            set {  _prestype = value; }
        }

    }
}
