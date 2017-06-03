using System;
using System.Data;

namespace HIS_PublicManage.Dao
{
    public interface IMemberInfoDao
    {
        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="strFieldName">查询类型</param>
        /// <param name="code">号码</param>
        /// <returns></returns>
        DataTable QueryMemberInfo(string strFieldName,string code);

        DataTable QueryMemberInfoForCardType(int cardType, string code);

        /// <summary>
        /// 获取有效帐户类型
        /// </summary>
        /// <returns></returns>
        DataTable QueryCardType();

        /// <summary>
        /// 查询积分兑换规则
        /// </summary>
        /// <param name="intCardTypeId"></param>
        /// <returns></returns>
        DataTable QueryScoreRull(int intCardTypeId);

        /// <summary>
        /// 更新帐户积分
        /// </summary>
        /// <param name="intAccountId">帐户ID</param>
        /// <param name="intNewScore">积分</param>
        /// <returns></returns>
        //保存帐户积分
        int SaveAccountScore(int intAccountId, int intNewScore);

        /// <summary>
        /// 新增一条积分明细记录
        /// </summary>
        /// <param name="intAccountId">帐户ID</param>
        /// <param name="intNewScore">积分</param>
        /// <param name="intScoreType">操作类型</param>
        /// <param name="strDocumentNo">单据号</param>
        /// <param name="intOperId">操作员</param>
        /// <returns></returns>
        int InsertScoreList(int intAccountId, int intNewScore, int intScoreType, string strDocumentNo,int intOperId);

        /// <summary>
        /// 获取卡类型
        /// </summary>
        /// <returns></returns>
        DataTable GetCardTypeList();

        /// <summary>
        /// 保存积分明细
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="score"></param>
        /// <param name="OperateDate"></param>
        /// <param name="OperateID"></param>
        /// <returns></returns>
        int UpdateAccountScore(int accountID, int score, DateTime OperateDate, int OperateID);
    }
}
