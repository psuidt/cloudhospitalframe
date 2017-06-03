using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMR_Entity.HomePage
{
    /// <summary>
    /// 其他相关信息
    /// </summary>
    public class MedicalCaseOtherInfo
    {
        private string _sszdwbyy;
        /// <summary>
        /// 损伤中毒外部原因
        /// </summary>
        public string SszdWbyy
        {
            get { return _sszdwbyy; }
            set { _sszdwbyy = value; }
        }

        private string _sszdwbyyCode;
        /// <summary>
        /// 损伤中毒外部原因疾病编码
        /// </summary>
        public string SszdWbyyCode
        {
            get { return _sszdwbyyCode; }
            set { _sszdwbyyCode = value; }
        }

        private string _blzd;
        /// <summary>
        /// 病理诊断
        /// </summary>
        public string Blzd
        {
            get { return _blzd; }
            set { _blzd = value; }
        }

        private string _blzdCode;
        /// <summary>
        /// 病理诊断编码
        /// </summary>
        public string BlzdCode
        {
            get { return _blzdCode; }
            set { _blzdCode = value; }
        }

        private string _blh;
        /// <summary>
        /// 病理号
        /// </summary>
        public string Blh
        {
            get { return _blh; }
            set { _blh = value; }
        }

        private string _ywgm;
        /// <summary>
        /// 药物过敏
        /// </summary>
        public string Ywgm
        {
            get { return _ywgm; }
            set { _ywgm = value; }
        }

        private string _ywgmDrug;
        /// <summary>
        /// 药物过敏药物
        /// </summary>
        public string YwgmDrug
        {
            get { return _ywgmDrug; }
            set { _ywgmDrug = value; }
        }

        private string _swhzsj;
        /// <summary>
        /// 死亡患者尸检
        /// </summary>
        public string Swhzsj
        {
            get { return _swhzsj; }
            set { _swhzsj = value; }
        }

        private string _bloodType;
        /// <summary>
        /// 血型
        /// </summary>
        public string BloodType
        {
            get { return _bloodType; }
            set { _bloodType = value; }
        }


        private string _rh;
        /// <summary>
        /// RH
        /// </summary>
        public string RH
        {
            get { return _rh; }
            set { _rh = value; }
        }

        private string _kzr;
        /// <summary>
        /// 科主任
        /// </summary>
        public string KZR
        {
            get { return _kzr; }
            set { _kzr = value; }
        }

        private string _kzrDoc;
        /// <summary>
        /// 主任(副主任)医生
        /// </summary>
        public string KZRDoc
        {
            get { return _kzrDoc; }
            set { _kzrDoc = value; }
        }

        private string _zzys;
        /// <summary>
        /// 主治医生
        /// </summary>
        public string Zzys
        {
            get { return _zzys; }
            set { _zzys = value; }
        }

        private string _zyys;
        /// <summary>
        /// 住院医生
        /// </summary>
        public string Zyys
        {
            get { return _zyys; }
            set { _zyys = value; }
        }

        private string _zrNurse;
        /// <summary>
        /// 住院护士
        /// </summary>
        public string ZrNurse
        {
            get { return _zrNurse; }
            set { _zrNurse = value; }
        }

        private string _jxys;
        /// <summary>
        /// 进修医生
        /// </summary>
        public string Jxys
        {
            get { return _jxys; }
            set { _jxys = value; }
        }

        private string _sxys;
        /// <summary>
        /// 实习医生
        /// </summary>
        public string Sxys
        {
            get { return _sxys; }
            set { _sxys = value; }
        }

        private string _bmy;
        /// <summary>
        /// 编码员
        /// </summary>
        public string Bmy
        {
            get { return _bmy; }
            set { _bmy = value; }
        }

        private string _bazl;
        /// <summary>
        /// 病案质量
        /// </summary>
        public string Bazl
        {
            get { return _bazl; }
            set { _bazl = value; }
        }

        private string _zkys;
        /// <summary>
        /// 质控医生
        /// </summary>
        public string Zkys
        {
            get { return _zkys; }
            set { _zkys = value; }
        }

        private string _zkNurse;
        /// <summary>
        /// 质控护士
        /// </summary>
        public string ZkNurse
        {
            get { return _zkNurse; }
            set { _zkNurse = value; }
        }

        private string _zkDate;
        /// <summary>
        /// 质控日期
        /// </summary>
        public string ZkDate
        {
            get { return _zkDate; }
            set { _zkDate = value; }
        }

        private string _lyfs;
        /// <summary>
        /// 离院方式
        /// </summary>
        public string Lyfs
        {
            get { return _lyfs; }
            set { _lyfs = value; }
        }

        private string _njsyljgmc;
        /// <summary>
        /// 拟接收医疗机构名称
        /// </summary>
        public string Njsyljgmc
        {
            get { return _njsyljgmc; }
            set { _njsyljgmc = value; }
        }

        private string _njsyljgmc1;
        /// <summary>
        /// 拟接收医疗机构名称
        /// </summary>
        public string Njsyljgmc1
        {
            get { return _njsyljgmc1; }
            set { _njsyljgmc1 = value; }
        }

        private string _inHosAgain;
        /// <summary>
        /// 是否有31天再入院计划
        /// </summary>
        public string InHosAgain
        {
            get { return _inHosAgain; }
            set { _inHosAgain = value; }
        }

        private string _purpose;
        /// <summary>
        /// 目的
        /// </summary>
        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }

        private string _beginInDays;
        /// <summary>
        /// 颅脑昏迷入院前天数
        /// </summary>
        public string BeginInDays
        {
            get { return _beginInDays; }
            set { _beginInDays = value; }
        }


        private string _beginInHours;
        /// <summary>
        /// 颅脑昏迷入院前小时
        /// </summary>
        public string BeginInHours
        {
            get { return _beginInHours; }
            set { _beginInHours = value; }
        }

        private string _beginInMinites;
        /// <summary>
        /// 颅脑昏迷入院前分钟
        /// </summary>
        public string BeginInMinites
        {
            get { return _beginInMinites; }
            set { _beginInMinites = value; }
        }

        private string _afterInDays;
        /// <summary>
        /// 颅脑昏迷入院后天数
        /// </summary>
        public string AfterInDays
        {
            get { return _afterInDays; }
            set { _afterInDays = value; }
        }


        private string _afterInHours;
        /// <summary>
        /// 颅脑昏迷入院后小时
        /// </summary>
        public string AfterInHours
        {
            get { return _afterInHours; }
            set { _afterInHours = value; }
        }

        private string _afterInMinites;
        /// <summary>
        /// 颅脑昏迷入院后分钟
        /// </summary>
        public string AfterInMinites
        {
            get { return _afterInMinites; }
            set { _afterInMinites = value; }
        }
    }
}
