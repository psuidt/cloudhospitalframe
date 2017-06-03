using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_PublicManage.Dao
{
    public class SqlMemberInfoDao:AbstractDao,IMemberInfoDao
    {
        public DataTable QueryMemberInfo(string strFieldName, string code)
        {

            string sql = @" select * from V_ME_AccountInfo where MemberUseFlag=1 
                                and AccountUseFlag=1 and " + strFieldName+"='"+code+"'";
            return oleDb.GetDataTable(sql);
        }

        public DataTable QueryMemberInfoForCardType(int cardTypeID, string code)
        {
            string sql = @" select * from V_ME_AccountInfo where MemberUseFlag=1 
                                and AccountUseFlag=1 and CardNO='" + code + "' and CardTypeID="+ cardTypeID;
            return oleDb.GetDataTable(sql);
        }


        /// <summary>
        /// 获取帐户类型
        /// </summary>
        /// <returns></returns>
        public DataTable QueryCardType()
        {
            string sql = @" select CardTypeID,CardTypeName,CardInterface from ME_CardTypeList where UseFalg=1 ";
            return oleDb.GetDataTable(sql);     
        }
        /// <summary>
        /// 获取帐户类型积分转换规则
        /// </summary>
        /// <param name="intCardTypeId"></param>
        /// <returns></returns>
        public DataTable QueryScoreRull(int intCardTypeId)
        {
            string sql = @" select * from ME_ConvertPoints where UseFlag=1 and CardTypeID=" + intCardTypeId.ToString();
            return oleDb.GetDataTable(sql);
        }

        public int SaveAccountScore(int intAccountId, int intNewScore)
        {
            string sql = @" update ME_MemberAccount set Score="+intNewScore+ " where AccountID="+ intAccountId;
            return oleDb.DoCommand(sql);
        }

        public int InsertScoreList(int intAccountId, int intNewScore, int intScoreType, string strDocumentNo, int intOperId)
        {
            string sql = @" insert into ME_ScoreList Values(" + intAccountId + ',' + intScoreType + ",'" +
                            strDocumentNo + "',"
                            + intNewScore + ",'" + DateTime.Now.ToString() + "'," + intOperId + "," + oleDb.WorkId + ")";
            return oleDb.InsertRecord(sql);
        }

       public DataTable GetCardTypeList()
        {
            string sql = @" SELECT CardTypeID,CardTypeName,CardInterface,WorkID from ME_CardTypeList where useflag=1  " ;
            return oleDb.GetDataTable(sql);
        }

        /// <summary>
        /// 保存积分明细
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="score"></param>
        /// <param name="OperateDate"></param>
        /// <param name="OperateID"></param>
        /// <returns></returns>
        public int UpdateAccountScore(int accountID, int score, DateTime OperateDate, int OperateID)
        {
            string sql = @" update ME_MemberAccount set score=  " + score + ",OperateDate='" + OperateDate.ToString()
                        + "',OperateID=" + OperateID + "  where AccountID=" + accountID;
            return oleDb.DoCommand(sql);
        }
    }
}

