using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPN_PresExecRecord", EntityType = EntityType.Table, IsGB = false)]
    public class OPN_PresExecRecord:AbstractEntity
    {
        private long  _presexecrecord;
        /// <summary>
        /// 处方执行记录ID
        /// </summary>
        [Column(FieldName = "PresExecRecord", DataKey = true, Match = "", IsInsert = false)]
        public long PresExecRecord
        {
            get { return  _presexecrecord; }
            set {  _presexecrecord = value; }
        }

        private long  _presheadid;
        /// <summary>
        /// 处方头ID
        /// </summary>
        [Column(FieldName = "PresHeadID", DataKey = false, Match = "", IsInsert = true)]
        public long PresHeadID
        {
            get { return  _presheadid; }
            set {  _presheadid = value; }
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

        private int  _execempid;
        /// <summary>
        /// 执行人ID
        /// </summary>
        [Column(FieldName = "ExecEmpID", DataKey = false, Match = "", IsInsert = true)]
        public int ExecEmpID
        {
            get { return  _execempid; }
            set {  _execempid = value; }
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

        private DateTime  _execdate;
        /// <summary>
        /// 执行日期
        /// </summary>
        [Column(FieldName = "ExecDate", DataKey = false, Match = "", IsInsert = true)]
        public DateTime ExecDate
        {
            get { return  _execdate; }
            set {  _execdate = value; }
        }

    }
}
