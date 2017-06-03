namespace WinMainUIFrame.Winform.ViewForm
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.BasepanelEx = new DevComponents.DotNetBar.PanelEx();
            this.btnconn = new System.Windows.Forms.LinkLabel();
            this.lab_Cancel = new System.Windows.Forms.Label();
            this.lab_OK = new System.Windows.Forms.Label();
            this.pb_Cancel = new System.Windows.Forms.PictureBox();
            this.pb_Ok = new System.Windows.Forms.PictureBox();
            this.ckAutoLogin = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ckRemPass = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtPassWord = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labsystemName = new System.Windows.Forms.Label();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pcb_background = new System.Windows.Forms.PictureBox();
            this.frmForm1 = new EfwControls.CustomControl.frmForm(this.components);
            this.BasepanelEx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_background)).BeginInit();
            this.SuspendLayout();
            // 
            // BasepanelEx
            // 
            this.BasepanelEx.Controls.Add(this.btnconn);
            this.BasepanelEx.Controls.Add(this.lab_Cancel);
            this.BasepanelEx.Controls.Add(this.lab_OK);
            this.BasepanelEx.Controls.Add(this.pb_Cancel);
            this.BasepanelEx.Controls.Add(this.pb_Ok);
            this.BasepanelEx.Controls.Add(this.ckAutoLogin);
            this.BasepanelEx.Controls.Add(this.ckRemPass);
            this.BasepanelEx.Controls.Add(this.labelX2);
            this.BasepanelEx.Controls.Add(this.labelX1);
            this.BasepanelEx.Controls.Add(this.txtPassWord);
            this.BasepanelEx.Controls.Add(this.labsystemName);
            this.BasepanelEx.Controls.Add(this.txtUser);
            this.BasepanelEx.Controls.Add(this.pcb_background);
            this.BasepanelEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasepanelEx.Location = new System.Drawing.Point(0, 0);
            this.BasepanelEx.Name = "BasepanelEx";
            this.BasepanelEx.Size = new System.Drawing.Size(620, 370);
            this.BasepanelEx.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.BasepanelEx.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.BasepanelEx.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.BasepanelEx.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.BasepanelEx.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.BasepanelEx.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.BasepanelEx.Style.GradientAngle = 90;
            this.BasepanelEx.TabIndex = 0;
            // 
            // btnconn
            // 
            this.btnconn.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(88)))), ((int)(((byte)(135)))));
            this.btnconn.AutoSize = true;
            this.btnconn.BackColor = System.Drawing.Color.AliceBlue;
            this.btnconn.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnconn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(88)))), ((int)(((byte)(135)))));
            this.btnconn.Location = new System.Drawing.Point(28, 338);
            this.btnconn.Name = "btnconn";
            this.btnconn.Size = new System.Drawing.Size(77, 12);
            this.btnconn.TabIndex = 25;
            this.btnconn.TabStop = true;
            this.btnconn.Text = "设置通讯连接";
            this.btnconn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnconn_LinkClicked);
            // 
            // lab_Cancel
            // 
            this.lab_Cancel.AutoSize = true;
            this.lab_Cancel.ForeColor = System.Drawing.Color.White;
            this.lab_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("lab_Cancel.Image")));
            this.lab_Cancel.Location = new System.Drawing.Point(504, 242);
            this.lab_Cancel.Name = "lab_Cancel";
            this.lab_Cancel.Size = new System.Drawing.Size(41, 12);
            this.lab_Cancel.TabIndex = 4;
            this.lab_Cancel.Text = "退  出";
            this.lab_Cancel.Click += new System.EventHandler(this.btCancel_Click);
            this.lab_Cancel.MouseLeave += new System.EventHandler(this.pcb_Cancel_MouseLeave);
            this.lab_Cancel.MouseHover += new System.EventHandler(this.pcb_Cancel_MouseHover);
            // 
            // lab_OK
            // 
            this.lab_OK.AutoSize = true;
            this.lab_OK.ForeColor = System.Drawing.Color.White;
            this.lab_OK.Image = ((System.Drawing.Image)(resources.GetObject("lab_OK.Image")));
            this.lab_OK.Location = new System.Drawing.Point(406, 242);
            this.lab_OK.Name = "lab_OK";
            this.lab_OK.Size = new System.Drawing.Size(41, 12);
            this.lab_OK.TabIndex = 3;
            this.lab_OK.Text = "登  录";
            this.lab_OK.Click += new System.EventHandler(this.btLogin_Click);
            this.lab_OK.MouseLeave += new System.EventHandler(this.pcb_OK_MouseLeave);
            this.lab_OK.MouseHover += new System.EventHandler(this.pcb_OK_MouseHover);
            // 
            // pb_Cancel
            // 
            this.pb_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("pb_Cancel.Image")));
            this.pb_Cancel.Location = new System.Drawing.Point(484, 235);
            this.pb_Cancel.Name = "pb_Cancel";
            this.pb_Cancel.Size = new System.Drawing.Size(81, 27);
            this.pb_Cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Cancel.TabIndex = 24;
            this.pb_Cancel.TabStop = false;
            this.pb_Cancel.Click += new System.EventHandler(this.btCancel_Click);
            this.pb_Cancel.MouseLeave += new System.EventHandler(this.pcb_Cancel_MouseLeave);
            this.pb_Cancel.MouseHover += new System.EventHandler(this.pcb_Cancel_MouseHover);
            // 
            // pb_Ok
            // 
            this.pb_Ok.Image = ((System.Drawing.Image)(resources.GetObject("pb_Ok.Image")));
            this.pb_Ok.Location = new System.Drawing.Point(386, 235);
            this.pb_Ok.Name = "pb_Ok";
            this.pb_Ok.Size = new System.Drawing.Size(80, 27);
            this.pb_Ok.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Ok.TabIndex = 23;
            this.pb_Ok.TabStop = false;
            this.pb_Ok.Click += new System.EventHandler(this.btLogin_Click);
            this.pb_Ok.MouseLeave += new System.EventHandler(this.pcb_OK_MouseLeave);
            this.pb_Ok.MouseHover += new System.EventHandler(this.pcb_OK_MouseHover);
            this.pb_Ok.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pb_Ok_PreviewKeyDown);
            // 
            // ckAutoLogin
            // 
            this.ckAutoLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            // 
            // 
            // 
            this.ckAutoLogin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckAutoLogin.Location = new System.Drawing.Point(481, 191);
            this.ckAutoLogin.Name = "ckAutoLogin";
            this.ckAutoLogin.Size = new System.Drawing.Size(100, 23);
            this.ckAutoLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckAutoLogin.TabIndex = 22;
            this.ckAutoLogin.Text = "自动登录";
            // 
            // ckRemPass
            // 
            this.ckRemPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            // 
            // 
            // 
            this.ckRemPass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckRemPass.Location = new System.Drawing.Point(386, 191);
            this.ckRemPass.Name = "ckRemPass";
            this.ckRemPass.Size = new System.Drawing.Size(100, 23);
            this.ckRemPass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckRemPass.TabIndex = 21;
            this.ckRemPass.Text = "记住密码";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(320, 156);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(65, 23);
            this.labelX2.TabIndex = 20;
            this.labelX2.Text = "密  码";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(320, 127);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(65, 23);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "用户名";
            // 
            // txtPassWord
            // 
            // 
            // 
            // 
            this.txtPassWord.Border.Class = "TextBoxBorder";
            this.txtPassWord.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassWord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassWord.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtPassWord.Location = new System.Drawing.Point(386, 153);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(179, 26);
            this.txtPassWord.TabIndex = 2;
            this.txtPassWord.Text = "";
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // labsystemName
            // 
            this.labsystemName.AutoSize = true;
            this.labsystemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.labsystemName.Font = new System.Drawing.Font("华文琥珀", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labsystemName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labsystemName.Location = new System.Drawing.Point(325, 322);
            this.labsystemName.Name = "labsystemName";
            this.labsystemName.Size = new System.Drawing.Size(77, 39);
            this.labsystemName.TabIndex = 15;
            this.labsystemName.Text = "xxx";
            this.labsystemName.Visible = false;
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUser.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtUser.Location = new System.Drawing.Point(386, 125);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(179, 26);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "";
            // 
            // pcb_background
            // 
            this.pcb_background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.pcb_background.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcb_background.Image = ((System.Drawing.Image)(resources.GetObject("pcb_background.Image")));
            this.pcb_background.Location = new System.Drawing.Point(0, 0);
            this.pcb_background.Name = "pcb_background";
            this.pcb_background.Size = new System.Drawing.Size(620, 370);
            this.pcb_background.TabIndex = 12;
            this.pcb_background.TabStop = false;
            // 
            // frmForm1
            // 
            this.frmForm1.IsSkip = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(620, 370);
            this.Controls.Add(this.BasepanelEx);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.VisibleChanged += new System.EventHandler(this.FrmLogin_VisibleChanged);
            this.BasepanelEx.ResumeLayout(false);
            this.BasepanelEx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EfwControls.CustomControl.frmForm frmForm1;
        private System.Windows.Forms.PictureBox pcb_background;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckAutoLogin;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckRemPass;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.Controls.TextBoxX txtPassWord;
        private System.Windows.Forms.Label labsystemName;
        public DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private System.Windows.Forms.PictureBox pb_Cancel;
        private System.Windows.Forms.PictureBox pb_Ok;
        private System.Windows.Forms.Label lab_Cancel;
        private System.Windows.Forms.Label lab_OK;
        private System.Windows.Forms.LinkLabel btnconn;
        public DevComponents.DotNetBar.PanelEx BasepanelEx;
    }
}