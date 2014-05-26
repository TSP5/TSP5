using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Prototype2._0
{
    public partial class Submit : Form
    {
        String account, password;
        public Submit()
        {
            InitializeComponent();
        }

        private void Submit_Load(object sender, EventArgs e)
        {
            Navigate(webBrowser1, "http://acm.hdu.edu.cn/userloginex.php");
        }

        // Navigates to the given URL if it is valid.
        private void Navigate(WebBrowser web, String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://"))
            {
                address = "http://" + address;
            }

            try
            {
                web.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }

        }

        #region 自动登录
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument log_auto = webBrowser1.Document;
            HtmlElement log_btn = null;

            foreach (HtmlElement em in log_auto.All) //轮循  
            {
                string str = em.Name;
                string id = em.Id;

                if ((str == "username") || (str == "userpass") || (str == "login")) //减少处理  
                {
                    switch (str)
                    {
                        case "username": em.SetAttribute("value", "ChangChang");
                            break; //赋用户名  
                        case "userpass": em.SetAttribute("value", "13823353176");
                            break; //赋密码  
                        case "login": log_btn = em;
                            break; //获取submit按钮  
                        default:
                            break;
                    }
                }

            }
            log_btn.InvokeMember("click"); //触发submit事件
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int language;
            String account,password,path,problemid,code;
            code = "#include <cstdio> int main(void) {int a;scanf(\"%d\",&a);printf(\"%d\n\");return 0;}";
            account = textBox2.Text;
            password = textBox1.Text;
            path = textBox4.Text;
            problemid = textBox3.Text;
            language = comboBox1.SelectedIndex;

            #region 登录
            HtmlDocument log_auto = webBrowser1.Document;
            HtmlElement log_btn = null;

            foreach (HtmlElement em in log_auto.All) //轮循  
            {
                string str = em.Name;
                string id = em.Id;

                if ((str == "username") || (str == "userpass") || (str == "login")) //减少处理  
                {
                    switch (str)
                    {
                        case "username": em.SetAttribute("value", account);
                            break; //赋用户名  
                        case "userpass": em.SetAttribute("value", password);
                            break; //赋密码  
                        case "login": log_btn = em;
                            break; //获取submit按钮  
                        default:
                            break;
                    }
                }

            }
            log_btn.InvokeMember("click"); //触发submit事件
            #endregion

            Navigate(webBrowser1, "http://acm.hdu.edu.cn/submit.php?pid=" + problemid);


            #region 提交
            HtmlDocument submit_html = webBrowser1.Document;
            foreach (HtmlElement em in submit_html.All) //轮循  
            {
                string str = em.Name;
                string id = em.Id;

                if ((str == "problemid") || (str == "language") || (str == "usercode")) //减少处理  
                {
                    switch (str)
                    {
                        case "problemid": em.SetAttribute("value", problemid.ToString());
                            break; //赋用户名  
                        case "language": em.SetAttribute("value", language.ToString());
                            break; //赋密码
                        case "usercode": em.SetAttribute("value", code);
                            break;
                        default:
                            break;
                    }
                }

            }

            webBrowser1.Document.InvokeScript("submit");
            #endregion
        }
    }
}
