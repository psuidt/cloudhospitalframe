using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HIS_Entity.MIManage.Common.Reg
{
    //XmlRoot表明这个类对应的是XML文件中的根节点
    [XmlRoot(ElementName = "root")]
    public class root
    {
        [XmlElement(ElementName = "input")]
        public input input { get; set; }
    }

    public class input
    {
        //XmlElement表明这个字段对应的是XML文件中当前父节点下面的一个子节点
        //ElementName就是XML里面显示的当前节点名称
        //类中的字段名称与对应的XML节点的名称可以不同(比如在这里类Config中的属性ClientDescription对应XML文件中根节点Config下面的子节点Description)
        [XmlElement(ElementName = "tradeinfo")]
        public tradeinfo tradeinfo { get; set; }

        [XmlElement(ElementName = "recipearray")]
        public recipearray recipearray { get; set; }

        [XmlElement(ElementName = "feeitemarray")]
        public feeitemarray feeitemarray
        {
            get;
            set;
        }
    }
    public class tradeinfo
    {
        private string _curetype = "";
        /// <summary>
        /// 就诊类型，11门诊，19急诊，17门诊挂号，18急诊挂号
        /// </summary>
        [XmlElement(ElementName = "curetype")]
        public string curetype { get { return _curetype; } set { _curetype = value; } }

        private string _billtype = "";
        /// <summary>
        /// 就诊方式 0普通 其他未启用
        /// </summary>
        [XmlElement(ElementName = "billtype")]
        public string billtype { get { return _billtype; } set { _billtype = value; } }

        private string _feeno = "";
        /// <summary>
        /// 收费单据号
        /// </summary>
        [XmlElement(ElementName = "feeno")]
        public string feeno { get { return _feeno; } set { _feeno = value; } }

        private string _operator1 = "";

        [XmlElement(ElementName = "operator1")]
        public string operator1 { get { return _operator1; } set { _operator1 = value; } }   
    }

    public class recipearray
    {
        [XmlElement(ElementName = "recipe")]
        public recipe[] recipe
        {
            get;
            set;
        }
    }
    public class recipe
    {
        private string _diagnoseno = "";
        /// <summary>
        /// 诊断序号--多诊断时，处方信息应该为多条记录，处方序号相同，诊断序号不同，一个诊断名称对应一个诊断编码。
        /// </summary>
        [XmlElement(ElementName = "diagnoseno")]
        public string diagnoseno { get { return _diagnoseno; } set { _diagnoseno = value; } }

        private string _recipeno = "";
        /// <summary>
        /// 处方序号
        /// </summary>
        [XmlElement(ElementName = "recipeno")]
        public string recipeno { get { return _recipeno; } set { _recipeno = value; } }

        private string _recipedate = "";
        /// <summary>
        /// 处方日期/时间 开处方的日期；格式yyyymmdd hhmmss；如果是预约挂号，则填写预约的就诊日期。
        /// </summary>
        [XmlElement(ElementName = "recipedate")]
        public string recipedate { get { return _recipedate; } set { _recipedate = value; } }

        private string _diagnosename = "";
        [XmlElement(ElementName = "diagnosename")]
        public string diagnosename { get { return _diagnosename; } set { _diagnosename = value; } }

        private string _diagnosecode = "";
        [XmlElement(ElementName = "diagnosecode")]
        public string diagnosecode { get { return _diagnosecode; } set { _diagnosecode = value; } }

        private string _medicalrecord = "";
        [XmlElement(ElementName = "medicalrecord")]
        public string medicalrecord { get { return _medicalrecord; } set { _medicalrecord = value; } }

        private string _sectioncode = "";
        [XmlElement(ElementName = "sectioncode")]
        public string sectioncode { get { return _sectioncode; } set { _sectioncode = value; } }

        private string _sectionname = "";
        [XmlElement(ElementName = "sectionname")]
        public string sectionname { get { return _sectionname; } set { _sectionname = value; } }
        private string _hissectionname = "";
        /// <summary>
        /// 本院科别名称
        /// </summary>
        [XmlElement(ElementName = "hissectionname")]
        public string hissectionname { get { return _hissectionname; } set { _hissectionname = value; } }
        private string _drid = "";
        [XmlElement(ElementName = "drid")]
        public string drid { get { return _drid; } set { _drid = value; } }
        private string _drname = "";
        [XmlElement(ElementName = "drname")]
        public string drname { get { return _drname; } set { _drname = value; } }
        private string _recipetype = "";
        /// <summary>
        /// 处方类别 1：医保内处方2：医保外处方
        /// </summary>
        [XmlElement(ElementName = "recipetype")]
        public string recipetype { get { return _recipetype; } set { _recipetype = value; } }
        private string _helpmedicineflag = "";
        /// <summary>
        /// 代开药标识 0：普通处方；1:代开药处方
        /// </summary>
        [XmlElement(ElementName = "helpmedicineflag")]
        public string helpmedicineflag { get { return _helpmedicineflag; } set { _helpmedicineflag = value; } }
        private string _remark = "";
        [XmlElement(ElementName = "remark")]
        public string remark { get { return _remark; } set { _remark = value; } }
        private string _registertradeno = "";
        [XmlElement(ElementName = "registertradeno")]
        public string registertradeno { get { return _registertradeno; } set { _registertradeno = value; } }
        private string _billstype = "";
        [XmlElement(ElementName = "billstype")]
        public string billstype { get { return _billstype; } set { _billstype = value; } }

    }

    public class feeitemarray
    {
        [XmlElement(ElementName = "feeitem")]
        public feeitem[] feeitem
        {
            get;
            set;
        }
    }
    public class feeitem
    {
        /// <summary>
        /// 项目序号
        /// </summary>
        [XmlAttribute(AttributeName = "itemno")]
        public string itemno { get; set; }
        /// <summary>
        /// 处方序号
        /// </summary>
        [XmlAttribute(AttributeName = "recipeno")]
        public string recipeno { get; set; }
        /// <summary>
        /// HIS项目代码
        /// </summary>
        [XmlAttribute(AttributeName = "hiscode")]
        public string hiscode { get; set; }
        /// <summary>
        /// HIS项目名称
        /// </summary>
        [XmlAttribute(AttributeName = "itemname")]
        public string itemname { get; set; }
        /// <summary>
        /// 项目类别 0药品 1诊疗项目和服务设施
        /// </summary>
        [XmlAttribute(AttributeName = "itemtype")]
        public string itemtype { get; set; }

        [XmlAttribute(AttributeName = "unitprice")]
        public string unitprice { get; set; }

        [XmlAttribute(AttributeName = "count")]
        public string count { get; set; }

        [XmlAttribute(AttributeName = "fee")]
        public string fee { get; set; }

        [XmlAttribute(AttributeName = "dose")]
        public string dose { get; set; }

        [XmlAttribute(AttributeName = "specification")]
        public string specification { get; set; }

        [XmlAttribute(AttributeName = "unit")]
        public string unit { get; set; }

        [XmlAttribute(AttributeName = "howtouse")]
        public string howtouse { get; set; }

        [XmlAttribute(AttributeName = "dosage")]
        public string dosage { get; set; }

        [XmlAttribute(AttributeName = "packaging")]
        public string packaging { get; set; }

        [XmlAttribute(AttributeName = "minpackage")]
        public string minpackage { get; set; }

        [XmlAttribute(AttributeName = "conversion")]
        public string conversion { get; set; }

        [XmlAttribute(AttributeName = "days")]
        public string days { get; set; }
        /// <summary>
        /// 生育费用标识 0：普通费用；1:生育类费用；对生育类门诊费用没有特殊处理的医院，可以不生成该节点；如使用并生成该节点，
        /// </summary>
        [XmlAttribute(AttributeName = "babyflag")]
        public string babyflag { get; set; }

        [XmlAttribute(AttributeName = "drugapprovalnumber")]
        public string drugapprovalnumber { get; set; }

    }

}
