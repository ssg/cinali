namespace cinali
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.runAtStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.sitesTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.browseFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.limitTextBox = new System.Windows.Forms.TextBox();
            this.noLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.limitPanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pollTimer = new System.Windows.Forms.Timer(this.components);
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.limitPanel.SuspendLayout();
            this.notifyIconContextMenuStrip.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // runAtStartupCheckBox
            // 
            this.runAtStartupCheckBox.AutoSize = true;
            this.runAtStartupCheckBox.Checked = true;
            this.runAtStartupCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runAtStartupCheckBox.Location = new System.Drawing.Point(3, 264);
            this.runAtStartupCheckBox.Name = "runAtStartupCheckBox";
            this.runAtStartupCheckBox.Size = new System.Drawing.Size(179, 17);
            this.runAtStartupCheckBox.TabIndex = 5;
            this.runAtStartupCheckBox.Text = "Açılışta otomatik çalışmaya başla";
            this.runAtStartupCheckBox.UseVisualStyleBackColor = true;
            this.runAtStartupCheckBox.CheckedChanged += new System.EventHandler(this.runAtStartupCheckBox_CheckedChanged);
            // 
            // sitesTextBox
            // 
            this.sitesTextBox.Location = new System.Drawing.Point(3, 16);
            this.sitesTextBox.Multiline = true;
            this.sitesTextBox.Name = "sitesTextBox";
            this.sitesTextBox.Size = new System.Drawing.Size(338, 129);
            this.sitesTextBox.TabIndex = 0;
            this.sitesTextBox.Text = "www.example-site.com";
            this.sitesTextBox.TextChanged += new System.EventHandler(this.sitesTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "İndirilecek siteler:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kaydedilecek dizin";
            // 
            // outputFolderTextBox
            // 
            this.outputFolderTextBox.Location = new System.Drawing.Point(4, 167);
            this.outputFolderTextBox.Name = "outputFolderTextBox";
            this.outputFolderTextBox.Size = new System.Drawing.Size(298, 20);
            this.outputFolderTextBox.TabIndex = 1;
            this.outputFolderTextBox.TextChanged += new System.EventHandler(this.outputFolderTextBox_TextChanged);
            // 
            // browseFolder
            // 
            this.browseFolder.Location = new System.Drawing.Point(308, 164);
            this.browseFolder.Name = "browseFolder";
            this.browseFolder.Size = new System.Drawing.Size(33, 23);
            this.browseFolder.TabIndex = 2;
            this.browseFolder.Text = "...";
            this.browseFolder.UseVisualStyleBackColor = true;
            this.browseFolder.Click += new System.EventHandler(this.browseFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hız sınırı";
            // 
            // limitTextBox
            // 
            this.limitTextBox.Location = new System.Drawing.Point(6, 16);
            this.limitTextBox.Name = "limitTextBox";
            this.limitTextBox.Size = new System.Drawing.Size(60, 20);
            this.limitTextBox.TabIndex = 0;
            this.limitTextBox.Text = "16";
            this.limitTextBox.TextChanged += new System.EventHandler(this.limitTextBox_TextChanged);
            // 
            // noLimitCheckBox
            // 
            this.noLimitCheckBox.AutoSize = true;
            this.noLimitCheckBox.Checked = true;
            this.noLimitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noLimitCheckBox.Location = new System.Drawing.Point(5, 194);
            this.noLimitCheckBox.Name = "noLimitCheckBox";
            this.noLimitCheckBox.Size = new System.Drawing.Size(150, 17);
            this.noLimitCheckBox.TabIndex = 3;
            this.noLimitCheckBox.Text = "Tüm bant genişliğini kullan";
            this.noLimitCheckBox.UseVisualStyleBackColor = true;
            this.noLimitCheckBox.CheckedChanged += new System.EventHandler(this.noLimitCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "kb/sn";
            // 
            // limitPanel
            // 
            this.limitPanel.Controls.Add(this.limitTextBox);
            this.limitPanel.Controls.Add(this.label4);
            this.limitPanel.Controls.Add(this.label3);
            this.limitPanel.Enabled = false;
            this.limitPanel.Location = new System.Drawing.Point(26, 217);
            this.limitPanel.Name = "limitPanel";
            this.limitPanel.Size = new System.Drawing.Size(200, 41);
            this.limitPanel.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 301);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "&Başlat";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(93, 301);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "&Dur";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(275, 301);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 9;
            this.quitButton.Text = "Çı&kış";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(194, 301);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 8;
            this.aboutButton.Text = "&Hakkında";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "cinali";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(121, 54);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem1.Text = "&cinali";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItem2.Text = "&Çıkış";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.sitesTextBox);
            this.settingsPanel.Controls.Add(this.runAtStartupCheckBox);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.outputFolderTextBox);
            this.settingsPanel.Controls.Add(this.browseFolder);
            this.settingsPanel.Controls.Add(this.limitPanel);
            this.settingsPanel.Controls.Add(this.noLimitCheckBox);
            this.settingsPanel.Location = new System.Drawing.Point(12, 12);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(343, 281);
            this.settingsPanel.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 336);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cinali - Internet indirme aracı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.limitPanel.ResumeLayout(false);
            this.limitPanel.PerformLayout();
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox runAtStartupCheckBox;
        private System.Windows.Forms.TextBox sitesTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.Button browseFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox limitTextBox;
        private System.Windows.Forms.CheckBox noLimitCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel limitPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer pollTimer;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Panel settingsPanel;
    }
}

