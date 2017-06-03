using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.WcfFrame.Utility.Mongodb;

namespace HIS_Entity.Mongo
{
    public class EmrPatData: AbstractMongoModel
    {
        public string emrName { get; set; }

        public Byte[] emrData { get; set; }

        public int workId { get; set; }
    }
}
