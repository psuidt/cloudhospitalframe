using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_PublicManage.Dao
{
    public class SqlPromotionProject: AbstractDao, IPromotionProjectDao
    {


        /// <summary>
        /// 获取有效的优惠方案
        /// </summary>
        /// <param name="PatientType"></param>
        /// <param name="CostType"></param>
        /// <param name="CardID">帐户ID</param>
        /// <param name="PromType"></param>
        /// <returns></returns>
        public DataTable QueryPromotionDetail(int PatientType, int CostType, int CardID, int PromType)
        {
            string PromTime = System.DateTime.Now.ToString();

            string sqlAccountID = @" select RegisterWork,CardTypeID from V_ME_AccountInfo where AccountID=" + CardID;
            DataTable dt = oleDb.GetDataTable(sqlAccountID);

            string CardType = Convert.ToString(dt.Rows[0]["CardTypeID"]);
            string workID= Convert.ToString(dt.Rows[0]["RegisterWork"]);

            string Sql = @" select * from V_ME_PromotionProject where CardTypeID=" + CardType +
                         " and PatientType=" + PatientType.ToString() +
                         " AND PromTypeID=" + PromType.ToString() + " and CostType=" + CostType +" AND workID="+ workID
                         + " and ( StartDate<='"+ PromTime + "' AND EndDate>='" + PromTime + "')";
            return oleDb.GetDataTable(Sql);
        }

        /// <summary>
        /// 获取帐户类型ID
        /// </summary>
        /// <param name="CardID"></param>
        /// <returns></returns>
        public DataTable GetCardTypeID(int CardID)
        {
            string sql = @" select CardTypeID,Score from ME_MemberAccount where AccountID=" + CardID;
            return oleDb.GetDataTable(sql);
        }

        /// <summary>
        /// 优惠明细生效
        /// </summary>
        /// <param name="accID"></param>
        /// <returns></returns>
        public int UpdateDiscountInfo(int accID,int timeFlag)
        {
            string sql = @" update ME_DiscountList set IsValid=1, AccID=" + accID + " where AccID=" + timeFlag;
            return oleDb.DoCommand(sql);
        }
    }
}
