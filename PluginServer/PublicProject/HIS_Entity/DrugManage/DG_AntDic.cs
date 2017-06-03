using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.DrugManage
{
    [Serializable]
    [Table(TableName = "DG_AntDic", EntityType = EntityType.Table, IsGB = true)]
    public class DG_AntDic:AbstractEntity
    {
        private int  _antid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "AntID", DataKey = false, Match = "", IsInsert = true)]
        public int AntID
        {
            get { return  _antid; }
            set {  _antid = value; }
        }

        private string  _antname;
        /// <summary>
        /// 厂家名称
        /// </summary>
        [Column(FieldName = "AntName", DataKey = false, Match = "", IsInsert = true)]
        public string AntName
        {
            get { return  _antname; }
            set {  _antname = value; }
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

        private int  _delflag;
        /// <summary>
        /// 删除标识
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
