using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPN_PresAstResult", EntityType = EntityType.Table, IsGB = false)]
    public class OPN_PresAstResult:AbstractEntity
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

        private int  _astresult;
        /// <summary>
        /// 皮试结果   0-阴 1-阳
        /// </summary>
        [Column(FieldName = "AstResult", DataKey = false, Match = "", IsInsert = true)]
        public int AstResult
        {
            get { return  _astresult; }
            set {  _astresult = value; }
        }

    }
}
