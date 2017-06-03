using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DS_ValidStorage", EntityType = EntityType.Table, IsGB = false)]
    public class DS_ValidStorage:AbstractEntity
    {
        private int _id;
        /// <summary>
        /// 库存量ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _storageid;
        /// <summary>
        /// 库存量ID
        /// </summary>
        [Column(FieldName = "StorageID", DataKey = false, Match = "", IsInsert = true)]
        public int StorageID
        {
            get { return  _storageid; }
            set {  _storageid = value; }
        }

        private long  _drugid;
        /// <summary>
        /// 厂家典ID
        /// </summary>
        [Column(FieldName = "DrugID", DataKey = false, Match = "", IsInsert = true)]
        public long DrugID
        {
            get { return  _drugid; }
            set {  _drugid = value; }
        }

        private Decimal  _validamount;
        /// <summary>
        /// 有效库存量
        /// </summary>
        [Column(FieldName = "ValidAmount", DataKey = false, Match = "", IsInsert = true)]
        public Decimal ValidAmount
        {
            get { return  _validamount; }
            set {  _validamount = value; }
        }

        private int  _deptid;
        /// <summary>
        /// 库房ID
        /// </summary>
        [Column(FieldName = "DeptID", DataKey = false, Match = "", IsInsert = true)]
        public int DeptID
        {
            get { return  _deptid; }
            set {  _deptid = value; }
        }

    }
}
