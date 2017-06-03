using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;
using HIS_PublicManage.ObjectModel.Promotion;
using HIS_Entity.MemberManage;
using HIS_PublicManage.Dao;

namespace HIS_PublicManage.ObjectModel
{
    public class PromotionManagement: AbstractObjectModel
    {

        
        private enum PromType:int
        {
            总额打折=1,
            按费用类别打折=2,
            按明细项目打折=3   
        }
        /// <summary>
        /// 优惠计算
        /// </summary>
        /// <param name="PatientType">病人类型</param>
        /// <param name="CostType">费用类型</param>
        /// <param name="CardID">帐户ID</param>
        /// <param name="Amount">消费金额</param>
        /// <param name="dtDetail">消费明细表</param>
        /// <param name="dtPromClass">消费分类表</param>
        /// <param name="outdtPromClass">带优惠金额的消费分类表</param>
        /// <param name="outDetail">带优惠金额的消费明细表</param>
        /// <returns>总优惠金额</returns>
        public decimal CalculationPromotion(int PatientType, int CostType, int CardID, decimal Amount, DataTable dtDetail, DataTable dtPromClass, out DataTable outdtPromClass, out DataTable outDetail)
        {
            decimal decAmount = 0M;
            decimal res = 0M;
            outdtPromClass = null;
            outDetail = null;
             
            foreach (int i in Enum.GetValues(typeof(PromType)))  //循环计算
            {
                int PromType = i;
                  res =
                NewObject<PromotionFactory>()
                    .MakePromotionType(PatientType, CostType, CardID, Amount, dtDetail, dtPromClass, PromType, out  outdtPromClass, out outDetail);
                decAmount = decAmount + res;
            } 
            return decAmount;
        }

        public DiscountInfo CalculationPromotion(DiscountInfo discountInfo)
        {
            discountInfo.DiscountList = new List<ME_DiscountList>();
            decimal decAmount = 0M;
            decimal res = 0M;
            DiscountInfo info = new DiscountInfo();
                        
            //foreach (int i in Enum.GetValues(typeof(PromType)))  //循环计算
            //{
            //    int PromType = i;
            //    info.DisAmount = 0;
            //     info =NewObject<PromotionFactory>().MakePromotionType(discountInfo, PromType);
            //    decAmount = decAmount + info.DisAmount;
            //}
            //类型优惠
            info.DisAmount = 0;
            info = NewObject<PromotionFactory>().MakePromotionType(discountInfo, 2);
            decAmount = decAmount + info.DisAmount;
            //明细优惠
            info.DisAmount = 0;
            info = NewObject<PromotionFactory>().MakePromotionType(discountInfo, 3);
            decAmount = decAmount + info.DisAmount;
            //总额优惠
            info.DisAmount = 0;
            discountInfo.Amount = discountInfo.Amount - decAmount;   //在总额中减去上两类优惠金后再计算总额优惠
            info = NewObject<PromotionFactory>().MakePromotionType(discountInfo, 1);
            decAmount = decAmount + info.DisAmount;
            info.DisAmount = decAmount;
            if (discountInfo.IsSave==true)
            {
                SaveDiscountInfo(discountInfo.DiscountList);
            }
            return info;
        }
        
        /// <summary>
        /// 保存优惠明细
        /// </summary>
        /// <param name="InfoList"></param>
        /// <returns></returns>
        public int SaveDiscountInfo(List<ME_DiscountList> InfoList)
        {
            int res=0;
            foreach (ME_DiscountList Info in InfoList)
            {
                this.BindDb(Info);
                res=Info.save();
            }
            return res;
        }

        /// <summary>
        /// 优惠明细生效
        /// </summary>
        /// <param name="accID">结算ID</param>
        /// <param name="timeFlag">住院为时间戳，门诊为结算ID</param>
        /// <returns></returns>
        public int UpdateDiscountInfo(int accID,int timeFlag)
        {
            return NewDao<IPromotionProjectDao>().UpdateDiscountInfo(accID,timeFlag);
        }


    }
}
