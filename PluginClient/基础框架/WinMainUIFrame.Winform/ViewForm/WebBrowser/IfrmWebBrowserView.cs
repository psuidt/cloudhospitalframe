using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.WinformFrame.Controller;

namespace WinMainUIFrame.Winform.ViewForm.WebBrowser
{
    public interface IfrmWebBrowserView : IBaseView
    {
        string Url { get; set; }
        void NavigateUrl();
    }
}
