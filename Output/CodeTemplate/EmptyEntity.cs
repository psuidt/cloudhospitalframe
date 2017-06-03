using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreFrame.Core.Orm;

namespace ${Entity.AppName}.Manager.BusinesEntity
{
    [Serializable]
    [Table(TableName = "${Entity.TableName}", EntityType = EntityType.Table, IsGB = false)]
    public abstract class ${Entity.ClassName}:CoreFrame.Business.AbstractBusines
    {
#foreach($val in $Entity.Property) 
        private $val.TypeName $val.varName;
        /// <summary>
        /// $val.remarks
        /// </summary>
        [Column(FieldName = "$val.FieldName", DataKey = $val.DataKey, IsSingleQuote = $val.IsSingleQuote, Match = "$val.Match", IsInsert = $val.IsInsert)]
        public $val.TypeName $val.PropertyName
        {
            get { return $val.varName; }
            set { $val.varName = value; }
        }

#end
    }
}
