using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace EMR_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Emr_MedicalTree", EntityType = EntityType.Table, IsGB = false)]
    public class Emr_MedicalTree:AbstractEntity
    {
        private int  _treeid;
        /// <summary>
        /// 节点编码
        /// </summary>
        [Column(FieldName = "TreeID", DataKey = true, Match = "", IsInsert = false)]
        public int TreeID
        {
            get { return  _treeid; }
            set {  _treeid = value; }
        }

        private string  _treename;
        /// <summary>
        /// 节点名称
        /// </summary>
        [Column(FieldName = "TreeName", DataKey = false, Match = "", IsInsert = true)]
        public string TreeName
        {
            get { return  _treename; }
            set {  _treename = value; }
        }

        private string  _treeimage;
        /// <summary>
        /// 节点图片
        /// </summary>
        [Column(FieldName = "TreeImage", DataKey = false, Match = "", IsInsert = true)]
        public string TreeImage
        {
            get { return  _treeimage; }
            set {  _treeimage = value; }
        }

        private int  _doctormode;
        /// <summary>
        /// 医生模式 0不可见 1可见 2可见只读 3可见编辑
        /// </summary>
        [Column(FieldName = "DoctorMode", DataKey = false, Match = "", IsInsert = true)]
        public int DoctorMode
        {
            get { return  _doctormode; }
            set {  _doctormode = value; }
        }

        private int  _nursemode;
        /// <summary>
        /// 护士模式 0不可见 1可见 2可见只读 3可见编辑
        /// </summary>
        [Column(FieldName = "NurseMode", DataKey = false, Match = "", IsInsert = true)]
        public int NurseMode
        {
            get { return  _nursemode; }
            set {  _nursemode = value; }
        }

        private int  _viewmode;
        /// <summary>
        /// 浏览模式 0不可见 1可见 2可见只读 3可见编辑
        /// </summary>
        [Column(FieldName = "ViewMode", DataKey = false, Match = "", IsInsert = true)]
        public int ViewMode
        {
            get { return  _viewmode; }
            set {  _viewmode = value; }
        }

        private string  _openview;
        /// <summary>
        /// 打开界面,通过字典表动态获取 
        /// </summary>
        [Column(FieldName = "OpenView", DataKey = false, Match = "", IsInsert = true)]
        public string OpenView
        {
            get { return  _openview; }
            set {  _openview = value; }
        }

        private int  _editmode;
        /// <summary>
        /// 编辑方式 0 合并编辑 1 独立编辑
        /// </summary>
        [Column(FieldName = "EditMode", DataKey = false, Match = "", IsInsert = true)]
        public int EditMode
        {
            get { return  _editmode; }
            set {  _editmode = value; }
        }

        private int  _createmode;
        /// <summary>
        /// 创建模式 0 只能创建一份 1 能创建多份
        /// </summary>
        [Column(FieldName = "CreateMode", DataKey = false, Match = "", IsInsert = true)]
        public int CreateMode
        {
            get { return  _createmode; }
            set {  _createmode = value; }
        }

        private string  _remark;
        /// <summary>
        /// 节点备注
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

        private int  _sortorder;
        /// <summary>
        /// 排序码
        /// </summary>
        [Column(FieldName = "SortOrder", DataKey = false, Match = "", IsInsert = true)]
        public int SortOrder
        {
            get { return  _sortorder; }
            set {  _sortorder = value; }
        }

        private int  _isstop;
        /// <summary>
        /// 停用状态 0 启用 1 停用
        /// </summary>
        [Column(FieldName = "IsStop", DataKey = false, Match = "", IsInsert = true)]
        public int IsStop
        {
            get { return  _isstop; }
            set {  _isstop = value; }
        }

    }
}
