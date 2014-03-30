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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String account = AccountTextBox.Text.ToString();
            if (!noticeCheckBox.Checked)
            {
                MessageBox.Show("请阅读使用须知");
                return;
            }
            if (account.Length == 0)
            {
                MessageBox.Show("账号不能为空！");
                return ;
            }
            PersonalInfoForm myInfoForm = new PersonalInfoForm(account);
            myInfoForm.Show();
            this.Hide();
        }
    }
}
