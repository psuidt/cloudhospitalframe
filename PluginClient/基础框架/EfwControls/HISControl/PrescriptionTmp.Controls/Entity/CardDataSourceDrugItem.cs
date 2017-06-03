using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.PrescriptionTmp.Controls.Entity
{
    public class CardDataSourceDrugItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Standard { get; set; }
        //补偿比例
        public string Scale { get; set; }
        //库存量
        public decimal StoreNum { get; set; }
        //包装单位(销售单位)
        public string UnPickUnit { get; set; }
        //销售价格
        public decimal SellPrice { get; set; }
        //执行科室
        public string ExecDeptName { get; set; }
        public string Pym { get; set; }
        public string Wbm { get; set; }
        //生产厂家
        public string Address { get; set; }

        //剂量单位
        public int DoseUnitId { get; set; }
        public string DoseUnitName { get; set; }
        //剂量对应包装单位系数
        public decimal DoseConvertNum { get; set; }

        //项目类型 0-所有 1-西药 2-中药  3-处方可开的物品 4-收费项目
        public int ItemType { get; set; }
        //大项目代码
        public string StatItemCode { get; set; }
        //处方打印显示名称
        public string ItemName_Print { get; set; }
        //包装单位ID
        public int UnPickUnitId { get; set; }
        //执行科室ID
        public int ExecDeptId { get; set; }

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
        public decimal default_Usage_Amount { get; set; }
        //默认用法
        public int default_Usage_Id { get; set; }
        public string default_Usage_Name { get; set; }
        //默认频次
        public int default_Frequency_Id { get; set; }
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

    }
}
