using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;
using HIS_PublicManage.Dao;
using HIS_Entity.MemberManage;

namespace HIS_PublicManage.ObjectModel.Promotion
{
    public class PromForAmount : AbstractObjectModel,IPromotion
    {
        private int __CardID;
        public int CardID
        {
            get
            {
                return __CardID;
            }

            set
            {
                __CardID = value;
            }
        }

        private int _CostType;
        public int CostType
        {
            get
            {
                return _CostType;
            }

            set
            {
                _CostType = value;
            }
        }

        private int _PatientType;
        public int PatientType
        {
            get
            {
                return _PatientType;
            }

            set
            {
                _PatientType = value;
            }
        }

        public int _PromType;
        public int PromType
        {
            get
            {
                return _PromType;
            }

            set
            {
                _PromType = value;
            }
        }

        public decimal Calculation(decimal Amount, DataTable dtPromClass, DataTable Detail,  out DataTable outdtPromClass, out DataTable outDetail)
        {
            decimal res = 0M;
            DataTable tempDt=NewDao<IPromotionProjectDao>().QueryPromotionDetail(PatientType, CostType, CardID, PromType);
            if (tempDt.Rows.Count > 0)
            {
                int PromBase = Convert.ToInt16(tempDt.Rows[0]["PromBase"]); //优惠基数
                int Disco = Convert.ToInt16(tempDt.Rows[0]["DiscountNumber"]); //优惠数字

                //当消费总额大于优惠基数时
                if (Amount > PromBase)
                {
                    if (Convert.ToInt16(tempDt.Rows[0]["Prom"]) == 1)  //优惠方式为折扣方式
                    {
                        res = Amount*Disco/100;
                    }
                    else
                    {
                        res = Disco;
                    }
                }
            }
            outdtPromClass = dtPromClass;
            outDetail = Detail;
            
            return res;
        }
        public DiscountInfo Calculation(DiscountInfo discountInfo)
        {
            discountInfo.DisAmount = 0M;
            DataTable tempDt = NewDao<IPromotionProjectDao>().QueryPromotionDetail(PatientType, CostType, CardID, PromType);
            if (tempDt.Rows.Count > 0)
            {
                int PromBase = Convert.ToInt16(tempDt.Rows[0]["PromBase"]); //优惠基数
                int Disco = Convert.ToInt16(tempDt.Rows[0]["DiscountNumber"]); //优惠数字
                int PromID = Convert.ToInt16(tempDt.Rows[0]["PromID"]);   //优惠方案ID
                string PromName = Convert.ToString(tempDt.Rows[0]["PromName"]);   //优惠方案名称
                int PromSunID = Convert.ToInt32(tempDt.Rows[0]["PromSunID"]);  //优惠方案明细ID

                //当消费总额大于优惠基数时
                if (discountInfo.Amount > PromBase)
                {
                    if (Convert.ToInt16(tempDt.Rows[0]["Prom"]) == 1)  //优惠方式为折扣方式
                    {
                        discountInfo.DisAmount = discountInfo.Amount * Disco / 100;
                    }
                    else
                    {
                        if (discountInfo.Amount > Disco)  //如果金额大于优惠
                        {
                            discountInfo.DisAmount = Disco;
                        } 
                        else
                        {
                            discountInfo.DisAmount = 0;
                        }       
                    }
                }
                ME_DiscountList DiscountList = new ME_DiscountList();

                DiscountList.PromID = PromID;
                DiscountList.AccountID = discountInfo.AccountID;
                DiscountList.SettlementNO = discountInfo.SettlementNO;
                DiscountList.PromName = PromName;
                DiscountList.PromSunID = PromSunID;
                DiscountList.CostTypeID = CostType;
                DiscountList.CardTypeID = CardID;   //帐户表ID
                DiscountList.PatientType = PatientType; //病人类型门诊或住院
                DiscountList.PromTypeID = PromType;    //优惠类型
                DiscountList.PromBase = PromBase;
                DiscountList.Prom = 1;                //
                DiscountList.IsValid = 0;
                DiscountList.AccID = discountInfo.AccID;
                DiscountList.DiscountNumber = Disco;
                DiscountList.Amount = discountInfo.Amount;
                DiscountList.DiscountTotal = discountInfo.DisAmount;
                DiscountList.OperateDate = System.DateTime.Now;
                DiscountList.OperateID = discountInfo.OperateID;
                discountInfo.DiscountList.Add(DiscountList);
            }
             return discountInfo;
        }
    }
}
