using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_FeeItemTemplateHead", EntityType = EntityType.Table, IsGB = false)]
    public class IP_FeeItemTemplateHead:AbstractEntity
    {
        private int  _tempheadid;
        /// <summary>
        /// 模板ID
        /// </summary>
        [Column(FieldName = "TempHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int TempHeadID
        {
            get { return  _tempheadid; }
            set {  _tempheadid = value; }
        }

        private int  _ptempheadid;
        /// <summary>
        /// 父模板ID
        /// </summary>
        [Column(FieldName = "PTempHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int PTempHeadID
        {
            get { return  _ptempheadid; }
            set {  _ptempheadid = value; }
        }

        private string  _tempname;
        /// <summary>
        /// 模板名称
        /// </summary>
        [Column(FieldName = "TempName", DataKey = false, Match = "", IsInsert = true)]
        public string TempName
        {
            get { return  _tempname; }
            set {  _tempname = value; }
        }

        private int  _templevel;
        /// <summary>
        /// 模板级别 0=全院 1=科室 2=个人
        /// </summary>
        [Column(FieldName = "TempLevel", DataKey = false, Match = "", IsInsert = true)]
        public int TempLevel
        {
            get { return  _templevel; }
            set {  _templevel = value; }
        }

        private int  _tempclass;
        /// <summary>
        /// 模板类型0=类型 1=模板
        /// </summary>
        [Column(FieldName = "TempClass", DataKey = false, Match = "", IsInsert = true)]
        public int TempClass
        {
            get { return  _tempclass; }
            set {  _tempclass = value; }
        }

        private int  _createdeptid;
        /// <summary>
        /// 创建科室ID
        /// </summary>
        [Column(FieldName = "CreateDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int CreateDeptID
        {
            get { return  _createdeptid; }
            set {  _createdeptid = value; }
        }

        private int  _createempid;
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column(FieldName = "CreateEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int CreateEmpID
        {
            get { return  _createempid; }
            set {  _createempid = value; }
        }

        private DateTime  _createdate;
        /// <summary>
        /// 创建日期
        /// </summary>
        [Column(FieldName = "CreateDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime CreateDate
        {
            get { return  _createdate; }
            set {  _createdate = value; }
        }

        private DateTime  _updatetime;
        /// <summary>
        /// 修改日期
        /// </summary>
        [Column(FieldName = "UpdateTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpdateTime
        {
            get { return  _updatetime; }
            set {  _updatetime = value; }
        }

        private string  _memo;
        /// <summary>
        /// 内容说明
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标志
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
