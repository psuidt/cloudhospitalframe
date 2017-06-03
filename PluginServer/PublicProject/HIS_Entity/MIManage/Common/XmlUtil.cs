using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HIS_Entity.MIManage.Common
{
    public class XmlUtil
    {
        //序列化
        //接收4个参数:srcObject(对象的实例),type(对象类型),xmlFilePath(序列化之后的xml文件的绝对路径),xmlRootName(xml文件中根节点名称)
        //当需要将多个对象实例序列化到同一个XML文件中的时候,xmlRootName就是所有对象共同的根节点名称,如果不指定,.net会默认给一个名称(ArrayOf+实体类名称)
        public static void SerializeToXmlPath(object srcObject, Type type, string xmlFilePath, string xmlRootName)
        {
            if (srcObject != null && !string.IsNullOrEmpty(xmlFilePath))
            {
                type = type != null ? type : srcObject.GetType();

                using (StreamWriter sw = new StreamWriter(xmlFilePath))
                {
                    XmlSerializer xs = string.IsNullOrEmpty(xmlRootName) ?
                        new XmlSerializer(type) :
                        new XmlSerializer(type, new XmlRootAttribute(xmlRootName));
                    xs.Serialize(sw, srcObject);
                }
            }
        }

        public static string SerializeToXml(object srcObject, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            StringWriter sw = new StringWriter();
            serializer.Serialize(sw, srcObject);
            string s = sw.ToString();
            sw.Close();
            return s;
        }
        //反序列化
        //接收2个参数:xmlFilePath(需要反序列化的XML文件的绝对路径),type(反序列化XML为哪种对象类型)
        public static object DeserializeFromXmlPath(string xmlFilePath, Type type)
        {
            object result = null;
            if (File.Exists(xmlFilePath))
            {
                using (StreamReader reader = new StreamReader(xmlFilePath))
                {
                    XmlSerializer xs = new XmlSerializer(type);
                    result = xs.Deserialize(reader);
                }
            }
            return result;
        }

        //反序列化
        //接收2个参数:xmlFilePath(需要反序列化的XML文件的绝对路径),type(反序列化XML为哪种对象类型)
        public static object DeserializeFromXml(string sXml, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            StringWriter sw = new StringWriter();
            StringReader sr = new StringReader(sXml);

            object ob = serializer.Deserialize(sr);
            return ob;
        }

    }
}
