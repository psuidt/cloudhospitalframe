using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseWorkers", EntityType = EntityType.Table, IsGB = true)]
    public class BaseWorkers : AbstractEntity
    {
        /// <summary>
        /// WorkId
        /// </summary>
        [Column(FieldName = "WorkId", DataKey = true, Match = "", IsInsert = false)]
        public int WorkId { get; set; }

        private string _workno;
        /// <summary>
        /// 机构编码
        /// </summary>
        [Column(FieldName = "WorkNo", DataKey = false, Match = "", IsInsert = true)]
        public string WorkNo
        {
            get { return _workno; }
            set { _workno = value; }
        }

        private string _workname;
        /// <summary>
        /// 工作组名称
        /// </summary>
        [Column(FieldName = "WorkName", DataKey = false, Match = "", IsInsert = true)]
        public string WorkName
        {
            get { return _workname; }
            set { _workname = value; }
        }

        private string _memo;
        /// <summary>
        /// 工作组备注
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false, Match = "", IsInsert = true)]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        private string _regkey;
        /// <summary>
        /// 注册码
        /// </summary>
        [Column(FieldName = "RegKey", DataKey = false, Match = "", IsInsert = true)]
        public string RegKey
        {
            get { return _regkey; }
            set { _regkey = value; }
        }

        private string _editioncode;
        /// <summary>
        /// 版本号
        /// </summary>
        [Column(FieldName = "EditionCode", DataKey = false, Match = "", IsInsert = true)]
        public string EditionCode
        {
            get { return _editioncode; }
            set { _editioncode = value; }
        }

        private int _delflag;
        /// <summary>
        /// 启用、停用标志
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return _delflag; }
            set { _delflag = value; }
        }

        public string StrDelFlag
        {
            get
            {
                switch (DelFlag)
                {
                    case 0: return "已启用";
                    case 1: return "已停用";
                    default: break;
                }
                return "已停用";
            }
            set
            {
                //nothing 
            }

        }
    }
}
