namespace PostBlog
{
    partial class BlogLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlogLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBlogURL = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.chkBoxAutoMode = new System.Windows.Forms.CheckBox();
            this.chkBoxManualMode = new System.Windows.Forms.CheckBox();
            this.cbBoxBlogURL = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Blog URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // txtBlogURL
            // 
            this.txtBlogURL.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlogURL.Location = new System.Drawing.Point(121, 131);
            this.txtBlogURL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBlogURL.Name = "txtBlogURL";
            this.txtBlogURL.Size = new System.Drawing.Size(449, 26);
            this.txtBlogURL.TabIndex = 7;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(121, 14);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(449, 26);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(121, 53);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(449, 26);
            this.txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(315, 141);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 32);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(458, 141);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 32);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkBoxAutoMode
            // 
            this.chkBoxAutoMode.AutoSize = true;
            this.chkBoxAutoMode.Checked = true;
            this.chkBoxAutoMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxAutoMode.Font = new System.Drawing.Font("Consolas", 10F);
            this.chkBoxAutoMode.Location = new System.Drawing.Point(77, 147);
            this.chkBoxAutoMode.Name = "chkBoxAutoMode";
            this.chkBoxAutoMode.Size = new System.Drawing.Size(99, 21);
            this.chkBoxAutoMode.TabIndex = 3;
            this.chkBoxAutoMode.Text = "Auto Mode";
            this.chkBoxAutoMode.UseVisualStyleBackColor = true;
            this.chkBoxAutoMode.CheckedChanged += new System.EventHandler(this.chkBoxAutoMode_CheckedChanged);
            // 
            // chkBoxManualMode
            // 
            this.chkBoxManualMode.AutoSize = true;
            this.chkBoxManualMode.Font = new System.Drawing.Font("Consolas", 10F);
            this.chkBoxManualMode.Location = new System.Drawing.Point(182, 147);
            this.chkBoxManualMode.Name = "chkBoxManualMode";
            this.chkBoxManualMode.Size = new System.Drawing.Size(115, 21);
            this.chkBoxManualMode.TabIndex = 4;
            this.chkBoxManualMode.Text = "Manual Mode";
            this.chkBoxManualMode.UseVisualStyleBackColor = true;
            this.chkBoxManualMode.CheckedChanged += new System.EventHandler(this.chkBoxManualMode_CheckedChanged);
            // 
            // cbBoxBlogURL
            // 
            this.cbBoxBlogURL.FormattingEnabled = true;
            this.cbBoxBlogURL.Location = new System.Drawing.Point(121, 92);
            this.cbBoxBlogURL.Name = "cbBoxBlogURL";
            this.cbBoxBlogURL.Size = new System.Drawing.Size(449, 27);
            this.cbBoxBlogURL.TabIndex = 2;
            // 
            // BlogLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(584, 191);
            this.Controls.Add(this.cbBoxBlogURL);
            this.Controls.Add(this.chkBoxManualMode);
            this.Controls.Add(this.chkBoxAutoMode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtBlogURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "BlogLogin";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blog Login";
            this.Load += new System.EventHandler(this.BlogLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBlogURL;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkBoxAutoMode;
        private System.Windows.Forms.CheckBox chkBoxManualMode;
        private System.Windows.Forms.ComboBox cbBoxBlogURL;
    }
}