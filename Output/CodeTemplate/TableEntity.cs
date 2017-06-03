using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace ${Entity.AppName}
{
    [Serializable]
    [Table(TableName = "${Entity.TableName}", EntityType = EntityType.Table, IsGB = false)]
    public class ${Entity.ClassName}:AbstractEntity
    {
#foreach($val in $Entity.Property) 
        private $val.TypeName $val.varName;
        /// <summary>
        /// $val.remarks
        /// </summary>
        [Column(FieldName = "$val.FieldName", DataKey = $val.DataKey, Match = "$val.Match", IsInsert = $val.IsInsert)]
        public $val.TypeName $val.PropertyName
        {
            get { return $val.varName; }
            set { $val.varName = value; }
        }

#end
    }
}
