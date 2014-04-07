using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prototype
{
    public partial class PersonalInfoForm : Form
    {
        private String account;
        public PersonalInfoForm(String account)
        {
            this.account = account;
            
            InitializeComponent();
        }
        private void PersonalInfoForm_Load(object sender, EventArgs e)
        {
            label1.Text = account;
            int[] yval = { 20, 61, 42, 53, 34, 25, 56, 67, 38, 29, 50, 61 };
            int[] xval = { 1, 2, 3, 4,5, 6, 7, 8, 9, 10, 11, 12 };
            chart1.ChartAreas[0].AxisX.Title = "注册后月份";
            chart1.ChartAreas[0].AxisY.Title = "做题数";
            chart1.Series["我"].Points.DataBindXY(xval, yval);
        }

        private void PersonalInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
