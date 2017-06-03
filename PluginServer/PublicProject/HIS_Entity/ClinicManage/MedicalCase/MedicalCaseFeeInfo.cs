using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_Entity.ClinicManage
{
    public class MedicalCaseFeeInfo
    {
        private Decimal _totalfee;
        /// <summary>
        /// 总金额-
        /// </summary>
        public Decimal TotalFee
        {
            get { return _totalfee; }
            set { _totalfee = value; }
        }

        private Decimal _selffee;
        /// <summary>
        /// 自付金额-
        /// </summary>
        public Decimal SelfFee
        {
            get { return _selffee; }
            set { _selffee = value; }
        }

        private Decimal 一般医疗服务费1;
        /// <summary>
        /// 一般医疗服务费-
        /// </summary>
        public Decimal 一般医疗服务费
        {
            get { return 一般医疗服务费1; }
            set { 一般医疗服务费1 = value; }
        }

        private Decimal 一般治疗操作费1;
        /// <summary>
        /// 一般治疗操作费-
        /// </summary>
        public Decimal 一般治疗操作费
        {
            get { return 一般治疗操作费1; }
            set { 一般治疗操作费1 = value; }
        }

        private Decimal 护理费1;
        /// <summary>
        /// 护理费1-
        /// </summary>
        public Decimal 护理费
        {
            get { return 护理费1; }
            set { 护理费1 = value; }
        }

        private Decimal 其他费用1;
        /// <summary>
        /// 其他费用-
        /// </summary>
        public Decimal 其他费用
        {
            get { return 其他费用1; }
            set { 其他费用1 = value; }
        }

        private Decimal 病理诊断费1;
        /// <summary>
        /// 病理诊断费-
        /// </summary>
        public Decimal 病理诊断费
        {
            get { return 病理诊断费1; }
            set { 病理诊断费1 = value; }
        }

        private Decimal 实验室诊断费1;
        /// <summary>
        /// 实验室诊断费-
        /// </summary>
        public Decimal 实验室诊断费
        {
            get { return 实验室诊断费1; }
            set { 实验室诊断费1 = value; }
        }

        private Decimal 影像学诊断费1;
        /// <summary>
        /// 影像学诊断费-
        /// </summary>
        public Decimal 影像学诊断费
        {
            get { return 影像学诊断费1; }
            set { 影像学诊断费1 = value; }
        }

        private Decimal 临床诊断项目费1;
        /// <summary>
        /// 临床诊断项目费-
        /// </summary>
        public Decimal 临床诊断项目费
        {
            get { return 临床诊断项目费1; }
            set { 临床诊断项目费1 = value; }
        }

        private Decimal 非手术治疗项目费1;
        /// <summary>
        /// 非手术治疗项目费-
        /// </summary>
        public Decimal 非手术治疗项目费
        {
            get { return 非手术治疗项目费1; }
            set { 非手术治疗项目费1 = value; }
        }

        private Decimal 临床物理治疗费1;
        /// <summary>
        /// 临床物理治疗费-
        /// </summary>
        public Decimal 临床物理治疗费
        {
            get { return 临床物理治疗费1; }
            set { 临床物理治疗费1 = value; }
        }

        private Decimal 手术治疗费1;
        /// <summary>
        /// 手术治疗费-
        /// </summary>
        public Decimal 手术治疗费
        {
            get { return 手术治疗费1; }
            set { 手术治疗费1 = value; }
        }

        private Decimal 麻醉费1;
        /// <summary>
        /// 麻醉费-
        /// </summary>
        public Decimal 麻醉费
        {
            get { return 麻醉费1; }
            set { 麻醉费1 = value; }
        }

        private Decimal 手术费1;
        /// <summary>
        /// 手术费-
        /// </summary>
        public Decimal 手术费
        {
            get { return 手术费1; }
            set { 手术费1 = value; }
        }

        private Decimal 康复费1;
        /// <summary>
        /// 康复费-
        /// </summary>
        public Decimal 康复费
        {
            get { return 康复费1; }
            set { 康复费1 = value; }
        }

        private Decimal 中医治疗费1;
        /// <summary>
        /// 中医治疗费-
        /// </summary>
        public Decimal 中医治疗费
        {
            get { return 中医治疗费1; }
            set { 中医治疗费1 = value; }
        }

        private Decimal 西药费1;
        /// <summary>
        /// 西药费-
        /// </summary>
        public Decimal 西药费
        {
            get { return 西药费1; }
            set { 西药费1 = value; }
        }

        private Decimal 抗菌药物费用1;
        /// <summary>
        /// 抗菌药物费用-
        /// </summary>
        public Decimal 抗菌药物费用
        {
            get { return 抗菌药物费用1; }
            set { 抗菌药物费用1 = value; }
        }

        private Decimal 中成药费1;
        /// <summary>
        /// 中成药费-
        /// </summary>
        public Decimal 中成药费
        {
            get { return 中成药费1; }
            set { 中成药费1 = value; }
        }

        private Decimal 中草药费1;
        /// <summary>
        /// 中草药费-
        /// </summary>
        public Decimal 中草药费
        {
            get { return 中草药费1; }
            set { 中草药费1 = value; }
        }

        private Decimal 血费1;
        /// <summary>
        /// 血费-
        /// </summary>
        public Decimal 血费
        {
            get { return 血费1; }
            set { 血费1 = value; }
        }

        private Decimal 白蛋白类制品费1;
        /// <summary>
        /// 白蛋白类制品费-
        /// </summary>
        public Decimal 白蛋白类制品费
        {
            get { return 白蛋白类制品费1; }
            set { 白蛋白类制品费1 = value; }
        }

        private Decimal 球蛋白类制品费1;
        /// <summary>
        /// 球蛋白类制品费-
        /// </summary>
        public Decimal 球蛋白类制品费
        {
            get { return 球蛋白类制品费1; }
            set { 球蛋白类制品费1 = value; }
        }

        private Decimal 凝血因子类制品费1;
        /// <summary>
        /// 凝血因子类制品费-
        /// </summary>
        public Decimal 凝血因子类制品费
        {
            get { return 凝血因子类制品费1; }
            set { 凝血因子类制品费1 = value; }
        }

        private Decimal 细胞因子类制品费1;
        /// <summary>
        /// 细胞因子类制品费-
        /// </summary>
        public Decimal 细胞因子类制品费
        {
            get { return 细胞因子类制品费1; }
            set { 细胞因子类制品费1 = value; }
        }

        private Decimal 检查用一次性医用材料费1;
        /// <summary>
        /// 检查用一次性医用材料费-
        /// </summary>
        public Decimal 检查用一次性医用材料费
        {
            get { return 检查用一次性医用材料费1; }
            set { 检查用一次性医用材料费1 = value; }
        }

        private Decimal 治疗用一次性医用材料费1;
        /// <summary>
        /// 治疗用一次性医用材料费-
        /// </summary>
        public Decimal 治疗用一次性医用材料费
        {
            get { return 治疗用一次性医用材料费1; }
            set { 治疗用一次性医用材料费1 = value; }
        }

        private Decimal 手术用一次性医用材料费1;
        /// <summary>
        /// 手术用一次性医用材料费-
        /// </summary>
        public Decimal 手术用一次性医用材料费
        {
            get { return 手术用一次性医用材料费1; }
            set { 手术用一次性医用材料费1 = value; }
        }

        private Decimal 其他费1;
        /// <summary>
        /// 其他费-
        /// </summary>
        public Decimal 其他费
        {
            get { return 其他费1; }
            set { 其他费1 = value; }
        }
        private Decimal _recurefee;
        /// <summary>
        /// 康复费用-
        /// </summary>
        public Decimal RecureFee
        {
            get { return _recurefee; }
            set { _recurefee = value; }
        }

        private Decimal _chinaTreatfee;
        /// <summary>
        /// 中医治疗费用-
        /// </summary>
        public Decimal ChinaMedialfee
        {
            get { return _chinaTreatfee; }
            set { _chinaTreatfee = value; }
        }

        private Decimal _westMedicalfee;
        /// <summary>
        /// 西药费用-
        /// </summary>
        public Decimal WestMedicalfee
        {
            get { return _westMedicalfee; }
            set { _westMedicalfee = value; }
        }

        private Decimal _antibacterialFee;
        /// <summary>
        /// 搞菌药物费用-
        /// </summary>
        public Decimal AntibacterialFee
        {
            get { return _antibacterialFee; }
            set { _antibacterialFee = value; }
        }

        private Decimal _patentFee;
        /// <summary>
        /// 中成药费用-
        /// </summary>
        public Decimal PatentFee
        {
            get { return _patentFee; }
            set { _patentFee = value; }
        }

        private Decimal _chinaMedicalFee;
        /// <summary>
        /// 中草药费用-
        /// </summary>
        public Decimal ChinaMedicalFee
        {
            get { return _chinaMedicalFee; }
            set { _chinaMedicalFee = value; }
        }
    }

    /// <summary>
    /// 综合医疗服务类
    /// </summary>
    public class MedicalCaseColligateFee
    {
        private Decimal _medicalServicefee;
        /// <summary>
        /// 一般医疗服务费-
        /// </summary>
        public Decimal MedicalServicefee
        {
            get { return _medicalServicefee; }
            set { _medicalServicefee = value; }
        }

        private Decimal _medicalCurefee;
        /// <summary>
        /// 一般治疗操作费
        /// </summary>
        public Decimal MedicalCurefee
        {
            get { return _medicalCurefee; }
            set { _medicalCurefee = value; }
        }

        private Decimal _medicalNusingfee;
        /// <summary>
        /// 护理费-
        /// </summary>
        public Decimal MedicalNusingfee
        {
            get { return _medicalNusingfee; }
            set { _medicalNusingfee = value; }
        }

        private Decimal _otherFee;
        /// <summary>
        /// 其他费-
        /// </summary>
        public Decimal OtherFee
        {
            get { return _otherFee; }
            set { _otherFee = value; }
        }
    }

    /// <summary>
    /// 诊断类费用
    /// </summary>
    public class MedicalCaseDiagnoseFee
    {
        private Decimal _pathoFee;
        /// <summary>
        /// 病理诊断费-
        /// </summary>
        public Decimal PathoFee
        {
            get { return _pathoFee; }
            set { _pathoFee = value; }
        }

        private Decimal _laboratoryFee;
        /// <summary>
        /// 实验室诊断费-
        /// </summary>
        public Decimal LaboratoryFee
        {
            get { return _laboratoryFee; }
            set { _laboratoryFee = value; }
        }

        private Decimal _iconographyFee;
        /// <summary>
        /// 影象学诊断费-
        /// </summary>
        public Decimal IconographyFee
        {
            get { return _iconographyFee; }
            set { _iconographyFee = value; }
        }

        private Decimal _clinicItemFee;
        /// <summary>
        /// 临床诊断项目费-
        /// </summary>
        public Decimal ClinicItemFee
        {
            get { return _clinicItemFee; }
            set { _clinicItemFee = value; }
        }
    }

    /// <summary>
    /// 治疗类费用
    /// </summary>
    public class MedicalCaseTreatFee
    {
        private Decimal _notOperationFee;
        /// <summary>
        /// 非手术治疗费-
        /// </summary>
        public Decimal NotOperationFee
        {
            get { return _notOperationFee; }
            set { _notOperationFee = value; }
        }

        private Decimal _clinicPysicalFee;
        /// <summary>
        /// 临床物理费
        /// </summary>
        public Decimal ClinicPysicalFee
        {
            get { return _clinicPysicalFee; }
            set { _clinicPysicalFee = value; }
        }

        private Decimal _operationTreatFee;
        /// <summary>
        /// 手术治疗费-
        /// </summary>
        public Decimal OperationTreatFee
        {
            get { return _operationTreatFee; }
            set { _operationTreatFee = value; }
        }

        private Decimal _operationFee;
        /// <summary>
        /// 手术费-
        /// </summary>
        public Decimal OperationFee
        {
            get { return _operationFee; }
            set { _operationFee = value; }
        }

        private Decimal _anaesthesiaFee;
        /// <summary>
        /// 麻醉费-
        /// </summary>
        public Decimal AnaesthesiaFee
        {
            get { return _anaesthesiaFee; }
            set { _anaesthesiaFee = value; }
        }      
    }
}
