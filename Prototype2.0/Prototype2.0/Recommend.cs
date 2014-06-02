using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Prototype2._0
{
    public partial class Recommend : Form
    {
        main parent = null;
        public Recommend(main parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void getRecommand()
        {
            groupBox2.Enabled = false;
            if (radioButton4.Checked == true)
            {
                try
                {
                    foreach (User cowMan in parent.cowMans)
                    {
                        if (cowMan.Name == comboBox2.SelectedItem.ToString())
                        {
                            parent.recommandProblems = parent.user.getProblemDiff(cowMan.Solve);
                            break;
                        }
                    }
                    label9.Text = String.Empty;
                    foreach (int i in parent.recommandProblems)
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
                User newCowMan = parent.webService.GetUser(parent.webService.GetUserNameByRank(rank), parent.getProgressBar());
                while (newCowMan.Submissions / newCowMan.ProblemsSolved > 20)
                {
                    rank = random.Next(99);
                    rank += 1;
                    newCowMan = parent.webService.GetUser(parent.webService.GetUserNameByRank(rank), parent.getProgressBar());
                }
                newCowMan.Solve = parent.webService.GetAccepted(newCowMan.Name, parent.getProgressBar());
                parent.recommandProblems = parent.user.getProblemDiff(newCowMan.Solve);
                label9.Text = String.Empty;
                foreach (int i in parent.recommandProblems)
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
                User newCowMan = parent.webService.GetUser(parent.webService.GetUserNameByRank(Rank), parent.getProgressBar());
                if (newCowMan == null)
                {
                    MessageBox.Show("No such cowMan.");
                    groupBox2.Enabled = true;
                    return;
                }
                newCowMan.Solve = parent.webService.GetAccepted(newCowMan.Name, parent.getProgressBar());
                parent.recommandProblems = parent.user.getProblemDiff(newCowMan.Solve);
                label9.Text = String.Empty;
                foreach (int i in parent.recommandProblems)
                {
                    label9.Text += i.ToString() + " ";
                }
            }
            groupBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(getRecommand);
            t.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Submit sb = new Submit();
            sb.MdiParent = parent;
            sb.Show();
        }
    }
}
