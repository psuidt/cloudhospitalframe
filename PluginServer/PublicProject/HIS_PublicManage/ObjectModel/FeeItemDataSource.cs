using EFWCoreLib.CoreFrame.Business;
using HIS_PublicManage.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 费用数据源
    /// </summary>
    public class FeeItemDataSource: AbstractObjectModel
    {
        /// <summary>
        /// 根据费用类别获取费用集合
        /// </summary>
        /// <param name="feeClass"></param>
        /// <returns></returns>
        public List<FeeItemObject> GetFeeItemData(FeeClass feeClass)
        {
            return null;
        }
        /// <summary>
        /// 根据业务类型获取费用集合
        /// </summary>
        /// <param name="feeType"></param>
        /// <returns></returns>
        public List<FeeItemObject> GetFeeItemData(FeeBusinessType feeType)
        {
            return null;
        }
        /// <summary>
        /// 根据费用类别获取简单费用集合
        /// </summary>
        /// <param name="feeClass"></param>
        /// <returns></returns>
        public List<SimpleFeeItemObject> GetSimpleFeeItemData(FeeClass feeClass)
        {
            DataTable dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData((int)feeClass);
            return EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<SimpleFeeItemObject>(dt);
        }
        /// <summary>
        /// 根据业务类型获取简单费用集合
        /// </summary>
        /// <param name="feeType"></param>
        /// <returns></returns>
        public List<SimpleFeeItemObject> GetSimpleFeeItemData(FeeBusinessType feeType)
        {
            DataTable dt = null;
            switch (feeType)
            {
                case FeeBusinessType.记账业务:
                    dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData(new int[] { 2, 3, 4 });
                    return EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<SimpleFeeItemObject>(dt);
                case FeeBusinessType.处方业务:
                    dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData(new int[] { 1, 2, 3, 4 });
                    return EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<SimpleFeeItemObject>(dt);
                case FeeBusinessType.医嘱业务:
                    dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData(new int[] { 1, 2, 3, 4, 5 });
                    return EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<SimpleFeeItemObject>(dt);
            }
            return new List<SimpleFeeItemObject>();
        }

        /// <summary>
        /// 根据费用类别获取简单费用集合
        /// </summary>
        /// <param name="feeClass"></param>
        /// <returns></returns>
        public DataTable GetSimpleFeeItemDataDt(FeeClass feeClass)
        {
            DataTable dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData((int)feeClass);
            return dt;
        }
        /// <summary>
        /// 根据业务类型获取简单费用集合
        /// </summary>
        /// <param name="feeType"></param>
        /// <returns></returns>
        public DataTable GetSimpleFeeItemDataDt(FeeBusinessType feeType)
        {
            DataTable dt = null;
            switch (feeType)
            {
                case FeeBusinessType.记账业务:
                    dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData(new int[] { 2, 3, 4 });
                    return dt;
                case FeeBusinessType.处方业务:
                    dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData(new int[] { 1, 2, 3, 4 });
                    return dt;
                case FeeBusinessType.医嘱业务:
                    dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData(new int[] { 1, 2, 3, 4, 5 });
                    return dt;
                case FeeBusinessType.基础业务:
                    dt = NewDao<IPublicManageDao>().GetSimpleFeeItemData(new int[] { 2, 3 });
                    return dt;
            }
            return new DataTable();
        }
        public DataTable GetFeeItemDataDt(FeeBusinessType feeType)
        {
            DataTable dt = null;
            switch (feeType)
            {               
                case FeeBusinessType.处方业务:
                    dt = NewDao<IPublicManageDao>().GetFeeItemData(new int[] { 1, 2, 3, 4 });
                    return dt;
                case FeeBusinessType.医嘱业务:
                    dt = NewDao<IPublicManageDao>().GetFeeItemData(new int[] { 1, 2, 3, 5 });
                    return dt;          
            }
            return new DataTable();
        }
        /// <summary>
        /// 通过组合项目ID获取组合项目的收费明细
        /// </summary>
        /// <param name="ExamItemID"></param>
        /// <returns></returns>
        public DataTable GetExamItemDetailDt(int examItemID)
        {
            DataTable dt = null;
            dt = NewDao<IPublicManageDao>().GetExamItemDetailDt(examItemID);
            return dt;
        }
    }
    /// <summary>
    /// 费用项目对象
    /// </summary>
    public class FeeItemObject:ICloneable
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Standard { get; set; }
        //补偿比例
        public string Scale { get; set; }
        //库存量
        public decimal StoreAmount { get; set; }
        
        //执行科室ID
        public int ExecDeptId { get; set; }
        //执行科室
        public string ExecDeptName { get; set; }
        //名称拼音码
        public string Pym { get; set; }
        public string Wbm { get; set; }
        //药品通用名的拼音码
        public string PymT { get; set; }
        public string WbmT { get; set; }
        //生产厂家
        public string Address { get; set; }

        //包装单位ID
        public int UnPickUnitId { get; set; }

        //包装单位(销售单位)
        public string UnPickUnit { get; set; }
        //销售价格
        public decimal SellPrice { get; set; }

        //基本单位
        public int MiniUnitId { get; set; }
        public string MiniUnitName { get; set; }
        //基本单位对应包装单位系数
        public decimal MiniConvertNum { get; set; }
        //单价价格
        public decimal UnitPrice { get; set; }

        //剂量单位
        public int DoseUnitId { get; set; }
        public string DoseUnitName { get; set; }
        //剂量对应包装单位系数
        public decimal DoseConvertNum { get; set; }

        //项目类型 1药品 2物资 3-收费项目 4组合项目 5说明性医嘱
        public int ItemClass { get; set; }
        public string ItemClassName { get; set; }
        //大项目代码
        public int StatID { get; set; }
        //处方打印显示名称
        public string ItemNamePrint { get; set; }
        //药品拆零 1可拆零
        public int ResolveFlag { get; set; }
        //按含量取整1 按剂量取整0
        public int FloatFlag { get; set; }

        //进价
        public decimal BuyPrice { get; set; }


        //剧毒标识
        public int VirulentFlag { get; set; }
        //麻醉标识
        public int NarcoticFlag { get; set; }
        //皮试标识
        public int SkinTestFlag { get; set; }
        //处方标识
        public int RecipeFlag { get; set; }
        //精神药品标识
        public int LunacyFlag { get; set; }
        //贵重药品标识
        public int CostlyFlag { get; set; }

        //默认用量
        public decimal default_UsageAmount { get; set; }
        //默认用法
        public int default_UsageId { get; set; }
        public string default_UsageName { get; set; }
        //默认频次
        public int default_FrequencyId { get; set; }
        public string default_FrequencyName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 简单费用项目对象
    /// </summary>
    public class SimpleFeeItemObject : ICloneable
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Standard { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public decimal StoreAmount { get; set; }

        //执行科室ID
        public int ExecDeptId { get; set; }
        //执行科室
        public string ExecDeptName { get; set; }
        //名称拼音码
        public string Pym { get; set; }
        public string Wbm { get; set; }
        //生产厂家
        public string Address { get; set; }

        //包装单位(销售单位)
        public string UnPickUnit { get; set; }
        //销售价格
        public decimal SellPrice { get; set; }

        public string MiniUnitName { get; set; }
        //基本单位对应包装单位系数
        public decimal MiniConvertNum { get; set; }
        //单价价格
        public decimal UnitPrice { get; set; }

        //项目类型 1药品 2物资 3-收费项目 4组合项目 5说明性医嘱
        public int ItemClass { get; set; }
        public string ItemClassName { get; set; }
        //大项目代码
        public int StatID { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    /// <summary>
    /// 费用类别
    /// </summary>
    public enum FeeClass
    {
        全部=0,药品=1,物资=2,收费项目=3,组合项目=4,说明性医嘱=5
    }
    /// <summary>
    /// 业务类型
    /// 记账业务=物资+收费项目+组合项目
    /// 处方业务=药品+物资+收费项目+组合项目
    /// 医嘱业务=药品+物资+收费项目+组合项目+说明性医嘱
    /// 基础业务=物资+收费项目
    /// </summary>
    public enum FeeBusinessType
    {
        记账业务,处方业务,医嘱业务,基础业务
    }
}
