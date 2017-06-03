using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EFWCoreLib.CoreFrame.Init;
using EFWCoreLib.WinformFrame.Controller;
using EfwControls.CustomControl;
using EFWCoreLib.CoreFrame.Business;

namespace WinMainUIFrame.Winform.ViewForm
{
    public partial class FrmWeclome : BaseFormBusiness
    {
        public FrmWeclome()
        {
            InitializeComponent();
        }

        private void FrmWeclome_Load(object sender, EventArgs e)
        {
            if (File.Exists(InvokeController("GetBackGroundImage").ToString()))
                this.pictureBox1.Image = Image.FromFile(InvokeController("GetBackGroundImage").ToString());
            else
                this.pictureBox1.Image = Image.FromFile(AppGlobal.AppRootPath + "images/backgroundImage.jpg");
        }
    }
}
