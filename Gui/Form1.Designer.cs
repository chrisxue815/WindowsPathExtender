namespace WindowsPathExtender
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonLoad = new System.Windows.Forms.ToolStripButton();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.buttonOptions = new System.Windows.Forms.ToolStripButton();
            this.buttonAbout = new System.Windows.Forms.ToolStripButton();
            this.textBoxEnv = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxEnv = new System.Windows.Forms.GroupBox();
            this.insideSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.outsidePanel = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBoxEnv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insideSplitContainer)).BeginInit();
            this.insideSplitContainer.Panel1.SuspendLayout();
            this.insideSplitContainer.Panel2.SuspendLayout();
            this.insideSplitContainer.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.outsidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonLoad,
            this.buttonSave,
            this.buttonOptions,
            this.buttonAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1025, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Image = global::WindowsPathExtender.Properties.Resources.FolderOpen_48x48_72;
            this.buttonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(80, 36);
            this.buttonLoad.Text = "&Load";
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::WindowsPathExtender.Properties.Resources.FloppyDisk;
            this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(79, 36);
            this.buttonSave.Text = "&Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOptions
            // 
            this.buttonOptions.Image = global::WindowsPathExtender.Properties.Resources.settings_48;
            this.buttonOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(101, 36);
            this.buttonOptions.Text = "&Options";
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Image = global::WindowsPathExtender.Properties.Resources.info;
            this.buttonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(88, 36);
            this.buttonAbout.Text = "&About";
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // textBoxEnv
            // 
            this.textBoxEnv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEnv.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEnv.Location = new System.Drawing.Point(4, 24);
            this.textBoxEnv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxEnv.MaxLength = 0;
            this.textBoxEnv.Multiline = true;
            this.textBoxEnv.Name = "textBoxEnv";
            this.textBoxEnv.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEnv.Size = new System.Drawing.Size(574, 444);
            this.textBoxEnv.TabIndex = 0;
            this.textBoxEnv.WordWrap = false;
            this.textBoxEnv.TextChanged += new System.EventHandler(this.textBoxEnv_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLoad,
            this.menuItemSave,
            this.menuItemOptions,
            this.menuItemAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1025, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // menuItemLoad
            // 
            this.menuItemLoad.Name = "menuItemLoad";
            this.menuItemLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.menuItemLoad.Size = new System.Drawing.Size(45, 19);
            this.menuItemLoad.Text = "&Load";
            this.menuItemLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSave.Size = new System.Drawing.Size(43, 19);
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.Name = "menuItemOptions";
            this.menuItemOptions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemOptions.Size = new System.Drawing.Size(61, 19);
            this.menuItemOptions.Text = "&Options";
            this.menuItemOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuItemAbout.Size = new System.Drawing.Size(52, 19);
            this.menuItemAbout.Text = "&About";
            this.menuItemAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.statusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1025, 31);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(150, 25);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // statusLabel1
            // 
            this.statusLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(97, 26);
            this.statusLabel1.Text = "statusLabel1";
            // 
            // groupBoxEnv
            // 
            this.groupBoxEnv.Controls.Add(this.textBoxEnv);
            this.groupBoxEnv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEnv.Location = new System.Drawing.Point(0, 0);
            this.groupBoxEnv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxEnv.Name = "groupBoxEnv";
            this.groupBoxEnv.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxEnv.Size = new System.Drawing.Size(582, 473);
            this.groupBoxEnv.TabIndex = 0;
            this.groupBoxEnv.TabStop = false;
            this.groupBoxEnv.Text = "Environment Variable";
            // 
            // insideSplitContainer
            // 
            this.insideSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insideSplitContainer.Location = new System.Drawing.Point(13, 10);
            this.insideSplitContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.insideSplitContainer.Name = "insideSplitContainer";
            // 
            // insideSplitContainer.Panel1
            // 
            this.insideSplitContainer.Panel1.Controls.Add(this.groupBoxEnv);
            // 
            // insideSplitContainer.Panel2
            // 
            this.insideSplitContainer.Panel2.Controls.Add(this.groupBoxLog);
            this.insideSplitContainer.Size = new System.Drawing.Size(999, 473);
            this.insideSplitContainer.SplitterDistance = 582;
            this.insideSplitContainer.SplitterWidth = 6;
            this.insideSplitContainer.TabIndex = 4;
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.textBoxLog);
            this.groupBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLog.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxLog.Size = new System.Drawing.Size(411, 473);
            this.groupBoxLog.TabIndex = 0;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLog.Location = new System.Drawing.Point(4, 24);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLog.MaxLength = 0;
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(403, 444);
            this.textBoxLog.TabIndex = 1;
            this.textBoxLog.WordWrap = false;
            // 
            // outsidePanel
            // 
            this.outsidePanel.Controls.Add(this.insideSplitContainer);
            this.outsidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outsidePanel.Location = new System.Drawing.Point(0, 39);
            this.outsidePanel.Name = "outsidePanel";
            this.outsidePanel.Padding = new System.Windows.Forms.Padding(13, 10, 13, 10);
            this.outsidePanel.Size = new System.Drawing.Size(1025, 493);
            this.outsidePanel.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 563);
            this.Controls.Add(this.outsidePanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Windows Path Extender";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxEnv.ResumeLayout(false);
            this.groupBoxEnv.PerformLayout();
            this.insideSplitContainer.Panel1.ResumeLayout(false);
            this.insideSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.insideSplitContainer)).EndInit();
            this.insideSplitContainer.ResumeLayout(false);
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.outsidePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonLoad;
        private System.Windows.Forms.ToolStripButton buttonSave;
        private System.Windows.Forms.ToolStripButton buttonOptions;
        private System.Windows.Forms.ToolStripButton buttonAbout;
        private System.Windows.Forms.TextBox textBoxEnv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoad;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.GroupBox groupBoxEnv;
        private System.Windows.Forms.SplitContainer insideSplitContainer;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Panel outsidePanel;
    }
}
