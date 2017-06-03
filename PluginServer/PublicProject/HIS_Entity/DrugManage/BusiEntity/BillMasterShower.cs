using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.DrugManage
{
    /// <summary>
    /// 业务类型实体
    /// </summary>
    public class BillMasterShower
    {
        public BillMasterShower()
        {
        }
        private string billNo;

        /// <summary>
        /// 单据号
        /// </summary>
        public string BillNo
        {
            get { return billNo; }
            set { billNo = value; }
        }

        private string opType;

        /// <summary>
        /// 业务类型
        /// </summary>
        public string OpType
        {
            get { return opType; }
            set { opType = value; }
        }

        private string relationPeople;

        /// <summary>
        /// 往来人员
        /// </summary>
        public string RelationPeople
        {
            get { return relationPeople; }
            set { relationPeople = value; }
        }
        private string relationUnit;

        /// <summary>
        /// 往来单位
        /// </summary>
        public string RelationUnit
        {
            get { return relationUnit; }
            set { relationUnit = value; }
        }
        private string relationPeopleNo;

        /// <summary>
        /// 往来人员编码
        /// </summary>
        public string RelationPeopleNo
        {
            get { return relationPeopleNo; }
            set { relationPeopleNo = value; }
        }
        private string regPeople;

        /// <summary>
        /// 操作人员
        /// </summary>
        public string RegPeople
        {
            get { return regPeople; }
            set { regPeople = value; }
        }
        private DateTime regTime;

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime RegTime
        {
            get { return regTime; }
            set { regTime = value; }
        }
        private DateTime auditTime;

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime AuditTime
        {
            get { return auditTime; }
            set { auditTime = value; }
        }

        private decimal retailFee;
        /// <summary>
        /// 零售金额
        /// </summary>
        public decimal RetailFee
        {
            get { return retailFee; }
            set { retailFee = value; }
        }
        private decimal stockFee;

        /// <summary>
        /// 进货金额
        /// </summary>
        public decimal StockFee
        {
            get { return stockFee; }
            set { stockFee = value; }
        }       

        private string remark;

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
