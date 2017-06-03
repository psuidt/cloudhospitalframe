using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_PresPrintRecord", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_PresPrintRecord:AbstractEntity
    {
        private long  _id;
        /// <summary>
        /// ID
        /// </summary>
        [Column(FieldName = "ID", DataKey = true, Match = "", IsInsert = false)]
        public long ID
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private long  _presdetailid;
        /// <summary>
        /// 处方明细ID
        /// </summary>
        [Column(FieldName = "PresDetailID", DataKey = false, Match = "", IsInsert = true)]
        public long PresDetailID
        {
            get { return  _presdetailid; }
            set {  _presdetailid = value; }
        }

        private int  _printempid;
        /// <summary>
        /// 打印人ID
        /// </summary>
        [Column(FieldName = "PrintEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int PrintEmpID
        {
            get { return  _printempid; }
            set {  _printempid = value; }
        }

        private DateTime  _printdate;
        /// <summary>
        /// 打印时间
        /// </summary>
        [Column(FieldName = "PrintDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime PrintDate
        {
            get { return  _printdate; }
            set {  _printdate = value; }
        }

        private int  _printstatus;
        /// <summary>
        /// 打印状态
        /// </summary>
        [Column(FieldName = "PrintStatus", DataKey = false, Match = "", IsInsert = true)]
        public int PrintStatus
        {
            get { return  _printstatus; }
            set {  _printstatus = value; }
        }

    }
}
