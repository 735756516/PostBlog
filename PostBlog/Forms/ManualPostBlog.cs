using System;
using System.Windows.Forms;

namespace PostBlog
{
    public partial class ManualPostBlog : Form
    {
        /// <summary>
        /// 全局变量定义
        /// </summary>
        private String strUserName = String.Empty;
        private String strPassword = String.Empty;
        private String strBlogURL = String.Empty;
        private String strTitle = String.Empty;
        private String strURL = String.Empty;

        /// <summary>
        /// 全局变量定义
        /// </summary>
        private MetaWeblogAPI metaWeblog = null;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <param name="strBlogURL"></param>
        /// <param name="strTitle"></param>
        /// <param name="strURL"></param>
        public ManualPostBlog(String strUserName, String strPassword, String strBlogURL, String strTitle, String strURL)
        {
            InitializeComponent();

            this.strUserName = strUserName;
            this.strPassword = strPassword;
            this.strBlogURL = strBlogURL;
            this.strTitle = strTitle;
            this.strURL = strURL;

            if (String.IsNullOrEmpty(this.strUserName) ||
                String.IsNullOrEmpty(this.strPassword) ||
                String.IsNullOrEmpty(this.strBlogURL) ||
                String.IsNullOrEmpty(this.strTitle) ||
                String.IsNullOrEmpty(this.strURL))
            {
                MessageBox.Show("Sorry，Init PostBlog Failed，Application Will Exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }
        }


        /// <summary>
        /// 窗体加载事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostBlog_Load(object sender, EventArgs e)
        {
            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();
            Application.DoEvents();
            this.InitForm();
            loadForm.Close();
        }


        /// <summary>
        /// 进入输入日志标题文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "Input Blog Title")
            {
                txtTitle.Text = String.Empty;
            }
        }


        /// <summary>
        /// 离开输入日志标题文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTitle_Leave(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                txtTitle.Text = "Input Blog Title";
            }
        }


        /// <summary>
        /// 进入设置类别文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSetCategories_Enter(object sender, EventArgs e)
        {
            if (txtSetCategories.Text.Trim() == "Select Blog Categories")
            {
                txtSetCategories.Text = String.Empty;
            }
        }


        /// <summary>
        /// 离开设置类别文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSetCategories_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSetCategories.Text.Trim()))
            {
                txtSetCategories.Text = "Select Blog Categories";
            }
        }


        /// <summary>
        /// CheckBoxList 选择更改事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxListCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            Int32 nCategories = 0;
            String strCategories = String.Empty;

            for (int i = 0; i < chkBoxListCategories.Items.Count; i++)
            {
                if (chkBoxListCategories.GetItemChecked(i))
                {
                    if (nCategories == 0)
                    {
                        strCategories += chkBoxListCategories.Items[i].ToString();
                    }
                    else
                    {
                        strCategories += "," + chkBoxListCategories.Items[i].ToString();
                    }
                    nCategories++;
                }
            }

            if (String.IsNullOrEmpty(strCategories) == false)
            {
                txtSetCategories.Text = strCategories;
            }
            else
            {
                txtSetCategories.Text = "Select Blog Categories";
            }
        }


        /// <summary>
        /// 发布按钮单击事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublish_Click(object sender, EventArgs e)
        {
            String strTmpTitle = txtTitle.Text.Trim();
            String strTmpDescription = txtDescription.Text.Trim();
            String strTmpCategories = txtSetCategories.Text.Trim();

            if (String.IsNullOrEmpty(strTmpCategories) || strTmpCategories == "Select Blog Categories")
            {
                MessageBox.Show("   Sorry，Please Select Blog Categories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(strTmpTitle) || strTmpTitle == "Input Blog Title")
            {
                MessageBox.Show("   Sorry，Please Input Blog Title.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(strTmpDescription))
            {
                MessageBox.Show("   Sorry，Please Input Blog Content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();
            Application.DoEvents();
            String strResult = this.btnPublishClick(strTmpTitle, strTmpDescription, strTmpCategories);
            loadForm.Close();

            if (String.IsNullOrEmpty(strResult) == false)
            {
                if (strResult.Contains("Succeed") == true)
                {
                    MessageBox.Show(strResult, "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(strResult, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// 刷新分类列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();
            Application.DoEvents();
            this.btnRefreshClick();
            loadForm.Close();
        }

         
        /// <summary>
        /// 刷新分类按钮事件处理
        /// </summary>
        private void btnRefreshClick()
        {
            System.Threading.Thread.Sleep(1500);

            chkBoxListCategories.Items.Clear();
            txtSetCategories.Text = "Select Blog Categories";

            try
            {
                MetaWeblogEntity.Category[] allCategory = metaWeblog.getCategories("MyBlog", strUserName, strPassword);

                for (int i = 0; i < allCategory.Length; i++)
                {
                    if (String.IsNullOrEmpty(allCategory[i].description) == false)
                    {
                        chkBoxListCategories.Items.Add(allCategory[i].description);
                    }
                }

                chkBoxListCategories.Focus();
                //MessageBox.Show("   Refresh Blog Categories Succeed.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("   Refresh Blog Categories Failed，Error Message: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            this.Text = this.strTitle;

            metaWeblog = new MetaWeblogAPI();
            metaWeblog.Url = strBlogURL;

            try
            {
                MetaWeblogEntity.Category[] allCategory = metaWeblog.getCategories("MyBlog", strUserName, strPassword);

                for (int i = 0; i < allCategory.Length; i++)
                {
                    if (String.IsNullOrEmpty(allCategory[i].description) == false)
                    {
                        chkBoxListCategories.Items.Add(allCategory[i].description);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("   Init Manual Post Blog Form，Error Message: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            System.Threading.Thread.Sleep(1500);
        }


        /// <summary>
        /// 发布按钮事件处理
        /// </summary>
        /// <param name="strTmpTitle"></param>
        /// <param name="strTmpDescription"></param>
        /// <param name="strTmpCategories"></param>
        private String btnPublishClick(String strTmpTitle, String strTmpDescription, String strTmpCategories)
        {
            System.Threading.Thread.Sleep(1500);

            String strResult = String.Empty;

            try
            {
                MetaWeblogEntity.Post post = new MetaWeblogEntity.Post();
                post.dateCreated = DateTime.Now;
                post.title = strTmpTitle;
                post.description = strTmpDescription;
                post.categories = strTmpCategories.Split(',');
                String strPostID = metaWeblog.newPost(String.Empty, strUserName, strPassword, post, true);


                txtSetCategories.Text = "Select Blog Categories";
                txtTitle.Text = "Input Blog Title";
                txtDescription.Text = String.Empty;

                for (int i = 0; i < chkBoxListCategories.Items.Count; i++)
                {
                    chkBoxListCategories.SetItemChecked(i, false);
                }
                chkBoxListCategories.Focus();

                strResult = "   Publish Blog Succeed.";
                
            }
            catch (Exception ex)
            {
                strResult = "   Publish Blog Failed，Error Message: " + ex.Message;
            }

            return strResult;
        }
    }
}
