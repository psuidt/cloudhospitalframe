using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "MSreplication_options", EntityType = EntityType.Table, IsGB = false)]
    public class MSreplication_options:AbstractEntity
    {
        private string  _optname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "optname", DataKey = false, Match = "", IsInsert = true)]
        public string optname
        {
            get { return  _optname; }
            set {  _optname = value; }
        }

        private bool  _value;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "value", DataKey = false, Match = "", IsInsert = true)]
        public bool value
        {
            get { return  _value; }
            set {  _value = value; }
        }

        private int  _major_version;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "major_version", DataKey = false, Match = "", IsInsert = true)]
        public int major_version
        {
            get { return  _major_version; }
            set {  _major_version = value; }
        }

        private int  _minor_version;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "minor_version", DataKey = false, Match = "", IsInsert = true)]
        public int minor_version
        {
            get { return  _minor_version; }
            set {  _minor_version = value; }
        }

        private int  _revision;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "revision", DataKey = false, Match = "", IsInsert = true)]
        public int revision
        {
            get { return  _revision; }
            set {  _revision = value; }
        }

        private int  _install_failures;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "install_failures", DataKey = false, Match = "", IsInsert = true)]
        public int install_failures
        {
            get { return  _install_failures; }
            set {  _install_failures = value; }
        }

    }
}
