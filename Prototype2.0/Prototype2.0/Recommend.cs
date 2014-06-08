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
        List<String> problemsID = new List<String>();
        public Recommend(main parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        private void label_Click(object sender, EventArgs e)
        {
            Label tmp = (Label)sender;

            Submit sub = new Submit(tmp.Text,parent);
            sub.MdiParent = parent;
            sub.Show();
        }

        private Boolean addProblemID(String text)
        {
            problemsID.Add(text);
            return true;
        }

        Boolean lockGroup()
        {
            groupBox1.Enabled = false;
            return true;
        }

        Boolean unlockGroup()
        {
            groupBox1.Enabled = true;
            return true;
        }

        private void getRecommand()
        {
            lockGroup();
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
                    foreach (int i in parent.recommandProblems)
                    {
                        addProblemID(i.ToString());
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("获取默认牛人失败。");
                }
                finally
                {
                    unlockGroup();
                }
            }
            else if (radioButton5.Checked == true)
            {
                Random random = new Random();
                int rank = random.Next(99);
                rank += 1;
                User newCowMan = parent.webService.GetUser(parent.webService.GetUserNameByRank(rank), progressBar1);
                while (newCowMan.Submissions / newCowMan.ProblemsSolved > 20)
                {
                    rank = random.Next(99);
                    rank += 1;
                    newCowMan = parent.webService.GetUser(parent.webService.GetUserNameByRank(rank), progressBar1);
                }
                newCowMan.Solve = parent.webService.GetAccepted(newCowMan.Name, progressBar1);
                parent.recommandProblems = parent.user.getProblemDiff(newCowMan.Solve);
                foreach (int i in parent.recommandProblems)
                {
                    addProblemID(i.ToString());
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
                    unlockGroup();
                    return;
                }
                User newCowMan = parent.webService.GetUser(parent.webService.GetUserNameByRank(Rank), progressBar1);
                if (newCowMan == null)
                {
                    MessageBox.Show("No such cowMan.");
                    unlockGroup();
                    return;
                }
                newCowMan.Solve = parent.webService.GetAccepted(newCowMan.Name, progressBar1);
                parent.recommandProblems = parent.user.getProblemDiff(newCowMan.Solve);

                foreach (int i in parent.recommandProblems)
                {
                    addProblemID(i.ToString());
                }
            }
            unlockGroup();
        }

        private void Recommend_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void doProblembutton_Click(object sender, EventArgs e)
        {
            Submit sb = new Submit();
            sb.MdiParent = parent;
            sb.Show();
        }

        private void getCowManbutton_Click(object sender, EventArgs e)
        {
            problemsID.Clear();
            flowLayoutPanel1.Controls.Clear();
            Thread t = new Thread(getRecommand);
            t.Start();
            t.Join();
            foreach (var c in problemsID)
            {
                Label tmp = new Label();
                tmp.AutoSize = true;
                tmp.Text = c;
                tmp.Click += label_Click;
                flowLayoutPanel1.Controls.Add(tmp);
            }
        }
    }
}
