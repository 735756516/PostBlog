using System;
using System.Windows.Forms;

namespace PostBlog
{
    public partial class BlogLogin : Form
    {
        private static String[] BlogAddress = new String[]
        {
            "http://www.icedeep.com/blog/xmlrpc.php",
            "http://www.cinir.com/security-news/xmlrpc.php"
        };
      
        //"http://www.cppblog.com/BoyXiao/services/metaweblog.aspx"
        //"http://www.cnblogs.com/BoyXiao/services/metaweblog.aspx"


        /// <summary>
        /// 构造函数
        /// </summary>
        public BlogLogin()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体加载事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlogLogin_Load(object sender, EventArgs e)
        {
            foreach(String strBlogAddr in BlogAddress)
            {
                cbBoxBlogURL.Items.Add(strBlogAddr);
            }

            cbBoxBlogURL.SelectedIndex = 0;

            txtBlogURL.Visible = false;
        }


        /// <summary>
        /// 登录按钮单击事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //String strBlogURL = txtBlogURL.Text.Trim();
            String strBlogURL = cbBoxBlogURL.Text.Trim();
            String strUserName = txtUserName.Text.Trim();
            String strPassword = txtPassword.Text.Trim();
            if (String.IsNullOrEmpty(strBlogURL) == true)
            {
                MessageBox.Show("Sorry，Please Input Correct Blog URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(strUserName) == true)
            {
                MessageBox.Show("Sorry，Please Input Correct User Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(strPassword) == true)
            {
                MessageBox.Show("Sorry，Please Input Correct Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();

            Application.DoEvents();
            MetaWeblogEntity.UserBlog[] allUserBlog = this.ClientLogin(strBlogURL, strUserName, strPassword);

            if (allUserBlog != null && allUserBlog.Length > 0)
            {
                loadForm.Close();

                String strURL = allUserBlog[0].url;
                String strTitle = allUserBlog[0].blogName;

                this.Visible = false;
                if (chkBoxManualMode.Checked == true)
                {
                    ManualPostBlog postBlog = new ManualPostBlog(strUserName, strPassword, strBlogURL, strTitle, strURL);
                    postBlog.ShowDialog();
                }
                else
                {
                    AutoPostBlog postBlog = new AutoPostBlog(strUserName, strPassword, strBlogURL, strTitle, strURL);
                    postBlog.ShowDialog();
                }
                this.Visible = true;
            }
            else
            {
                loadForm.Close();
            }
        }


        /// <summary>
        /// 客户端登陆
        /// </summary>
        /// <param name="strBlogURL"></param>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        private MetaWeblogEntity.UserBlog[] ClientLogin(String strBlogURL, String strUserName, String strPassword)
        {
            System.Threading.Thread.Sleep(2000);

            MetaWeblogAPI metaWeblog = new MetaWeblogAPI();
            metaWeblog.Url = strBlogURL;

            try
            {
                return metaWeblog.getUsersBlogs(String.Empty, strUserName, strPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }


        /// <summary>
        /// 退出按钮单击事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// 自动模式选择事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBoxAutoMode.Checked == true)
            {
                chkBoxManualMode.Checked = false;
            }
            else
            {
                chkBoxManualMode.Checked = true;
            }
        }


        /// <summary>
        /// 手动模式选择事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxManualMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxManualMode.Checked == true)
            {
                chkBoxAutoMode.Checked = false;
            }
            else
            {
                chkBoxAutoMode.Checked = true;
            }
        }
    }
}
