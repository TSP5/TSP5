using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace Prototype2._0
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = this.button1;
        }
        private User user = new User();
        private WebService ws = new WebService();
        private void getUser()
        {

            progressBar1.Visible = true;
            Application.DoEvents();
            progressBar1.Value = 40;
            Application.DoEvents();
            user = ws.GetUser(textBox1.Text);
            if (user == null)
            {
                MessageBox.Show("No such user.");
                return;
            }
            progressBar1.Value = 100;
            Application.DoEvents();
            user.Solve = ws.GetAccepted(user.Name);
            Application.DoEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                MessageBox.Show("请阅读使用须知");
                return ;
            }
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("请输入初始账号");
                return ;
            }
            Thread t = new Thread(new ThreadStart(getUser));
            t.Start();
            if (t.Join(100000000))
            {
                if (user != null)
                {
                    this.Hide();
                    new main(user).Show();
                }
                else
                {
                    this.Refresh();
                }

            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        //无边框窗口拖动代码
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        

    }
}
