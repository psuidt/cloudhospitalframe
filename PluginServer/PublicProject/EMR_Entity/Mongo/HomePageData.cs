using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.WcfFrame.Utility.Mongodb;

namespace EMR_Entity.Mongo
{
    public class HomePageData: AbstractMongoModel
    {
        public string  PageName { get; set; }

        public Byte[] homePageData { get; set; }

        public int workId { get; set; }
    }
}
