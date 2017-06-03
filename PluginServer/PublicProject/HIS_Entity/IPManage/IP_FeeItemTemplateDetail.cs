using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.IPManage
{
    [Serializable]
    [Table(TableName = "IP_FeeItemTemplateDetail", EntityType = EntityType.Table, IsGB = false)]
    public class IP_FeeItemTemplateDetail:AbstractEntity
    {
        private int  _tempdetailid;
        /// <summary>
        /// 模板明细ID
        /// </summary>
        [Column(FieldName = "TempDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int TempDetailID
        {
            get { return  _tempdetailid; }
            set {  _tempdetailid = value; }
        }

        private int  _tempheadid;
        /// <summary>
        /// 模板ID
        /// </summary>
        [Column(FieldName = "TempHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int TempHeadID
        {
            get { return  _tempheadid; }
            set {  _tempheadid = value; }
        }

        private int  _itemclass;
        /// <summary>
        /// 项目类型，1药品 2项目 3 材料 4组合项目
        /// </summary>
        [Column(FieldName = "ItemClass", DataKey = false, Match = "", IsInsert = true)]
        public int ItemClass
        {
            get { return  _itemclass; }
            set {  _itemclass = value; }
        }

        private int  _itemid;
        /// <summary>
        /// 医嘱项目ID
        /// </summary>
        [Column(FieldName = "ItemID", DataKey = false, Match = "", IsInsert = true)]
        public int ItemID
        {
            get { return  _itemid; }
            set {  _itemid = value; }
        }

        private string  _itemname;
        /// <summary>
        /// 项目内容
        /// </summary>
        [Column(FieldName = "ItemName", DataKey = false, Match = "", IsInsert = true)]
        public string ItemName
        {
            get { return  _itemname; }
            set {  _itemname = value; }
        }

        private int  _itemamount;
        /// <summary>
        /// 数量
        /// </summary>
        [Column(FieldName = "ItemAmount", DataKey = false, Match = "", IsInsert = true)]
        public int ItemAmount
        {
            get { return  _itemamount; }
            set {  _itemamount = value; }
        }

        private string  _itemunit;
        /// <summary>
        /// 单位
        /// </summary>
        [Column(FieldName = "ItemUnit", DataKey = false, Match = "", IsInsert = true)]
        public string ItemUnit
        {
            get { return  _itemunit; }
            set {  _itemunit = value; }
        }

        private int  _execdeptid;
        /// <summary>
        /// 执行科室ID
        /// </summary>
        [Column(FieldName = "ExecDeptID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecDeptID
        {
            get { return  _execdeptid; }
            set {  _execdeptid = value; }
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
