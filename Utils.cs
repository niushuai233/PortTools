using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
