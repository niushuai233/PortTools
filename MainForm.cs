using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PortKiller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void changeBtn(bool status)
        {
            this.SearchBtn.Enabled = status;
            this.KillBtn.Enabled = status;
            this.SearchAndKillBtn.Enabled = status;
        }

        private void changeTipsText(string text)
        {
            Debug.WriteLine("text: " + text);
            this.tipsLabel.Text = text;
            this.Refresh();
        }

        /**
         * 只允许输入数字
         * @author niushuai233
         * @date 2021/01/26 19:00:36
         */
        private void PortInput_KeyPress(Object sender, KeyPressEventArgs e)
        {
            // 是否是退格键
            bool BackspaceKey = e.KeyChar == (char)Keys.Back;
            if (!BackspaceKey)
            {
                // 非退格键
                // 非数字 丢弃
                if (!Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            // 方便后面设计一键查杀调用
            changeBtn(false);
            string do_res = Do_Process();
            changeBtn(true);
            if (do_res != null)
            {
                MessageBox.Show(do_res, "提示", MessageBoxButtons.OK);
            }
        }

        private string Do_Process()
        {
            // 清空之前的数据
            this.BindDataGridView.Rows.Clear();

            string PortInputText = this.PortInput.Text;
            if (PortInputText.Length == 0)
            {
                return "请输入端口号";
            }

            if (!Check_Port(PortInputText))
            {
                return "端口号范围1-65535, 请确认";
            }

            changeTipsText("查询端口[" + this.PortInput.Text + "]占用");

            int port;
            int.TryParse(PortInputText, out port);

            Thread.Sleep(1000);

            Process p = Get_Process("cmd.exe");
            
            // 获取端口号相关的pid
            List<int> pid_list = Get_Pid_By_Port(p, port);

            Console.WriteLine("pid_list: " + string.Join("\t", pid_list));

            // 根据pid获取进程信息
            List<BindData> process_list = Get_ProcessName_By_Pid(p, pid_list);
            changeTipsText("查询完毕");

            Console.WriteLine("process_list: " + string.Join("\n", process_list));

            // 关闭process进程
            p.Close();

            if (process_list.Count == 0)
            {
                return "端口[" + port + "]未被占用";
            }

            // 填充数据到窗体
            int i = 0;

            foreach (var dataBean in process_list)
            {
                this.BindDataGridView.Rows.Add();
                // 序号
                this.BindDataGridView.Rows[i].Cells[0].Value = i + 1;
                // 进程PID
                this.BindDataGridView.Rows[i].Cells[1].Value = dataBean.Pid;
                // 程序名称
                this.BindDataGridView.Rows[i].Cells[2].Value = dataBean.ProcessName;
                // 空间占用
                this.BindDataGridView.Rows[i].Cells[3].Value = dataBean.Space;
                i++;
            }
            return null;
        }

        private static Process Get_Process(string fileName)
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            return p;
        }

        private List<BindData> Get_ProcessName_By_Pid(Process process, List<int> pid_list)
        {
            // 开启process进程
            process.Start();
            List<BindData> process_list = new List<BindData>();
            StreamReader reader;
            foreach (var pid in pid_list)
            {
                // 查找process
                process.StandardInput.WriteLine(string.Format("tasklist |findstr \"{0}\"", pid));
                process.StandardInput.WriteLine("exit");
                // 获取输出内容
                reader = process.StandardOutput;
                string line = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    line = line.Trim();
                    // 映像名称                       PID   会话名              会话#       内存使用
                    // Everything.exe                3776 Services                   0      1,036 K
                    if (line.Length > 0 && ((line.Contains(".exe"))))
                    {
                        Regex regex = new Regex(@"\s+");
                        string[] split_lines = regex.Split(line);
                        if (split_lines.Length > 0 && split_lines[1].Equals(pid + ""))
                        {
                            process_list.Add(new BindData(split_lines[0], int.Parse(split_lines[1]), split_lines[4].Replace(",","") + "k"));
                        }
                    }
                    line = reader.ReadLine();
                }
                process.WaitForExit();
            }
            Console.WriteLine("Get_ProcessName_By_Pid Over ============================================");
            return process_list;
        }

        private List<int> Get_Pid_By_Port(Process process, int port)
        {
            //Console.WriteLine("port: " + port + string.Format("netstat -ano|findstr \":{0} \"", port));
            // 开始进程
            process.Start();
            // 输入根据端口号查询pid的命令
            process.StandardInput.WriteLine(string.Format("netstat -ano|findstr \":{0} \"", port));
            // 退出
            process.StandardInput.WriteLine("exit");

            List<int> pid_list = new List<int>();
            
            // 接收结果
            StreamReader reader = process.StandardOutput;
            string line = reader.ReadLine();

            while(!reader.EndOfStream)
            {
                //Console.WriteLine("line: " + line);
                line = line.Trim();
                if (line.Length > 0 && (line.Contains("UDP") || line.Contains("TCP"))) {
                    Regex regex = new Regex(@"\s+");
                    // 分隔行内容
                    string[] split_lines = regex.Split(line);
                    // 类型   本地地址              远程地址             监听状态         PID
                    // TCP    0.0.0.0:443            0.0.0.0:0              LISTENING       6808
                    // 理论上应该分隔出 5 个长度的内容
                    //Console.WriteLine("split_lines: " + string.Join("\t", split_lines));
                    if (split_lines.Length == 5)
                    {
                        int pid;
                        // 是否为数字
                        bool is_digit = int.TryParse(split_lines[4], out pid);

                        if (is_digit && !pid_list.Contains(pid) && split_lines[1].EndsWith(":" + port))
                        {
                            // 经测试查80端口会将8080一并查出
                            // 再加入判断 本地端口
                            // split_lines[1].Contains(":80")
                            pid_list.Add(pid);
                        }
                    }
                }
                line = reader.ReadLine();
            }

            Console.WriteLine("Get_Pid_By_Port Over ============================================");
            return pid_list;
        }

        private bool Check_Port(String PortStr)
        {
            int port;
            return int.TryParse(PortStr, out port) && port != 0 && port <= 65535;
        }

        private void KillBtn_Click(object sender, EventArgs e)
        {
            // 方便后面设计一键查杀
            kill();
        }

        private void kill()
        {
            changeTipsText("进程查杀开始");
            DataGridViewRowCollection rows = this.BindDataGridView.Rows;
            if (rows == null || rows.Count == 0)
            {
                MessageBox.Show("未找到相关进程", "提示", MessageBoxButtons.OK);
                return;
            }

            // 第一行
            DataGridViewRow row = rows[0];
            // 第二列 pid
            object pid = row.Cells[1].Value;
            string killCmd = "taskkill /F /PID " + pid;
            Console.WriteLine("kill pid: " + pid + "  " + killCmd);
            Process process = Get_Process("cmd.exe");

            process.Start();
            process.StandardInput.WriteLine(killCmd);
            process.StandardInput.WriteLine("exit");

            //StreamReader reader = process.StandardOutput;
            //string line = reader.ReadLine();

            //while (!reader.EndOfStream)
            //{
            //    line = line.Trim();
            //    Console.WriteLine(line);
            //    // 读取下一行数据
            //    line = reader.ReadLine();
            //}
            string line = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            process.Close();
            if (line.Contains("成功:"))
            {
                MessageBox.Show("进程[" + row.Cells[2].Value + "]已杀死", "提示", MessageBoxButtons.OK);
            } else
            {
                MessageBox.Show("进程[" + row.Cells[2].Value + "]查杀失败, 请尝试以管理员权限运行", "提示", MessageBoxButtons.OK);
            }
            changeTipsText("进程查杀完成");
        }
        private void About_ToolStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "端口查杀工具v1.1 © 版权所有 2021.1 @niushuai233\n\n" +
                "主页：https://github.com/niushuai233\n" +
                "邮箱：shuai.niu@foxmail.com", 
                "关于", MessageBoxButtons.OK);
        }

        private void SearchAndKillBtn_Click(object sender, EventArgs e)
        {
            string do_res = Do_Process();
            if (null == do_res)
            {
                kill();
            } else
            {
                MessageBox.Show(do_res, "提示", MessageBoxButtons.OK);
            }
        }
    }
}
