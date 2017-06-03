using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HIS_Entity.MIManage.Common.DivideResult
{
    //, Namespace = "http://www.cpandl.com",IsNullable = false
    [XmlRootAttribute("root")]
    public class root
    {
        public state state;
        public output output;
    }

    public class state
    {
        public string error;
        public string warning;
    }
    public class output
    {
        public tradeinfo tradeinfo;
        [XmlArrayAttribute("feeitemarray")]
        public feeitem[] feeitems;
        public sumpay sumpay;
        public payinfo payinfo;
        public medicatalog medicatalog;
        public medicatalog2 medicatalog2;
    }

    public class tradeinfo
    {
        public string tradeno;
        public string feeno;
        public string tradedate;
    }

    public class feeitem
    {
        [XmlAttribute]
        public string itemno;
        [XmlAttribute]
        public string recipeno;
        [XmlAttribute]
        public string hiscode;
        [XmlAttribute]
        public string itemcode;
        [XmlAttribute]
        public string itemname;
        [XmlAttribute]
        public string itemtype;
        [XmlAttribute]
        public string unitprice;
        [XmlAttribute]
        public string count;
        [XmlAttribute]
        public string fee;
        [XmlAttribute]
        public string feein;
        [XmlAttribute]
        public string feeout;
        [XmlAttribute]
        public string selfpay2;
        [XmlAttribute]
        public string state;
        [XmlAttribute]
        public string fee_type;
        [XmlAttribute]
        public string preferentialfee;
        [XmlAttribute]
        public string preferentialscale;
    }

    public class sumpay
    {
        public string feeall;
        public string fund;
        public string cash;
        public string personcountpay;
    }

    public class payinfo
    {
        public string mzfee;
        public string mzfeein;
        public string mzfeeout;
        public string mzpayfirst;
        public string mzselfpay2;
        public string mzbigpay;
        public string mzbigselfpay;
        public string mzoutofbig;
        public string bcpay;
        public string jcbz;
    }

    public class medicatalog
    {
        /// <summary>
        /// 西药
        /// </summary>
        public string medicine;
        public string tmedicine;
        public string therb;
        public string examine;
        public string ct;
        public string mri;
        public string ultrasonic;
        public string oxygen;
        public string operation;
        public string treatment;
        public string xray;
        public string labexam;
        public string bloodt;
        public string orthodontics;
        public string prosthesis;
        public string forensic_expertise;
        public string material;
        public string other;
    }
    public class medicatalog2
    {
        /// <summary>
        /// 西药
        /// </summary>
        public string diagnosis;
        public string examine;
        public string labexam;
        public string treatment;
        public string operation;
        public string material;
        public string medicine;
        public string therb;
        public string tmedicine;
        public string medicalservice;
        public string commonservice;
        public string registfee;
        public string otheropfee;
    }
}
