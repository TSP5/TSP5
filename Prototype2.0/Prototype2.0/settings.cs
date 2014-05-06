using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Prototype2._0
{
    public partial class settings : Form
    {
        private User user;
        private Chart chart2, chart5, chart4;
        private main ma;
        string str2 = null;
        private List<Problem> solve;

        public settings()
        {
            InitializeComponent();
            //ma = f1;
        }
        private void settings_Load(object sender, EventArgs e)
        {

            InitMenu();
            RefleshMenu();
            InitPanel();
            RefleshPanel();
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
            this.menu.Add(this.button1, new List<Button>());
            this.menu.Add(this.button2, new List<Button>());
            this.menu.Add(this.button3, new List<Button>());

            firstMenu = this.menu.Keys;
        }
        //初始化Panel
        private void InitPanel()
        {
            this.panel.Add(this.panel2);       //Index:0
            this.panel.Add(this.panel3);
            this.panel.Add(this.panel4);
        }
        //刷新左侧菜单项
        private void RefleshMenu()
        {
            int top = this.panel1.Top + 10;
            int left = this.panel1.Left + 10;
            foreach (KeyValuePair<Button, List<Button>> menuItem in this.menu)
            {
                menuItem.Key.Top = top;
                menuItem.Key.Left = left;
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

        private void button1_Click(object sender, EventArgs e)
        {
            MenuClick(0);
            ShowPanel(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuClick(1);
            ShowPanel(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuClick(2);
            ShowPanel(2);
        }

        public Chart ToPieChart(Chart chart)
        {
            solve = user.Solve;
            Dictionary<String, int> dic = new Dictionary<string, int>();
            int othernum = 0;
            List<String> list = new List<String>();
            string[] ContentLines = str2.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string al in ContentLines)
            {
                dic.Add(al.Substring(0, al.IndexOf(':')), 0);
            }
            //遍历
            foreach (Problem problem in solve)
            {
                bool isOther = true;
                for (int i = 0; i < ContentLines.Length; i++)
                {
                    if (ContentLines[i].Contains(problem.Id.ToString()))
                    {
                        //listnum++;
                        dic[ContentLines[i].Substring(0, ContentLines[i].IndexOf(':'))]++;
                        isOther = false;
                        break;
                    }
                }
                //新题目，其他类型
                if (isOther)
                {
                    othernum++;
                }
            }

            dic.Add("其他", othernum);
            chart.Series[0].Label = "#VALX, #VALY[#PERCENT]";
            chart.Series[0].Points.DataBindXY(dic.Keys, dic.Values);
            chart.Series[0]["PieLabelStyle"] = "Outside";

            return chart;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("已保存");

            if (!checkBox1.Checked)
            {
                ma = (main)this.Owner;
            chart2 = ma.CHART2;
            chart2 = ToPieChart(chart2);
            //chart5 = ma.CHART5;
            //chart5 = ToPieChart(chart5);
            chart4 = ma.CHART4;
            chart4 = ToPieChart(chart4);

            ma.CHART2 = chart2;
            //ma.CHART5 = chart5;
            ma.CHART4 = chart4;
            this.Close();
            //bool flag = false;
            ma.FLAG = false;
            ma.getUser();
            //ma.RefleshZuotifenleiPanel();
            }
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        internal void setlabel4Name(User user)
        {
            this.user = user;
            label4.Text = user.Name;
        }

        //默认账号的更改
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text.Equals("更改"))
            {
                label4.Visible = false;
                textBox3.Visible = true;
                textBox3.Select();
                textBox3.SelectAll();
                button5.Text = "确定";
            }
            else
            {   
                label4.Text = textBox3.Text;
                textBox3.Visible = false;
                label4.Visible = true;
                button5.Text = "更改";
            }
        }

        //查看分类
        private void button7_Click(object sender, EventArgs e)
        {            
            FenLei fl = new FenLei();

            if (checkBox1.Checked == true)
            {
                string str;
                StreamReader sr;
                
                
                sr = new StreamReader("分类.txt", Encoding.Default);
                
                while ((str = sr.ReadLine()) != null)
                {
                    FenLei.textBox1.Text = FenLei.textBox1.Text + str + "\r\n";
                }
                sr.Close();
                
                fl.ShowDialog();
            }
            else
            {
                FenLei.textBox1.Text = str2;
                fl.ShowDialog();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog ofd = sender as OpenFileDialog;
            StreamWriter sw = new StreamWriter("分类副本.txt");
            //sw = new StreamWriter(ofd.OpenFile(), Encoding.Default);

            string str;
            StreamReader sr = new StreamReader(ofd.OpenFile(),Encoding.UTF8);
            //byte[] bytes = new byte[ofd.OpenFile().Length];
            
            while ((str = sr.ReadLine()) != null)
            {
                str2 = str2 + str + "\r\n";
            }
            sw.Write(str2);
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //此条记录不存在则添加,并且只能在自定义分类上添加

            if (str2 == null)
            {
                MessageBox.Show("您还没有批量导入分类");
            }
            else if(!str2.Contains(textBox1.Text))
            {
                if (!str2.Contains(textBox2.Text))
                {
                    str2 = str2 + textBox2.Text + ":" + textBox1.Text + "\r\n";
                }
                else
                {
                    int pos = str2.IndexOf(textBox2.Text + ":");
                    str2 = str2.Insert(pos + textBox2.Text.Length + 1, textBox1.Text + " ");
                }
                
            }
        }
    }
}
