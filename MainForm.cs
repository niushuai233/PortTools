using System;
using System.Windows.Forms;

namespace PortKiller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /**
         * 只允许输入数字
         * @author niushuai233
         * @date 2021/01/26 19:00:36
         */ 
        private void PortInput_KeyPress(Object sender, KeyPressEventArgs e)
        {
            // 是否是退格键
            bool BackspaceKey = e.KeyChar == (char) Keys.Back;
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
            string PortInputText = this.PortInput.Text;
            if (PortInputText.Length == 0)
            {
                MessageBox.Show("请输入端口号", "提示", MessageBoxButtons.OK);
            }
            
            if (!Check_Port(PortInputText))
            {
                MessageBox.Show("端口号范围1-65535, 请确认", "提示", MessageBoxButtons.OK);
            }
            
        }

        private bool Check_Port(String PortStr)
        {
            int port;
            return int.TryParse(PortStr, out port) && port != 0 && port <= 65535;
        }

        private void KillBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
