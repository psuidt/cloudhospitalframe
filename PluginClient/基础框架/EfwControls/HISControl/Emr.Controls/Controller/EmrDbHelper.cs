using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.WcfFrame.DataSerialize;
using HIS_Entity.Mongo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EfwControls.HISControl.Emr.Controls.Controller
{
    class EmrDbHelper: WcfClientController,IEmrDbHelper
    {
        string emrid = null;
        [WinformMethod]
        public string SaveEmrFile(Stream stream)
        {
            EmrPatData data = new EmrPatData();
            data.emrName = "入院记录";
            data.emrData = StreamToBytes(stream); stream.Close();
            data.workId = 1;
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(data);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRMongoDB.Service", "EMRStoreController", "SaveEmr", requestAction);
            if (retdata.GetData<bool>(0))
            {
                return retdata.GetData<string>(1);
                //MessageBox.Show(emrid);
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

        [WinformMethod]
        public StreamReader GetEmrFile(string emrid)
        {
         
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(emrid);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRMongoDB.Service", "EMRStoreController", "GetEmr", requestAction);
            if (retdata.GetData<bool>(0))
            {
                EmrPatData data = retdata.GetData<EmrPatData>(1);
                return BytesToStream(data.emrData);
            }
            else
            {
                return null;
            }
        }
    }
}
