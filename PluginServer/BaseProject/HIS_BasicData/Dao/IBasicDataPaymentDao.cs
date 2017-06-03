using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 支付方式数据访问接口
    /// </summary>
    public interface IBasicDataPaymentDao
    {
        /// <summary>
        /// 获取支付方式计算方式
        /// </summary>
        /// <returns>支付方式计算方式</returns>
        DataTable GetPayInputFrom();

        /// <summary>
        /// 删除支付方式
        /// </summary>
        /// <param name="paymentId">支付方式ID</param>
        /// <param name="val">删除标志</param>
        /// <returns>true：删除成功</returns>
        bool SwitchPayment(int paymentId, int val);

        /// <summary>
        /// 获取支付方式列表
        /// </summary>
        /// <returns>支付方式列表</returns>
        DataTable GetPaymentData();

        /// <summary>
        /// 获取支付方式类型列表
        /// </summary>
        /// <returns>支付方式类型列表</returns>
        DataTable GetPayTypeData();

        /// <summary>
        /// 获取中心支付方式
        /// </summary>
        /// <returns>中心支付方式列表</returns>
        DataTable GetCenterPaymentData();

        /// <summary>
        /// 获取本院支付方式
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="patTypeId">支付方式类型</param>
        /// <returns>本院支付方式</returns>
        DataTable GetHostPaymentData(int workId, int userType, int patTypeId);

        /// <summary>
        /// 删除本院支付方式
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>true：删除成功</returns>
        bool DeleteHostPaymentData(int id);

        /// <summary>
        /// 添加本院支付方式
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="patTypeId">支付方式类型ID</param>
        /// <param name="paymentId">支付方式ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="payorder">排序</param>
        /// <returns>true：保存成功</returns>
        bool AddHospPayment(int workId, int patTypeId, int paymentId, int userType, int payorder);

        /// <summary>
        /// 本院支付方式顺序调整
        /// </summary>
        /// <param name="dtPayment">支付方式列表</param>
        void SortPayment(DataTable dtPayment);
    }
}
