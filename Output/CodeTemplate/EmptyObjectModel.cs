using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ${Class.AppName}.Manager.BusinesEntity;
using ${Class.AppName}.Manager.Dao;

namespace ${Class.AppName}.Manager.ObjectModel
{
    public class ${Class.ClassName} : ${Class.EntityName}
    {
        private ${Class.DaoName} ${Class.varDao} = null;

        public ${Class.ClassName}()
        {
        }

        public override void InitDao()
        {
            base.InitDao();
            ${Class.varDao} = NewDao<${Class.DaoName}>();
        }

    }
}
