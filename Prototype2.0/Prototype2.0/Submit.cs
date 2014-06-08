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
        main parent = null;
        public Submit(String proID, main parent)
        {
            this.parent = parent;
            InitializeComponent();
            accounttextBox.Text = parent.user.Name;
            proIDtextBox.Text = proID;
        }

        public Submit()
        {
            InitializeComponent();
        }

        private void Submit_Load(object sender, EventArgs e)
        {
            String id = proIDtextBox.Text;
            Navigate(webBrowser1, "http://acm.hdu.edu.cn/showproblem.php?pid="+id);
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

        //#region 自动登录
        //private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    HtmlDocument log_auto = webBrowser1.Document;
        //    HtmlElement log_btn = null;

        //    foreach (HtmlElement em in log_auto.All) //轮循  
        //    {
        //        string str = em.Name;
        //        string id = em.Id;

        //        if ((str == "username") || (str == "userpass") || (str == "login")) //减少处理  
        //        {
        //            switch (str)
        //            {
        //                case "username": em.SetAttribute("value", "ChangChang");
        //                    break; //赋用户名  
        //                case "userpass": em.SetAttribute("value", "13823353176");
        //                    break; //赋密码  
        //                case "login": log_btn = em;
        //                    break; //获取submit按钮  
        //                default:
        //                    break;
        //            }
        //        }

        //    }
        //    log_btn.InvokeMember("click"); //触发submit事件
        //}
        //#endregion

        private void addcodebutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                codepathtextBox.Text = openFileDialog1.FileName;
            }
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            int language;
            String account, password, path, problemid, code;
            account = accounttextBox.Text;
            password = passwordtextBox.Text;
            path = codepathtextBox.Text;
            problemid = proIDtextBox.Text;
            language = languagecomboBox.SelectedIndex;
            code = getCode(path);

            Navigate(webBrowser1, "http://acm.hdu.edu.cn/showproblem.php?pid=" + problemid);

            WebService ws = new WebService();
            ws.loginAccount(account, password);
            ws.submitProblem(account, problemid, language.ToString(), code);
        }

        private String getCode(String path)
        {
            String ret = String.Empty;
            try
            {
                FileStream aFile = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                String tmp = sr.ReadLine();
                while (tmp != null)
                {
                    ret += (tmp+'\n');
                    tmp = sr.ReadLine();
                }
                sr.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ret;
        }
    }
}
