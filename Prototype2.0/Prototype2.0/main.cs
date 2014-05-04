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
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Collections;
using System.Threading;
namespace Prototype2._0
{
    public partial class main : Form
    {
        private User user = new User();
        private User cowMan = new User();
        private List<int> recommandProblems = new List<int>();
        private WebService webService = new WebService();
        public main()
        {
            InitializeComponent();
            this.AcceptButton = button3;
        }
        //窗口载入时调用
        private void main_Load(object sender, EventArgs e)
        {
            
            InitMenu();
            RefleshMenu();
            InitPanel();
            RefleshPanel();
            ShowPanel(9);
            panel_menu.Enabled = false;
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
            this.menu[this.button_xuexiniuren].Add(this.button_zhexiantuduibi);
            this.menu[this.button_xuexiniuren].Add(this.button_bingtuduibi);
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
            this.panel.Add(this.panel_Login);
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
        //刷新我的信息panel
        private void RefleshWodexinxiPanel()
        {
            this.label301.Text = user.Name;
            this.label25.Text = user.Rank.ToString();
            this.label27.Text = user.ProblemsSubmitted.ToString();
            this.label29.Text = user.ProblemsSolved.ToString();
            this.label5.Text = user.Submissions.ToString();
            this.label6.Text = user.Accepted.ToString();
            this.listBox1.Items.Clear();
            foreach (Problem problem in user.Solve)
            {
                String s = problem.Id + "  " + problem.AcTime.ToString();
                listBox1.Items.Add(s);
            }
        }
        //刷新奋斗史panel
        private void RefleshFendoushiPanel()
        {
            chart1.Series.Clear();
            chart3.Series.Clear();
            user.ToLineChart(chart1, "month");
            user.ToLineChart(chart3, "month");
            user.ToPieChart(chart4);
        }
        //刷新做题分类panel
        private void RefleshZuotifenleiPanel()
        {
            user.ToPieChart(chart2);
        }
        //获取默认用户
        private void getUser()
        {
            panel_Login.Enabled = false;
            panel_menu.Enabled = false;
            user = webService.GetUser(textBox3.Text, progressBar1);
            if (user == null)
            {
                MessageBox.Show("No such user.");
                return;
            }
            user.Solve = webService.GetAccepted(user.Name, progressBar1);
            RefleshWodexinxiPanel();
            RefleshFendoushiPanel();
            RefleshZuotifenleiPanel();
            panel_menu.Enabled = true;
            ShowPanel(0);
            panel_Login.Enabled = true;
        }
        //获取牛人
        private void getCowMan()
        {
            groupBox1.Enabled = false;
            if (radioButton1.Checked == true)
            {
                cowMan = webService.GetUser(textBox1.Text, progressBar1);
                if (cowMan == null)
                {
                    MessageBox.Show("No such cowMan.");
                    return;
                }
            }
            else if (radioButton2.Checked == true)
            {
                int Rank;
                try
                {
                    Rank = Convert.ToInt32(textBox2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Number required.");
                    return;
                }
                cowMan = webService.GetUser(webService.GetUserNameByRank(Rank), progressBar1);
                if (cowMan == null)
                {
                    MessageBox.Show("No such cowMan.");
                    return;
                }
            }
            else if (radioButton3.Checked == true)
            {
                Random random = new Random();
                int rank = random.Next(99);
                rank += 1;
                cowMan = webService.GetUser(webService.GetUserNameByRank(rank), progressBar1);
                while (cowMan.Submissions / cowMan.ProblemsSolved > 20)
                {
                    rank = random.Next(99);
                    rank += 1;
                    cowMan = webService.GetUser(webService.GetUserNameByRank(rank), progressBar1);
                }
            }
            cowMan.Solve = webService.GetAccepted(cowMan.Name, progressBar1);
            if (cowMan.Solve == null)
                return;
            label33.Text = cowMan.Name;
            label19.Text = cowMan.Rank.ToString();
            label17.Text = cowMan.ProblemsSubmitted.ToString();
            label12.Text = cowMan.ProblemsSolved.ToString();
            label24.Text = cowMan.Submissions.ToString();
            label23.Text = cowMan.Accepted.ToString();
            listBox2.Items.Clear();
            foreach (Problem problem in cowMan.Solve)
            {
                String s = problem.Id + "  " + problem.AcTime.ToString();
                listBox2.Items.Add(s);
            }
            chart3.Series.Clear();
            user.ToLineChart(chart3, "month");
            cowMan.ToLineChart(chart3, "month");
            cowMan.ToPieChart(chart5);
            groupBox1.Enabled = true;
            label11.Text = cowMan.Name;
            radioButton4.Checked = true;
        }
        //获取荐题
        private void getRecommand()
        {
            groupBox2.Enabled = false;
            if (radioButton4.Checked == true)
            {
                try
                {
                    recommandProblems = user.getProblemDiff(cowMan.Solve);
                    label9.Text = String.Empty;
                    foreach (int i in recommandProblems)
                    {
                        label9.Text += i.ToString() + " ";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("获取默认牛人失败。");
                }
            }
            else if (radioButton5.Checked == true)
            {
                Random random = new Random();
                int rank = random.Next(99);
                rank += 1;
                User newCowMan = webService.GetUser(webService.GetUserNameByRank(rank), progressBar1);
                while (newCowMan.Submissions / newCowMan.ProblemsSolved > 20)
                {
                    rank = random.Next(99);
                    rank += 1;
                    newCowMan = webService.GetUser(webService.GetUserNameByRank(rank), progressBar1);
                }
                newCowMan.Solve = webService.GetAccepted(newCowMan.Name, progressBar1);
                recommandProblems = user.getProblemDiff(newCowMan.Solve);
                label9.Text = String.Empty;
                foreach (int i in recommandProblems)
                {
                    label9.Text += i.ToString() + " ";
                }
            }
            else if (radioButton6.Checked == true)
            {
                int Rank;
                try
                {
                    Rank = Convert.ToInt32(textBox4.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Number required.");
                    groupBox2.Enabled = true;
                    return;
                }
                User newCowMan = webService.GetUser(webService.GetUserNameByRank(Rank), progressBar1);
                if (cowMan == null)
                {
                    MessageBox.Show("No such cowMan.");
                    groupBox2.Enabled = true;
                    return;
                }
                newCowMan.Solve = webService.GetAccepted(newCowMan.Name, progressBar1);
                recommandProblems = user.getProblemDiff(newCowMan.Solve);
                label9.Text = String.Empty;
                foreach (int i in recommandProblems)
                {
                    label9.Text += i.ToString() + " ";
                }
            }
            groupBox2.Enabled = true;
        }
        private void button_wodexinxi_Click(object sender, EventArgs e)
        {
            MenuClick(0);
            ShowPanel(0);
        }

        private void button_jiudehuiyi_Click(object sender, EventArgs e)
        {
            MenuClick(1);
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
            Thread t = new Thread(getCowMan);
            t.Start();
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

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Thread t = new Thread(getRecommand);
            t.Start();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            settings setting = new settings();
            setting.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ShowPanel(9);
            textBox3.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(getUser);
            t.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.RemoveAt(0);
            if (comboBox1.SelectedIndex == 0)
                user.ToLineChart(chart1, "day");
            else if (comboBox1.SelectedIndex == 1)
                user.ToLineChart(chart1, "month");
            else if (comboBox1.SelectedIndex == 2)
                user.ToLineChart(chart1, "year");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart3.Series.RemoveAt(0);
            if(chart3.Series.Count==1)
                chart3.Series.RemoveAt(0);
            if (comboBox2.SelectedIndex == 0)
            {
                user.ToLineChart(chart3, "day");
                cowMan.ToLineChart(chart3, "day");
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                user.ToLineChart(chart3, "month");
                cowMan.ToLineChart(chart3, "month");

            }
            else if (comboBox2.SelectedIndex == 2)
            {
                user.ToLineChart(chart3, "year");
                cowMan.ToLineChart(chart3, "year");
            }
        }

        
    }
}
