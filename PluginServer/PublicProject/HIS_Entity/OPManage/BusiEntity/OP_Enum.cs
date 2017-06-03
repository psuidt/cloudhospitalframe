using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.OPManage
{
    /// <summary>
    /// 门诊枚举
    /// </summary>
    public class OP_Enum
    {
        /// <summary>
        /// 门诊查询类别
        /// </summary>
        public enum MemberQueryType
        {
            账户号码 = 1,
            姓名 = 2,
            医保卡号 = 3,
            电话号码 = 4,
            身份证号 = 5,
            门诊就诊号 = 6,
            会员ID = 7,
            退费发票号 = 8
        }
        /// <summary>
        /// 门诊报表打印
        /// </summary>
        public enum PrintReport
        {
            西成药 = 2016,
            中草药 = 2017,
            新西成药 = 2028,
            新中草药 = 2027,
            输液卡 = 2021,
            医技工作量统计= 6002,
            门诊化验申请单=2022,
            门诊检查申请单 = 2023,
            门诊治疗申请单 = 2024,
            住院化验申请单 = 2012,
            住院检查申请单 = 2013,
            住院治疗申请单 = 2014,
            门诊医生费用=5000
        }

        public enum RoundType
        {
            正常四舍五入 = 0,
            逢分进位 = 1
        }

        /// <summary>
        /// 处方状态 
        /// </summary>
        public enum PresStatus
        {
            /// <summary>
            /// 
            /// </summary>
            全部 = 0,
            /// <summary>
            /// 
            /// </summary>
            未收费 = 1,
            /// <summary>
            /// 
            /// </summary>
            已收费未发药 = 2,
            /// <summary>
            /// 
            /// </summary>
            已收费已发药 = 3,
            /// <summary>
            /// 
            /// </summary>
            已收费已退药 = 4
        }

        //项目类型 1药品 2物资 3-收费项目 4组合项目 5说明性医嘱
        public enum ItemType
        {
            药品 = 1,
            物资,
            收费项目,
            组合项目,
            说明性医嘱
        }
        /// <summary>
        /// 收费结算方式
        /// </summary>
        public enum BalanceType
        {
            一次结算多张票号 = 0,
            一次结算一张票号 = 1
        }
    }


    /// <summary>
    /// 参数常量，对应数据库参数表的paraID
    /// </summary>
    public class OpConfigConstant
    {
        /// <summary>
        /// 挂号医保支付对应的医保支付Code
        /// </summary>
        public const string RegMedicareCode = "RegMedicareCode";
        /// <summary>
        /// 挂号上午开始时间
        /// </summary>
        public const string RegMoningBTime = "RegMoningBTime";
        /// <summary>
        /// 挂号下午开始时间
        /// </summary>
        public const string RegAfternoonBtime = "RegAfternoonBtime";
        /// <summary>
        /// 挂号晚上开始时间
        /// </summary>
        public const string RegNightBtime = "RegNightBtime";
        /// <summary>
        /// 医保病人对应的病人类型ID
        /// </summary>
        public const string IsMedicarePat = "IsMedicarePat";
        /// <summary>
        /// 门诊处方四舍五入方式
        /// </summary>
        public const string FeeRountType = "FeeRountType";
        /// <summary>
        /// 门诊挂号费用录入对应的费用大项目代码
        /// </summary>
        public const string RegFeeStatID = "RegFeeStatID";
        /// <summary>
        /// 门诊收费处理方式 0一张处方一次结算 1多张处方一次结算
        /// </summary>
        public const string BalanceType = "BalanceType";
        /// <summary>
        /// 门诊收费小票打印方式 0按项目分类打印 1按项目明细打印
        /// </summary>
        public const string BillPrintType = "BillPrintType";
        /// <summary>
        /// 门诊是否上了门诊医生站系统
        /// </summary>
        public const string HasOpDSystem = "HasOpDSystem";
        /// <summary>
        /// 院长报表SSRSWeb服务地址
        /// </summary>
        public const string SSRSWebAddress = "SSRSWebAddress";
        /// <summary>
        /// SSRS访问用户名
        /// </summary>
        public const string SSRSUserName = "SSRSUserName";
        /// <summary>
        ///  SSRS访问密码
        /// </summary>
        public const string SSRSPWD = "SSRSPWD";
        /// <summary>
        /// 院长驾驶舱报表地址
        /// </summary>
        public const string DeanReportPath = "DeanReportPath";
        /// <summary>
        /// 全院收益分析报表地址
        /// </summary>
        public const string RevenueReportPath = "RevenueReportPath";
        /// <summary>
        /// 全院工作量统计报表地址
        /// </summary>
        public const string WorkLoadReportPath = "WorkLoadReportPath";
        /// <summary>
        /// 医保病人收费项目中大项目代码不能重复的大项目ID
        /// </summary>
        public const string MedicalNotBalanceStatID = "MedicalNotBalanceStatID";
        /// <summary>
        /// 门诊收费Pos退费方式 0表示Pos退现金,1表示Pos退Pos
        /// </summary>
        public const string RefundPosType = "RefundPosType";
    }

    public class ChargeInfo
    {
        /// <summary>
        /// 结算号
        /// </summary>
        public int CostHeadID;
        /// <summary>
        /// 所结算的处方的费用ID
        /// </summary>
        public int[] FeeItemHeadIDs;
        /// <summary>
        /// 发票张数
        /// </summary>
        public int InvoiceCount;
        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime ChargeDate;
        /// <summary>
        /// 总金额（自付+记账+优惠）
        /// </summary>
        public decimal TotalFee;
        /// <summary>
        /// 支付方式明细
        /// </summary>
        public List<OP_CostPayMentInfo> PayInfoList;
        /// <summary>
        /// 结算框支付总金额
        /// </summary>
        public decimal PayTotalFee;
        /// <summary>
        /// 优惠总金额
        /// </summary>
        public decimal FavorableTotalFee;
        /// <summary>
        /// POS金额
        /// </summary>
        public decimal PosFee;
        /// <summary>
        /// 现金金额
        /// </summary>
        public decimal CashFee;
        public decimal RoundFee;
        public decimal ChangeFee;

    }
}
