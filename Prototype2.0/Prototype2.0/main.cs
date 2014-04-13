using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
namespace Prototype2._0
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        //窗口载入时调用
        private void main_Load(object sender, EventArgs e)
        {
            
            InitMenu();
            RefleshMenu();
            InitPanel();
            RefleshPanel();

        }
        //无边框窗口拖动代码
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        
        //左侧菜单项集合
        private Dictionary<Button, List<Button>> menu = new Dictionary<Button, List<Button>>();
        private Dictionary<Button, List<Button>>.KeyCollection firstMenu;
        //Panel集合
        private List<Panel> panel = new List<Panel>();
        //设置子菜单按钮高度
        private readonly int buttonHeight = 23;
        //记录已展开的菜单项
        private int menuOpen = -1;
        //初始化左侧菜单项
        private void InitMenu()
        {
            this.menu.Add(this.button_wodexinxi, new List<Button>());
            this.menu.Add(this.button_jiudehuiyi, new List<Button>());
            this.menu.Add(this.button_xuexiniuren, new List<Button>());
            this.menu[this.button_jiudehuiyi].Add(this.button_fendoushi);
            this.menu[this.button_jiudehuiyi].Add(this.button_zuotifenlei);
            this.menu[this.button_jiudehuiyi].Add(this.button_wodeliangdian);
            this.menu[this.button_xuexiniuren].Add(this.button_niurenduibi);
            this.menu[this.button_xuexiniuren].Add(this.button_jiantixitong);
            firstMenu = this.menu.Keys;
        }
        //初始化Panel
        private void InitPanel()
        {
            this.panel.Add(this.panel_wodexinxi);
            this.panel.Add(this.panel_jiudehuiyi);
            this.panel.Add(this.panel_xuexiniuren);
        }
        //刷新左侧菜单项
        private void RefleshMenu()
        {
            int top = this.panel_menu.Top + 10;
            foreach (KeyValuePair<Button, List<Button>> menuItem in this.menu)
            {
                menuItem.Key.Top = top;
                top += menuItem.Key.Height + 10;
                foreach (Button button in menuItem.Value)
                {
                    button.Hide();
                }
            }
        }
        //左侧菜单项点击事件处理
        private void MenuClick(int index)
        {
            if (this.menuOpen != index)
            {
                RefleshMenu();
                OpenMenu(index);
                menuOpen = index;
            }
            else
            {
                RefleshMenu();
                menuOpen = -1;
            }
        }
        //展开指定菜单项
        private void OpenMenu(int index)
        {
            for (int i = index + 1; i < menu.Count; i++)
            {
                this.firstMenu.ElementAt(i).Top += this.menu[this.firstMenu.ElementAt(index)].Count * (this.buttonHeight + 10);
            }
            int top = this.firstMenu.ElementAt(index).Top + this.firstMenu.ElementAt(index).Height + 10;
            foreach (Button button in this.menu[this.firstMenu.ElementAt(index)])
            {
                button.Top = top;
                top += this.buttonHeight + 10;
                button.Show();
            }
        }
        
        //刷新Panel
        private void RefleshPanel()
        {
            foreach (Panel panel in this.panel)
            {
                panel.Hide();
            }
            this.panel[0].Show();
        }
        //显示index指定的panel
        private void ShowPanel(int index)
        {
            foreach (Panel panel in this.panel)
            {
                panel.Hide();
            }
            this.panel[index].Show();
        }
        private void button_wodexinxi_Click(object sender, EventArgs e)
        {
            MenuClick(0);
            ShowPanel(0);
        }

        private void button_jiudehuiyi_Click(object sender, EventArgs e)
        {
            MenuClick(1);
            ShowPanel(1);
        }

        private void button_xuexiniuren_Click(object sender, EventArgs e)
        {
            MenuClick(2);
            ShowPanel(2);
        }

        

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

          


        
    }
}
