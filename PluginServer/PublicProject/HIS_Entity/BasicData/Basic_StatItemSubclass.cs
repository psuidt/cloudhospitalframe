using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "Basic_StatItemSubclass", EntityType = EntityType.Table, IsGB = false)]
    public class Basic_StatItemSubclass:AbstractEntity
    {
        private int  _subid;
        /// <summary>
        /// 子类型ID
        /// </summary>
        [Column(FieldName = "SubID", DataKey = true, Match = "", IsInsert = false)]
        public int SubID
        {
            get { return  _subid; }
            set {  _subid = value; }
        }

        private int  _subtype;
        /// <summary>
        /// 子类型分类，1会计分类 2核算分类 3病案分类 4住院发票分类 5门诊发票分类 6医保分类
        /// </summary>
        [Column(FieldName = "SubType", DataKey = false, Match = "", IsInsert = true)]
        public int SubType
        {
            get { return  _subtype; }
            set {  _subtype = value; }
        }

        private string  _subname;
        /// <summary>
        /// 子分类名称
        /// </summary>
        [Column(FieldName = "SubName", DataKey = false, Match = "", IsInsert = true)]
        public string SubName
        {
            get { return  _subname; }
            set {  _subname = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PyCode", DataKey = false, Match = "", IsInsert = true)]
        public string PyCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WbCode", DataKey = false, Match = "", IsInsert = true)]
        public string WbCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private int  _ordernum;
        /// <summary>
        /// 排序
        /// </summary>
        [Column(FieldName = "OrderNum", DataKey = false, Match = "", IsInsert = true)]
        public int OrderNum
        {
            get { return  _ordernum; }
            set {  _ordernum = value; }
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

        public string StopText
        {
            get
            {
                if (DelFlag == 1)
                    return "已停用";
                else
                    return "已启用";
            }
        }
    }
}
