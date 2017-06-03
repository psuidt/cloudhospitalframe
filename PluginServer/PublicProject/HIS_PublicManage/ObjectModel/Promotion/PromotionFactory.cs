using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using HIS_Entity.MemberManage;

namespace HIS_PublicManage.ObjectModel.Promotion
{
    public class PromotionFactory: AbstractObjectModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PatientType">病人类型(1.门诊,2.住院)</param>
        /// <param name="CostType">病人收费类型</param>
        /// <param name="CardID">病人会员帐户ID</param>
        /// <param name="Amount">消费总金额</param>
        /// <param name="Detail">优惠明细"项目明细ID|金额|优惠金额"</param>
        /// <returns></returns>
        public decimal MakePromotionType(int PatientType,int CostType,int CardID, decimal Amount,DataTable Detail, DataTable dtPromClass,int PromType,out DataTable outdtPromClass, out DataTable outDetail)
        {
            IPromotion MyProm = null;
            try
            {
                Type type = Type.GetType(ConvertToClass(PromType), true);
                MyProm = (IPromotion) Activator.CreateInstance(type);
                this.BindDb(MyProm);
                MyProm.PatientType = PatientType;
                MyProm.CardID = CardID;
                MyProm.CostType = CostType;
                MyProm.PromType = PromType;
                return MyProm.Calculation(Amount, dtPromClass,Detail, out outdtPromClass, out outDetail);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
                outdtPromClass = null;
                outDetail = null;
                return -1M;
            }
        }

        public DiscountInfo MakePromotionType(DiscountInfo discountInfo,int PromType)
        {
            IPromotion MyProm = null;
            try
            {
                Type type = Type.GetType(ConvertToClass(PromType), true);
                MyProm = (IPromotion)Activator.CreateInstance(type);
                this.BindDb(MyProm);
                MyProm.PatientType = discountInfo.PatientType;
                MyProm.CardID = discountInfo.AccountID;
                MyProm.CostType = discountInfo.CostType;
                MyProm.PromType = PromType;
                return MyProm.Calculation(discountInfo);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
                return discountInfo;
            }
        }
        /// <summary>
        /// 优惠类型转换
        /// </summary>
        /// <param name="PromType"></param>
        /// <returns></returns>
        private string ConvertToClass(int PromType)
        {
            string ClassName = "";
            switch (PromType)
            {
                case 1:
                    ClassName = "HIS_PublicManage.ObjectModel.Promotion.PromForAmount";
                    break;
                case 2:
                    ClassName = "HIS_PublicManage.ObjectModel.Promotion.PromForClass";
                    break;
                case 3:
                    ClassName = "HIS_PublicManage.ObjectModel.Promotion.PromForDetail";
                    break;
            }

            return ClassName;
        }

    }
}