using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PostBlog
{
    public partial class AutoPostBlog : Form
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
        public AutoPostBlog(String strUserName, String strPassword, String strBlogURL, String strTitle, String strURL)
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
        private void AutoPostBlog_Load(object sender, EventArgs e)
        {
            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();
            Application.DoEvents();
            this.InitForm();
            loadForm.Close();
        }


        /// <summary>
        /// 用户选择 URL 选择事件改变处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBoxDefaultURL_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();
            Application.DoEvents();
            this.cbBoxDefaultURLChanged();
            loadForm.Close();
        }


        /// <summary>
        /// 发布用户选择的按钮单击事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublishSelected_Click(object sender, EventArgs e)
        {
            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();
            Application.DoEvents();
            String strResult = this.btnPublishSelectedClick();
            loadForm.Close();

            if(String.IsNullOrEmpty(strResult) == false)
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
        /// 刷新最近 Post 列表按钮单击事件处理例程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshRecent_Click(object sender, EventArgs e)
        {
            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();
            Application.DoEvents();
            this.ReBindRecentPost();
            loadForm.Close();
        }


        /// <summary>
        /// 删除用户选择的最近的 Post 文章
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure you want to delete the selected blog ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                ClearRecentSelectedBlogs();

                return;
            }

            /* 显示加载窗口 */
            Loading loadForm = new Loading(this.Location, this.Size);
            loadForm.Show();
            Application.DoEvents();
            this.btnDeleteSelectedClick();
            this.ReBindRecentPost();
            loadForm.Close();

            MessageBox.Show("   Delete Blog Succeed.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// 重新绑定最近的 Post 列表
        /// </summary>
        private void ReBindRecentPost()
        {
            /* 重新绑定数据 */
            recentPostList.Clear();

            try
            {
                recentPostList = new List<MetaWeblogEntity.Post>(metaWeblog.getRecentPosts(String.Empty, strUserName, strPassword, ConfigEntity.Recent_Post_Count));
                if (recentPostList != null && recentPostList.Count > 0)
                {
                    List<Int32> indexList = new List<Int32>();
                    for (int i = 0; i < recentPostList.Count; i++)
                    {
                        try
                        {
                            MetaWeblogEntity.Post post = metaWeblog.getPost(recentPostList[i].postid.ToString(), strUserName, strPassword);
                            if (recentPostList[i].postid.ToString() == post.postid.ToString())
                            {
                                indexList.Add(i);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    List<MetaWeblogEntity.Post> tmpRecentPostList = new List<MetaWeblogEntity.Post>();

                    dgvRecent.Rows.Clear();
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        dgvRecent.Rows.Add(i + 1, recentPostList[indexList[i]].title, strUserName, recentPostList[indexList[i]].dateCreated.ToString("yyyy-MM-dd HH:mm"));
                        tmpRecentPostList.Add(recentPostList[indexList[i]]);
                    }

                    recentPostList.Clear();
                    recentPostList.AddRange(tmpRecentPostList);
                }
            }
            catch (Exception ex)
            {
                PInvokeAPI.OutputDebugString("Error In ReBindRecentPost，ErrorMessage: " + ex.Message);

                recentPostList.Clear();
            }
        }


        /// <summary>
        /// 设置所有项都不选择
        /// </summary>
        private void ClearDefaultSelectedBlogs()
        {
             for (int i = 0; i < dgvDefault.Rows.Count; i++)
             {
                 dgvDefault.Rows[i].Selected = false;
             }
        }


        /// <summary>
        /// 设置所有项都不选择
        /// </summary>
        private void ClearRecentSelectedBlogs()
        {
            for (int i = 0; i < dgvRecent.Rows.Count; i++)
            {
                dgvRecent.Rows[i].Selected = false;
            }
        }


        /// <summary>
        /// 获取用户所选择的分类
        /// </summary>
        /// <returns></returns>
        private String GetSelectedCategories()
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

            return strCategories;
        }


        /// <summary>
        /// 最近的 Post
        /// </summary>
        List<MetaWeblogEntity.Post> recentPostList = new List<MetaWeblogEntity.Post>();


        /// <summary>
        /// 博客园首页
        /// </summary>
        List<String> strCnBlogsHomePageTitleList = new List<String>();
        List<String> strCnBlogsHomePageUrlList = new List<String>();
        List<String> strCnBlogsHomePageDescList = new List<String>();
        List<String> strCnBlogsHomePageAuthorList = new List<String>();
        List<String> strCnBlogsHomePageDateTimeList = new List<String>();

        /// <summary>
        /// 博客园新闻
        /// </summary>
        List<String> strCnBlogsNewsTitleList = new List<String>();
        List<String> strCnBlogsNewsUrlList = new List<String>();
        List<String> strCnBlogsNewsDescList = new List<String>();
        List<String> strCnBlogsNewsAuthorList = new List<String>();
        List<String> strCnBlogsNewsDateTimeList = new List<String>();

        /// <summary>
        /// 博客园精华
        /// </summary>
        List<String> strCnBlogsPreciousTitleList = new List<String>();
        List<String> strCnBlogsPreciousUrlList = new List<String>();
        List<String> strCnBlogsPreciousDescList = new List<String>();
        List<String> strCnBlogsPreciousAuthorList = new List<String>();
        List<String> strCnBlogsPreciousDateTimeList = new List<String>();

        /// <summary>
        /// C++ 博客首页
        /// </summary>
        List<String> strCppBlogHomePageTitleList = new List<String>();
        List<String> strCppBlogHomePageUrlList = new List<String>();
        List<String> strCppBlogHomePageDescList = new List<String>();
        List<String> strCppBlogHomePageAuthorList = new List<String>();
        List<String> strCppBlogHomePageDateTimeList = new List<String>();

        /// <summary>
        /// CIOAge 首页
        /// </summary>
        List<String> strCIOAgeHomePageTitleList = new List<String>();
        List<String> strCIOAgeHomePageUrlList = new List<String>();
        List<String> strCIOAgeHomePageDescList = new List<String>();
        List<String> strCIOAgeHomePageAuthorList = new List<String>();
        List<String> strCIOAgeHomePageDateTimeList = new List<String>();

        /// <summary>
        /// 资安人首页
        /// </summary>
        List<String> strInfoSecurityTitleList = new List<String>();
        List<String> strInfoSecurityUrlList = new List<String>();
        List<String> strInfoSecurityDescList = new List<String>();
        List<String> strInfoSecurityAuthorList = new List<String>();
        List<String> strInfoSecurityDateTimeList = new List<String>();

        /// <summary>
        /// TechCrunch 文章列表
        /// </summary>
        List<String> strTechCrunchTitleList = new List<String>();
        List<String> strTechCrunchUrlList = new List<String>();
        List<String> strTechCrunchDescList = new List<String>();
        List<String> strTechCrunchAuthorList = new List<String>();
        List<String> strTechCrunchDateTimeList = new List<String>();


        /// <summary>
        /// 清空博客园首页缓存信息
        /// </summary>
        public void ClearCnBlogsHomePageCache()
        {
            strCnBlogsHomePageTitleList.Clear();
            strCnBlogsHomePageUrlList.Clear();
            strCnBlogsHomePageDescList.Clear();
            strCnBlogsHomePageAuthorList.Clear();
            strCnBlogsHomePageDateTimeList.Clear();
        }


        /// <summary>
        /// 清空博客园新闻缓存信息
        /// </summary>
        public void ClearCnBlogsNewsCache()
        {
            strCnBlogsNewsTitleList.Clear();
            strCnBlogsNewsUrlList.Clear();
            strCnBlogsNewsDescList.Clear();
            strCnBlogsNewsAuthorList.Clear();
            strCnBlogsNewsDateTimeList.Clear();
        }


        /// <summary>
        /// 清空博客园精华区缓存信息
        /// </summary>
        public void ClearCnBlogsPreciousCache()
        {
            strCnBlogsPreciousTitleList.Clear();
            strCnBlogsPreciousUrlList.Clear();
            strCnBlogsPreciousDescList.Clear();
            strCnBlogsPreciousAuthorList.Clear();
            strCnBlogsPreciousDateTimeList.Clear();
        }


        /// <summary>
        /// 清空 C++ 博客首页缓存信息
        /// </summary>
        public void ClearCppBlogHomePageCache()
        {
            strCppBlogHomePageTitleList.Clear();
            strCppBlogHomePageUrlList.Clear();
            strCppBlogHomePageDescList.Clear();
            strCppBlogHomePageAuthorList.Clear();
            strCppBlogHomePageDateTimeList.Clear();
        }


        /// <summary>
        /// 清空 CIOAge 首页缓存信息
        /// </summary>
        public void ClearCIOAgeHomePageCache()
        {
            strCIOAgeHomePageTitleList.Clear();
            strCIOAgeHomePageUrlList.Clear();
            strCIOAgeHomePageDescList.Clear();
            strCIOAgeHomePageAuthorList.Clear();
            strCIOAgeHomePageDateTimeList.Clear();
        }

        
        /// <summary>
        /// 清空资安人缓存信息
        /// </summary>
        public void ClearInfoSecurityCache()
        {
            strInfoSecurityTitleList.Clear();
            strInfoSecurityUrlList.Clear();
            strInfoSecurityDescList.Clear();
            strInfoSecurityAuthorList.Clear();
            strInfoSecurityDateTimeList.Clear();
        }


        /// <summary>
        /// 清空 TechCrunch 缓存信息
        /// </summary>
        public void ClearTechCrunchCache()
        {
            strTechCrunchTitleList.Clear();
            strTechCrunchUrlList.Clear();
            strTechCrunchDescList.Clear();
            strTechCrunchAuthorList.Clear();
            strTechCrunchDateTimeList.Clear();
        }
        

        /// <summary>
        /// 重新加载数据前的初始化
        /// </summary>
        public void InitReLoadData()
        {
            ClearCnBlogsHomePageCache();
            ClearCnBlogsNewsCache();
            ClearCnBlogsPreciousCache();
            ClearCppBlogHomePageCache();
            ClearCIOAgeHomePageCache();
            ClearInfoSecurityCache();
            ClearTechCrunchCache();
        }


        /// <summary>
        /// 初始化窗口
        /// </summary>
        private void InitForm()
        {
            dgvRecent.Columns.Clear();
            dgvRecent.Columns.Add("ID", "ID");
            dgvRecent.Columns.Add("Title", "Title");
            dgvRecent.Columns.Add("Author", "Author");
            dgvRecent.Columns.Add("Date", "Date");

            dgvRecent.Columns[0].Width = 40;
            dgvRecent.Columns[1].Width = 400;
            dgvRecent.Columns[2].Width = 120;
            dgvRecent.Columns[3].Width = 140;
            dgvRecent.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecent.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecent.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDefault.Columns.Clear();
            dgvDefault.Columns.Add("ID", "ID");
            dgvDefault.Columns.Add("Title", "Title");
            dgvDefault.Columns.Add("Author", "Author");
            dgvDefault.Columns.Add("Date", "Date");

            dgvDefault.Columns[0].Width = 40;
            dgvDefault.Columns[1].Width = 400;
            dgvDefault.Columns[2].Width = 120;
            dgvDefault.Columns[3].Width = 140;
            dgvDefault.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDefault.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDefault.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Text = this.strTitle;

            metaWeblog = new MetaWeblogAPI();
            metaWeblog.Url = strBlogURL;

            /* 绑定最近列表 */
            ReBindRecentPost();

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
                MessageBox.Show("   Init Auto Post Blog Form，Error Message: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < ConfigEntity.Default_URL.Length; i++)
            {
                cbBoxDefaultURL.Items.Add(ConfigEntity.Default_URL[i]);
            }

            cbBoxDefaultURL.SelectedIndex = 0;

            System.Threading.Thread.Sleep(1500);
        }


        /// <summary>
        /// 用户选择 URL 选择事件改变处理
        /// </summary>
        private void cbBoxDefaultURLChanged()
        {
            String strSelected = cbBoxDefaultURL.SelectedItem.ToString();
            if (String.IsNullOrEmpty(strSelected) == false)
            {
                switch (strSelected)
                {
                    case ConfigEntity.TechCrunch_Article_Name:
                        {
                            /* 重置数据 */
                            InitReLoadData();

                            /* TechCrunch 首页 */
                            Int32 nCount = TechCrunchBLL.GetArticlesFromTechCrunch(ref strTechCrunchTitleList, ref strTechCrunchUrlList, ref strTechCrunchDescList, ref strTechCrunchAuthorList, ref strTechCrunchDateTimeList);

                            /* 重新绑定数据 */
                            dgvDefault.Rows.Clear();
                            for (int i = 0; i <= nCount; i++)
                            {
                                dgvDefault.Rows.Add(i + 1, strTechCrunchTitleList[i], strTechCrunchAuthorList[i], strTechCrunchDateTimeList[i]);
                            }

                            break;
                        }
                    case ConfigEntity.InfoSecurity_Article_Name:
                        {
                            /* 重置数据 */
                            InitReLoadData();

                            /* InfoSecurity 首页 */
                            Int32 nCount = InfoSecurityBLL.GetArticlesFromInfoSecurity(ref strInfoSecurityTitleList, ref strInfoSecurityUrlList, ref strInfoSecurityDescList, ref strInfoSecurityAuthorList, ref strInfoSecurityDateTimeList);

                            /* 重新绑定数据 */
                            dgvDefault.Rows.Clear();
                            for (int i = 0; i <= nCount; i++)
                            {
                                dgvDefault.Rows.Add(i + 1, strInfoSecurityTitleList[i], strInfoSecurityAuthorList[i], strInfoSecurityDateTimeList[i]);
                            }

                            break;
                        }
                    case ConfigEntity.CIOAge_HomePage_Name:
                        {
                            /* 重置数据 */
                            InitReLoadData();

                            /* CIOAge 首页 */
                            Int32 nCount = CIOAgeBLL.GetHomePageBlogsFromCIOAge(ref strCIOAgeHomePageTitleList, ref strCIOAgeHomePageUrlList, ref strCIOAgeHomePageDescList, ref strCIOAgeHomePageAuthorList, ref strCIOAgeHomePageDateTimeList);

                            /* 重新绑定数据 */
                            dgvDefault.Rows.Clear();
                            for (int i = 0; i <= nCount; i++)
                            {
                                dgvDefault.Rows.Add(i + 1, strCIOAgeHomePageTitleList[i], strCIOAgeHomePageAuthorList[i], strCIOAgeHomePageDateTimeList[i]);
                            }

                            break;
                        }
                    case ConfigEntity.CppBlog_HomePage_Name:
                        {
                            /* 重置数据 */
                            InitReLoadData();

                            /* C++ 博客首页区 */
                            Int32 nCount = CppBlogBLL.GetHomePageBlogsFromCppBlog(ref strCppBlogHomePageTitleList, ref strCppBlogHomePageUrlList, ref strCppBlogHomePageDescList, ref strCppBlogHomePageAuthorList, ref strCppBlogHomePageDateTimeList);

                            /* 重新绑定数据 */
                            dgvDefault.Rows.Clear();
                            for (int i = 0; i <= nCount; i++)
                            {
                                dgvDefault.Rows.Add(i + 1, strCppBlogHomePageTitleList[i], strCppBlogHomePageAuthorList[i], strCppBlogHomePageDateTimeList[i]);
                            }

                            break;
                        }
                    case ConfigEntity.CnBlogs_HomePage_Name:
                        {
                            /* 重置数据 */
                            InitReLoadData();

                            /* 博客园首页区 */
                            Int32 nCount = CnBlogsBLL.GetHomePageBlogsFromCnBlogs(ref strCnBlogsHomePageTitleList, ref strCnBlogsHomePageUrlList, ref strCnBlogsHomePageDescList, ref strCnBlogsHomePageAuthorList, ref strCnBlogsHomePageDateTimeList);

                            /* 重新绑定数据 */
                            dgvDefault.Rows.Clear();
                            for (int i = 0; i <= nCount; i++)
                            {
                                dgvDefault.Rows.Add(i + 1, strCnBlogsHomePageTitleList[i], strCnBlogsHomePageAuthorList[i], strCnBlogsHomePageDateTimeList[i]);
                            }

                            break;
                        }
                    case ConfigEntity.CnBlogs_News_Name:
                        {
                            /* 重置数据 */
                            InitReLoadData();

                            /* 博客园新闻区 */
                            Int32 nCount = CnBlogsBLL.GetNewsFromCnBlogs(ref strCnBlogsNewsTitleList, ref strCnBlogsNewsUrlList, ref strCnBlogsNewsDescList, ref strCnBlogsNewsAuthorList, ref strCnBlogsNewsDateTimeList);

                            /* 重新绑定数据 */
                            dgvDefault.Rows.Clear();
                            for (int i = 0; i <= nCount; i++)
                            {
                                dgvDefault.Rows.Add(i + 1, strCnBlogsNewsTitleList[i], strCnBlogsNewsAuthorList[i], strCnBlogsNewsDateTimeList[i]);
                            }

                            break;
                        }
                    case ConfigEntity.CnBlogs_Precious_Name:
                        {
                            /* 重置数据 */
                            InitReLoadData();

                            /* 博客园精华区 */
                            Int32 nCount = CnBlogsBLL.GetPreciousFromCnBlogs(ref strCnBlogsPreciousTitleList, ref strCnBlogsPreciousUrlList, ref strCnBlogsPreciousDescList, ref strCnBlogsPreciousAuthorList, ref strCnBlogsPreciousDateTimeList);

                            /* 重新绑定数据 */
                            dgvDefault.Rows.Clear();
                            for (int i = 0; i <= nCount; i++)
                            {
                                dgvDefault.Rows.Add(i + 1, strCnBlogsPreciousTitleList[i], strCnBlogsPreciousAuthorList[i], strCnBlogsPreciousDateTimeList[i]);
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            System.Threading.Thread.Sleep(1500);
        }


        /// <summary>
        /// 发布用户选择的按钮单击事件处理
        /// </summary>
        private String btnPublishSelectedClick()
        {
            String strResult = String.Empty;

            String strSelected = cbBoxDefaultURL.SelectedItem.ToString();
            if (String.IsNullOrEmpty(strSelected) == false)
            {
                String strCategories = GetSelectedCategories();
                switch (strSelected)
                {
                    case ConfigEntity.TechCrunch_Article_Name:
                        {
                            /* TechCrunch 文章列表 */
                            for (int i = 0; i < dgvDefault.SelectedRows.Count; i++)
                            {
                                Int32 nIndex = (Int32)dgvDefault.SelectedRows[i].Cells[0].Value - 1;

                                String strTechCrunchHTML = String.Empty;
                                String strTechCrunchURL = strTechCrunchUrlList[nIndex];
                                if (DownloadBLL.DownloadHTML2String(strTechCrunchURL, Encoding.UTF8, ref strTechCrunchHTML) == true && String.IsNullOrEmpty(strTechCrunchHTML) == false)
                                {
                                    String strBodyOuterHtml = String.Empty;
                                    String strBodyInnerHtml = String.Empty;
                                    String strBodyInnerText = String.Empty;

                                    TechCrunchBLL.GetArticleBodyFromTechCrunch(strTechCrunchHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);

                                    try
                                    {
                                        MetaWeblogEntity.Post post = new MetaWeblogEntity.Post();
                                        post.title = strTechCrunchTitleList[nIndex];
                                        post.description = strBodyOuterHtml;
                                        post.categories = String.IsNullOrEmpty(strCategories) == true ? null : strCategories.Split(',');
                                        post.post_status = "new";
                                        post.dateCreated = DateTime.Now;
                                        String strPostID = metaWeblog.newPost(String.Empty, strUserName, strPassword, post, true);

                                        strResult = "   Publish Blog Succeed.";
                                    }
                                    catch (Exception ex)
                                    {
                                        strResult = "   Publish Blog Failed，Error Message: " + ex.Message;
                                    }
                                }
                            }
                            break;
                        }
                    case ConfigEntity.InfoSecurity_Article_Name:
                        {
                            /* 资安人文章列表 */
                            for (int i = 0; i < dgvDefault.SelectedRows.Count; i++)
                            {
                                Int32 nIndex = (Int32)dgvDefault.SelectedRows[i].Cells[0].Value - 1;

                                String strInfoSecurityHTML = String.Empty;
                                String strInfoSecurityURL = strInfoSecurityUrlList[nIndex];
                                if (DownloadBLL.DownloadHTML2String(strInfoSecurityURL, Encoding.UTF8, ref strInfoSecurityHTML) == true && String.IsNullOrEmpty(strInfoSecurityHTML) == false)
                                {
                                    String strBodyOuterHtml = String.Empty;
                                    String strBodyInnerHtml = String.Empty;
                                    String strBodyInnerText = String.Empty;

                                    InfoSecurityBLL.GetArticleBodyFromInfoSecurity(strInfoSecurityHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);

                                    try
                                    {
                                        MetaWeblogEntity.Post post = new MetaWeblogEntity.Post();
                                        post.title = strInfoSecurityTitleList[nIndex];
                                        post.description = strBodyOuterHtml;
                                        post.categories = String.IsNullOrEmpty(strCategories) == true ? null : strCategories.Split(',');
                                        post.post_status = "new";
                                        post.dateCreated = DateTime.Now;
                                        String strPostID = metaWeblog.newPost(String.Empty, strUserName, strPassword, post, true);

                                        strResult = "   Publish Blog Succeed.";
                                    }
                                    catch (Exception ex)
                                    {
                                        strResult = "   Publish Blog Failed，Error Message: " + ex.Message;
                                    }
                                }
                            }
                            break;
                        }
                    case ConfigEntity.CIOAge_HomePage_Name:
                        {
                            /* CIOAge 首页 */
                            for (int i = 0; i < dgvDefault.SelectedRows.Count; i++)
                            {
                                Int32 nIndex = (Int32)dgvDefault.SelectedRows[i].Cells[0].Value - 1;

                                String strCIOAgeBlogsHTML = String.Empty;
                                String strCIOAgeBlogsURL = strCIOAgeHomePageUrlList[nIndex];
                                if (DownloadBLL.DownloadHTML2String(strCIOAgeBlogsURL, Encoding.Default, ref strCIOAgeBlogsHTML) == true && String.IsNullOrEmpty(strCIOAgeBlogsHTML) == false)
                                {
                                    String strBodyOuterHtml = String.Empty;
                                    String strBodyInnerHtml = String.Empty;
                                    String strBodyInnerText = String.Empty;

                                    CIOAgeBLL.GetArticleBodyFromCIOAge(strCIOAgeBlogsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);

                                    try
                                    {
                                        MetaWeblogEntity.Post post = new MetaWeblogEntity.Post();
                                        post.title = strCIOAgeHomePageTitleList[nIndex];
                                        post.description = strBodyOuterHtml;
                                        post.categories = String.IsNullOrEmpty(strCategories) == true ? null : strCategories.Split(',');
                                        post.post_status = "new";
                                        post.dateCreated = DateTime.Now;
                                        String strPostID = metaWeblog.newPost(String.Empty, strUserName, strPassword, post, true);

                                        strResult = "   Publish Blog Succeed.";
                                    }
                                    catch (Exception ex)
                                    {
                                        strResult = "   Publish Blog Failed，Error Message: " + ex.Message;
                                    }
                                }
                            }
                            break;
                        }
                    case ConfigEntity.CppBlog_HomePage_Name:
                        {
                            /* C++ 博客首页区 */
                            for (int i = 0; i < dgvDefault.SelectedRows.Count; i++)
                            {
                                Int32 nIndex = (Int32)dgvDefault.SelectedRows[i].Cells[0].Value - 1;

                                String strCppBlogBlogsHTML = String.Empty;
                                String strCppBlogBlogsURL = strCppBlogHomePageUrlList[nIndex];
                                if (DownloadBLL.DownloadHTML2String(strCppBlogBlogsURL, Encoding.UTF8, ref strCppBlogBlogsHTML) == true && String.IsNullOrEmpty(strCppBlogBlogsHTML) == false)
                                {
                                    String strBodyOuterHtml = String.Empty;
                                    String strBodyInnerHtml = String.Empty;
                                    String strBodyInnerText = String.Empty;

                                    CppBlogBLL.GetBlogsBodyFromCppBlog(strCppBlogBlogsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);

                                    try
                                    {
                                        MetaWeblogEntity.Post post = new MetaWeblogEntity.Post();
                                        post.dateCreated = DateTime.Now;
                                        post.title = strCppBlogHomePageTitleList[nIndex];
                                        post.description = strBodyOuterHtml;
                                        post.categories = String.IsNullOrEmpty(strCategories) == true ? null : strCategories.Split(',');
                                        post.dateCreated = DateTime.Now;
                                        String strPostID = metaWeblog.newPost(String.Empty, strUserName, strPassword, post, true);

                                        strResult = "   Publish Blog Succeed.";
                                    }
                                    catch (Exception ex)
                                    {
                                        strResult = "   Publish Blog Failed，Error Message: " + ex.Message;
                                    }
                                }
                            }

                            break;
                        }
                    case ConfigEntity.CnBlogs_HomePage_Name:
                        {
                            /* 博客园首页区 */
                            for (int i = 0; i < dgvDefault.SelectedRows.Count; i++)
                            {
                                Int32 nIndex = (Int32)dgvDefault.SelectedRows[i].Cells[0].Value - 1;

                                String strCnBlogsBlogsHTML = String.Empty;
                                String strCnBlogsBlogsURL = strCnBlogsHomePageUrlList[nIndex];
                                if (DownloadBLL.DownloadHTML2String(strCnBlogsBlogsURL, Encoding.UTF8, ref strCnBlogsBlogsHTML) == true && String.IsNullOrEmpty(strCnBlogsBlogsHTML) == false)
                                {
                                    String strBodyOuterHtml = String.Empty;
                                    String strBodyInnerHtml = String.Empty;
                                    String strBodyInnerText = String.Empty;

                                    CnBlogsBLL.GetBlogsBodyFromCnBlogs(strCnBlogsBlogsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);

                                    try
                                    {
                                        MetaWeblogEntity.Post post = new MetaWeblogEntity.Post();
                                        post.dateCreated = DateTime.Now;
                                        post.title = strCnBlogsHomePageTitleList[nIndex];
                                        post.description = strBodyOuterHtml;
                                        post.categories = String.IsNullOrEmpty(strCategories) == true ? null : strCategories.Split(',');
                                        post.dateCreated = DateTime.Now;
                                        String strPostID = metaWeblog.newPost(String.Empty, strUserName, strPassword, post, true);

                                        strResult = "   Publish Blog Succeed.";
                                    }
                                    catch (Exception ex)
                                    {
                                        strResult = "   Publish Blog Failed，Error Message: " + ex.Message;
                                    }
                                }
                            }
                            break;
                        }
                    case ConfigEntity.CnBlogs_News_Name:
                        {
                            /* 博客园新闻区 */
                            for (int i = 0; i < dgvDefault.SelectedRows.Count; i++)
                            {
                                Int32 nIndex = (Int32)dgvDefault.SelectedRows[i].Cells[0].Value - 1;

                                String strCnBlogsNewsHTML = String.Empty;
                                String strCnBlogsNewsURL = strCnBlogsNewsUrlList[nIndex]; ;
                                if (DownloadBLL.DownloadHTML2String(strCnBlogsNewsURL, Encoding.UTF8, ref strCnBlogsNewsHTML) == true && String.IsNullOrEmpty(strCnBlogsNewsHTML) == false)
                                {
                                    String strBodyOuterHtml = String.Empty;
                                    String strBodyInnerHtml = String.Empty;
                                    String strBodyInnerText = String.Empty;

                                    CnBlogsBLL.GetNewsBodyFromCnBlogs(strCnBlogsNewsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);

                                    try
                                    {
                                        MetaWeblogEntity.Post post = new MetaWeblogEntity.Post();
                                        post.dateCreated = DateTime.Now;
                                        post.title = strCnBlogsNewsTitleList[nIndex];
                                        post.description = strBodyOuterHtml;
                                        post.categories = String.IsNullOrEmpty(strCategories) == true ? null : strCategories.Split(',');
                                        post.dateCreated = DateTime.Now;
                                        String strPostID = metaWeblog.newPost(String.Empty, strUserName, strPassword, post, true);

                                        strResult = "   Publish Blog Succeed.";
                                    }
                                    catch (Exception ex)
                                    {
                                        strResult = "   Publish Blog Failed，Error Message: " + ex.Message;
                                    }
                                }
                            }
                            break;
                        }
                    case ConfigEntity.CnBlogs_Precious_Name:
                        {
                            /* 博客园精华区 */
                            for (int i = 0; i < dgvDefault.SelectedRows.Count; i++)
                            {
                                Int32 nIndex = (Int32)dgvDefault.SelectedRows[i].Cells[0].Value - 1;

                                String strCnBlogsBlogsHTML = String.Empty;
                                String strCnBlogsBlogsURL = strCnBlogsPreciousUrlList[nIndex]; ;
                                if (DownloadBLL.DownloadHTML2String(strCnBlogsBlogsURL, Encoding.UTF8, ref strCnBlogsBlogsHTML) == true && String.IsNullOrEmpty(strCnBlogsBlogsHTML) == false)
                                {
                                    String strBodyOuterHtml = String.Empty;
                                    String strBodyInnerHtml = String.Empty;
                                    String strBodyInnerText = String.Empty;

                                    CnBlogsBLL.GetBlogsBodyFromCnBlogs(strCnBlogsBlogsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);

                                    try
                                    {
                                        MetaWeblogEntity.Post post = new MetaWeblogEntity.Post();
                                        post.dateCreated = DateTime.Now;
                                        post.title = strCnBlogsPreciousTitleList[nIndex];
                                        post.description = strBodyOuterHtml;
                                        post.categories = String.IsNullOrEmpty(strCategories) == true ? null : strCategories.Split(',');
                                        post.dateCreated = DateTime.Now;
                                        String strPostID = metaWeblog.newPost(String.Empty, strUserName, strPassword, post, true);

                                        strResult = "   Publish Blog Succeed.";
                                    }
                                    catch (Exception ex)
                                    {
                                        strResult = "   Publish Blog Failed，Error Message: " + ex.Message;
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                ClearDefaultSelectedBlogs();
            }

            System.Threading.Thread.Sleep(1500);

            return strResult;
        }


        /// <summary>
        /// 删除用户选择的最近的 Post 文章
        /// </summary>
        private void btnDeleteSelectedClick()
        {
            for (int i = 0; i < dgvRecent.SelectedRows.Count; i++)
            {
                Int32 nIndex = (Int32)dgvRecent.SelectedRows[i].Cells[0].Value - 1;
                Object objPostID = recentPostList[nIndex].postid;
                metaWeblog.deletePost(String.Empty, objPostID, strUserName, strPassword, true);

                //System.Threading.Thread.Sleep(500);
            }

            ReBindRecentPost();
        }
    }
}
