using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MIManage
{
    public class PatientInfo
    {
        #region IC卡信息        
        private string _cardno;
        /// <summary>
        /// 社保卡卡号
        /// </summary>
        public string CardNo
        {
            get { return _cardno; }
            set { _cardno = value; }
        }

        private string _icno;
        /// <summary>
        /// 医保应用号
        /// </summary>
        public string IcNo
        {
            get { return _icno; }
            set { _icno = value; }
        }

        private string _idno;
        /// <summary>
        /// 公民身份号码
        /// </summary>
        public string IdNo
        {
            get { return _idno; }
            set { _idno = value; }
        }


        private string _personname;
        /// <summary>
        /// 姓名
        /// </summary>
        public string PersonName
        {
            get { return _personname; }
            set { _personname = value; }
        }


        private string _sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }


        private string _birthday;
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }


        private string _fromhosp;
        /// <summary>
        /// 转诊医院编码
        /// </summary>
        public string FromHosp
        {
            get { return _fromhosp; }
            set { _fromhosp = value; }
        }


        private string _fromhospdate;
        /// <summary>
        /// 转诊时间
        /// </summary>
        public string FromHospDate
        {
            get { return _fromhospdate; }
            set { _fromhospdate = value; }
        }


        private string _fundtype;
        /// <summary>
        /// 险种类型
        /// </summary>
        public string FundType
        {            
            set { _fundtype = value; }
            get
            {
                string s = _fundtype;
                switch (_fundtype)
                {
                    case "1":
                        s = "基本养老保险";
                        break;
                    case "2":
                        s = "失业保险";
                        break;
                    case "3":
                        s = "基本医疗保险";
                        break;
                    case "4":
                        s = "工伤保险";
                        break;
                    case "5":
                        s = "生育保险";
                        break;
                    case "6":
                        s = "企业补充养老保险";
                        break;
                    case "7":
                        s = "个人储蓄性养老保险";
                        break;
                    case "8":
                        s = "预提补充医疗保险";
                        break;
                    case "81":
                        s = "退休人员统一补充医疗保险";
                        break;
                    case "20":
                        s = "大额医疗互助";
                        break;
                    case "30":
                        s = "公务员医疗补助";
                        break;
                    case "31":
                        s = "离休医疗费统筹";
                        break;
                    case "32":
                        s = "公费医疗";
                        break;
                    case "91":
                        s = "学生儿童大病医疗保险";
                        break;
                    case "92":
                        s = "城镇无保障老年人大病医疗保险";
                        break;
                    case "93":
                        s = "城镇居民基本医疗保险";
                        break;
                    case "33":
                        s = "征地超转人员医疗保险";
                        break;
                    default:
                        s = _fundtype;
                        break;
                }
                return s;
            }
        }



        private string _isyt;
        /// <summary>
        /// 预提人员标示
        /// </summary>
        public string IsYT
        {
            get { return _isyt; }
            set { _isyt = value; }
        }



        private string _jclevel;
        /// <summary>
        /// 军残等级
        /// </summary>
        public string JcLevel
        {
            get { return _jclevel; }
            set { _jclevel = value; }
        }

        private string _hospflag;
        /// <summary>
        /// 在院标志
        /// </summary>
        public string HospFlag
        {
            get { return _hospflag; }
            set { _hospflag = value; }
        }
        #endregion

        #region 联网信息
        private string _persontype;
        /// <summary>
        /// 参保人员类别
        /// </summary>
        public string PersonType
        {
            get { return _persontype; }
            set { _persontype = value; }
        }

        private string _isinredlist;
        /// <summary>
        /// 是否在红名单
        /// </summary>
        public string IsInredList
        {
            get { return _isinredlist; }
            set { _isinredlist = value; }
        }

        private string _isspecifiedhosp;
        /// <summary>
        /// 本人定点医院状态 0:本地红名单，默认为本人定点医院； 1：是本人定点医院、A类医院、专科医院、中医医院；2：不是本人定点医院 3：转诊
        /// </summary>
        public string IsSpecifiedHosp
        {
            get { return _isspecifiedhosp; }
            set { _isspecifiedhosp = value; }
        }


        private string _ischronichosp;
        /// <summary>
        /// 是否本人慢病定点医院
        /// </summary>
        public string IsChronicHosp
        {
            get { return _ischronichosp; }
            set { _ischronichosp = value; }
        }

        private string _personcount;
        /// <summary>
        /// 个人帐户余额
        /// </summary>
        public string PersonCount
        {
            get { return _personcount; }
            set { _personcount = value; }
        }

        private string _chroniccode;
        /// <summary>
        /// 慢病编码
        /// </summary>
        public string ChronIcCode
        {
            get { return _chroniccode; }
            set { _chroniccode = value; }
        }
        #endregion

        private string _showMiPatInfo;
        /// <summary>
        /// 前台界面显示的病人信息内容
        /// </summary>
        public string ShowMiPatInfo
        {
            get { return _showMiPatInfo; }
            set { _showMiPatInfo = value; }
        }


    }

    
}
