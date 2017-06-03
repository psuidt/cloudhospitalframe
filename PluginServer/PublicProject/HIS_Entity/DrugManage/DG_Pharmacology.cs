using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_Pharmacology", EntityType = EntityType.Table, IsGB = true)]
    public class DG_Pharmacology:AbstractEntity
    {
        private int  _pharmid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PharmID", DataKey = true, Match = "", IsInsert = false)]
        public int PharmID
        {
            get { return  _pharmid; }
            set {  _pharmid = value; }
        }

        private int  _parentid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ParentID", DataKey = false, Match = "", IsInsert = true)]
        public int ParentID
        {
            get { return  _parentid; }
            set {  _parentid = value; }
        }

        private string  _pharmname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PharmName", DataKey = false, Match = "", IsInsert = true)]
        public string PharmName
        {
            get { return  _pharmname; }
            set {  _pharmname = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Delflag", DataKey = false, Match = "", IsInsert = true)]
        public int Delflag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

    }
}
