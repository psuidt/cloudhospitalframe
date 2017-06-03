using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.Prescription.Controls.Entity
{
    public class PresDetail
    {

        protected int _item_id;
        protected string _item_name;
        protected decimal _usage_amount;
        protected int _dosage;
        protected int _days;
        protected int _item_amount;
        protected string _item_money;

        //
        public int PresListId { get; set; }
        //
        public int PresHeadId { get; set; }
        //序号
        public int OrderNo { get; set; }
        //
        public int Item_Id
        {
            get
            {
                return _item_id;
            }
            set
            {
                _item_id = value;
            }
        }
        //
        public string Item_Name
        {
            get
            {
                return _item_name;
            }
            set
            {
                _item_name = value;
            }
        }
        //项目类型 1西药 2中药 3项目材料 4套餐
        public int Item_Type { get; set; }
        //大项目代码
        public string StatItem_Code { get; set; }

        //销售价
        public decimal Sell_Price { get; set; }
        //进价
        public decimal Buy_Price { get; set; }
        //单价
        public decimal Item_Price { get; set; }
        //规格
        public string Standard { get; set; }
        //用量
        public decimal Usage_Amount
        {
            get
            {
                return _usage_amount;
            }
            set
            {
                _usage_amount = value;
            }
        }
        //用量单位
        public string Usage_Unit { get; set; }
        //用量单位系数
        public decimal Usage_Rate { get; set; }

        //中草药剂数（付数）
        public int Dosage
        {
            get
            {
                return _dosage;
            }
            set
            {
                _dosage = value;
            }
        }

        //用法
        public int Usage_Id { get; set; }
        //频次
        public int Frequency_Id { get; set; }

        //天数
        public int Days
        {
            get
            {
                return _days;
            }
            set
            {
                _days = value;
            }
        }

        //开药数量
        public int Item_Amount
        {
            get
            {
                return _item_amount;
            }
            set
            {
                _item_amount = value;
            }
        }
        //开药单位
        public string Item_Unit { get; set; }
        //开药系数（基本单位对应最大包装单位的系数）
        public int Item_Rate { get; set; }

        
        //发药数量
        public decimal Amount { get; set; }
        //发药单位
        public string Unit { get; set; }

        //分组ID
        public int Group_Id { get; set; }
        //皮试标志（0 不需皮试 1 需要皮试 2 阴性 3 阳性 4 免皮试）
        public int SkinTest_Flag { get; set; }


        //自备
        public int SelfDrug_Flag { get; set; }
        /// <summary>
        /// 医保报销
        /// </summary>
        public int IsReimbursement { get; set; }
        //嘱托
        public string Entrust { get; set; }
        //中药脚注
        public string FootNote { get; set; }
        //
        public int Tc_Flag { get; set; }
        //
        public int Service_Item_Id { get; set; }
        
        //
        public int Delete_Bit { get; set; }
        
        //费用表反写ID
        public int PresOrderId { get; set; }
    }
}
