using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.ClinicManage
{
    [Serializable]
    [Table(TableName = "OPD_OMRTmpDetail", EntityType = EntityType.Table, IsGB = false)]
    public class OPD_OMRTmpDetail:AbstractEntity
    {
        private int  _omrtmpdetailid;
        /// <summary>
        /// 模板明细表ID
        /// </summary>
        [Column(FieldName = "OMRTmpDetailID", DataKey = true, Match = "", IsInsert = false)]
        public int OMRTmpDetailID
        {
            get { return  _omrtmpdetailid; }
            set {  _omrtmpdetailid = value; }
        }

        private int  _omrtmpheadid;
        /// <summary>
        /// 模板头ID
        /// </summary>
        [Column(FieldName = "OMRTmpHeadID", DataKey = false, Match = "", IsInsert = true)]
        public int OMRTmpHeadID
        {
            get { return  _omrtmpheadid; }
            set {  _omrtmpheadid = value; }
        }

        private string  _symptoms;
        /// <summary>
        /// 主诉
        /// </summary>
        [Column(FieldName = "Symptoms", DataKey = false, Match = "", IsInsert = true)]
        public string Symptoms
        {
            get { return  _symptoms; }
            set {  _symptoms = value; }
        }

        private string  _sicknesshistory;
        /// <summary>
        /// 病史
        /// </summary>
        [Column(FieldName = "SicknessHistory", DataKey = false, Match = "", IsInsert = true)]
        public string SicknessHistory
        {
            get { return  _sicknesshistory; }
            set {  _sicknesshistory = value; }
        }

        private string  _physicalexam;
        /// <summary>
        /// 体查
        /// </summary>
        [Column(FieldName = "PhysicalExam", DataKey = false, Match = "", IsInsert = true)]
        public string PhysicalExam
        {
            get { return  _physicalexam; }
            set {  _physicalexam = value; }
        }

        private string  _docadvise;
        /// <summary>
        /// 医生建议
        /// </summary>
        [Column(FieldName = "DocAdvise", DataKey = false, Match = "", IsInsert = true)]
        public string DocAdvise
        {
            get { return  _docadvise; }
            set {  _docadvise = value; }
        }

        private string  _auxiliaryexam;
        /// <summary>
        /// 辅助检查
        /// </summary>
        [Column(FieldName = "AuxiliaryExam", DataKey = false, Match = "", IsInsert = true)]
        public string AuxiliaryExam
        {
            get { return  _auxiliaryexam; }
            set {  _auxiliaryexam = value; }
        }

        private string  _remark;
        /// <summary>
        /// 备注
        /// </summary>
        [Column(FieldName = "Remark", DataKey = false, Match = "", IsInsert = true)]
        public string Remark
        {
            get { return  _remark; }
            set {  _remark = value; }
        }

    }
}
