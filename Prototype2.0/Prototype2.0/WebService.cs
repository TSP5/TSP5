using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
namespace Prototype2._0
{
    class WebService
    {
        //获取整个网页
        public  String GetWebContent(String Url, Encoding encode)
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
        
        //根据账号获取用户信息
        public User GetUser(String name)
        {
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
            return user;
        }
        //根据账号获取AC题目信息
        public List<Problem> GetAccepted(String name)
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
    }

}
