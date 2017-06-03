using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_BusiType", EntityType = EntityType.Table, IsGB = false)]
    public class DG_BusiType:AbstractEntity
    {
        private int  _busitypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BusiTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int BusiTypeID
        {
            get { return  _busitypeid; }
            set {  _busitypeid = value; }
        }

        private string  _busitypename;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BusiTypeName", DataKey = false, Match = "", IsInsert = true)]
        public string BusiTypeName
        {
            get { return  _busitypename; }
            set {  _busitypename = value; }
        }

        private string  _remark;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

        private string  _busicode;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "BusiCode", DataKey = false, Match = "", IsInsert = true)]
        public string BusiCode
        {
            get { return  _busicode; }
            set {  _busicode = value; }
        }

        private int  _isstop;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "IsStop", DataKey = false, Match = "", IsInsert = true)]
        public int IsStop
        {
            get { return  _isstop; }
            set {  _isstop = value; }
        }

        private int  _depttype;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DeptType", DataKey = false, Match = "", IsInsert = true)]
        public int DeptType
        {
            get { return  _depttype; }
            set {  _depttype = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
