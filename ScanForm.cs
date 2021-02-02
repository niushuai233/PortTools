using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKiller
{
    public class ScanForm
    {
        /// <summary>
        /// 起始ip
        /// </summary>
        public string ip_start { set; get; }
        /// <summary>
        /// 终止ip
        /// </summary>
        public string ip_end { set; get; }
        /// <summary>
        /// IP地址列表
        /// </summary>
        public List<string> ip_list { set; get; }
        /// <summary>
        /// 端口列表
        /// </summary>
        public List<int> port_list { set; get; }
        /// <summary>
        /// 超时
        /// </summary>
        public int timeout { set; get; }
        /// <summary>
        /// 同时工作的线程数
        /// </summary>
        public int thread_nums { set; get; }

        public ScanForm()
        {
            // 初始化超时为200
            this.timeout = 200;
            // 线程数为1
            this.thread_nums = 1;
        }
    }
}
