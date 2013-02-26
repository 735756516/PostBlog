namespace PostBlog
{
    partial class ManualPostBlog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualPostBlog));
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSetCategories = new System.Windows.Forms.TextBox();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.chkBoxListCategories = new System.Windows.Forms.CheckedListBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeft_2 = new System.Windows.Forms.Panel();
            this.pnlLeft_3 = new System.Windows.Forms.Panel();
            this.pnlLeft_1 = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnl3.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLeft_2.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(734, 25);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "Input Blog Title";
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.txtTitle_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(734, 440);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.WordWrap = false;
            // 
            // txtSetCategories
            // 
            this.txtSetCategories.AutoCompleteCustomSource.AddRange(new string[] {
            "dddd",
            "ddsdsd",
            "dstrt",
            "fdfdgfs",
            "fdbd",
            "dsssd"});
            this.txtSetCategories.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSetCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSetCategories.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtSetCategories.Location = new System.Drawing.Point(0, 0);
            this.txtSetCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSetCategories.Name = "txtSetCategories";
            this.txtSetCategories.ReadOnly = true;
            this.txtSetCategories.Size = new System.Drawing.Size(734, 25);
            this.txtSetCategories.TabIndex = 0;
            this.txtSetCategories.Text = "Select Blog Categories";
            this.txtSetCategories.Enter += new System.EventHandler(this.txtSetCategories_Enter);
            this.txtSetCategories.Leave += new System.EventHandler(this.txtSetCategories_Leave);
            // 
            // pnl3
            // 
            this.pnl3.Controls.Add(this.txtDescription);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl3.Location = new System.Drawing.Point(0, 60);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(734, 440);
            this.pnl3.TabIndex = 8;
            // 
            // chkBoxListCategories
            // 
            this.chkBoxListCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkBoxListCategories.CheckOnClick = true;
            this.chkBoxListCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBoxListCategories.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.chkBoxListCategories.FormattingEnabled = true;
            this.chkBoxListCategories.HorizontalScrollbar = true;
            this.chkBoxListCategories.Location = new System.Drawing.Point(0, 0);
            this.chkBoxListCategories.Name = "chkBoxListCategories";
            this.chkBoxListCategories.Size = new System.Drawing.Size(230, 500);
            this.chkBoxListCategories.TabIndex = 0;
            this.chkBoxListCategories.SelectedValueChanged += new System.EventHandler(this.chkBoxListCategories_SelectedValueChanged);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlLeft_2);
            this.pnlLeft.Controls.Add(this.pnlLeft_3);
            this.pnlLeft.Controls.Add(this.pnlLeft_1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 42);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(230, 500);
            this.pnlLeft.TabIndex = 10;
            // 
            // pnlLeft_2
            // 
            this.pnlLeft_2.Controls.Add(this.chkBoxListCategories);
            this.pnlLeft_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft_2.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft_2.Name = "pnlLeft_2";
            this.pnlLeft_2.Size = new System.Drawing.Size(230, 500);
            this.pnlLeft_2.TabIndex = 3;
            // 
            // pnlLeft_3
            // 
            this.pnlLeft_3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLeft_3.Location = new System.Drawing.Point(0, 500);
            this.pnlLeft_3.Name = "pnlLeft_3";
            this.pnlLeft_3.Size = new System.Drawing.Size(230, 0);
            this.pnlLeft_3.TabIndex = 2;
            // 
            // pnlLeft_1
            // 
            this.pnlLeft_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeft_1.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft_1.Name = "pnlLeft_1";
            this.pnlLeft_1.Size = new System.Drawing.Size(230, 0);
            this.pnlLeft_1.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnPublish);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(964, 42);
            this.pnlTop.TabIndex = 11;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(2, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(175, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh Category";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPublish.Image = ((System.Drawing.Image)(resources.GetObject("btnPublish.Image")));
            this.btnPublish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPublish.Location = new System.Drawing.Point(230, 4);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(145, 35);
            this.btnPublish.TabIndex = 0;
            this.btnPublish.Text = "Publish Blog";
            this.btnPublish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnl2);
            this.pnlRight.Controls.Add(this.pnl1);
            this.pnlRight.Controls.Add(this.pnl3);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(230, 42);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(734, 500);
            this.pnlRight.TabIndex = 12;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.txtTitle);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl2.Location = new System.Drawing.Point(0, 30);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(734, 30);
            this.pnl2.TabIndex = 10;
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.txtSetCategories);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(734, 30);
            this.pnl1.TabIndex = 9;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 542);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(964, 0);
            this.pnlBottom.TabIndex = 13;
            // 
            // ManualPostBlog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(964, 542);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Consolas", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ManualPostBlog";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManualPostBlog";
            this.Load += new System.EventHandler(this.PostBlog_Load);
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft_2.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSetCategories;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.CheckedListBox chkBoxListCategories;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlLeft_1;
        private System.Windows.Forms.Panel pnlLeft_3;
        private System.Windows.Forms.Panel pnlLeft_2;
    }
}