using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.Emr.Controls.Controller
{
    interface IEmrDbHelper
    {
        string SaveEmrFile(Stream stream);
        StreamReader GetEmrFile(string emrid);
    }
}
