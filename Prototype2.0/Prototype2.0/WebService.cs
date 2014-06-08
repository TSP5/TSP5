using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Windows.Forms;
using System.Web;
namespace Prototype2._0
{
    public class WebService
    {
        //获取整个网页
        public String GetWebContent(String Url, Encoding encode)
        {
            try
            {
                if (Url.Equals("about:blank")) return null;
                if (!Url.StartsWith("http://") && !Url.StartsWith("https://"))
                {
                    Url = "http://" + Url;
                }


                //根据获取网址向服务器发送请求：
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(Url);
                //设置超时(10秒)
                myReq.Timeout = 60000;
                myReq.Accept = "Accept-Language:zh-cn";
                myReq.KeepAlive = true;
                myReq.Referer = Url;
                myReq.MaximumAutomaticRedirections = 100;
                myReq.AllowAutoRedirect = true;
                //网络响应请求
                HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();
                //获取网页字符流，并最终转换为系统默认的字符：
                Stream WebStream = myres.GetResponseStream();
                StreamReader Sreader = new StreamReader(WebStream, encode);
                String HtmlText = Sreader.ReadToEnd();
                //关闭字符流：
                Sreader.Close();
                WebStream.Close();
                return HtmlText;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }
        //根据排名获取用户名
        public String GetUserNameByRank(int rank)
        {
            if (rank < 0)
            {
                return null;
            }
            String url = "http://acm.hdu.edu.cn/ranklist.php?from=" + rank.ToString();
            Encoding encode = Encoding.GetEncoding("gb2312");
            String Page = this.GetWebContent(url, encode);
            int head, foot;
            head = Page.IndexOf("<td  height=22>" + rank.ToString() + "</td>");
            head = Page.IndexOf("<A href=\"userstatus.php?user=", head);
            head += 29;
            foot = Page.IndexOf("&PHPSESSID", head);
            return Page.Substring(head, foot - head);
        }


        //根据账号获取用户信息
        public User GetUser(String name, ProgressBar progressBar)
        {
            progressBar.Value = 0;
            Application.DoEvents();
            User user = new User();
            user.Name = name;
            String url = "http://acm.hdu.edu.cn/userstatus.php?user=" + name;
            Encoding encode = Encoding.GetEncoding("gb2312");
            String Page = this.GetWebContent(url, encode);
            if (Page.Contains("No such user."))
            {
                return null;
            }
            int head, foot;
            head = Page.IndexOf("<td>Rank</td>");
            Page.Remove(0, head);
            foot = Page.IndexOf("</tr>", head);
            head += 30;
            foot -= 5;
            user.Rank = System.Int32.Parse(Page.Substring(head, foot - head));
            head = Page.IndexOf("<td>Problems Submitted</td>", foot);
            foot = Page.IndexOf("</tr>", head);
            head += 44;
            foot -= 5;
            user.ProblemsSubmitted = System.Int32.Parse(Page.Substring(head, foot - head));
            head = Page.IndexOf("<td>Problems Solved</td>", foot);
            foot = Page.IndexOf("</tr>", head);
            head += 41;
            foot -= 5;
            user.ProblemsSolved = System.Int32.Parse(Page.Substring(head, foot - head));
            head = Page.IndexOf("<td>Submissions</td>", foot);
            foot = Page.IndexOf("</tr>", head);
            head += 37;
            foot -= 5;
            user.Submissions = System.Int32.Parse(Page.Substring(head, foot - head));
            head = Page.IndexOf("<td>Accepted</td>", foot);
            foot = Page.IndexOf("</tr>", head);
            head += 34;
            foot -= 5;
            user.Accepted = System.Int32.Parse(Page.Substring(head, foot - head));
            progressBar.Maximum = 50 + user.Accepted;
            Application.DoEvents();
            progressBar.Value += 50;
            Application.DoEvents();
            return user;
        }
        //根据账号获取AC题目信息
        public List<Problem> GetAccepted(String name, ProgressBar progressBar)
        {
            List<Problem> Result = new List<Problem>();  
            int ProID = 0;
            String SubmitTime = String.Empty;
            //go
            
            String temp = String.Empty;
            String url = "http://acm.hdu.edu.cn/status.php?user="+name+"&pid=0&lang=0&status=5#status";
            Encoding encode = Encoding.GetEncoding("gb2312");
            String Page = String.Empty;
            int head = 0;
            int foot = 0;
            try
            {
                while (true)
                {
                    Page = this.GetWebContent(url, encode);
                    if (!Page.Contains("<font color=red>Accepted</font>"))
                    {
                        break;
                    }
                    head = Page.IndexOf("</center></form></td>");
                    head = Page.IndexOf("<td>", head);
                    while (true)
                    {
                        head += 4;
                        foot = Page.IndexOf("</td>", head);
                        SubmitTime = Page.Substring(head, foot - head);
                        head = Page.IndexOf("<a href=", head);
                        head = Page.IndexOf(">", head);
                        head += 1;
                        foot = Page.IndexOf("</a>", head);
                        ProID = System.Int32.Parse(Page.Substring(head, foot - head));
                        Problem problem = new Problem();
                        problem.Id = ProID;
                        problem.AcTime = Convert.ToDateTime(SubmitTime);
                        Result.Add(problem);
                        progressBar.Value += progressBar.Value == progressBar.Maximum ? 0 : 1;
                        Application.DoEvents();
                        head = Page.IndexOf("</tr>", head);
                        if (Page.Substring(head, 13).Equals("</tr></table>"))
                        {
                            break;
                        }
                        head = Page.IndexOf("<td>", head);
                    }
                    if (!Page.Contains("Next Page"))
                    {
                        break;
                    }
                    head = Page.IndexOf("Prev Page</a>", head);
                    head += 48;
                    foot = Page.IndexOf("Next Page", head);
                    foot -= 2;
                    temp = Page.Substring(head, foot - head);
                    url = "http://acm.hdu.edu.cn" + temp;
                }
                return Result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        int getStatu(String Page)
        {
            int WT = 0, AC = 1, TLE = 2, RE = 3, WA = 4, CE = 5;
            int begin = Page.IndexOf("<input type=submit value=Go");
            for (int i = 0; i < 12; i++)
            {
                begin = Page.IndexOf(">",begin);
                begin++;
            }
            char c = Page[begin];
            switch (c)
            {
                case 'Q': return WT;
                case 'A': return AC;
                case 'T': return TLE;
                case 'R': return RE;
                case 'W': return WA;
            }
            return CE;
        }

        // httpPost方法
        private CookieContainer m_cookieContainer;
        public void loginAccount(string userID, string password)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create("http://acm.hdu.edu.cn/userloginex.php?action=login");//实例化web访问类  
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";//数据提交方式为POST  
                request.ContentType = "application/x-www-form-urlencoded";    //模拟头  
                request.AllowAutoRedirect = false;   // 不用需自动跳转

                string postdata = "username=" + userID + "&userpass=" + password + "&login=Sign+In";//////////////////////////

                request.Accept = "text/html, application/xhtml+xml,*/*";
                request.Referer = "http://acm.hdu.edu.cn/status.php";
                request.ContentLength = postdata.Length;////////////////////////////////////
                request.ContentType = "application/x-www-form-urlencoded";


                Cookie c1 = new Cookie("exesubmitlang", "2");
                c1.Domain = "acm.hdu.edu.cn";
                c1.Path = "/";
                //c1.Expires = "2015/6/1 星期一 23:48:34";

                m_cookieContainer = request.CookieContainer = new System.Net.CookieContainer();
                request.CookieContainer.Add(c1);

                request.KeepAlive = true;
                //提交请求  
                byte[] postdatabytes = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = postdatabytes.Length;
                Stream stream;
                stream = request.GetRequestStream();
                //设置POST 数据
                stream.Write(postdatabytes, 0, postdatabytes.Length);
                stream.Close();
                //接收响应  
                response = (HttpWebResponse)request.GetResponse();
                Stream WebStream = response.GetResponseStream();
                StreamReader Sreader = new StreamReader(WebStream, Encoding.Default);
                String Page = Sreader.ReadToEnd();

                if (Page.Contains("No such user or wrong password"))
                    MessageBox.Show("No such user");

                CookieCollection responseCookie = response.Cookies;
                m_cookieContainer.Add(responseCookie);
            }
            catch (System.Exception ex)
            {
                string msg = "网页请求异常，详细信息：" + ex.ToString();
                MessageBox.Show(msg);
            }
        }

        public string SubmitResult(string userID)
        {
            string result = string.Empty;

            return result;
        }

        public void submitProblem(string userID, string problemid, string language, string usercode)
        {

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create("http://acm.hdu.edu.cn/submit.php?action=submit");//实例化web访问类  

                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";//数据提交方式为POST  
                request.ContentType = "application/x-www-form-urlencoded";    //模拟头  
                request.AllowAutoRedirect = false;   // 不用需自动跳转
                
                request.CookieContainer = m_cookieContainer;//////
                usercode = HttpUtility.UrlEncode(usercode, Encoding.UTF8);
                string postdata = "check=0&problemid=" + problemid + "&language=" + language + "&usercode="+usercode;

                request.Accept = "text/html, application/xhtml+xml,*/*";
                request.Referer = "http://acm.hdu.edu.cn/submit.php?pid=1000";
                request.ContentLength = postdata.Length;////////////

                request.KeepAlive = true;
                //提交请求
                byte[] postdatabytes1 = Encoding.UTF8.GetBytes(postdata);
                int leng = postdata.Length;
                request.ContentLength = postdatabytes1.Length;
                Stream stream;
                stream = request.GetRequestStream();
                //设置POST 数据
                stream.Write(postdatabytes1, 0, postdatabytes1.Length);
                stream.Close();
                //接收响应  
                response = (HttpWebResponse)request.GetResponse();

                Stream stream2;
                stream2 = response.GetResponseStream();
                byte[] responseBytes = new byte[1024];

                if (usercode.Length < 50 || usercode.Length > 65536)
                {
                    MessageBox.Show("Code length is improper! Make sure your code length is longer than 50 and not exceed 65536 Bytes.");
                }
                else
                {
                    String url = "http://acm.hdu.edu.cn/status.php?user=" + userID;
                    Encoding encode = Encoding.GetEncoding("gb2312");

                    SubmitResult sr = new SubmitResult();
                    sr.Show();
                    sr.label1.Text = "Waiting";
                    sr.Update();
                    String WT,AC,TLE,RE,WA,CE;
                    WT = "Waiting";
                    AC = "Accepted";
                    TLE = "Time Limit Exceeded";
                    RE = "Runtime Error";
                    WA = "Wrong Answer";
                    CE = "Compilation Error";
                    int statu;
                    int times = 0;
                    while ((statu = getStatu(this.GetWebContent(url, encode))) == 0)
                    {
                        String tmp = WT;
                        for (int i = 0; i < times; i++)
                            tmp += ".";
                        sr.label1.Text = tmp;
                        sr.Update();
                        times++;
                        times %= 6;
                        System.Threading.Thread.Sleep(500);
                    }

                    switch (statu)
                    {
                        case 1: sr.label1.Text = AC; sr.label1.ForeColor = System.Drawing.Color.SeaGreen; ; break;
                        case 2: sr.label1.Text = TLE; sr.label1.ForeColor = System.Drawing.Color.Red; break;
                        case 3: sr.label1.Text = RE; sr.label1.ForeColor = System.Drawing.Color.Red;  break;
                        case 4: sr.label1.Text = WA; sr.label1.ForeColor = System.Drawing.Color.Red; break;
                        case 5: sr.label1.Text = CE; sr.label1.ForeColor = System.Drawing.Color.Red; break;
                    }
                    sr.Update();
                }
            }
            catch (System.Exception ex)
            {
                string msg = "网页请求异常，详细信息：" + ex.ToString();
                MessageBox.Show(msg);
            }
        }
    }

}
