namespace InFocusCtrl
{
    partial class MainForm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_inputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_inputComposite = new System.Windows.Forms.ToolStripMenuItem();
            this.m_inputHdmi = new System.Windows.Forms.ToolStripMenuItem();
            this.m_inputSVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.m_inputVga1 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_inputVga2 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_powerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_powerOn = new System.Windows.Forms.ToolStripMenuItem();
            this.m_powerOff = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_lampInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trayIcon
            // 
            this.m_trayIcon.ContextMenuStrip = this.m_trayMenu;
            this.m_trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_trayIcon.Icon")));
            this.m_trayIcon.Text = "m_trayIcon";
            this.m_trayIcon.Visible = true;
            // 
            // m_trayMenu
            // 
            this.m_trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_inputMenuItem,
            this.m_powerMenuItem,
            this.toolStripSeparator1,
            this.m_lampInfo,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem,
            this.m_quitMenuItem});
            this.m_trayMenu.Name = "m_trayMenu";
            this.m_trayMenu.Size = new System.Drawing.Size(153, 148);
            // 
            // m_inputMenuItem
            // 
            this.m_inputMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_inputComposite,
            this.m_inputHdmi,
            this.m_inputSVideo,
            this.m_inputVga1,
            this.m_inputVga2});
            this.m_inputMenuItem.Name = "m_inputMenuItem";
            this.m_inputMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_inputMenuItem.Text = "&Input";
            // 
            // m_inputComposite
            // 
            this.m_inputComposite.Name = "m_inputComposite";
            this.m_inputComposite.Size = new System.Drawing.Size(132, 22);
            this.m_inputComposite.Text = "Composite";
            this.m_inputComposite.Click += new System.EventHandler(this.ISetSourceComposite);
            // 
            // m_inputHdmi
            // 
            this.m_inputHdmi.Name = "m_inputHdmi";
            this.m_inputHdmi.Size = new System.Drawing.Size(132, 22);
            this.m_inputHdmi.Text = "HDMI";
            this.m_inputHdmi.Click += new System.EventHandler(this.ISetSourceHdmi);
            // 
            // m_inputSVideo
            // 
            this.m_inputSVideo.Name = "m_inputSVideo";
            this.m_inputSVideo.Size = new System.Drawing.Size(132, 22);
            this.m_inputSVideo.Text = "S-Video";
            this.m_inputSVideo.Click += new System.EventHandler(this.ISetSourceSVideo);
            // 
            // m_inputVga1
            // 
            this.m_inputVga1.Name = "m_inputVga1";
            this.m_inputVga1.Size = new System.Drawing.Size(132, 22);
            this.m_inputVga1.Text = "VGA1";
            this.m_inputVga1.Click += new System.EventHandler(this.ISetSourceVga1);
            // 
            // m_inputVga2
            // 
            this.m_inputVga2.Name = "m_inputVga2";
            this.m_inputVga2.Size = new System.Drawing.Size(132, 22);
            this.m_inputVga2.Text = "VGA2";
            this.m_inputVga2.Click += new System.EventHandler(this.ISetSourceVga2);
            // 
            // m_powerMenuItem
            // 
            this.m_powerMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_powerOn,
            this.m_powerOff});
            this.m_powerMenuItem.Name = "m_powerMenuItem";
            this.m_powerMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_powerMenuItem.Text = "&Power";
            // 
            // m_powerOn
            // 
            this.m_powerOn.Name = "m_powerOn";
            this.m_powerOn.Size = new System.Drawing.Size(91, 22);
            this.m_powerOn.Text = "On";
            this.m_powerOn.Click += new System.EventHandler(this.IPowerOn);
            // 
            // m_powerOff
            // 
            this.m_powerOff.Name = "m_powerOff";
            this.m_powerOff.Size = new System.Drawing.Size(91, 22);
            this.m_powerOff.Text = "Off";
            this.m_powerOff.Click += new System.EventHandler(this.IPowerOff);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // m_lampInfo
            // 
            this.m_lampInfo.Name = "m_lampInfo";
            this.m_lampInfo.Size = new System.Drawing.Size(152, 22);
            this.m_lampInfo.Text = "Lamp Info";
            this.m_lampInfo.Click += new System.EventHandler(this.IShowLampInfo);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // m_quitMenuItem
            // 
            this.m_quitMenuItem.Name = "m_quitMenuItem";
            this.m_quitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_quitMenuItem.Text = "&Quit";
            this.m_quitMenuItem.Click += new System.EventHandler(this.IQuit);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.IShowAboutBox);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Projector CP";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.m_trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon m_trayIcon;
        private System.Windows.Forms.ContextMenuStrip m_trayMenu;
        private System.Windows.Forms.ToolStripMenuItem m_inputMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_inputHdmi;
        private System.Windows.Forms.ToolStripMenuItem m_inputVga1;
        private System.Windows.Forms.ToolStripMenuItem m_inputVga2;
        private System.Windows.Forms.ToolStripMenuItem m_inputComposite;
        private System.Windows.Forms.ToolStripMenuItem m_powerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_powerOn;
        private System.Windows.Forms.ToolStripMenuItem m_powerOff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_quitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_lampInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem m_inputSVideo;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}