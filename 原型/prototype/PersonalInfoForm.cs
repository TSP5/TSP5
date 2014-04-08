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
            //chart1
            chart1.ChartAreas[0].AxisX.Title = "注册后月份";
            chart1.ChartAreas[0].AxisY.Title = "做题数";
            chart1.Series[0].Points.DataBindXY(xval, yval);
            chart1.Series[0].LegendText = "我";
            //chart2
            String[] chart2X = { "动态规划", "博弈", "搜索", "模拟" };
            int[] chart2Y = { 20, 15, 30, 50 };
            chart2.Series[0].LegendText = "#VALX";
            chart2.Series[0].Label = "#VALY[#PERCENT]";
            chart2.ChartAreas[0].AxisX.Title = "类型";
            chart2.ChartAreas[0].AxisY.Title = "做题数";
            chart2.Series[0].Points.DataBindXY(chart2X, chart2Y);
            chart2.Series[0]["PieLabelStyle"] = "Outside";

            //chart3
            int[] chart3Y = { 20, 61, 42, 53, 34, 25, 56, 67, 38, 29, 50, 61 };
            int[] chart3X = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            chart3.ChartAreas[0].AxisX.Title = "注册后月份";
            chart3.ChartAreas[0].AxisY.Title = "做题数";
            chart3.Series[0].Points.DataBindXY(chart3X, chart3Y);
            int[] chart3Y2 = { 40, 81, 92, 103, 64, 75, 86, 117, 128, 99, 60, 71 };
            chart3.Series[1].Points.DataBindXY(chart3X, chart3Y2);
            chart3.Series[0].LegendText = "我";
            chart3.Series[1].LegendText = "牛人";
            //chart4
            String[] chart4X = { "动态规划", "博弈", "搜索", "模拟" };
            int[] chart4Y = { 20, 15, 30, 50 };
            chart4.Series[0].LegendText = "#VALX";
            chart4.Series[0].Label = "#VALY[#PERCENT]";
            chart4.ChartAreas[0].AxisX.Title = "类型";
            chart4.ChartAreas[0].AxisY.Title = "做题数";
            chart4.Series[0].Points.DataBindXY(chart4X, chart4Y);
            chart4.Series[0]["PieLabelStyle"] = "Outside";

            //chart5
            String[] chart5X = { "动态规划", "博弈", "搜索", "模拟" };
            int[] chart5Y = { 400, 500, 900, 300 };
            chart5.Series[0].LegendText = "#VALX";
            chart5.Series[0].Label = "#VALY[#PERCENT]";
            chart5.ChartAreas[0].AxisX.Title = "类型";
            chart5.ChartAreas[0].AxisY.Title = "做题数";
            chart5.Series[0].Points.DataBindXY(chart5X, chart5Y);
            chart5.Series[0]["PieLabelStyle"] = "Outside";
        }

        private void PersonalInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
