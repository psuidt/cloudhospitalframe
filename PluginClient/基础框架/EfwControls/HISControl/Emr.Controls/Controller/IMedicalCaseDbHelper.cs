using EMR_Entity.BasicData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using EMR_Entity.HomePage;

namespace EfwControls.HISControl.Emr.Controls.Controller
{
    interface IMedicalCaseDbHelper
    {
        /// <summary>
        /// 获取病案记录
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        StreamReader GetMedicalCaseFile(int patlistid,out Emr_CaseRecord caseRecord);

        /// <summary>
        /// 保存病案内容
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        string SaveMedicalCaseFile(Stream stream);

        /// <summary>
        /// 保存病案记录
        /// </summary>
        /// <param name="caseRecord"></param>
        void SaveMedicalCaseRecord(Emr_CaseRecord caseRecord);

        /// <summary>
        /// 获取绑定数据源信息
        /// </summary>
        /// <param name="patlistID">病人Id</param>
        /// <returns>数据源信息</returns>
        DataSet GetCaseDataSource(int patlistID);

        /// <summary>
        /// 获取病案首页病人信息
        /// </summary>
        /// <param name="patlistID">病人Id</param>
        /// <returns>病人对象</returns>
        MedicalCasePatient GetCasePatient(int patlistID);

        /// <summary>
        /// 获取病案首页诊断信息
        /// </summary>
        /// <param name="patlistID">病人Id</param>
        /// <returns>诊断信息</returns>
        MedicalCaseDiagoInfo GetCaseDiagInfo(int patlistID);
    }
}
