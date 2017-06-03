using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_DosageDic", EntityType = EntityType.Table, IsGB = true)]
    public class DG_DosageDic:AbstractEntity
    {
        private int  _dosageid;
        /// <summary>
        /// 药品剂型标识ID
        /// </summary>
        [Column(FieldName = "DosageID", DataKey = true, Match = "", IsInsert = false)]
        public int DosageID
        {
            get { return  _dosageid; }
            set {  _dosageid = value; }
        }

        private int  _typeid;
        /// <summary>
        /// 药品类型标识ID
        /// </summary>
        [Column(FieldName = "TypeID", DataKey = false, Match = "", IsInsert = true)]
        public int TypeID
        {
            get { return  _typeid; }
            set {  _typeid = value; }
        }

        private string  _dosagename;
        /// <summary>
        /// 名称
        /// </summary>
        [Column(FieldName = "DosageName", DataKey = false, Match = "", IsInsert = true)]
        public string DosageName
        {
            get { return  _dosagename; }
            set {  _dosagename = value; }
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

        private int _delflag;
        /// <summary>
        /// 删除标识
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return _delflag; }
            set { _delflag = value; }
        }
    }
}
