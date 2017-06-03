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
    public class PromForClass : AbstractObjectModel, IPromotion
    {
        private int _CardID;
        public int CardID
        {
            get
            {
                return _CardID;
            }

            set
            {
                _CardID = value;
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

        public decimal Calculation(decimal Amount, DataTable dtPromClass, DataTable Detail, out DataTable outdtPromClass, out DataTable outDetail)
        {
            decimal res = 0M;
            DataTable tempDt = NewDao<IPromotionProjectDao>().QueryPromotionDetail(PatientType, CostType, CardID, PromType);//获取优惠明细

            for (int j = 0; j < tempDt.Rows.Count; j++)
            {
                int PromClass = Convert.ToInt16(tempDt.Rows[j]["PromClass"]); //优惠明细项目类别ID
                int Disco = Convert.ToInt16(tempDt.Rows[j]["DiscountNumber"]); //优惠额度
                int promBase = Convert.ToInt16(tempDt.Rows[j]["PromBase"]);  //优惠基数

                decimal tempAount2 = 0M;
                //当消费总额大于优惠基数时

                    DataRow[] drTemp = dtPromClass.Select(" ClassTypeID=" + PromClass);   //
                    decimal tempAount = 0M;
                    foreach (DataRow dr in drTemp)
                    {
                        //当消费总额大于优惠基数时
                        if (Convert.ToDecimal(dr["ClassAmount"]) > promBase)
                        {
                            if (Convert.ToInt16(tempDt.Rows[j]["Prom"]) == 1)  //优惠方式为折扣方式
                            {
                                tempAount = Convert.ToDecimal(dr["ClassAmount"]) * Disco/100;
                            }
                            else
                            {
                                tempAount = Disco;
                            }
                            tempAount2 = tempAount2 + tempAount;
                            dr["PromAmount"] = tempAount;
                        }
                        else
                        {
                            dr["PromAmount"] = 0M;
                        }
                        dtPromClass.AcceptChanges();
                    }
                
                res = res + tempAount2;
            }
            outdtPromClass = dtPromClass;
            outDetail = Detail;

            return res;
        }
        public DiscountInfo Calculation(DiscountInfo discountInfo)
        {
            decimal res = 0M;
            DataTable tempDt = NewDao<IPromotionProjectDao>().QueryPromotionDetail(PatientType, CostType, CardID, PromType);//获取优惠明细

            for (int j = 0; j < tempDt.Rows.Count; j++)
            {
                int PromClass = Convert.ToInt16(tempDt.Rows[j]["PromClass"]); //优惠明细项目类别ID
                int Disco = Convert.ToInt16(tempDt.Rows[j]["DiscountNumber"]); //优惠额度
                int promBase = Convert.ToInt16(tempDt.Rows[j]["PromBase"]);  //优惠基数
                string PromName = Convert.ToString(tempDt.Rows[0]["PromName"]);   //优惠方案名称
                int PromSunID = Convert.ToInt32(tempDt.Rows[0]["PromSunID"]);  //优惠方案明细ID
                int PromID = Convert.ToInt16(tempDt.Rows[0]["PromID"]);   //优惠方案ID

                decimal tempAount2 = 0;
                //当消费总额大于优惠基数时

                    DataRow[] drTemp = discountInfo.DtClass.Select(" ClassTypeID=" + PromClass);   //
                decimal tempAount = 0;
                    foreach (DataRow dr in drTemp)
                    {
                        //当消费总额大于优惠基数时
                        if (Convert.ToDecimal(dr["ClassAmount"]) > promBase)
                        {
                            if (Convert.ToInt32(tempDt.Rows[j]["Prom"]) == 1)  //优惠方式为折扣方式
                            {
                                tempAount =Convert.ToDecimal(dr["ClassAmount"]) * Disco / 100;
                            }
                            else
                            {

                               if (Convert.ToDecimal(dr["ClassAmount"]) > Disco)  //如果金额大于优惠
                                {
                                    tempAount = Disco;
                                }
                                else
                                {
                                    tempAount = 0;
                                }

                            }
                            tempAount2 = tempAount2 + tempAount;
                            dr["PromAmount"] = tempAount;
                        }
                        else
                        {
                            dr["PromAmount"] = 0M;
                        }
                        discountInfo.DtClass.AcceptChanges();

                    ME_DiscountList DiscountList = new ME_DiscountList();
                    DiscountList.AccountID = discountInfo.AccountID;
                    DiscountList.PromID = PromID;
                    DiscountList.SettlementNO = discountInfo.SettlementNO;
                    DiscountList.PromName = PromName;
                    DiscountList.PromSunID = PromSunID;
                    DiscountList.CostTypeID = CostType;
                    DiscountList.CardTypeID = CardID;   //帐户表ID
                    DiscountList.PatientType = PatientType; //病人类型门诊或住院
                    DiscountList.PromTypeID = PromType;    //优惠类型
                    DiscountList.PromBase = promBase;
                    DiscountList.PromClass = PromClass;
                    DiscountList.Prom = 2;                //
                    DiscountList.IsValid = 0;
                    DiscountList.AccID = discountInfo.AccID;
                    DiscountList.DiscountNumber = Disco;
                    DiscountList.Amount = discountInfo.Amount;
                    DiscountList.DiscountTotal = tempAount;
                    DiscountList.OperateDate = System.DateTime.Now;
                    DiscountList.OperateID = discountInfo.OperateID;
                    discountInfo.DiscountList.Add(DiscountList);
                }
                res = res + tempAount2;
            }
            discountInfo.DisAmount = res;
            return discountInfo;
        }
    }
}
