using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace PostBlog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            #region 测试代码

            //String strCnBlogsNewsHTML = String.Empty;
            //String strCnBlogsNewsURL = "http://news.cnblogs.com/n/148705/";
            //if (DownloadBLL.DownloadHTML2String(strCnBlogsNewsURL, Encoding.UTF8, ref strCnBlogsNewsHTML) == true && String.IsNullOrEmpty(strCnBlogsNewsHTML) == false)
            //{
            //    String strTitleOuterHtml = String.Empty;
            //    String strTitleInnerHtml = String.Empty;
            //    String strTitleInnerText = String.Empty;

            //    String strBodyOuterHtml = String.Empty;
            //    String strBodyInnerHtml = String.Empty;
            //    String strBodyInnerText = String.Empty;

            //    DownloadBLL.GetNewsTitleFromCnBlogs(strCnBlogsNewsHTML, ref strTitleOuterHtml, ref strTitleInnerHtml, ref strTitleInnerText);
            //    DownloadBLL.GetNewsBodyFromCnBlogs(strCnBlogsNewsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);
            //}



            //String strCnBlogsBlogsHTML = String.Empty;
            //String strCnBlogsBlogsURL = "http://www.cnblogs.com/techborther/archive/2012/07/05/2577322.html";
            //if (DownloadBLL.DownloadHTML2String(strCnBlogsBlogsURL, Encoding.UTF8, ref strCnBlogsBlogsHTML) == true && String.IsNullOrEmpty(strCnBlogsBlogsHTML) == false)
            //{
            //    String strTitleOuterHtml = String.Empty;
            //    String strTitleInnerHtml = String.Empty;
            //    String strTitleInnerText = String.Empty;

            //    String strBodyOuterHtml = String.Empty;
            //    String strBodyInnerHtml = String.Empty;
            //    String strBodyInnerText = String.Empty;

            //    DownloadBLL.GetBlogsTitleFromCnBlogs(strCnBlogsBlogsHTML, ref strTitleOuterHtml, ref strTitleInnerHtml, ref strTitleInnerText);
            //    DownloadBLL.GetBlogsBodyFromCnBlogs(strCnBlogsBlogsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);
            //}



            //String strCIOAgeArticleHTML = String.Empty;
            //String strCIOAgeArticleURL = "http://www.cioage.com/art/201207/97938.htm";
            //if (DownloadBLL.DownloadHTML2String(strCIOAgeArticleURL, Encoding.Default, ref strCIOAgeArticleHTML) == true && String.IsNullOrEmpty(strCIOAgeArticleHTML) == false)
            //{
            //    String strTitleOuterHtml = String.Empty;
            //    String strTitleInnerHtml = String.Empty;
            //    String strTitleInnerText = String.Empty;

            //    String strGuidanceOuterHtml = String.Empty;
            //    String strGuidanceInnerHtml = String.Empty;
            //    String strGuidanceInnerText = String.Empty;

            //    String strBodyOuterHtml = String.Empty;
            //    String strBodyInnerHtml = String.Empty;
            //    String strBodyInnerText = String.Empty;

            //    CIOAgeBLL.GetArticleTitleFromCIOAge(strCIOAgeArticleHTML, ref strTitleOuterHtml, ref strTitleInnerHtml, ref strTitleInnerText);
            //    CIOAgeBLL.GetArticleBodyFromCIOAge(strCIOAgeArticleHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);
            //}



            //String strCppBlogBlogsHTML = String.Empty;
            //String strCppBlogBlogsURL = "http://www.cppblog.com/coreBugZJ/archive/2012/07/04/181341.html";
            //if (DownloadBLL.DownloadHTML2String(strCppBlogBlogsURL, Encoding.UTF8, ref strCppBlogBlogsHTML) == true && String.IsNullOrEmpty(strCppBlogBlogsHTML) == false)
            //{
            //    String strTitleOuterHtml = String.Empty;
            //    String strTitleInnerHtml = String.Empty;
            //    String strTitleInnerText = String.Empty;

            //    String strBodyOuterHtml = String.Empty;
            //    String strBodyInnerHtml = String.Empty;
            //    String strBodyInnerText = String.Empty;

            //    CppBlogBLL.GetBlogsTitleFromCppBlog(strCppBlogBlogsHTML, ref strTitleOuterHtml, ref strTitleInnerHtml, ref strTitleInnerText);
            //    CppBlogBLL.GetBlogsBodyFromCppBlog(strCppBlogBlogsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);
            //}


            //String strCppBlogBlogsHTML = String.Empty;
            //String strCppBlogBlogsURL = "http://www.informationsecurity.com.tw/article/article_detail.aspx?aid=6912";
            //if (DownloadBLL.DownloadHTML2String(strCppBlogBlogsURL, Encoding.UTF8, ref strCppBlogBlogsHTML) == true && String.IsNullOrEmpty(strCppBlogBlogsHTML) == false)
            //{
            //    String strTitleOuterHtml = String.Empty;
            //    String strTitleInnerHtml = String.Empty;
            //    String strTitleInnerText = String.Empty;

            //    String strBodyOuterHtml = String.Empty;
            //    String strBodyInnerHtml = String.Empty;
            //    String strBodyInnerText = String.Empty;

            //    //CppBlogBLL.GetBlogsTitleFromCppBlog(strCppBlogBlogsHTML, ref strTitleOuterHtml, ref strTitleInnerHtml, ref strTitleInnerText);
            //    InfoSecurityBLL.GetArticleBodyFromInfoSecurity(strCppBlogBlogsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);
            //}


            //String strCppBlogBlogsHTML = String.Empty;
            //String strCppBlogBlogsURL = "http://techcrunch.com/2012/07/13/angelhack-winners/";
            //if (DownloadBLL.DownloadHTML2String(strCppBlogBlogsURL, Encoding.UTF8, ref strCppBlogBlogsHTML) == true && String.IsNullOrEmpty(strCppBlogBlogsHTML) == false)
            //{
            //    String strTitleOuterHtml = String.Empty;
            //    String strTitleInnerHtml = String.Empty;
            //    String strTitleInnerText = String.Empty;

            //    String strBodyOuterHtml = String.Empty;
            //    String strBodyInnerHtml = String.Empty;
            //    String strBodyInnerText = String.Empty;

            //    //CppBlogBLL.GetBlogsTitleFromCppBlog(strCppBlogBlogsHTML, ref strTitleOuterHtml, ref strTitleInnerHtml, ref strTitleInnerText);
            //    TechCrunchBLL.GetArticleBodyFromTechCrunch(strCppBlogBlogsHTML, ref strBodyOuterHtml, ref strBodyInnerHtml, ref strBodyInnerText);
            //}



            //List<String> strPreciousTitleList = new List<String>();
            //List<String> strPreciousUrlList = new List<String>();
            //List<String> strPreciousDescList = new List<String>();
            //List<String> strPreciousAuthor = new List<String>();
            //List<String> strPreciousDateTime = new List<String>();
            //TechCrunchBLL.GetArticlesFromTechCrunch(ref strPreciousTitleList, ref strPreciousUrlList, ref strPreciousDescList, ref strPreciousAuthor, ref strPreciousDateTime);

            #endregion  //


            /************************************************************************
                User:       ctsadmin
                Password:   23448890
                Login:      http://www.cinir.com/security-news/wp-login.php
                Server:     http://www.cinir.com
                Path:       /security-news/xmlrpc.php
                URL:        http://www.cinir.com/security-news/xmlrpc.php
                URL:        http://www.cinir.com/xmlrpc.php
            ************************************************************************/

            Application.Run(new BlogLogin());
        }
    }
}
