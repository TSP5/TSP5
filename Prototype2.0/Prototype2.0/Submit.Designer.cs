namespace Prototype2._0
{
    partial class Submit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.passwordtextBox = new System.Windows.Forms.TextBox();
            this.languagecomboBox = new System.Windows.Forms.ComboBox();
            this.submitbutton = new System.Windows.Forms.Button();
            this.accounttextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.proIDtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.codepathtextBox = new System.Windows.Forms.TextBox();
            this.addcodebutton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "密码：";
            // 
            // passwordtextBox
            // 
            this.passwordtextBox.Location = new System.Drawing.Point(221, 24);
            this.passwordtextBox.Name = "passwordtextBox";
            this.passwordtextBox.Size = new System.Drawing.Size(100, 21);
            this.passwordtextBox.TabIndex = 1;
            this.passwordtextBox.UseSystemPasswordChar = true;
            // 
            // languagecomboBox
            // 
            this.languagecomboBox.FormattingEnabled = true;
            this.languagecomboBox.Items.AddRange(new object[] {
            "G++",
            "GCC",
            "C++",
            "C",
            "Pascal",
            "Java"});
            this.languagecomboBox.Location = new System.Drawing.Point(837, 136);
            this.languagecomboBox.Name = "languagecomboBox";
            this.languagecomboBox.Size = new System.Drawing.Size(76, 20);
            this.languagecomboBox.TabIndex = 2;
            // 
            // submitbutton
            // 
            this.submitbutton.BackColor = System.Drawing.Color.DimGray;
            this.submitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitbutton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.submitbutton.ForeColor = System.Drawing.Color.White;
            this.submitbutton.Location = new System.Drawing.Point(816, 252);
            this.submitbutton.Name = "submitbutton";
            this.submitbutton.Size = new System.Drawing.Size(88, 27);
            this.submitbutton.TabIndex = 3;
            this.submitbutton.Text = "Submit";
            this.submitbutton.UseVisualStyleBackColor = false;
            this.submitbutton.Click += new System.EventHandler(this.submitbutton_Click);
            // 
            // accounttextBox
            // 
            this.accounttextBox.Location = new System.Drawing.Point(66, 24);
            this.accounttextBox.Name = "accounttextBox";
            this.accounttextBox.Size = new System.Drawing.Size(100, 21);
            this.accounttextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "账号：";
            // 
            // proIDtextBox
            // 
            this.proIDtextBox.Location = new System.Drawing.Point(838, 95);
            this.proIDtextBox.Name = "proIDtextBox";
            this.proIDtextBox.Size = new System.Drawing.Size(100, 21);
            this.proIDtextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(799, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "题号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(799, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "语言：";
            // 
            // codepathtextBox
            // 
            this.codepathtextBox.Location = new System.Drawing.Point(432, 24);
            this.codepathtextBox.Name = "codepathtextBox";
            this.codepathtextBox.Size = new System.Drawing.Size(385, 21);
            this.codepathtextBox.TabIndex = 9;
            // 
            // addcodebutton
            // 
            this.addcodebutton.BackColor = System.Drawing.Color.DimGray;
            this.addcodebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addcodebutton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addcodebutton.ForeColor = System.Drawing.Color.White;
            this.addcodebutton.Location = new System.Drawing.Point(825, 22);
            this.addcodebutton.Name = "addcodebutton";
            this.addcodebutton.Size = new System.Drawing.Size(88, 25);
            this.addcodebutton.TabIndex = 10;
            this.addcodebutton.Text = "添加代码";
            this.addcodebutton.UseVisualStyleBackColor = false;
            this.addcodebutton.Click += new System.EventHandler(this.addcodebutton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(31, 77);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(742, 523);
            this.webBrowser1.TabIndex = 11;
            // 
            // Submit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(962, 666);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.addcodebutton);
            this.Controls.Add(this.codepathtextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.proIDtextBox);
            this.Controls.Add(this.accounttextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submitbutton);
            this.Controls.Add(this.languagecomboBox);
            this.Controls.Add(this.passwordtextBox);
            this.Controls.Add(this.label1);
            this.Name = "Submit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Submit";
            this.Load += new System.EventHandler(this.Submit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordtextBox;
        private System.Windows.Forms.ComboBox languagecomboBox;
        private System.Windows.Forms.Button submitbutton;
        private System.Windows.Forms.TextBox accounttextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox proIDtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codepathtextBox;
        private System.Windows.Forms.Button addcodebutton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}