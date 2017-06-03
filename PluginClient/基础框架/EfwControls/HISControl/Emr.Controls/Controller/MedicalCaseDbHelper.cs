using EFWCoreLib.WcfFrame.ClientController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EMR_Entity.Mongo;
using EMR_Entity.BasicData;
using System.Data;
using EMR_Entity.HomePage;

namespace EfwControls.HISControl.Emr.Controls.Controller
{
   public class MedicalCaseDbHelper : WcfClientController, IMedicalCaseDbHelper
    {
        [WinformMethod]
        public StreamReader GetMedicalCaseFile(int patlistid,out  Emr_CaseRecord caseRecord)
        {
            caseRecord = new Emr_CaseRecord();
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(patlistid);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRDocProject.Service", "HomePageController", "GetCaseRecord", requestAction);
            List<Emr_CaseRecord> list = retdata.GetData<List<Emr_CaseRecord>>(0);
            if (list.Count > 0)
            {
                caseRecord = list[0];
                requestAction = ((ClientRequestData request) =>
                {
                    request.AddData(list[0].MongoCaseID);
                });
                retdata = InvokeWcfService("EMRMongoDB.Service", "HomePageStoreController", "GetMedicalCase", requestAction);
                if (retdata.GetData<bool>(0))
                {
                    HomePageData data = retdata.GetData<HomePageData>(1);
                    if (data == null || data.homePageData == null)
                    {
                        return null;
                    }
                    else
                    {
                        return BytesToStream(data.homePageData);
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        private byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        private StreamReader BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            StreamReader reader = new StreamReader(stream);
            return reader;

        }

        /// <summary>
        /// 保存病案首页内容
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public string SaveMedicalCaseFile(Stream stream)
        {
            HomePageData data = new HomePageData();
            data.PageName = "病案首页";
            data.homePageData = StreamToBytes(stream); stream.Close();
            data.workId = LoginUserInfo.WorkId;
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(data);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRMongoDB.Service", "HomePageStoreController", "SaveMedicalCase", requestAction);
            if (retdata.GetData<bool>(0))
            {
                return retdata.GetData<string>(1);
            }
            return null;
        }

        /// <summary>
        /// 保存病案首页记录
        /// </summary>
        /// <param name="caseRecord"></param>
        public void SaveMedicalCaseRecord(Emr_CaseRecord caseRecord)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(caseRecord);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRDocProject.Service", "HomePageController", "SaveCaseRecord", requestAction);           
        }

        public DataSet GetCaseDataSource(int patlistID)
        {
            DataSet ds= new DataSet();
            return ds;
        }

        /// <summary>
        /// 获取病案首页病人信息
        /// </summary>
        /// <param name="patlistID">病人Id</param>
        /// <returns>病人对象</returns>
        public MedicalCasePatient GetCasePatient(int patlistID)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(patlistID);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRDocProject.Service", "HomePageController", "GetCasePatientInfo", requestAction);
            MedicalCasePatient pat = retdata.GetData<MedicalCasePatient>(0);
            return pat;
        }

        /// <summary>
        /// 获取病案首页诊断信息
        /// </summary>
        /// <param name="patlistID">病人Id</param>
        /// <returns>诊断信息</returns>
        public MedicalCaseDiagoInfo GetCaseDiagInfo(int patlistID)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(patlistID);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRDocProject.Service", "HomePageController", "GetCaseDiagInfo", requestAction);
            MedicalCaseDiagoInfo diagInfo = retdata.GetData<MedicalCaseDiagoInfo>(0);
            return diagInfo;
        }
    }
}
