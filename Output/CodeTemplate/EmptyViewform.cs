using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ${Form.AppName}.FormUI.Ation;
using ${Form.AppName}.FormUI.IViewform;

namespace ${Form.AppName}.FormUI.Viewform
{
    public partial class ${Form.ClassName} : FromCommonControl.BaseForm, ${Form.IViewformName}
    {
        public event WinFormFrame.Common.Controller.ControllerEventHandler ControllerEvent;

        public ${Form.ClassName}()
        {
            InitializeComponent();
        }

      
    }
}
