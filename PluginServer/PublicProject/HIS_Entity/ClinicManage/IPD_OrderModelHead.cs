using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "IPD_OrderModelHead", EntityType = EntityType.Table, IsGB = false)]
    public class IPD_OrderModelHead:AbstractEntity
    {
        private int  _modelheadid;
        /// <summary>
        /// 模板ID
        /// </summary>
        [Column(FieldName = "ModelHeadID", DataKey = true, Match = "", IsInsert = false)]
        public int ModelHeadID
        {
            get { return  _modelheadid; }
            set {  _modelheadid = value; }
        }

        private int  _pid;
        /// <summary>
        /// 父模板ID
        /// </summary>
        [Column(FieldName = "PID", DataKey = false, Match = "", IsInsert = true)]
        public int PID
        {
            get { return  _pid; }
            set {  _pid = value; }
        }

        private string  _modelname;
        /// <summary>
        /// 模板名称
        /// </summary>
        [Column(FieldName = "ModelName", DataKey = false, Match = "", IsInsert = true)]
        public string ModelName
        {
            get { return  _modelname; }
            set {  _modelname = value; }
        }

        private int  _modellevel;
        /// <summary>
        /// 模板级别 0=全院 1=科室 2=个人
        /// </summary>
        [Column(FieldName = "ModelLevel", DataKey = false, Match = "", IsInsert = true)]
        public int ModelLevel
        {
            get { return  _modellevel; }
            set {  _modellevel = value; }
        }

        private int  _modeltype;
        /// <summary>
        /// 模板类型0=类型 1=模板
        /// </summary>
        [Column(FieldName = "ModelType", DataKey = false, Match = "", IsInsert = true)]
        public int ModelType
        {
            get { return  _modeltype; }
            set {  _modeltype = value; }
        }

        private int  _creatdeptid;
        /// <summary>
        /// 创建科室ID
        /// </summary>
        [Column(FieldName = "CreatDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int CreatDeptID
        {
            get { return  _creatdeptid; }
            set {  _creatdeptid = value; }
        }

        private int  _createdocid;
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Column(FieldName = "CreateDocID", DataKey = false, Match = "", IsInsert = true)]
        public int CreateDocID
        {
            get { return  _createdocid; }
            set {  _createdocid = value; }
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

        private DateTime  _updatedate;
        /// <summary>
        /// 修改日期
        /// </summary>
        [Column(FieldName = "UpdateDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UpdateDate
        {
            get { return  _updatedate; }
            set {  _updatedate = value; }
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

        private int  _deleteflag;
        /// <summary>
        /// 删除标志
        /// </summary>
        [Column(FieldName = "DeleteFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DeleteFlag
        {
            get { return  _deleteflag; }
            set {  _deleteflag = value; }
        }

    }
}
