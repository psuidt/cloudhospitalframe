using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_DiseaseInformation", EntityType = EntityType.Table, IsGB = false)]
    public class MI_DiseaseInformation:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ID", DataKey = false, Match = "", IsInsert = true)]
        public int ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _miid;
        /// <summary>
        /// 医保类型ID
        /// </summary>
        [Column(FieldName = "MIID", DataKey = false, Match = "", IsInsert = true)]
        public int MIID
        {
            get { return  _miid; }
            set {  _miid = value; }
        }

        private string  _疾病编码;
        /// <summary>
        /// 疾病编码
        /// </summary>
        [Column(FieldName = "疾病编码", DataKey = false, Match = "", IsInsert = true)]
        public string 疾病编码
        {
            get { return  _疾病编码; }
            set {  _疾病编码 = value; }
        }

        private string  _疾病类型;
        /// <summary>
        /// c疾病类型
        /// </summary>
        [Column(FieldName = "疾病类型", DataKey = false, Match = "", IsInsert = true)]
        public string 疾病类型
        {
            get { return  _疾病类型; }
            set {  _疾病类型 = value; }
        }

        private string  _病种类别;
        /// <summary>
        /// 病种类别
        /// </summary>
        [Column(FieldName = "病种类别", DataKey = false, Match = "", IsInsert = true)]
        public string 病种类别
        {
            get { return  _病种类别; }
            set {  _病种类别 = value; }
        }

        private string  _病种名称;
        /// <summary>
        /// 病种名称
        /// </summary>
        [Column(FieldName = "病种名称", DataKey = false, Match = "", IsInsert = true)]
        public string 病种名称
        {
            get { return  _病种名称; }
            set {  _病种名称 = value; }
        }

        private int  _病种报销标注;
        /// <summary>
        /// 报销标志： 0不可报销 1可报销
   
        /// </summary>
        [Column(FieldName = "病种报销标注", DataKey = false, Match = "", IsInsert = true)]
        public int 病种报销标注
        {
            get { return  _病种报销标注; }
            set {  _病种报销标注 = value; }
        }

        private string  _特病分类;
        /// <summary>
        /// 特病分类
        /// </summary>
        [Column(FieldName = "特病分类", DataKey = false, Match = "", IsInsert = true)]
        public string 特病分类
        {
            get { return  _特病分类; }
            set {  _特病分类 = value; }
        }

        private string  _拼音码;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "拼音码", DataKey = false, Match = "", IsInsert = true)]
        public string 拼音码
        {
            get { return  _拼音码; }
            set {  _拼音码 = value; }
        }

        private string  _五笔码;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "五笔码", DataKey = false, Match = "", IsInsert = true)]
        public string 五笔码
        {
            get { return  _五笔码; }
            set {  _五笔码 = value; }
        }

        private int  _有效标志;
        /// <summary>
        /// 有效标志
        /// </summary>
        [Column(FieldName = "有效标志", DataKey = false, Match = "", IsInsert = true)]
        public int 有效标志
        {
            get { return  _有效标志; }
            set {  _有效标志 = value; }
        }

        private string  _经办人;
        /// <summary>
        /// 经办人
        /// </summary>
        [Column(FieldName = "经办人", DataKey = false, Match = "", IsInsert = true)]
        public string 经办人
        {
            get { return  _经办人; }
            set {  _经办人 = value; }
        }

        private string  _经办日期;
        /// <summary>
        /// 经办日期
        /// </summary>
        [Column(FieldName = "经办日期", DataKey = false, Match = "", IsInsert = true)]
        public string 经办日期
        {
            get { return  _经办日期; }
            set {  _经办日期 = value; }
        }

        private string  _工伤标志;
        /// <summary>
        /// 工商标志：0非工伤疾病 1 普通 2职业病
   
        /// </summary>
        [Column(FieldName = "工伤标志", DataKey = false, Match = "", IsInsert = true)]
        public string 工伤标志
        {
            get { return  _工伤标志; }
            set {  _工伤标志 = value; }
        }

        private string  _生育标志;
        /// <summary>
        /// 生育标志：0否 1 是
   
        /// </summary>
        [Column(FieldName = "生育标志", DataKey = false, Match = "", IsInsert = true)]
        public string 生育标志
        {
            get { return  _生育标志; }
            set {  _生育标志 = value; }
        }

        private string  _memo;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "memo", DataKey = false, Match = "", IsInsert = true)]
        public string memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

    }
}
