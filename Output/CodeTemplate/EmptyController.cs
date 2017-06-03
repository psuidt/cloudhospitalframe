using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ${Class.AppName}.Manager.BusinesEntity;

public class ${Class.ClassName} : AbstractJqueryController
{
    public void HelloWorld()
    {
        try
        {
            //TxtJson = base.ListToJson(user.GetUserList());
        }
        catch (Exception err)
        {
            TxtJson = ReturnError(err.Message);
        }
    }
}

