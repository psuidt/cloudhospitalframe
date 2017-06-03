using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.Prescription.Controls.Entity
{
    public class CardDataSourceDrugItem
    {
        /// <summary>
        /// 项目Id
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }
        /// <summary>
        /// 补偿比例
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 库存量
        /// </summary>
        public decimal StoreNum { get; set; }
        /// <summary>
        /// 包装单位(销售单位)
        /// </summary>
        public string UnPickUnit { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal SellPrice { get; set; }
        /// <summary>
        /// 执行科室
        /// </summary>
        public string ExecDeptName { get; set; }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string Pym { get; set; }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string Wbm { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 剂量单位ID
        /// </summary>
        public int DoseUnitId { get; set; }
        /// <summary>
        /// 计量单位名称
        /// </summary>
        public string DoseUnitName { get; set; }
        /// <summary>
        /// 剂量对应包装单位系数
        /// </summary>
        public decimal DoseConvertNum { get; set; }
        /// <summary>
        /// 项目类型 0-所有 1-西药 2-中药  3-处方可开的物品 4-收费项目
        /// </summary>
        public int ItemType { get; set; }
        /// <summary>
        /// 大项目代码
        /// </summary>
        public string StatItemCode { get; set; }
        /// <summary>
        /// 处方打印显示项目名称
        /// </summary>
        public string ItemName_Print { get; set; }
        /// <summary>
        /// 包装单位ID
        /// </summary>
        public int UnPickUnitId { get; set; }
        /// <summary>
        /// 执行科室ID
        /// </summary>
        public int ExecDeptId { get; set; }
        /// <summary>
        /// 按含量取整1 按剂量取整0
        /// </summary>
        public int FloatFlag { get; set; }
        /// <summary>
        /// 进价
        /// </summary>
        public decimal BuyPrice { get; set; }
        /// <summary>
        /// 剧毒标识
        /// </summary>
        public int VirulentFlag { get; set; }
        /// <summary>
        /// 麻醉标识
        /// </summary>
        public int NarcoticFlag { get; set; }
        /// <summary>
        /// 皮试标识
        /// </summary>
        public int SkinTestFlag { get; set; }
        /// <summary>
        /// 处方标识
        /// </summary>
        public int RecipeFlag { get; set; }
        /// <summary>
        /// 精神药品标识
        /// </summary>
        public int LunacyFlag { get; set; }
        /// <summary>
        /// 贵重药品标识
        /// </summary>
        public int CostlyFlag { get; set; }
        /// <summary>
        /// 默认用量
        /// </summary>
        public decimal default_Usage_Amount { get; set; }
        /// <summary>
        /// 默认用法ID
        /// </summary>
        public int default_Usage_Id { get; set; }
        /// <summary>
        /// 默认用法名称
        /// </summary>
        public string default_Usage_Name { get; set; }
        /// <summary>
        /// 默认频次Id
        /// </summary>
        public int default_Frequency_Id { get; set; }
        /// <summary>
        /// 默认频次名称
        /// </summary>
        public string default_Frequency_Name { get; set; }
        /// <summary>
        /// 拆零标志
        /// </summary>
        public int ResolveFlag
        {
            get;
            set;
        }
        /// <summary>
        /// 包装系数
        /// </summary>
        public int PresFactor
        {
            get;
            set;
        }
        /// <summary>
        /// 最小单位
        /// </summary>
        public string MiniUnit
        {
            get;
            set;
        }
        /// <summary>
        /// 医保类型
        /// </summary>
        public int MedicareID
        {
            get;
            set;
        }
        /// <summary>
        /// 医保类型名称
        /// </summary>
        public string MedicareName
        {
            get;
            set;
        }
        /// <summary>
        /// 医保报销比例
        /// </summary>
        public string MedicarePer
        {
            get;
            set;
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string ChemPym { get; set; }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string ChemWbm { get; set; }

    }
}
