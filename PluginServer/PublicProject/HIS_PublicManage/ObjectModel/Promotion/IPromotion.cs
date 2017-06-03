using HIS_Entity.MemberManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel.Promotion
{
    interface IPromotion
    {
        /// <summary>
        /// 优惠类型
        /// </summary>
        int PromType { get; set; }
        /// <summary>
        /// 病人类型
        /// </summary>
        int PatientType { get; set; }
        /// <summary>
        /// 帐户ID
        /// </summary>
        int CardID { get; set; }
        /// <summary>
        /// 病人费用类
        /// </summary>
        int CostType { get; set; }

        decimal Calculation(decimal Amount, DataTable  Detail, DataTable dtPromClass,out DataTable outdtPromClass, out DataTable outDetail);
        DiscountInfo Calculation(DiscountInfo discountInfo);

    }
}
