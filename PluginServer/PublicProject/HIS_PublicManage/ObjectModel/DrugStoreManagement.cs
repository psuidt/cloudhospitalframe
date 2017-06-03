using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS_PublicManage.Dao;
using HIS_Entity.MemberManage;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_PublicManage.ObjectModel
{
    public class DrugStoreManagement : AbstractObjectModel
    {
        #region 药房发药调用门诊收费接口
        /// <summary>
        /// 药房公共接口
        /// <param name="code">发票号或会员卡号</param>
        /// <param name="execDeptID">执行科室Id</param>
        /// <param name="distributeFlag">发药标志1发药0未发药</param>
        /// <returns>结算数据集</returns>
        /// </summary>     
        public DataTable QueryPatientInfo(string code, int execDeptID, int distributeFlag)
        {
            return NewDao<IDrugStoreInfoDao>().QueryPatientInfo(code, execDeptID, distributeFlag);
        }

        /// <summary>
        /// 获取收费主表
        /// </summary>
        /// <param name="costHeadId">发票号</param>
        /// <param name="deptId">科室Id</param>
        /// <returns>收费头表数据集</returns>
        public DataTable GetFeeItemHead(string invoiceNO, int deptId)
        {
            return NewDao<IDrugStoreInfoDao>().GetFeeItemHead(invoiceNO, deptId);
        }

        /// <summary>
        /// 获取费用明细
        /// </summary>
        /// <param name="feeItemHeadID">费用主表Id</param>
        /// <returns>费用明细</returns>
        public DataTable GetFeeItemDetail(int feeItemHeadId)
        {
            return NewDao<IDrugStoreInfoDao>().GetFeeItemDetail(feeItemHeadId);
        }

        /// <summary>
        /// 获取执行单配置信息
        /// </summary>
        public DataTable GetExecuteBills()
        {
            return NewDao<IDrugStoreInfoDao>().GetExecuteBills();
        }

        /// <summary>
        /// 获取费用明细
        /// </summary>
        /// <param name="feeItemHeadIds">多个处方头ID字符串'(1,2,3)'</param>
        /// <returns>费用明细</returns>
        public DataTable GetFeeItemDetail(string feeItemHeadIds)
        {
            return NewDao<IDrugStoreInfoDao>().GetFeeItemDetail(feeItemHeadIds);
        }

        /// <summary>
        /// 退费消息表中是否存在
        /// </summary>
        /// <param name="invoiceNo">发票号</param>
        /// <returns></returns>
        public bool HasRefund(string invoiceNo)
        {
            return NewDao<IDrugStoreInfoDao>().HasRefund(invoiceNo);
        }

        /// <summary>
        /// 取得退药明细
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>退药明细</returns>
        public DataTable GetRefundDetail(Dictionary<string, string> condition)
        {
            return NewDao<IDrugStoreInfoDao>().GetRefundDetail(condition);
        }

        #endregion

        #region 药库药房公共方法
        /// <summary>
            /// 判断库房是否处于盘点状态
            /// </summary>
            /// <param name="deptId">库房ID</param>
            /// <param name="deptType">药剂科室类型0药房1药库</param>
            /// <returns>返回True是系统正在盘点，false正常运营</returns>
        public bool IsCheckStatus(int deptId, int deptType)
        {
            return NewDao<IDrugStoreInfoDao>().IsCheckStatus(deptId, deptType);
        }
        #endregion

        #region 药品有效库存判断，有效库存操作
        /// <summary>
        /// 通过药品ID和科室获取药品实时库存
        /// </summary>
        /// <param name="drugID">药品ID</param>
        /// <param name="DeptID">药房ID</param>
        /// <returns></returns>
        public decimal GetStorage(int drugID, int DeptID)
        {
            decimal amount = NewDao<IDrugStoreInfoDao>().GetStorage(drugID, DeptID);     
            return amount;
        }
        /// <summary>
        /// 通过药品ID，药房ID，变化数量改变虚拟库存数量
        /// </summary>
        /// <param name="drugID">药品ID</param>
        /// <param name="DeptID">药房ID</param>
        /// <param name="updateAmount">变化数量(减库存传负数，加库存传正数)</param>
        /// <returns></returns>
        public bool UpdateStorage(int drugID, int DeptID, decimal updateAmount)
        {
            if (updateAmount < 0)//判断库存数是否足够
            {
                if (GetStorage(drugID, DeptID) < updateAmount * (-1))
                {
                    throw new Exception("库存数不够");
                }
            }
            bool result = NewDao<IDrugStoreInfoDao>().UpdateStorage(drugID, DeptID,updateAmount);
            return result;
        }
        #endregion

        #region 住院发药接口
        /// <summary>
        /// 取得统领单头表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>统领头表</returns>
        public DataTable GetIPDrugBillHead(Dictionary<string, string> condition)
        {
            DataTable dt = NewDao<IDrugStoreInfoDao>().GetIPDrugBillHead(condition);
            return dt;
        }
        /// <summary>
        /// 取得统领单明细表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>统领明细表</returns>
        public DataTable GetIPDrugBillDetail(Dictionary<string, string> condition)
        {
            return NewDao<IDrugStoreInfoDao>().GetIPDrugBillDetail(condition);
        }

        /// <summary>
        /// 发药头表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public DataTable GetDispIPBillHead(Dictionary<string, string> condition)
        {
            return NewDao<IDrugStoreInfoDao>().GetDispIPBillHead(condition);
        }

        /// <summary>
        /// 取得统领单明细表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>统领明细表</returns>
        public DataTable GetIPDrugBillDetailPrint(int iDispHeadID)
        {
            return NewDao<IDrugStoreInfoDao>().GetIPDrugBillDetailPrint(iDispHeadID);
        }
        #endregion
    }

}
