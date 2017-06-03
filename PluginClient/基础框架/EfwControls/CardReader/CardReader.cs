using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfwControls.CardReader
{
    public class CardReader
    {
        private static System.Xml.XmlDocument xmlDoc = null;
        private static string configfile = System.Windows.Forms.Application.StartupPath + "\\ModulePlugin\\MIService\\ActionMapping.xml";
        private static void InitConfig()
        {
            xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(configfile);
        }

        public static List<ActionObjectMapping> getActionList()
        {
            if (xmlDoc == null) InitConfig();

            List<ActionObjectMapping> _List = new List<ActionObjectMapping>();
            System.Xml.XmlNodeList xnlist = xmlDoc.DocumentElement.SelectNodes("ActionMapping/action");
            foreach (System.Xml.XmlNode n in xnlist)
            {
                ActionObjectMapping action = new ActionObjectMapping();
                action.Name = n.Attributes["name"].Value;
                action.ObjectName = n.Attributes["actionclass"].Value;
                _List.Add(action);
            }
            return _List;
        }
     
    }        

    public class ActionObjectMapping
    {
        public string Name { get; set; }
        public string ObjectName { get; set; }
    }

    public enum CardType
    {
        会员卡,
        医保卡
    }
}
