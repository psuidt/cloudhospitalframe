using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MIManage
{
    [Serializable]
    [Table(TableName = "MI_MedicalInsuranceType", EntityType = EntityType.Table, IsGB = false)]
    public class MI_MedicalInsuranceType:AbstractEntity
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

        private string  _miname;
        /// <summary>
        /// 医保名称
        /// </summary>
        [Column(FieldName = "MIName", DataKey = false, Match = "", IsInsert = true)]
        public string MIName
        {
            get { return  _miname; }
            set {  _miname = value; }
        }

        private int  _vaildflag;
        /// <summary>
        /// 有效标志
        /// </summary>
        [Column(FieldName = "VaildFlag", DataKey = false, Match = "", IsInsert = true)]
        public int VaildFlag
        {
            get { return  _vaildflag; }
            set {  _vaildflag = value; }
        }

        private string  _route;
        /// <summary>
        /// 动态库目录
        /// </summary>
        [Column(FieldName = "Route", DataKey = false, Match = "", IsInsert = true)]
        public string Route
        {
            get { return  _route; }
            set {  _route = value; }
        }

        private int  _matchmode;
        /// <summary>
        /// 1:集成2：外挂医院匹配3：外挂医保匹配
        /// </summary>
        [Column(FieldName = "MatchMode", DataKey = false, Match = "", IsInsert = true)]
        public int MatchMode
        {
            get { return  _matchmode; }
            set {  _matchmode = value; }
        }

        private int  _pattypeid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PatTypeID", DataKey = false, Match = "", IsInsert = true)]
        public int PatTypeID
        {
            get { return  _pattypeid; }
            set {  _pattypeid = value; }
        }

        private int  _zymode;
        /// <summary>
        /// 1:集成2：外挂
        /// </summary>
        [Column(FieldName = "ZyMode", DataKey = false, Match = "", IsInsert = true)]
        public int ZyMode
        {
            get { return  _zymode; }
            set {  _zymode = value; }
        }

    }
}
