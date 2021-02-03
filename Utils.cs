using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PortKiller
{
    public class Utils
    {
        /// <summary>
        /// 校验ip是否合法
        /// </summary>
        /// <param name="ip">ip字符串</param>
        /// <returns></returns>
        public static bool CheckIp(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"); ;
        }

        /// <summary>
        /// 弹框提示
        /// </summary>
        /// <param name="text">弹框内容</param>
        public static void Alert_Tips(string text)
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 拼接ip字符串
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <param name="i3"></param>
        /// <param name="i4"></param>
        /// <returns></returns>
        public static string Get_Ip(int i1, int i2, int i3, int i4)
        {
            return i1 + "." + i2 + "." + i3 + "." + i4;
        }


        public static uint Ip2UInt(string ip)
        {
            string disjunctiveStr = ".,: ";
            char[] delimiter = disjunctiveStr.ToCharArray();
            string[] ip_arr = null;
            for (int i = 1; i <= 5; i++)
            {
                ip_arr = ip.Split(delimiter, i);
            }
            string a1 = ip_arr[0].ToString();
            string a2 = ip_arr[1].ToString();
            string a3 = ip_arr[2].ToString();
            string a4 = ip_arr[3].ToString();
            uint U1 = uint.Parse(a1);
            uint U2 = uint.Parse(a2);
            uint U3 = uint.Parse(a3);
            uint U4 = uint.Parse(a4);

            uint U = U1 << 24;
            U += U2 << 16;
            U += U3 << 8;
            U += U4;
            return U;
        }

        public static string UIntToIP(uint ipAddress)
        {
            long ui1 = ipAddress & 0xFF000000;
            ui1 >>= 24;
            long ui2 = ipAddress & 0x00FF0000;
            ui2 >>= 16;
            long ui3 = ipAddress & 0x0000FF00;
            ui3 >>= 8;
            long ui4 = ipAddress & 0x000000FF;
            string IP_Str = Convert.ToString(ui1) + "."
                + Convert.ToString(ui2) + "."
                + Convert.ToString(ui3)
                + "." + Convert.ToString(ui4);
            return IP_Str;
        }

        public static bool CheckPort(int port)
        {
            return port > 0 && port <= 65535;
        }

        internal static bool CanConnect(string ip, int port, int timeout)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);

            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

            try
            {

                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IAsyncResult asyncResult = sock.BeginConnect(endPoint, null, null);

                asyncResult.AsyncWaitHandle.WaitOne(timeout, true);
                if (asyncResult.IsCompleted)
                {
                    // 连接成功
                    Console.WriteLine(ip + ":" + port + " if 连接: " + true);
                    sock.Close();
                    return true;
                } else
                {
                    // 连接失败
                    Console.WriteLine(ip + ":" + port + " else 连接: " + false);
                    return false;
                }
            } catch(SocketException e)
            {
                Console.WriteLine(ip + ":" + port + " exception 连接: " + false);
                return false;
            }
        }
    }
}
