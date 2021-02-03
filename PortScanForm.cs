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
                Utils.Alert_Tips("端口号不合法");
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
            List<string> ip_list = new List<string>();
            string startText = this.IpStartTextBox.Text;
            string endText = this.IpEndTextBox.Text;

            uint ustart = Utils.Ip2UInt(startText);
            uint uend = Utils.Ip2UInt(endText);
            for(var tmp_ip = ustart; tmp_ip <= uend; tmp_ip++)
            {
                ip_list.Add(Utils.UIntToIP(tmp_ip));
            }

            return ip_list;
        }
        // 正观新闻
        private List<int> Get_Port_List()
        {
            // 22,80,8080-8088
            List<int> port_list = new List<int>();

            string portText = this.PortTextBox.Text;
            string[] port_split_first = portText.Split(',');

            for(var i = 0; i < port_split_first.Length; i++)
            {
                string tmp_str = port_split_first[i];
                // 不包含 - 时直接添加跳过
                if (!tmp_str.Contains("-"))
                {
                    port_list.Add(int.Parse(tmp_str));
                    continue;
                }

                string[] port_split_twice = tmp_str.Split('-');
                // 按照-分隔的要获取它中间的所有端口

                for (var j = int.Parse(port_split_twice[0]); j <= int.Parse(port_split_twice[1]); j++)
                {
                    // 添加端口
                    port_list.Add(j);
                }
            }
            port_list.ForEach(item =>
            {
                this.ResultRichTextBox.AppendText(item + "\n");
            });
            return port_list;
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
            return PortStr != null && PortStr.Length > 0;
        }

        private void End_Scan()
        {
            if (this.backgroundWorker1.IsBusy) { 
                this.backgroundWorker1.CancelAsync();
            }
        }

        private void Start_Scan()
        {
            this.backgroundWorker1.RunWorkerAsync(Prepare_Data());
        }

        private void Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 中文逗号转英文逗号
            if ((int)e.KeyChar == 65292 || (int)e.KeyChar == 44)
            {
                // 按了逗号键
                e.KeyChar = (char)44;
            }
            else if ((int)e.KeyChar == 8212 || (int)e.KeyChar == 45)
            {
                // 按了短横线键
                e.KeyChar = (char)45;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                // 按了退格键
            }
            else if (!Char.IsDigit(e.KeyChar))
            {
                // 非数字
                e.Handled = true;
            }
        }

        private void ip_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 中文句号转英文句号
            if ((int)e.KeyChar == 12290 || (int)e.KeyChar == 46)
            {
                // 按了逗号键
                e.KeyChar = (char)46;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                // 按了退格键
            }
            else if (!Char.IsDigit(e.KeyChar))
            {
                // 非数字
                e.Handled = true;
            }
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                // 按了退格键
            }
            else if (!Char.IsDigit(e.KeyChar))
            {
                // 非数字
                e.Handled = true;
            }
        }
    }


}
