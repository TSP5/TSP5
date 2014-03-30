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

        private void button1_Click(object sender, EventArgs e)
        {
            Memories myMemoryForm = new Memories();
            myMemoryForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LForm learnForm = new LForm();
            learnForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RForm rcommendForm = new RForm();
            rcommendForm.Show();
        }

        private void PersonalInfoForm_Load(object sender, EventArgs e)
        {
            label1.Text = account;
        }
    }
}
