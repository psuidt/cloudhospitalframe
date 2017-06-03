using System.Collections.Generic;
using System.Data;

namespace HIS_PublicManage.Dao
{
    /// <summary>
    /// 药房公共接口
    /// </summary>
    public interface IDrugStoreInfoDao
    {
        #region 门诊收费接口
        /// <summary>
        /// 药房公共接口
        /// <param name="code">发票号或会员卡号</param>
        /// <param name="execDeptID">执行科室Id</param>
        /// <param name="distributeFlag">发药标志</param>
        /// <returns>结算数据集</returns>
        /// </summary>     
        DataTable QueryPatientInfo(string code, int execDeptID, int distributeFlag);

        /// <summary>
        /// 获取收费主表
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="deptId">科室Id</param>
        /// <returns>收费头表数据集</returns>
        DataTable GetFeeItemHead(string invoiceNO, int deptId);

        /// <summary>
        /// 获取费用明细
        /// </summary>
        /// <param name="feeItemHeadID">费用主表Id</param>
        /// <returns>费用明细</returns>
        DataTable GetFeeItemDetail(int feeItemHeadId);

        /// <summary>
        /// 获取执行单信息
        /// </summary>
        DataTable GetExecuteBills();

        /// <summary>
        /// 获取费用明细
        /// </summary>
        /// <param name="feeItemHeadIds">多个处方头ID字符串</param>
        /// <returns>费用明细</returns>
        DataTable GetFeeItemDetail(string feeItemHeadIds);

        /// <summary>
        /// 取得退药明细
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>退药明细</returns>
        DataTable GetRefundDetail(Dictionary<string, string> condition);

        /// <summary>
        /// 退费消息表中是否存在
        /// </summary>
        /// <param name="invoiceNo">发票号</param>
        /// <returns></returns>
        bool HasRefund(string invoiceNo);
        #endregion

        #region 药房药库公共方法
        /// <summary>
        /// 判断库房是否处于盘点状态
        /// </summary>
        /// <param name="deptId">库房ID</param>
        /// <param name="deptType">药剂科室类型0药房1药库</param>
        /// <returns>返回True是系统正在盘点，false正常运营</returns>
        bool IsCheckStatus(int deptId, int deptType);
        #endregion

        #region 药品有效库存判断，有效库存操作
        /// <summary>
        /// 通过药品ID和科室获取药品实时库存
        /// </summary>
        /// <param name="drugID">药品ID</param>
        /// <param name="DeptID">药房ID</param>
        /// <returns></returns>
        decimal GetStorage(int drugID, int DeptID);
        /// <summary>
        /// 通过药品ID，药房ID，变化数量改变虚拟库存数量
        /// </summary>
        /// <param name="drugID">药品ID</param>
        /// <param name="DeptID">科室ID</param>
        /// <param name="updateAmount">变化数量(减库存传负数，加库存传正数)</param>
        /// <returns></returns>
        bool UpdateStorage(int drugID, int DeptID, decimal updateAmount);
        #endregion


        #region 住院统领发药接口
        /// <summary>
        /// 取得统领单头表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>统领头表</returns>
        DataTable GetIPDrugBillHead(Dictionary<string, string> condition);
        /// <summary>
        /// 取得统领单明细表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>统领明细表</returns>
        DataTable GetIPDrugBillDetail(Dictionary<string, string> condition);

        /// <summary>
        /// 取得已发药表头
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        DataTable GetDispIPBillHead(Dictionary<string, string> condition);


        /// <summary>
        /// 取得统领单明细表-打印
        /// </summary>
        /// <param name="iDispHeadID">头Id</param>
        DataTable GetIPDrugBillDetailPrint(int iDispHeadID);
        #endregion
    }
}
