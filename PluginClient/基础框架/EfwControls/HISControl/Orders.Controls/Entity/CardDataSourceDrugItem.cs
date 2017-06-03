using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.HISControl.Orders.Controls.Entity
{
    public class CardDataSourceDrugItem
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
    }
}
