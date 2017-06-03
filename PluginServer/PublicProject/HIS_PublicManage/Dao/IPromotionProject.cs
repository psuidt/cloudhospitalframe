using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.Dao
{
    interface IPromotionProjectDao
    {
        DataTable QueryPromotionDetail(int PatientType, int CostType, int CardType, int PromType);

        DataTable GetCardTypeID(int CardID);
        int UpdateDiscountInfo(int accID,int timeFlag);
    }
}
