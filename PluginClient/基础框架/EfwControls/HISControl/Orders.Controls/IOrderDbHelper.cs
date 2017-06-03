using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfwControls.HISControl.Orders.Controls.Entity;

namespace EfwControls.HISControl.Orders.Controls
{
    /// <summary>
    /// 医嘱控件和医嘱管里界面接口类
    /// </summary>
    public interface IOrderDbHelper
    {
        /// <summary>
        /// 医嘱控件数据集获取
        /// </summary>
        /// <param name="orderCategory">医嘱类别0长嘱1临嘱</param>
        /// <param name="pageNo">页号</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">过滤条件</param>
        /// <returns>DataSet</returns>
        DataSet OrderDataInit(int orderCategory, int pageNo, int pageSize, string filter);

        /// <summary>
        /// 获取医嘱选项卡数据
        /// </summary>
        /// <param name="orderCategory">0长嘱1临嘱</param>
        /// <param name="pageNo">页号</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">过滤条件</param>
        /// <returns>DataTable</returns>
        DataTable GetDrugItem(int orderCategory, int pageNo, int pageSize, string filter);

        /// <summary>
        /// 刷新重新获取嘱托
        /// </summary>
        /// <returns>嘱托信息</returns>
        DataTable GetRefreshEntrust();

        /// <summary>
        /// 检查药品库存是否足够
        /// </summary>
        /// <param name="list">医嘱数据</param>
        /// <param name="errlist">库存不足医嘱数据</param>
        /// <returns>bool</returns>
        bool IsDrugStore(List<OrderRecord> list, List<OrderRecord> errlist);

        /// <summary>
        /// 医嘱保存
        /// </summary>
        /// <param name="list">医嘱数据</param>
        /// <returns>bool</returns>
        bool Save(List<OrderRecord> list); 

        /// <summary>
        /// 医嘱操作
        /// </summary>
        /// <param name="orderRecords">医嘱数据</param>
        /// <param name="operatorType">1医嘱删除 2医嘱发送 3医嘱停嘱 4医嘱取消停</param>
        /// <param name="operatorEmpId">操作员ID</param>
        /// <returns>操作是否成功</returns>
        bool OperatorOrder(List<OrderRecord> orderRecords, int operatorType,int operatorEmpId);


        /// <summary>
        /// 获得医嘱信息
        /// </summary>
        /// <param name="orderCategory">医嘱类别</param>
        /// <param name="status">医嘱状态</param>
        /// <param name="patlistid">病人ID</param>
        /// <param name="deptid">科室ID</param>
        /// <returns>医嘱信息</returns>
        DataTable GetOrders(int orderCategory, int status,int patlistid, int deptid); 
           
        /// <summary>
        /// 获取组号
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="orderCategory">医嘱类别</param>
        /// <returns>组号</returns>
        int GetGroupMax(int patlistid, int orderCategory);

        /// <summary>
        /// 获取皮试用药药品ID
        /// </summary>
        /// <returns>皮试用药药品ID</returns>
        int GetActDrugID();

        /// <summary>
        /// 根据频次默认次数
        /// </summary>
        /// <param name="type">0首次默认1末次默认</param>
        /// <param name="frequencyId">频次ID</param>
        /// <param name="date">日adwe</param>
        /// <returns>默认次数</returns>
        int GetExecCount(int type, int frequencyId, DateTime date);

        /// <summary>
        /// 转科，出院，死亡判断是否存在未执行医嘱
        /// </summary>
        /// <param name="patlistid">病人Id</param>
        /// <returns>未执行医嘱</returns>
        DataTable getNotExsistOrders(int patlistid);

        /// <summary>
        /// 获取所有住院临床科室
        /// </summary>
        /// <returns>住院临床科室</returns>
        DataTable getIpDept();

        /// <summary>
        /// 转科医嘱保存
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <param name="list">医嘱数据</param>
        /// <param name="transDate">转科日期</param>
        /// <param name="transDeptId">转入科室</param>
        /// <param name="operatorid">操作人</param>
        /// <param name="spciRecord">转科医嘱对象</param>
        /// <returns>bool</returns>
        bool TransDeptOrder(int patlistid, List<OrderRecord> list, DateTime transDate, int transDeptId, int operatorid, OrderRecord spciRecord);

        /// <summary>
        /// 获取诊断
        /// </summary>
        /// <returns>诊断内容</returns>        
        DataTable getDisease();

        /// <summary>
        /// 获取出院情况
        /// </summary>
        /// <returns>出院情况</returns>
        DataTable getOutSituation();

        /// <summary>
        /// 出院医嘱，死亡医嘱保存
        /// </summary>
        /// <param name="CurrPatListId">病人Id</param>
        /// <param name="list">停嘱医嘱内容</param>
        /// <param name="OutDate">出院日期</param>
        /// <param name="outDiseaseName">出院诊断名称</param>
        /// <param name="outDiseaseCode">出院诊断Code</param>
        /// <param name="outSituation">出院情况</param>
        /// <param name="PresDoctorId">操作医生</param>
        /// <param name="spciOrderRecord">出院医嘱对象</param>
        /// <returns>bool</returns>
        bool OutHospOrder(int CurrPatListId, List<OrderRecord> list, DateTime OutDate, string outDiseaseName, string outDiseaseCode, string outSituation, int PresDoctorId, OrderRecord spciOrderRecord);
    }
}
