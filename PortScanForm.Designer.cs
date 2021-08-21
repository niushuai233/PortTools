
namespace PortKiller
{
    partial class PortScanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortScanForm));
            this.InfoGroupBox = new System.Windows.Forms.GroupBox();
            this.MillsLabel = new System.Windows.Forms.Label();
            this.ThreadTextBox = new System.Windows.Forms.TextBox();
            this.TimeoutTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.IpEndTextBox = new System.Windows.Forms.TextBox();
            this.IpStartTextBox = new System.Windows.Forms.TextBox();
            this.ThreadLabel = new System.Windows.Forms.Label();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.IPEndLabel = new System.Windows.Forms.Label();
            this.IPStartLabel = new System.Windows.Forms.Label();
            this.ResultGroupBox = new System.Windows.Forms.GroupBox();
            this.ResultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AboutToolStripMenuItemForm2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PortKillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScanProgressBar = new System.Windows.Forms.ProgressBar();
            this.ScanBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ProcessLabel = new System.Windows.Forms.Label();
            this.InfoGroupBox.SuspendLayout();
            this.ResultGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoGroupBox
            // 
            this.InfoGroupBox.Controls.Add(this.MillsLabel);
            this.InfoGroupBox.Controls.Add(this.ThreadTextBox);
            this.InfoGroupBox.Controls.Add(this.TimeoutTextBox);
            this.InfoGroupBox.Controls.Add(this.PortTextBox);
            this.InfoGroupBox.Controls.Add(this.IpEndTextBox);
            this.InfoGroupBox.Controls.Add(this.IpStartTextBox);
            this.InfoGroupBox.Controls.Add(this.ThreadLabel);
            this.InfoGroupBox.Controls.Add(this.TimeoutLabel);
            this.InfoGroupBox.Controls.Add(this.PortLabel);
            this.InfoGroupBox.Controls.Add(this.IPEndLabel);
            this.InfoGroupBox.Controls.Add(this.IPStartLabel);
            this.InfoGroupBox.Location = new System.Drawing.Point(12, 29);
            this.InfoGroupBox.Name = "InfoGroupBox";
            this.InfoGroupBox.Size = new System.Drawing.Size(179, 179);
            this.InfoGroupBox.TabIndex = 0;
            this.InfoGroupBox.TabStop = false;
            this.InfoGroupBox.Text = "信息设置";
            this.InfoGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupBox_Paint);
            // 
            // MillsLabel
            // 
            this.MillsLabel.AutoSize = true;
            this.MillsLabel.Location = new System.Drawing.Point(137, 110);
            this.MillsLabel.Name = "MillsLabel";
            this.MillsLabel.Size = new System.Drawing.Size(29, 12);
            this.MillsLabel.TabIndex = 10;
            this.MillsLabel.Text = "毫秒";
            // 
            // ThreadTextBox
            // 
            this.ThreadTextBox.Enabled = false;
            this.ThreadTextBox.Location = new System.Drawing.Point(55, 136);
            this.ThreadTextBox.MaxLength = 3;
            this.ThreadTextBox.Multiline = true;
            this.ThreadTextBox.Name = "ThreadTextBox";
            this.ThreadTextBox.Size = new System.Drawing.Size(112, 20);
            this.ThreadTextBox.TabIndex = 9;
            this.ThreadTextBox.Text = "1";
            this.ThreadTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // TimeoutTextBox
            // 
            this.TimeoutTextBox.Location = new System.Drawing.Point(55, 106);
            this.TimeoutTextBox.MaxLength = 3;
            this.TimeoutTextBox.Multiline = true;
            this.TimeoutTextBox.Name = "TimeoutTextBox";
            this.TimeoutTextBox.Size = new System.Drawing.Size(75, 20);
            this.TimeoutTextBox.TabIndex = 8;
            this.TimeoutTextBox.Text = "200";
            this.TimeoutTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_KeyPress);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(55, 76);
            this.PortTextBox.Multiline = true;
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(112, 20);
            this.PortTextBox.TabIndex = 7;
            this.PortTextBox.Text = "22,80,8080-8088";
            this.PortTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Port_KeyPress);
            // 
            // IpEndTextBox
            // 
            this.IpEndTextBox.Location = new System.Drawing.Point(55, 46);
            this.IpEndTextBox.Multiline = true;
            this.IpEndTextBox.Name = "IpEndTextBox";
            this.IpEndTextBox.Size = new System.Drawing.Size(112, 20);
            this.IpEndTextBox.TabIndex = 6;
            this.IpEndTextBox.Text = "127.0.0.1";
            // this.IpEndTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ip_KeyPress);
            // 
            // IpStartTextBox
            // 
            this.IpStartTextBox.Location = new System.Drawing.Point(55, 17);
            this.IpStartTextBox.Multiline = true;
            this.IpStartTextBox.Name = "IpStartTextBox";
            this.IpStartTextBox.Size = new System.Drawing.Size(112, 20);
            this.IpStartTextBox.TabIndex = 5;
            this.IpStartTextBox.Text = "127.0.0.1";
            // this.IpStartTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ip_KeyPress);
            // 
            // ThreadLabel
            // 
            this.ThreadLabel.AutoSize = true;
            this.ThreadLabel.Location = new System.Drawing.Point(6, 140);
            this.ThreadLabel.Name = "ThreadLabel";
            this.ThreadLabel.Size = new System.Drawing.Size(47, 12);
            this.ThreadLabel.TabIndex = 4;
            this.ThreadLabel.Text = "线程数:";
            // 
            // TimeoutLabel
            // 
            this.TimeoutLabel.AutoSize = true;
            this.TimeoutLabel.Location = new System.Drawing.Point(6, 110);
            this.TimeoutLabel.Name = "TimeoutLabel";
            this.TimeoutLabel.Size = new System.Drawing.Size(47, 12);
            this.TimeoutLabel.TabIndex = 3;
            this.TimeoutLabel.Text = "超  时:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(6, 80);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(47, 12);
            this.PortLabel.TabIndex = 2;
            this.PortLabel.Text = "端口号:";
            // 
            // IPEndLabel
            // 
            this.IPEndLabel.AutoSize = true;
            this.IPEndLabel.Location = new System.Drawing.Point(6, 50);
            this.IPEndLabel.Name = "IPEndLabel";
            this.IPEndLabel.Size = new System.Drawing.Size(47, 12);
            this.IPEndLabel.TabIndex = 1;
            this.IPEndLabel.Text = "结束IP:";
            // 
            // IPStartLabel
            // 
            this.IPStartLabel.AutoSize = true;
            this.IPStartLabel.Location = new System.Drawing.Point(6, 20);
            this.IPStartLabel.Name = "IPStartLabel";
            this.IPStartLabel.Size = new System.Drawing.Size(47, 12);
            this.IPStartLabel.TabIndex = 0;
            this.IPStartLabel.Text = "起始IP:";
            // 
            // ResultGroupBox
            // 
            this.ResultGroupBox.Controls.Add(this.ResultRichTextBox);
            this.ResultGroupBox.Location = new System.Drawing.Point(191, 29);
            this.ResultGroupBox.Name = "ResultGroupBox";
            this.ResultGroupBox.Size = new System.Drawing.Size(210, 179);
            this.ResultGroupBox.TabIndex = 1;
            this.ResultGroupBox.TabStop = false;
            this.ResultGroupBox.Text = "扫描结果";
            this.ResultGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupBox_Paint);
            // 
            // ResultRichTextBox
            // 
            this.ResultRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ResultRichTextBox.Location = new System.Drawing.Point(6, 18);
            this.ResultRichTextBox.Name = "ResultRichTextBox";
            this.ResultRichTextBox.Size = new System.Drawing.Size(198, 155);
            this.ResultRichTextBox.TabIndex = 0;
            this.ResultRichTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItemForm2,
            this.PortKillToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(415, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AboutToolStripMenuItemForm2
            // 
            this.AboutToolStripMenuItemForm2.Name = "AboutToolStripMenuItemForm2";
            this.AboutToolStripMenuItemForm2.Size = new System.Drawing.Size(44, 21);
            this.AboutToolStripMenuItemForm2.Text = "关于";
            this.AboutToolStripMenuItemForm2.Click += new System.EventHandler(this.About_ToolStrip_Click);
            // 
            // PortKillToolStripMenuItem
            // 
            this.PortKillToolStripMenuItem.Name = "PortKillToolStripMenuItem";
            this.PortKillToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.PortKillToolStripMenuItem.Text = "端口查杀";
            this.PortKillToolStripMenuItem.Click += new System.EventHandler(this.GoPortKillForm_Click);
            // 
            // ScanProgressBar
            // 
            this.ScanProgressBar.Location = new System.Drawing.Point(10, 250);
            this.ScanProgressBar.Name = "ScanProgressBar";
            this.ScanProgressBar.Size = new System.Drawing.Size(393, 10);
            this.ScanProgressBar.Step = 1;
            this.ScanProgressBar.TabIndex = 3;
            // 
            // ScanBtn
            // 
            this.ScanBtn.Location = new System.Drawing.Point(329, 217);
            this.ScanBtn.Name = "ScanBtn";
            this.ScanBtn.Size = new System.Drawing.Size(75, 23);
            this.ScanBtn.TabIndex = 4;
            this.ScanBtn.Text = "扫描";
            this.ScanBtn.UseVisualStyleBackColor = true;
            this.ScanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bgw1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Bgw1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bgw1_RunWorkerCompleted);
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.AutoSize = true;
            this.ProcessLabel.Location = new System.Drawing.Point(13, 217);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(11, 12);
            this.ProcessLabel.TabIndex = 5;
            this.ProcessLabel.Text = " ";
            // 
            // PortScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(415, 266);
            this.Controls.Add(this.ProcessLabel);
            this.Controls.Add(this.ScanBtn);
            this.Controls.Add(this.ScanProgressBar);
            this.Controls.Add(this.ResultGroupBox);
            this.Controls.Add(this.InfoGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortScanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PortScaner v1.0 @niushuai233";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PortFormClosed_Event);
            this.InfoGroupBox.ResumeLayout(false);
            this.InfoGroupBox.PerformLayout();
            this.ResultGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox InfoGroupBox;
        private System.Windows.Forms.GroupBox ResultGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItemForm2;
        private System.Windows.Forms.ToolStripMenuItem PortKillToolStripMenuItem;
        private System.Windows.Forms.ProgressBar ScanProgressBar;
        private System.Windows.Forms.Label IPStartLabel;
        private System.Windows.Forms.Label IPEndLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.Label ThreadLabel;
        private System.Windows.Forms.RichTextBox ResultRichTextBox;
        private System.Windows.Forms.TextBox ThreadTextBox;
        private System.Windows.Forms.TextBox TimeoutTextBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox IpEndTextBox;
        private System.Windows.Forms.TextBox IpStartTextBox;
        private System.Windows.Forms.Label MillsLabel;
        private System.Windows.Forms.Button ScanBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label ProcessLabel;
    }
}