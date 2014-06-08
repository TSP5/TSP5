using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype2._0
{
    public partial class InputCompare : Form
    {
        String cowName;
        Compare parent;
        public WebService webService = new WebService();
        public InputCompare(String cowName, Compare parent)
        {
            this.cowName = cowName;
            this.parent = parent;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            parent.cowMan = getCowMan();
            parent.showUpdate();
            this.Close();
        }

        private void InputCompare_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = cowName;
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
    }
}
