using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "Basic_AttachAdvice", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_AttachAdvice:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private string  _itemcode;
        /// <summary>
        /// 说明性医嘱代码
        /// </summary>
        [Column(FieldName = "ItemCode", DataKey = false, Match = "", IsInsert = true)]
        public string ItemCode
        {
            get { return  _itemcode; }
            set {  _itemcode = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 名称
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private string  _itemspec;
        /// <summary>
        /// 规格
        /// </summary>
        [Column(FieldName = "ItemSpec", DataKey = false, Match = "", IsInsert = true)]
        public string ItemSpec
        {
            get { return  _itemspec; }
            set {  _itemspec = value; }
        }

        private string  _unit;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "Unit", DataKey = false, Match = "", IsInsert = true)]
        public string Unit
        {
            get { return  _unit; }
            set {  _unit = value; }
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

        private int  _uploader;
        /// <summary>
        /// 更新人
        /// </summary>
        [Column(FieldName = "Uploader", DataKey = false, Match = "", IsInsert = true)]
        public int Uploader
        {
            get { return  _uploader; }
            set {  _uploader = value; }
        }

        private DateTime  _uploadtime;
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column(FieldName = "UploadTime", DataKey = false, Match = "", IsInsert = true)]
        public DateTime UploadTime
        {
            get { return  _uploadtime; }
            set {  _uploadtime = value; }
        }

        private int _delflag;
        /// <summary>
        /// 删除标志
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return _delflag; }
            set { _delflag = value; }
        }

    }
}
