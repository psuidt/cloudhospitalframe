using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS_PublicManage.Dao;
using HIS_Entity.MemberManage;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;

namespace HIS_PublicManage.ObjectModel
{
    public class MemberManagement:EFWCoreLib.CoreFrame.Business.AbstractObjectModel
    {
        /// <summary>
        /// 根椐指定号码类型与号码返回会员与对应的帐户信息
        /// </summary>
        /// <param name="codeType">号码类型</param>
        /// <param name="code">号码</param>
        /// <returns></returns>
        public DataTable QueryMemberInfo(int codeType, string code)
        {
            string strFieldName= "";
            switch (codeType)
            {
                case 1:    //帐户号码
                    strFieldName = "CardNO";
                    break;
                case 2:    //身份证号
                    strFieldName = "IDNumber";
                    break;
                case 3:    //医保卡号
                    strFieldName = "MedicareCard" ;
                    break;
                case 4:    //手机号码
                    strFieldName = "Mobile";
                    break;
            }
            return NewDao<IMemberInfoDao>().QueryMemberInfo(strFieldName, code);
        }
        /// <summary>
        /// 根椐帐户类型与帐户号码获取会员信息
        /// </summary>
        /// <param name="cardTypeID">帐户类型</param>
        /// <param name="code">帐户号码</param>
        /// <returns></returns>
        public DataTable QueryMemberInfoForCardType(int cardTypeID, string code)
        {
            return NewDao<IMemberInfoDao>().QueryMemberInfoForCardType(cardTypeID, code);
        }

        /// <summary>
        /// 返回消费积分
        /// </summary>
        /// <param name="CodeType">帐户类型</param>
        /// <param name="Code">帐户号码</param>
        /// <param name="Amount">消费金额</param>
        /// <returns>如果帐户处于失效状态则积分返回0</returns>
        private int ConvertToScore(int intCardType, Decimal cash)
        {

            DataTable dtTemp= NewDao<IMemberInfoDao>().QueryScoreRull(intCardType);

            if (dtTemp.Rows.Count > 0)
            {
                int intCash = Convert.ToInt32(dtTemp.Rows[0]["Cash"]);
                int intScore = Convert.ToInt32(dtTemp.Rows[0]["Score"]);
                 
                //本次积分=本次消费金额/金额转换系数*积分比例
                return  Convert.ToInt32(Math.Floor(cash/intCash))*intScore;      

            }
            else  //没有有效积分兑换规则
            {
                return 0;
            } 
        }

        /// <summary>
        /// 返回操作员所属机构帐户类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetCardTypeList()
        {
            return NewDao<IMemberInfoDao>().GetCardTypeList();
        }

        /// <summary>
        /// 保存消费是积分明细
        /// </summary>
        /// <param name="accountID">帐户ID</param>
        /// <param name="amount">消费金额</param>
        /// <param name="scoreType">消费类型1、帐户充值，2、门诊消费，3、住院消费，4、积分清零，5、物品兑换</param>
        /// <param name="DocumentNo">消费单据号</param>
        /// <returns></returns>
        public int SaveAddScoreList(int accountID,decimal amount,int scoreType,string DocumentNo,int OperateID)
        {
            DataTable dt=NewDao<IPromotionProjectDao>().GetCardTypeID(accountID);
            int intCardType = Convert.ToInt32(dt.Rows[0]["CardTypeID"]);
            int oldScore =Convert.ToInt32(dt.Rows[0]["Score"]);

            ME_ScoreList scoreList = new ME_ScoreList();
            this.BindDb(scoreList);
            scoreList.AccountID = accountID;
            scoreList.ScoreType = scoreType;
            scoreList.DocumentNo = DocumentNo;
            int score = ConvertToScore(intCardType, amount);
            scoreList.Score = score;
            scoreList.OperateDate = DateTime.Now;
            scoreList.OperateID = OperateID;


            scoreList.save();
            return NewDao<IMemberInfoDao>().UpdateAccountScore(scoreList.AccountID, oldScore+scoreList.Score, scoreList.OperateDate, scoreList.OperateID);
        }
    }

}
