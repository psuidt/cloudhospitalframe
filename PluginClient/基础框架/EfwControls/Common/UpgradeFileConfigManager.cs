using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EfwControls.Common
{
    /// <summary>
    /// 升级文件配置管理
    /// </summary>
    public class UpgradeFileConfigManager
    {
        private static string AppRootPath = EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath;
        public static System.Xml.XmlDocument xmlDoc = null;

        public static void LoadConfig()
        {
            xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(AppRootPath + @"Config/UpgradeFileConfig.xml");
        }
        /// <summary>
        /// 获取报表的更新时间
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static DateTime? GetReportUpdateTime(string filename)
        {
            if (xmlDoc == null) LoadConfig();
            System.Xml.XmlNodeList nodelist = xmlDoc.SelectNodes("/root/reportfile/item[@filename='" + filename + "']");

            if (nodelist.Count > 0)
                return Convert.ToDateTime(nodelist[0].Attributes["updatetime"].Value);
            return null;
        }
        /// <summary>
        /// 设置报表更新时间
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static void SetReportUpdateTime(string filename,DateTime updatetime)
        {
            if (xmlDoc == null) LoadConfig();
            System.Xml.XmlNodeList nodelist = xmlDoc.SelectNodes("/root/reportfile/item[@filename='" + filename + "']");

            if (nodelist.Count > 0)
            {
                nodelist[0].Attributes["updatetime"].Value = updatetime.ToString("yyyy-MM-dd HH:mm:ss");
                xmlDoc.Save(AppRootPath + @"Config/UpgradeFileConfig.xml");
            }
        }
        /// <summary>
        /// 获取程序文件的更新时间
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DateTime? GetProgramUpdateTime(string filename, string path)
        {
            if (xmlDoc == null) LoadConfig();
            System.Xml.XmlNodeList nodelist = xmlDoc.SelectNodes("/root/programfile/item[@filename='" + filename + "'][@filepath='" + path + "']");

            if (nodelist.Count > 0)
                return Convert.ToDateTime(nodelist[0].Attributes["updatetime"].Value);
            return null;
        }

        /// <summary>
        /// 设置程序文件的更新时间
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="path"></param>
        /// <param name="updatetitme"></param>
        public static void SetProgramUpdateTime(string filename, string path, DateTime updatetime)
        {
            if (xmlDoc == null) LoadConfig();
            System.Xml.XmlNodeList nodelist = xmlDoc.SelectNodes("/root/programfile/item[@filename='" + filename + "'][@filepath='" + path + "']");

            if (nodelist.Count > 0)
            {
                nodelist[0].Attributes["updatetime"].Value = updatetime.ToString("yyyy-MM-dd HH:mm:ss");
                xmlDoc.Save(AppRootPath + @"Config/UpgradeFileConfig.xml");
            }
        }
        /// <summary>
        /// 增加报表
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="updatetime"></param>
        /// <param name="path"></param>
        public static void AddReport(string filename,DateTime updatetime)
        {
            if (xmlDoc == null) LoadConfig();
            System.Xml.XmlNodeList nodelist = xmlDoc.SelectNodes("/root/reportfile/item[@filename='" + filename + "']");

            if (nodelist.Count > 0)
            {
                nodelist[0].Attributes["updatetime"].Value = updatetime.ToString("yyyy-MM-dd HH:mm:ss");
                xmlDoc.Save(AppRootPath + @"Config/UpgradeFileConfig.xml");
            }
            else
            {
                XmlNode file= xmlDoc.SelectSingleNode("/root/reportfile");
                XmlElement xe1 = xmlDoc.CreateElement("item");//
                xe1.SetAttribute("filename", filename);//
                xe1.SetAttribute("updatetime", updatetime.ToString("yyyy-MM-dd HH:mm:ss"));//  
                xe1.SetAttribute("filepath", "");//
                file.AppendChild(xe1);
                xmlDoc.Save(AppRootPath + @"Config/UpgradeFileConfig.xml");
            }
        }
        /// <summary>
        /// 增加程序文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="updatetime"></param>
        /// <param name="path"></param>
        public static void AddProgram(string filename,DateTime updatetime,string path)
        {
            if (xmlDoc == null) LoadConfig();
            System.Xml.XmlNodeList nodelist = xmlDoc.SelectNodes("/root/programfile/item[@filename='" + filename + "'][@filepath='" + path + "']");

            if (nodelist.Count > 0)
            {
                nodelist[0].Attributes["updatetime"].Value = updatetime.ToString("yyyy-MM-dd HH:mm:ss");
                xmlDoc.Save(AppRootPath + @"Config/UpgradeFileConfig.xml");
            }
            else
            {
                XmlNode file = xmlDoc.SelectSingleNode("/root/programfile");
                XmlElement xe1 = xmlDoc.CreateElement("item");//
                xe1.SetAttribute("filename", filename);//
                xe1.SetAttribute("updatetime", updatetime.ToString("yyyy-MM-dd HH:mm:ss"));//  
                xe1.SetAttribute("filepath", path);//
                file.AppendChild(xe1);
                xmlDoc.Save(AppRootPath + @"Config/UpgradeFileConfig.xml");
            }
        }
    }
}
