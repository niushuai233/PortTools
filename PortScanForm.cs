using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PortKiller
{
    public partial class PortScanForm : Form
    {
        public PortScanForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void GoPortKillForm_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Hide();
            mainForm.Show();
        }

        private void About_ToolStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "端口扫描工具v1.0 © 版权所有 2021.1 @niushuai233\n\n" +
                "主页：https://github.com/niushuai233\n" +
                "邮箱：shuai.niu@foxmail.com",
                "关于", MessageBoxButtons.OK);
        }

        private void PortFormClosed_Event(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox1 = (GroupBox) sender;
            e.Graphics.Clear(groupBox1.BackColor);
            e.Graphics.DrawString(groupBox1.Text, groupBox1.Font, Brushes.Black, 10, 1);
            e.Graphics.DrawLine(Pens.Gray, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Gray, e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font).Width + 8, 7, groupBox1.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Gray, 1, 7, 1, groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Gray, 1, groupBox1.Height - 2, groupBox1.Width - 2, groupBox1.Height - 2);
            e.Graphics.DrawLine(Pens.Gray, groupBox1.Width - 2, 7, groupBox1.Width - 2, groupBox1.Height - 2);
        }

        bool scanFlag = true;
        private void ScanBtn_Click(object sender, EventArgs e)
        {
            //testIpReg();
            // ip地址要求为ipv4地址
            // 起始ip是否合法
            bool IpStartValid = Utils.CheckIp(this.IpStartTextBox.Text);
            if (!IpStartValid)
            {
                Utils.Alert_Tips("起始IP不合法");
                this.IpStartTextBox.Focus();
                return;
            }
            // 结束ip是否合法
            bool IpEndValid = Utils.CheckIp(this.IpEndTextBox.Text);
            if (!IpEndValid)
            {
                Utils.Alert_Tips("结束IP不合法");
                this.IpEndTextBox.Focus();
                return;
            }
            if (!Check_Port(this.PortTextBox.Text))
            {
                Utils.Alert_Tips("端口号输入错误, 请确认");
                this.PortTextBox.Focus();
                return;
            }

            this.ScanBtn.Text = scanFlag ? "停止" : "扫描";
            this.Refresh();

            if (scanFlag)
            {
                this.Start_Scan();
            } else
            {
                this.End_Scan();
            }
            scanFlag = !scanFlag;
        }

        private ScanForm Prepare_Data()
        {
            ScanForm form = new ScanForm();
            form.ip_start = this.IpStartTextBox.Text;
            form.ip_end = this.IpEndTextBox.Text;

            form.ip_list = Get_Ip_List();
            form.port_list = Get_Port_List();

            form.timeout = int.Parse(this.TimeoutTextBox.Text);
            form.thread_nums = int.Parse(this.ThreadTextBox.Text);
            return form;
        }

        private List<string> Get_Ip_List()
        {
            return null;
        }

        private List<int> Get_Port_List()
        {
            return null;
        }

        private void Bgw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ScanProgressBar.Value = e.ProgressPercentage;
        }

        private void Bgw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ScanBtn.Text = "扫描";
            this.Refresh();
        }
     
        private void Bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int x = 1; x <= 100; x++)
            {
                // 每次迴圈讓程式休眠300毫秒
                System.Threading.Thread.Sleep(100);
                // 執行PerformStep()函式
                BackgroundWorker tmp = ((BackgroundWorker) sender);
                tmp.ReportProgress(x);
                if (tmp.CancellationPending)
                {
                    tmp.ReportProgress(100);
                    return;
                }
            }
        }

        private bool Check_Port(String PortStr)
        {
            int port;
            // return int.TryParse(PortStr, out port) && port != 0 && port <= 65535;
            return true;
        }

        private void End_Scan()
        {
            this.backgroundWorker1.CancelAsync();
        }

        private void Start_Scan()
        {
            // 获取ip区间
            List<string> ip_list = Get_Ip_List();

            this.backgroundWorker1.RunWorkerAsync();
        }

        
    }


}
