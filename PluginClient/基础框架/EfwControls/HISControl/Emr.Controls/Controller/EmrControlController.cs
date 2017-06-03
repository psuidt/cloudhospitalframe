using EfwControls.HISControl.Emr.Controls.IView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.Emr.Controls.Controller
{
   
    public class EmrControlController
    {
        private IEmrControlView iview;
        public EmrControlController(IEmrControlView _view)
        {
            iview = _view;
        }
        public string SaveFile(Stream stream)
        {
            EmrDbHelper helper = new EmrDbHelper();
            return helper.SaveEmrFile(stream);
        }
        public StreamReader OpenFile(string emrid)
        {
            EmrDbHelper helper = new EmrDbHelper();
            return helper.GetEmrFile(emrid);
        }
    }
}
