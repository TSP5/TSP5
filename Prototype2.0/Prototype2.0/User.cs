using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Collections;
using System.Windows.Forms;
namespace Prototype2._0
{
    public class User
    {
        private String name;
        private List<Problem> solve;
        private int rank;
        private int problemsSubmitted;
        private int problemsSolved;
        private int submissions;
        private int accepted;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Problem> Solve
        {
            get { return solve; }
            set { solve = value; }
        }
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        public int ProblemsSubmitted
        {
            get { return problemsSubmitted; }
            set { problemsSubmitted = value; }
        }
        public int ProblemsSolved
        {
            get { return problemsSolved; }
            set { problemsSolved = value; }
        }
        public int Submissions
        {
            get { return submissions; }
            set { submissions = value; }
        }
        public int Accepted
        {
            get { return accepted; }
            set { accepted = value; }
        }
        public void ToLineChart(Chart chart, String type)
        {
            if (type == "month")
            {
                chart.ChartAreas[0].AxisX.Title = "注册后月份";
                chart.ChartAreas[0].AxisY.Title = "做题数";
                chart.ChartAreas[0].AxisX.IsMarginVisible = false;
                Series series = new Series();
                series.ChartType = SeriesChartType.Line;
                series.MarkerStyle = MarkerStyle.Square;
                series.Label = "#VALY";
                series.SmartLabelStyle.Enabled = true;
                series.LegendText = name + "\n注册时间: " + solve[solve.Count - 1].AcTime.ToShortDateString();
                int totalMonth = this.getMonthdiff(solve[solve.Count - 1].AcTime, solve[0].AcTime);
                Dictionary<int, int> monthAc = new Dictionary<int, int>();
                for (int i = 0; i <= totalMonth; i++)
                {
                    monthAc[i] = 0;
                }
                for (int i = 0; i < solve.Count; i++)
                {
                    monthAc[this.getMonthdiff(solve[solve.Count - 1].AcTime, solve[i].AcTime)]++;
                }

                for (int i = 0; i <= totalMonth; i++)
                {
                    series.Points.Add(monthAc[i]);
                }
                chart.Series.Add(series);
            }
            else if (type == "day")
            {
                int dayDiff = (solve[0].AcTime - solve[solve.Count - 1].AcTime).Days;
                chart.ChartAreas[0].AxisX.Title = "注册后天数";
                chart.ChartAreas[0].AxisY.Title = "做题数";
                chart.ChartAreas[0].AxisX.IsMarginVisible = false;
                Series series = new Series();
                series.ChartType = SeriesChartType.Line;
                series.SmartLabelStyle.Enabled = true;
                series.LegendText = name + "\n注册时间: " + solve[solve.Count - 1].AcTime.ToShortDateString();

                Dictionary<int, Double> dayAc = new Dictionary<int, Double>();
                for (int i = 0; i <= dayDiff; i++)
                {
                    dayAc[i] = 0;
                }
                for (int i = 0; i < solve.Count; i++)
                {
                    dayAc[(solve[i].AcTime - solve[solve.Count - 1].AcTime).Days]++;
                }
                for (int i = 0; i <= dayDiff; i++)
                {
                    if (dayAc[i] == 0)
                    {
                        dayAc[i] = Double.NaN;
                    }
                }
                for (int i = 0; i <= dayDiff; i++)
                {
                    series.Points.Add(dayAc[i]);
                }
                chart.Series.Add(series);

            }
            
            else if (type == "year")
            {
                int yearDiff = solve[0].AcTime.Year - solve[solve.Count - 1].AcTime.Year;
                chart.ChartAreas[0].AxisX.Title = "注册后年数";
                chart.ChartAreas[0].AxisY.Title = "做题数";
                chart.ChartAreas[0].AxisX.IsMarginVisible = false;
                Series series = new Series();
                series.Label = "#VALY";
                series.ChartType = SeriesChartType.Line;
                series.MarkerStyle = MarkerStyle.Square;
                series.SmartLabelStyle.Enabled = true;
                series.LegendText = name + "\n注册时间: " + solve[solve.Count - 1].AcTime.ToShortDateString();
                Dictionary<int, int> yearAc = new Dictionary<int, int>();
                for (int i = 0; i <= yearDiff; i++)
                {
                    yearAc[i] = 0;
                }
                for (int i = 0; i < solve.Count; i++)
                {
                    yearAc[solve[i].AcTime.Year - solve[solve.Count - 1].AcTime.Year]++;
                }

                for (int i = 0; i <= yearDiff; i++)
                {
                    series.Points.Add(yearAc[i]);
                }
                chart.Series.Add(series);
            }
        }
        public void ToPieChart(Chart chart, bool selectFlag, bool showElse)
        {
            Dictionary<String, int> dic = new Dictionary<string, int>();
            string str = "";
            int othernum = 0;
            List<String> list = new List<String>();
            StreamReader sr;
            try
            {
                if (selectFlag == true)
                    sr = new StreamReader("分类.txt", Encoding.Default);
                else
                    sr = new StreamReader("分类副本.txt", Encoding.Default);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
            while ((str = sr.ReadLine()) != null)
            {
                list.Add(str);
            }
            sr.Close();
            foreach (string al in list)
            {
                dic.Add(al.Substring(0, al.IndexOf(':')), 0);
            }
            //遍历
            foreach (Problem problem in solve)
            {
                bool isOther = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ToString().Contains(problem.Id.ToString()))
                    {
                        //listnum++;
                        dic[list[i].ToString().Substring(0, list[i].ToString().IndexOf(':'))]++;
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
            if (showElse)
                dic.Add("其他", othernum);
            chart.Series[0].Label = "#VALX, #VALY[#PERCENT]";
            chart.Series[0].Points.DataBindXY(dic.Keys, dic.Values);
            chart.Series[0]["PieLabelStyle"] = "Outside";
        }    
        
        private int getMonthdiff(DateTime date1, DateTime date2)
        {
            int year1 = date1.Year;
            int year2 = date2.Year;
            int month1 = date1.Month;
            int month2 = date2.Month;
            int months = 12 * (year2 - year1) + (month2 - month1);
            return months;
        }
        public List<int> getProblemDiff(List<Problem> problems)
        {
            if (problems.Count == 0)
                return null;
            List<int> result = new List<int>();
            for (int i = problems.Count - 1; i >= 0; i--)
            {
                bool found = false;
                foreach (Problem problem in solve)
                {
                    if (problem.Id == problems[i].Id)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                    continue;
                else
                    result.Add(problems[i].Id);
                if (result.Count == 100)
                    break;
            }
            return result.Distinct().ToList();
        }

    }
}
