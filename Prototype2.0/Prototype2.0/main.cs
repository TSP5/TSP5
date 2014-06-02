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
        public User user = null;
        public List<int> recommandProblems = new List<int>();
        public WebService webService = new WebService();

        public Compare tmpForm = null;

        public main()
        {
            InitializeComponent();
        }
        //窗口载入时调用
        private void main_Load(object sender, EventArgs e)
        {
            panel_xuexiniuren.SendToBack();
        }


        //获取默认用户
        public User getUser()
        {
            this.Enabled = false;
            User ret = webService.GetUser(textBox3.Text, progressBar1);
            if (ret == null)
            {
                MessageBox.Show("No such user.");
                this.Enabled = true;
                return null;
            }
            ret.Solve = webService.GetAccepted(ret.Name, progressBar1);
            this.Enabled = true;
            return ret;
        }

        private User getCowMan()
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
                    return null;
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
                    return null;
                }
                cowMan = webService.GetUser(webService.GetUserNameByRank(Rank), progressBar1);
                if (cowMan == null)
                {
                    MessageBox.Show("No such cowMan.");
                    this.Enabled = true;
                    return null;
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
            return cowMan;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user = null;
            panel_Login.BringToFront();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings set = new settings();
            set.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButtonInfo_Click(object sender, EventArgs e)
        {
            panel_xuexiniuren.SendToBack();
            panel_Login.SendToBack();
        }

        private void toolStripButtonJianti_Click(object sender, EventArgs e)
        {
            Recommend rc = new Recommend(this);
            rc.MdiParent = this;
            rc.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            User tmp = getUser();
            if (user == null)
                user = tmp;
            this.panel_Login.SendToBack();
            Compare cp = new Compare(tmp, null, this);
            cp.MdiParent = this;
            cp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tmpForm.cowMan = getCowMan();
            tmpForm.showUpdate();
            this.panel_xuexiniuren.SendToBack();
        }

        public void showXuexiniuren(String cowName)
        {
            this.panel_xuexiniuren.BringToFront();
            this.textBox1.Text = cowName;
        }

        public void showLogin()
        {
            this.panel_Login.BringToFront();
        }

        public ProgressBar getProgressBar()
        {
            return this.progressBar1;
        }

        private void 添加查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLogin();
        }
    }
}
