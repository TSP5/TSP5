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
        private string str2 = null;
        private StreamReader sr;
        private List<Problem> solve;
        TreeNode flRoot = new TreeNode();

        public settings()
        {
            InitializeComponent();
            sr = new StreamReader("分类.txt", Encoding.Default);
            flRoot.Text = "默认分类";
            initFenLei(sr, flRoot);
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

        private void initFenLei(StreamReader sr, TreeNode flRoot)
        {
            int i = 0;
            string str, LeiName = string.Empty;
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            //读取文件
            while ((str = sr.ReadLine()) != null)
            {
                if (str.Contains(':'))
                {
                    i = str.IndexOf(':') + 1;
                    LeiName = str.Substring(0, str.IndexOf(':'));
                    dict.Add(LeiName, new List<string>());
                }

                for (int j = 0; j < str.Length; )
                {
                    dict[LeiName].Add(str.Substring(i, 4));
                    i = i + 5;
                    j = i + 7;
                }
            }
            sr.Close();

            //把分类添加到分类树上
            treeView1.Nodes.Add(flRoot);

            foreach (string key in dict.Keys)
            {
                TreeNode lei = new TreeNode();
                lei.Text = key;
                flRoot.Nodes.Add(lei);
                foreach (string value in dict[key])
                {
                    TreeNode id = new TreeNode();
                    id.Text = value;
                    lei.Nodes.Add(id);
                }
            }
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

        //分类管理菜单按钮的单击事件
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

        

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog ofd = sender as OpenFileDialog;
            StreamReader sr = new StreamReader(ofd.OpenFile(), Encoding.UTF8);
            TreeNode flRoot = new TreeNode();
            flRoot.Text = "自定义分类";
            initFenLei(sr, flRoot);
        }

        

        private void button12_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
            TreeNode node = treeView1.SelectedNode;
            string str = string.Empty;

            foreach (TreeNode tn in node.Nodes)
            {
                str = str + tn.Text + ":";
                foreach (TreeNode tnChild in tn.Nodes)
                {
                    str = str + " " + tnChild.Text;
                }
                str += "\r\n";
            }

            //获得字节数组
            byte[] data = new UTF8Encoding().GetBytes(str);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        //添加子节点
        private void button10_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            TreeNode newNode = new TreeNode();
            newNode.Text = "新节点";
            treeView1.SelectedNode.Nodes.Add(newNode);
        }

        //删除子节点
        private void button11_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            treeView1.SelectedNode.Remove();
        }

        //编辑子节点
        private void button9_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请先选择分类");
                return;
            }
            treeView1.SelectedNode.BeginEdit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("已保存");
            this.Close();
        }
    }
}
