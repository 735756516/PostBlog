using System;

namespace PostBlog
{
    public class ConfigEntity
    {
        /// <summary>
        /// 博客园首页 - 默认获取 5 页数据
        /// </summary>
        public static String[] CnBlogs_HomePage = new String[] 
        { 
            "http://www.cnblogs.com/p1",
            "http://www.cnblogs.com/p2",
            "http://www.cnblogs.com/p3"
            //"http://www.cnblogs.com/p4",
            //"http://www.cnblogs.com/p5"
        };


        /// <summary>
        /// 博客园新闻 - 默认获取 5 页数据
        /// </summary>
        public static String[] CnBlogs_News = new String[]
        {
            "http://news.cnblogs.com/n/page/1/",
            "http://news.cnblogs.com/n/page/2/",
            "http://news.cnblogs.com/n/page/3/"
            //"http://news.cnblogs.com/n/page/4/",
            //"http://news.cnblogs.com/n/page/5/"
        };


        /// <summary>
        /// 博客园精华 - 默认获取 5 页数据
        /// </summary>
        public static String[] CnBlogs_Precious = new String[]
        {
            "http://www.cnblogs.com/pick/1/",
            "http://www.cnblogs.com/pick/2/",
            "http://www.cnblogs.com/pick/3/"
            //"http://www.cnblogs.com/pick/4/",
            //"http://www.cnblogs.com/pick/5/"
        };


        /// <summary>
        /// C++ 博客首页 - 默认取 5 页数据
        /// </summary>
        public static String[] CppBlog_HomePage = new String[]
        {
            "http://www.cppblog.com/default.html?paging=1&page=1",
            "http://www.cppblog.com/default.html?paging=1&page=2",
            "http://www.cppblog.com/default.html?paging=1&page=3"
            //"http://www.cppblog.com/default.html?paging=1&page=4",
            //"http://www.cppblog.com/default.html?paging=1&page=5"
        };


        /// <summary>
        /// CIOAge 首页 - 默认取所有数据 20xx 年 xx 月数据
        /// </summary>
        public static String[] CIOAge_HomePage = new String[]
        {
            "http://www.cioage.com"
        };


        /// <summary>
        /// CIOAge 首页过滤
        /// </summary>
        public static String[] CIOAge_HomePage_Filter = new String[]
        {
              "http://www.cioage.com/art/20"
        };


        /// <summary>
        /// 资安人文章列表
        /// </summary>
        public static String[] InfoSecurity_Article = new String[]
        {
            "http://www.informationsecurity.com.tw/article/article_list.aspx?mod=2-1&Page=1",
            "http://www.informationsecurity.com.tw/article/article_list.aspx?mod=2-1&Page=2",
            "http://www.informationsecurity.com.tw/article/article_list.aspx?mod=2-1&Page=3"
            //"http://www.informationsecurity.com.tw/article/article_list.aspx?mod=2-1&Page=4",
            //"http://www.informationsecurity.com.tw/article/article_list.aspx?mod=2-1&Page=5"
        };

        
        /// <summary>
        /// TechCrunch 文章列表
        /// </summary>
        public static String[] TechCrunch_Article = new String[]
        {
            "http://techcrunch.com/startups/page/1/",
            "http://techcrunch.com/startups/page/2/",
            "http://techcrunch.com/startups/page/3/"
            //"http://techcrunch.com/startups/page/4/",
            //"http://techcrunch.com/startups/page/5/"
        };


        public const String CnBlogs_HomePage_Name = "http://www.cnblogs.com/                     -      博客园首页区";
        public const String CnBlogs_News_Name = "http://news.cnblogs.com/                    -      博客园新闻区";
        public const String CnBlogs_Precious_Name = "http://www.cnblogs.com/pick/                -      博客园精华区";
        public const String CppBlog_HomePage_Name = "http://www.cppblog.com/                     -      C++ 博客首页区";
        public const String CIOAge_HomePage_Name = "http://www.cioage.com/                      -      CIOAge IT 推动创新";
        public const String InfoSecurity_Article_Name = "http://www.informationsecurity.com.tw/      -      资安人文章区";
        public const String TechCrunch_Article_Name = "http://techcrunch.com/startups/             -      TechCrunch 文章区";


        /// <summary>
        /// 读取最近 Post 的条数
        /// </summary>
        public const Int32 Recent_Post_Count = 20;


        /// <summary>
        /// 默认供用户选择的项
        /// </summary>
        public static String[] Default_URL = new String[]
        {
            CIOAge_HomePage_Name,
            InfoSecurity_Article_Name,
            TechCrunch_Article_Name,
            CnBlogs_HomePage_Name,
            CnBlogs_News_Name,
            CnBlogs_Precious_Name,
            CppBlog_HomePage_Name
        };
    }
}
