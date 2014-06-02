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
        public List<User> cowMans = new List<User>();
        //public Dictionary<User, List<User>> compare = new Dictionary<User, List<User>>();
        private User user = null;
        private List<int> recommandProblems = new List<int>();
        private WebService webService = new WebService();
        private bool flag = true;
        public main()
        {
            InitializeComponent();
            this.AcceptButton = button3;
            this.textBox3.Select();
            this.ContextMenuStrip = contextMenuStrip1;
        }
        //窗口载入时调用
        private void main_Load(object sender, EventArgs e)
        {
            
            InitMenu();
            RefleshMenu();
            InitPanel();
            RefleshPanel();
            ShowPanel(7);
            panel_menu.Enabled = false;

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
            this.panel.Add(this.panel_jiantixitong);    //Index:6
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
        //刷新对比
        public void RefleshCompare()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Dispose();
            }
            foreach (User cowman in cowMans)
            {
                Compare cp = new Compare(user, cowman);
                cp.MdiParent = this;
                cp.Show();
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
            this.panel[index].Enabled = true;
            this.panel[index].Show();
            for (int i = 0; i < this.panel.Count; i++)
            {
                if (i != index)
                    this.panel[i].Hide();
            }
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
            user.ToLineChart(chart1, "month");
        }
        // 刷新我的亮点panel
        private void RefleshWodeliangdian()
        {
            List<String> shark = new List<string>();
            String tmp = "至今为止你已经做了"+ user.ProblemsSolved +"道题啦！AC率达"+ user.Accepted*100/user.Submissions +"%！你就是明日大牛！";
            shark.Add(tmp);
            if (100 < user.Rank && user.Rank <= 1000)
            {
                tmp = "你的目前排名是第"+user.Rank+"名，不错哦，你已杀入前1000名啦！";
                shark.Add(tmp);
            }

            if ((user.Accepted - user.ProblemsSolved) * 10 > user.ProblemsSolved)
            {
                tmp = "同一道题目经常被你AC几次，看来你是一个追求极致的人！";
                shark.Add(tmp);
            }

            if (user.Rank <= 100)
            {
                tmp = "你目前排名第"+ user.Rank +",你已经进入大牛行列啦！实在是太厉害啦！";
                shark.Add(tmp);
            }
            if (shark.Count < 4)
            {
                for (int i = shark.Count; i <= 4; i++)
                {
                    tmp = "";
                    shark.Add(tmp);
                }
            }
            label14.Text = shark[0];
            label15.Text = shark[1];
            label8.Text = shark[2];
            label10.Text = shark[3];
        }
        //刷新做题分类panel
        private void RefleshZuotifenleiPanel()
        {
            user.ToPieChart(chart2, flag, true);
        }
        //获取默认用户
        public void getUser()
        {
            this.Enabled = false;
            user = webService.GetUser(textBox3.Text, progressBar1);
            if (user == null)
            {
                MessageBox.Show("No such user.");
                this.Enabled = true;
                return;
            }
            user.Solve = webService.GetAccepted(user.Name, progressBar1);
            RefleshWodexinxiPanel();
            RefleshFendoushiPanel();
            RefleshWodeliangdian();
            RefleshZuotifenleiPanel();
            this.Enabled = true;
            this.panel_menu.Enabled = true;
            ShowPanel(0);
        }

        private void getCowMan()
        {
            User cowMan = new User();
            this.Enabled = false;
            if (radioButton1.Checked == true)
            {
                cowMan = webService.GetUser(textBox5.Text, progressBar1);
                if (cowMan == null)
                {
                    MessageBox.Show("No such cowMan.");
                    this.Enabled = true;
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
                    this.Enabled = true;
                    return;
                }
                cowMan = webService.GetUser(webService.GetUserNameByRank(Rank), progressBar1);
                if (cowMan == null)
                {
                    MessageBox.Show("No such cowMan.");
                    this.Enabled = true;
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
            this.Enabled = true;
            cowMans.Add(cowMan);

        }
        //获取荐题
        private void getRecommand()
        {
            groupBox2.Enabled = false;
            if (radioButton4.Checked == true)
            {
                try
                {
                    foreach (User cowMan in cowMans)
                    {
                        if (cowMan.Name == comboBox2.SelectedItem.ToString())
                        {
                            recommandProblems = user.getProblemDiff(cowMan.Solve);
                            break;
                        }
                    }
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
                finally
                {
                    groupBox2.Enabled = true;
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
                if (newCowMan == null)
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
            RefleshPanel();
            RefleshCompare();
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
            comboBox2.Items.Clear();
            foreach (User cowman in cowMans)
                comboBox2.Items.Add(cowman.Name);
            MenuClick(3);
            ShowPanel(6);
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
            setting.setlabel4Name(user);
            setting.ShowDialog(this);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ShowPanel(9);
            textBox3.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getUser();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            if (comboBox1.SelectedIndex == 0)
                user.ToLineChart(chart1, "day");
            else if (comboBox1.SelectedIndex == 1)
                user.ToLineChart(chart1, "month");
            else if (comboBox1.SelectedIndex == 2)
                user.ToLineChart(chart1, "year");

        }

        

        public Chart CHART2
        {
            get { return chart2; }
            set { chart2 = value; }
        }
        
        public bool FLAG
        {
            get { return flag; }
            set { flag = value; }
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel(7);
            textBox3.Focus();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings setting = new settings();
            if (user != null)
                setting.setlabel4Name(user);
            setting.ShowDialog(this);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (cowMans.Count == 0)
            {
                MessageBox.Show("查看对比结果前至少添加一个牛人。");
                return;
            }
            RefleshPanel();
            foreach (Form form in this.MdiChildren)
            {
                form.Dispose();
            }
            foreach (User cowMan in cowMans)
            {
                Compare compare = new Compare(user, cowMan);
                compare.MdiParent = this;
                compare.Show();
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            user.ToPieChart(chart2, true, checkBox2.Checked);
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("请先登录。");
                return;
            }
            textBox1.Text = user.Name;
            listBox2.Items.Clear();
            foreach (User c in cowMans)
                listBox2.Items.Add(c.Name);
            ShowPanel(2);
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefleshPanel();
            RefleshCompare();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            getCowMan();
            RefleshPanel();
            RefleshCompare();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == 0)
                return;

            foreach (User c in cowMans)
            {
                if (c.Name == listBox2.SelectedItem.ToString())
                {
                    cowMans.Remove(c);
                    break;
                }
            }
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Submit().Show();
        }








    }
}
