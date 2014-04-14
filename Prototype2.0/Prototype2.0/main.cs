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

            int[] yval = { 20, 61, 42, 53, 34, 25, 56, 67, 38, 29, 50, 61 };
            int[] xval = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            //chart1
            chart1.ChartAreas[0].AxisX.Title = "注册后月份";
            chart1.ChartAreas[0].AxisY.Title = "做题数";
            chart1.Series[0].Points.DataBindXY(xval, yval);
            chart1.Series[0].LegendText = "我";

            //chart2
            String[] chart2X = { "动态规划", "博弈", "搜索", "模拟" };
            int[] chart2Y = { 20, 15, 30, 50 };
            chart2.Series[0].LegendText = "#VALX";
            chart2.Series[0].Label = "#VALY[#PERCENT]";
            chart2.ChartAreas[0].AxisX.Title = "类型";
            chart2.ChartAreas[0].AxisY.Title = "做题数";
            chart2.Series[0].Points.DataBindXY(chart2X, chart2Y);
            chart2.Series[0]["PieLabelStyle"] = "Outside";

            //chart3
            int[] chart3Y = { 20, 61, 42, 53, 34, 25, 56, 67, 38, 29, 50, 61 };
            int[] chart3X = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            chart3.ChartAreas[0].AxisX.Title = "注册后月份";
            chart3.ChartAreas[0].AxisY.Title = "做题数";
            chart3.Series[0].Points.DataBindXY(chart3X, chart3Y);
            int[] chart3Y2 = { 40, 81, 92, 103, 64, 75, 86, 117, 128, 99, 60, 71 };
            chart3.Series[1].Points.DataBindXY(chart3X, chart3Y2);
            chart3.Series[0].LegendText = "我";
            chart3.Series[1].LegendText = "牛人";

            //chart4
            String[] chart4X = { "动态规划", "博弈", "搜索", "模拟" };
            int[] chart4Y = { 20, 15, 30, 50 };
            chart4.Series[0].LegendText = "#VALX";
            chart4.Series[0].Label = "#VALY[#PERCENT]";
            chart4.ChartAreas[0].AxisX.Title = "类型";
            chart4.ChartAreas[0].AxisY.Title = "做题数";
            chart4.Series[0].Points.DataBindXY(chart4X, chart4Y);
            chart4.Series[0]["PieLabelStyle"] = "Outside";

            //chart5
            String[] chart5X = { "动态规划", "博弈", "搜索", "模拟" };
            int[] chart5Y = { 400, 500, 900, 300 };
            chart5.Series[0].LegendText = "#VALX";
            chart5.Series[0].Label = "#VALY[#PERCENT]";
            chart5.ChartAreas[0].AxisX.Title = "类型";
            chart5.ChartAreas[0].AxisY.Title = "做题数";
            chart5.Series[0].Points.DataBindXY(chart5X, chart5Y);
            chart5.Series[0]["PieLabelStyle"] = "Outside";
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
        private readonly int buttonHeight = 25;
        //记录已展开的菜单项
        private int menuOpen = -1;
        //初始化左侧菜单项
        private void InitMenu()
        {
            this.menu.Add(this.button_wodexinxi, new List<Button>());
            this.menu.Add(this.button_jiudehuiyi, new List<Button>());
            this.menu.Add(this.button_xuexiniuren, new List<Button>());
            this.menu.Add(this.button_jiantixitong, new List<Button>());
            this.menu[this.button_jiudehuiyi].Add(this.button_fendoushi);
            this.menu[this.button_jiudehuiyi].Add(this.button_zuotifenlei);
            this.menu[this.button_jiudehuiyi].Add(this.button_wodeliangdian);
            this.menu[this.button_xuexiniuren].Add(this.button_bingtuduibi);
            this.menu[this.button_xuexiniuren].Add(this.button_zhexiantuduibi);
            //this.menu[this.button_xuexiniuren].Add(this.button_jiantixitong);
            firstMenu = this.menu.Keys;
        }
        //初始化Panel
        private void InitPanel()
        {
            this.panel.Add(this.panel_wodexinxi);       //Index:0
            this.panel.Add(this.panel_jiudehuiyi);      //Index:1
            this.panel.Add(this.panel_xuexiniuren);     //Index:2
            this.panel.Add(this.panel_fendoushi);       //Index:3      
            this.panel.Add(this.panel_zuotifenlei);     //Index:4
            this.panel.Add(this.panel_wodeliangdian);   //Index:5
            this.panel.Add(this.panel_bingtuduibi);     //Index:6
            this.panel.Add(this.panel_zhexiantuduibi);  //Index:7
            this.panel.Add(this.panel_jiantixitong);    //Index:8
        }
        //刷新左侧菜单项
        private void RefleshMenu()
        {
            int top = this.panel_menu.Top;
            int left = this.panel_menu.Left;
            foreach (KeyValuePair<Button, List<Button>> menuItem in this.menu)
            {
                menuItem.Key.Top = top;
                menuItem.Key.Left = left+10;
                top += menuItem.Key.Height + 10;
                foreach (Button button in menuItem.Value)
                {
                    button.Left = left + 30;
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
            //ShowPanel(1);
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

        private void button_fendoushi_Click(object sender, EventArgs e)
        {
            ShowPanel(3);
        }

        private void button_niurenduibi_Click(object sender, EventArgs e)
        {
            ShowPanel(6);
        }

        private void button_jiantixitong_Click(object sender, EventArgs e)
        {
            MenuClick(3);
            ShowPanel(8);
        }

        private void button_zuotifenlei_Click(object sender, EventArgs e)
        {
            ShowPanel(4);
        }

        private void button_wodeliangdian_Click(object sender, EventArgs e)
        {
            ShowPanel(5);
        }

        private void button_zhexiantuduibi_Click(object sender, EventArgs e)
        {
            ShowPanel(7);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowPanel(7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Focus();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox5.Visible = true;

        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            settings setting = new settings();
            setting.Show();
        }
        
    }
}
