using EfwControls.Common;
using EfwControls.HISControl.Emr.Controls.IView;
using EMR_Entity.BasicData;
using EMR_Entity.HomePage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.Emr.Controls.Controller
{
   public class MedicalCaseControlController
    {
        private IMedicalCaseControlView iview;

        public MedicalCaseControlController(IMedicalCaseControlView _view)
        {
            iview = _view;
        }

        /// <summary>
        /// 保存首页内容和首页记录
        /// </summary>
        /// <param name="stream">首页内容</param>
        /// <returns></returns>
        public bool SaveMedicalCase(MemoryStream stream)
        {
            //先调用mogodb保存获取mogoID
            MedicalCaseDbHelper helper = new MedicalCaseDbHelper();
            string mogoCaseid= helper.SaveMedicalCaseFile(stream);

            //再EMR库实体保存
            if (!string.IsNullOrEmpty(mogoCaseid))
            {
                Emr_CaseRecord caseRecord = iview.curCaseRecord;
                if (caseRecord.CaseRecordID == 0)
                {
                    caseRecord.PatListID = iview.CurrPatListId;
                    caseRecord.CreateTime = DateTime.Now;
                    caseRecord.CreateUserID = iview.EmpId;
                    caseRecord.CreateUserName = iview.EmpName;
                    caseRecord.CreateDeptID = iview.PatDeptID;
                    caseRecord.CreateDeptName = iview.PatDeptName;
                    caseRecord.DeleteStatus = 0;
                    caseRecord.UploadStatus = 0;
                    caseRecord.UpdateUserID = iview.EmpId;
                    caseRecord.UpdateUserName = iview.EmpName;
                    caseRecord.UpdateTime = caseRecord.CreateTime;
                    caseRecord.MongoCaseID = mogoCaseid;
                }
                else
                {
                    caseRecord.UpdateUserID = iview.EmpId;
                    caseRecord.UpdateUserName = iview.EmpName;
                    caseRecord.UpdateTime = DateTime.Now;
                    caseRecord.MongoCaseID = mogoCaseid;
                }
                helper.SaveMedicalCaseRecord(caseRecord);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 打开病案首页内容
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <returns></returns>
        public StreamReader OpenFile(int patlistid)
        {
            MedicalCaseDbHelper helper = new MedicalCaseDbHelper();
            Emr_CaseRecord caseRecord = new Emr_CaseRecord();
            StreamReader stream= helper.GetMedicalCaseFile(patlistid,out caseRecord);
            iview.curCaseRecord = caseRecord;
            return stream;
        }

        /// <summary>
        /// 获取绑定数据源信息
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <returns>病人信息数据</returns>
        public MedicalCasePatient GetCasePatInfoDataSource(int patlistid)
        {
            MedicalCaseDbHelper helper = new MedicalCaseDbHelper();
            MedicalCasePatient casePatInfo = helper.GetCasePatient(patlistid);
            AgeValue ageValue = AgeExtend.GetAgeValue(casePatInfo.Birthday, casePatInfo.EnterHDate);
            casePatInfo.Age = "0";
            if (ageValue.Y_num > 0)
            {
                casePatInfo.Age = ageValue.Y_num.ToString();
            }
            else
            {
                casePatInfo.BirthDays=( ageValue.M_num * 30 + ageValue.D_num)/30;
            }
            return casePatInfo;
        }

        /// <summary>
        /// 获取绑定数据源信息
        /// </summary>
        /// <param name="patlistid">病人ID</param>
        /// <returns>病人信息数据</returns>
        public MedicalCaseDiagoInfo GetCaseDiagInfo(int patlistid)
        {
            MedicalCaseDbHelper helper = new MedicalCaseDbHelper();
            MedicalCaseDiagoInfo caseDiagInfo = helper.GetCaseDiagInfo(patlistid);           
            return caseDiagInfo;
        }
    }
}
