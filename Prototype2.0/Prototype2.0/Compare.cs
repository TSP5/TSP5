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
    public partial class Compare : Form
    {
        private User user = new User();
        private User cowMan = new User();
        public Compare(User user, User cowMan)
        {
            this.user = user;
            this.cowMan = cowMan;
            InitializeComponent();
            this.Text = user.Name + "   ->   " + cowMan.Name;
            label301.Text = user.Name;
            label25.Text = user.Rank.ToString();
            label27.Text = user.ProblemsSubmitted.ToString();
            label29.Text = user.ProblemsSolved.ToString();
            label5.Text = user.Submissions.ToString();
            label6.Text = user.Accepted.ToString();
            label9.Text = cowMan.Name;
            label3.Text = cowMan.Rank.ToString();
            label2.Text = cowMan.ProblemsSubmitted.ToString();
            label1.Text = cowMan.ProblemsSolved.ToString();
            label8.Text = cowMan.Submissions.ToString();
            label7.Text = cowMan.Accepted.ToString();
            user.ToLineChart(chart1, "month");
            cowMan.ToLineChart(chart1, "month");
            user.ToPieChart(chart2, true, true);
            cowMan.ToPieChart(chart3, true, true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                user.ToLineChart(chart1, "day");
                cowMan.ToLineChart(chart1, "day");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                user.ToLineChart(chart1, "month");
                cowMan.ToLineChart(chart1, "month");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                user.ToLineChart(chart1, "year");
                cowMan.ToLineChart(chart1, "year");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            user.ToPieChart(chart2, true, checkBox2.Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cowMan.ToPieChart(chart3, true, checkBox1.Checked);
        }
    }
}
