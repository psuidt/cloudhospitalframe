using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MIManage
{
    public class TradeData
    {
        private int _workID;
        /// <summary>
        /// 机构ID
        /// </summary>
        public int WorkID
        {
            get { return _workID; }
            set { _workID = value; }
        }

        private int _mIID;
        /// <summary>
        /// 机构ID
        /// </summary>
        public int MIID
        {
            get { return _mIID; }
            set { _mIID = value; }
        }

        private string _socityCreateNum = "";
        public string SocityCreateNum
        {
            get { return _socityCreateNum; }
            set { _socityCreateNum = value; }
        }

        private string _serialNo = "";
        public string SerialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; }
        }

        public Tradeinfo tradeinfo;

        public RecipeList recipeList;

        public FeeitemList feeitemList;
    }

    public class Tradeinfo
    {
        public TradeType tradeType;
        /// <summary>
        /// 就诊方式,目前都是0普通
        /// </summary>
        public string billtype;

        /// <summary>
        /// 收费单据号
        /// </summary>
        public string feeno = "0";
    }

    public class RecipeList
    {
        public List<Recipe> recipes;
    }

    public class Recipe
    {
        /// <summary>
        /// 诊断序号
        /// </summary>
        public string diagnoseno = "1";
        /// <summary>
        /// 处方序号
        /// </summary>
        public string recipeno = "1";
        /// <summary>
        /// 处方日期-开处方的日期；格式yyyymmdd hhmmss；如果是预约挂号，则填写预约的就诊日期。
        /// </summary>
        public string recipedate = DateTime.Now.ToString("yyyyMMdd HHmmss");
        /// <summary>
        /// 处方类别-1：医保内处方2：医保外处方
        /// </summary>
        public string recipetype = "1";
        /// <summary>
        /// 代开药标识-0：普通处方；1:代开药处方 
        /// </summary>
        public string helpmedicineflag = "0";
        /// <summary>
        /// 诊断名
        /// </summary>
        public string diagnosename = "";
        /// <summary>
        /// 诊断编码
        /// </summary>
        public string diagnosecode = "";
        /// <summary>
        /// 医生ID
        /// </summary>
        public string drid = "";
        /// <summary>
        /// 医生名
        /// </summary>
        public string drname = "";
        /// <summary>
        /// 科别编码
        /// </summary>
        public string sectioncode = "";
        /// <summary>
        /// 科别名
        /// </summary>
        public string sectionname = "";
        /// <summary>
        /// his科别名
        /// </summary>
        public string hissectionname = "";
        /// <summary>
        /// 挂号交易流水号
        /// </summary>
        public string registertradeno = "";
        /// <summary>
        /// 单据类型（1-挂号；2-西药或中成药处方；4-中草药处方；5-检验治疗；）
        /// </summary>
        public string billstype = "2";

    }

    public class FeeitemList
    {
        public List<Feeitem> feeitems;
    }

    public class Feeitem
    {
        /// <summary>
        /// 处方序号
        /// </summary>
        public string recipeno = "1";
        /// <summary>
        /// 项目序号
        /// </summary>
        public string itemno = "1";
        /// <summary>
        /// HIS项目代码
        /// </summary>
        public string hiscode = "1";
        /// <summary>
        /// HIS项目名称
        /// </summary>
        public string itemname = "1";
        /// <summary>
        /// 项目类别-0药品 1诊疗项目和服务设施
        /// </summary>
        public string itemtype = "1";
        /// <summary>
        /// 单价
        /// </summary>
        public string unitprice = "1";
        /// <summary>
        /// 数量
        /// </summary>
        public string count = "1";
        /// <summary>
        /// 项目总金额
        /// </summary>
        public string fee = "1";
        /// <summary>
        /// 生育费用标识-0：普通费用；1:生育类费用
        /// </summary>
        public string babyflag = "1";
        /// <summary>
        /// 药品准字号，仅药品需要填
        /// </summary>
        public string drugapprovalnumber = "";

        /// <summary>
        /// 单次用量
        /// </summary>
        public string dosage = "";
        /// <summary>
        /// 剂型
        /// </summary>
        public string dose = "";
        /// <summary>
        /// 天数
        /// </summary>
        public string days = "1";
        /// <summary>
        /// 用法
        /// </summary>
        public string howtouse = "";
        /// <summary>
        /// 规格
        /// </summary>
        public string specification = "";
        /// <summary>
        /// 单位
        /// </summary>
        public string unit = "";
  

    }


    public enum TradeType
    {
        普通门诊 = 11,
        门诊挂号 = 17,
        急诊挂号 = 18,
        普通急诊 = 19
    }
}
