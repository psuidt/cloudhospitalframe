using EfwControls.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.Common
{
    /// <summary>
    /// 客户端配置文件操作类
    /// </summary>
    public class CustomConfigManager
    {
        private static string AppRootPath = EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath;
        public static System.Xml.XmlDocument xmlDoc = null;

        public static void LoadConfig()
        {
            xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(AppRootPath + @"Config/CustomConfig.xml");
        }

        public static int GetMainStyle()
        {
            if (xmlDoc == null) LoadConfig();
            return Convert.ToInt32(xmlDoc.DocumentElement.SelectNodes("mainStyle")[0].Attributes["value"].Value);
        }

        public static int GetInputMethod(EN_CH ench)
        {
            if (xmlDoc == null) LoadConfig();
            try
            {
                if (ench == EN_CH.CH)
                    return Convert.ToInt32(xmlDoc.DocumentElement.SelectNodes("inputMethod")[0].Attributes["CH"].Value);
                else if (ench == EN_CH.EN)
                    return Convert.ToInt32(xmlDoc.DocumentElement.SelectNodes("inputMethod")[0].Attributes["EN"].Value);
                else
                    return -1;
            }
            catch
            {
                return -1;
            }
        }

        public static int GetDisplayWay()
        {
            if (xmlDoc == null) LoadConfig();
            return Convert.ToInt32(xmlDoc.DocumentElement.SelectNodes("displayWay")[0].Attributes["value"].Value);
        }

        public static int GetPrinter(int type)
        {
            if (xmlDoc == null) LoadConfig();
            return Convert.ToInt32(xmlDoc.DocumentElement.SelectNodes("printer")[0].Attributes[type].Value);
        }
        /// <summary>
        /// 获取打印机名称
        /// </summary>
        /// <param name="type">0：打印机（1） 1：打印机（2） 2：打印机（3）</param>
        /// <returns></returns>
        public static string GetPrintName(int type)
        {
            int index = GetPrinter(type);
            //打印机
            ManagementObjectSearcher query;
            ManagementObjectCollection queryCollection;
            string _classname = "SELECT * FROM Win32_Printer";

            query = new ManagementObjectSearcher(_classname);
            queryCollection = query.Get();
            int i = 0;
            foreach (ManagementObject mo in queryCollection)
            {
                if (i == index)
                {
                    return mo["Name"].ToString();
                }
                i++;
            }
            return "";
        }

        public static int GetrunacceptMessage()
        {
            if (xmlDoc == null) LoadConfig();
            return Convert.ToInt32(xmlDoc.DocumentElement.SelectNodes("message")[0].Attributes["runaccept"].Value);
        }

        public static string GetBackgroundImage()
        {
            if (xmlDoc == null) LoadConfig();
            return xmlDoc.DocumentElement.SelectNodes("backgroundimage")[0].Attributes["path"].Value;
        }

        public static void SaveConfig(int ENIndex, int CHIndex, int printfirst, int printsecond, int printthree, int runaccept, int displayway, string path, int mainStyle)
        {
            if (xmlDoc == null) LoadConfig();

            xmlDoc.DocumentElement.SelectNodes("mainStyle")[0].Attributes["value"].Value = mainStyle.ToString();
            xmlDoc.DocumentElement.SelectNodes("inputMethod")[0].Attributes["CH"].Value = CHIndex.ToString();
            xmlDoc.DocumentElement.SelectNodes("inputMethod")[0].Attributes["EN"].Value = ENIndex.ToString();

            xmlDoc.DocumentElement.SelectNodes("printer")[0].Attributes["first"].Value = printfirst.ToString();
            xmlDoc.DocumentElement.SelectNodes("printer")[0].Attributes["second"].Value = printsecond.ToString();
            xmlDoc.DocumentElement.SelectNodes("printer")[0].Attributes["three"].Value = printthree.ToString();

            xmlDoc.DocumentElement.SelectNodes("message")[0].Attributes["runaccept"].Value = runaccept.ToString();
            xmlDoc.DocumentElement.SelectNodes("displayWay")[0].Attributes["value"].Value = displayway.ToString();

            xmlDoc.DocumentElement.SelectNodes("backgroundimage")[0].Attributes["path"].Value = path;

            xmlDoc.Save(AppRootPath + @"Config/CustomConfig.xml");
        }
    }
}
