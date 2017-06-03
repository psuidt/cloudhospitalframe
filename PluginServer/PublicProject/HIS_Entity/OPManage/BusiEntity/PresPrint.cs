using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.OPManage.BusiEntity
{
    /// <summary>
    /// 处方打印对象模型
    /// </summary>
    public class PresPrint
    {
        /// <summary>
        /// 类别
        /// </summary>
        string _types;
        public string Types
        {
            get { return _types; }
            set { _types = value; }
        }
        /// <summary>
        /// 病人类型
        /// </summary>
        string _patType;
        public string PatType
        {
            get{ return _patType;}
            set{_patType = value;}
        }
        /// <summary>
        /// 病人姓名
        /// </summary>
        string _patName;
        public string PatName
        {
            get { return _patName; }
            set { _patName = value; }
        }
        /// <summary>
        /// 门诊号
        /// </summary>
        string _visitNO;
        public string VisitNO
        {
            get { return _visitNO; }
            set { _visitNO = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        string _sex;
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        string _age;
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
        /// <summary>
        /// 诊断
        /// </summary>
        string _diagnosis;
        public string Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        string _telPhone;
        public string TelPhone
        {
            get { return _telPhone; }
            set { _telPhone = value; }
        }
        /// <summary>
        /// 处方号
        /// </summary>
        string _presNO;
        public string PresNO
        {
            get { return _presNO; }
            set { _presNO = value; }
        }
        /// <summary>
        /// 处方类型
        /// </summary>
        string _presType;
        public string PresType
        {
            get { return _presType; }
            set { _presType = value; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        string _totalFee;
        public string TotalFee
        {
            get { return _totalFee; }
            set { _totalFee = value; }
        }
        /// <summary>
        /// 机构名称
        /// </summary>
        string _workerName;
        public string WorkerName
        {
            get { return _workerName; }
            set { _workerName = value; }
        }
        /// <summary>
        /// 科室名称
        /// </summary>
        string _deptName;
        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }
        /// <summary>
        /// 处方时间
        /// </summary>
        string _presDate;
        public string PresDate
        {
            get { return _presDate; }
            set { _presDate = value; }
        }
        /// <summary>
        /// 医生名称
        /// </summary>
        string _doctorName;
        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }
        /// <summary>
        /// 用法
        /// </summary>
        string _channelName;
        public string ChannelName
        {
            get { return _channelName; }
            set { _channelName = value; }
        }
        /// <summary>
        /// 频次
        /// </summary>
        string _frequencyName;
        public string FrequencyName
        {
            get { return _frequencyName; }
            set { _frequencyName = value; }
        }
        /// <summary>
        /// 剂量
        /// </summary>
        string _doseNum;
        public string DoseNum
        {
            get { return _doseNum; }
            set { _doseNum = value; }
        }
        /// <summary>
        /// 打印类型
        /// </summary>
        string _printType;
        public string PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// <summary>
        /// 机构ID
        /// </summary>
        string _workerId;
        public string WorkerID
        {
            get { return _workerId; }
            set { _workerId = value; }
        }
        /// <summary>
        /// 等级
        /// </summary>
        string _level;
        public string Level
        {
            get { return _level; }
            set { _level = value; }
        }
        /// <summary>
        /// 病人ID
        /// </summary>
        string _patid;
        public string PatId
        {
            get { return _patid; }
            set { _patid = value; }
        }
    }
}
