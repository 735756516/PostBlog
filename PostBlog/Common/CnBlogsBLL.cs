using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace PostBlog
{
    /// <summary>
    /// 针对 www.cnblogs.com 的处理
    /// </summary>
    public class CnBlogsBLL
    {
        /// <summary>
        /// 获取博客园首页文章信息
        /// 返回 -1 表示失败
        /// </summary>
        /// <param name="strHomePageTitleList"></param>
        /// <param name="strHomePageUrlList"></param>
        /// <param name="strHomePageDescList"></param>
        /// <param name="strHomePageAuthorList"></param>
        /// <param name="strHomePageDateTimeList"></param>
        /// <returns></returns>
        public static Int32 GetHomePageBlogsFromCnBlogs(ref List<String> strHomePageTitleList, ref List<String> strHomePageUrlList, ref List<String> strHomePageDescList, ref List<String> strHomePageAuthorList, ref List<String> strHomePageDateTimeList)
        {
            strHomePageTitleList.Clear();
            strHomePageUrlList.Clear();
            strHomePageDescList.Clear();
            strHomePageAuthorList.Clear();
            strHomePageDateTimeList.Clear();

            try
            {
                Int32 nCount = -1;

                for (int i = 0; i < ConfigEntity.CnBlogs_HomePage.Length; i++)
                {
                    String strHTML = String.Empty;
                    if (DownloadBLL.DownloadHTML2String(ConfigEntity.CnBlogs_HomePage[i], Encoding.UTF8, ref strHTML) == true && String.IsNullOrEmpty(strHTML) == false)
                    {
                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(strHTML);

                        HtmlNode parentNode = doc.GetElementbyId("post_list");
                        HtmlNodeCollection titleList = parentNode.SelectNodes("//div[2]/h3/a[@class='titlelnk']");
                        HtmlNodeCollection descList = parentNode.SelectNodes("//div[2]/p[@class='post_item_summary']");
                        HtmlNodeCollection footerList = parentNode.SelectNodes("//div[2]/div[1]/a[@class='lightblue']");

                        if (titleList != null && descList != null && footerList != null)
                        {
                            if (titleList.Count == descList.Count && descList.Count == footerList.Count)
                            {
                                for (int j = 0; j < titleList.Count; j++)
                                {
                                    nCount++;

                                    strHomePageTitleList.Add(titleList[j].InnerText.Trim());
                                    strHomePageUrlList.Add(titleList[j].Attributes["href"].Value.ToString().Trim());
                                    strHomePageDescList.Add(descList[j].InnerText.Trim());
                                    strHomePageAuthorList.Add(footerList[j].InnerHtml.Trim());
                                    strHomePageDateTimeList.Add(footerList[j].NextSibling.InnerText.Replace("发布于", "").Trim());
                                }
                            }
                        }
                    }
                }

                return nCount;
            }
            catch (Exception ex)
            {
                strHomePageTitleList.Clear();
                strHomePageUrlList.Clear();
                strHomePageDescList.Clear();
                strHomePageAuthorList.Clear();
                strHomePageDateTimeList.Clear();

                PInvokeAPI.OutputDebugString("Error In GetHomePageBlogsFromCnBlogs，ErrorMessage: " + ex.Message);

                return -1;
            }
        }


        /// <summary>
        /// 获取博客园新闻信息
        /// 返回 -1 表示失败
        /// </summary>
        /// <param name="strNewsTitleList"></param>
        /// <param name="strNewsUrlList"></param>
        /// <param name="strNewsDescList"></param>
        /// <param name="strNewsAuthorList"></param>
        /// <param name="strNewsDateTimeList"></param>
        /// <returns></returns>
        public static Int32 GetNewsFromCnBlogs(ref List<String> strNewsTitleList, ref List<String> strNewsUrlList, ref List<String> strNewsDescList, ref List<String> strNewsAuthorList, ref List<String> strNewsDateTimeList)
        {
            strNewsTitleList.Clear();
            strNewsUrlList.Clear();
            strNewsDescList.Clear();
            strNewsAuthorList.Clear();
            strNewsDateTimeList.Clear();

            try
            {
                Int32 nCount = -1;
                for (int i = 0; i < ConfigEntity.CnBlogs_News.Length; i++)
                {
                    String strHTML = String.Empty;
                    if (DownloadBLL.DownloadHTML2String(ConfigEntity.CnBlogs_News[i], Encoding.UTF8, ref strHTML) == true && String.IsNullOrEmpty(strHTML) == false)
                    {
                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(strHTML);

                        HtmlNode parentNode = doc.GetElementbyId("news_list");
                        HtmlNodeCollection titleList = parentNode.SelectNodes("//div[2]/h2[@class='news_entry']/a");
                        HtmlNodeCollection descList = parentNode.SelectNodes("//div[2]/div[1][@class='entry_summary']");
                        HtmlNodeCollection authorList = parentNode.SelectNodes("//div[2]/div[2][@class='entry_footer']/a[@class='gray']");
                        HtmlNodeCollection dateTimeList = parentNode.SelectNodes("//div[2]/div[2][@class='entry_footer']/span[@class='gray']");

                        if (titleList != null && descList != null && authorList != null && dateTimeList != null)
                        {
                            if (titleList.Count == descList.Count && descList.Count == authorList.Count && authorList.Count == dateTimeList.Count)
                            {
                                for (int j = 0; j < titleList.Count; j++)
                                {
                                    nCount++;

                                    strNewsTitleList.Add(titleList[j].InnerText.Trim());
                                    strNewsUrlList.Add("http://news.cnblogs.com" + titleList[j].Attributes["href"].Value.ToString().Trim());
                                    strNewsDescList.Add(descList[j].InnerText.Trim());
                                    strNewsAuthorList.Add(authorList[j].InnerHtml.Trim());
                                    strNewsDateTimeList.Add(dateTimeList[j].InnerText.Trim());
                                }
                            }
                        }
                    }
                }

                return nCount;
            }
            catch (Exception ex)
            {
                strNewsTitleList.Clear();
                strNewsUrlList.Clear();
                strNewsDescList.Clear();
                strNewsAuthorList.Clear();
                strNewsDateTimeList.Clear();

                PInvokeAPI.OutputDebugString("Error In GetNewsFromCnBlogs，ErrorMessage: " + ex.Message);

                return -1;
            }
        }


        /// <summary>
        /// 获取博客园精华信息
        /// 返回 -1 表示失败
        /// </summary>
        /// <param name="strPreciousTitleList"></param>
        /// <param name="strPreciousUrlList"></param>
        /// <param name="strPreciousDescList"></param>
        /// <param name="strPreciousAuthorList"></param>
        /// <param name="strPreciousDateTimeList"></param>
        /// <returns></returns>
        public static Int32 GetPreciousFromCnBlogs(ref List<String> strPreciousTitleList, ref List<String> strPreciousUrlList, ref List<String> strPreciousDescList, ref List<String> strPreciousAuthorList, ref List<String> strPreciousDateTimeList)
        {
            strPreciousTitleList.Clear();
            strPreciousUrlList.Clear();
            strPreciousDescList.Clear();
            strPreciousAuthorList.Clear();
            strPreciousDateTimeList.Clear();

            try
            {
                Int32 nCount = -1;
                for (int i = 0; i < ConfigEntity.CnBlogs_Precious.Length; i++)
                {
                    String strHTML = String.Empty;
                    if (DownloadBLL.DownloadHTML2String(ConfigEntity.CnBlogs_Precious[i], Encoding.UTF8, ref strHTML) == true && String.IsNullOrEmpty(strHTML) == false)
                    {
                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(strHTML);

                        HtmlNode parentNode = doc.GetElementbyId("post_list");
                        HtmlNodeCollection titleList = parentNode.SelectNodes("//div[2]/h3/a[@class='titlelnk']");
                        HtmlNodeCollection descList = parentNode.SelectNodes("//div[2]/p[@class='post_item_summary']");
                        HtmlNodeCollection footerList = parentNode.SelectNodes("//div[2]/div[1]/a[@class='lightblue']");

                        if (titleList != null && descList != null && footerList != null)
                        {
                            if (titleList.Count == descList.Count && descList.Count == footerList.Count)
                            {
                                for (int j = 0; j < titleList.Count; j++)
                                {
                                    nCount++;

                                    strPreciousTitleList.Add(titleList[j].InnerText.Trim());
                                    strPreciousUrlList.Add(titleList[j].Attributes["href"].Value.ToString().Trim());
                                    strPreciousDescList.Add(descList[j].InnerText.Trim());
                                    strPreciousAuthorList.Add(footerList[j].InnerHtml.Trim());
                                    strPreciousDateTimeList.Add(footerList[j].NextSibling.InnerText.Replace("发布于", "").Trim());
                                }
                            }
                        }
                    }
                }

                return nCount;
            }
            catch (Exception ex)
            {
                strPreciousTitleList.Clear();
                strPreciousUrlList.Clear();
                strPreciousDescList.Clear();
                strPreciousAuthorList.Clear();
                strPreciousDateTimeList.Clear();

                PInvokeAPI.OutputDebugString("Error In GetPreciousFromCnBlogs，ErrorMessage: " + ex.Message);

                return -1;
            }
        }


        /// <summary>
        /// 从博客园的新闻网页上获取到此条新闻的标题
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetNewsTitleFromCnBlogs(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(strHTML);

                HtmlNode bodyNode = htmlDoc.GetElementbyId("news_title");
                if (bodyNode != null)
                {
                    strOuterHtml = bodyNode.OuterHtml;
                    strInnerHtml = bodyNode.InnerHtml;
                    strInnerText = bodyNode.InnerText;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                strOuterHtml = String.Empty;
                strInnerHtml = String.Empty;
                strInnerText = String.Empty;

                PInvokeAPI.OutputDebugString("Error In GetNewsTitleFromCnBlogs，ErrorMessage: " + ex.Message);

                return false;
            }
        }


        /// <summary>
        /// 从博客园新闻网页上获取到此条新闻的内容
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetNewsBodyFromCnBlogs(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(strHTML);

                HtmlNode bodyNode = htmlDoc.GetElementbyId("news_body");
                if (bodyNode != null)
                {
                    strOuterHtml = bodyNode.OuterHtml;
                    strInnerHtml = bodyNode.InnerHtml;
                    strInnerText = bodyNode.InnerText;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                strOuterHtml = String.Empty;
                strInnerHtml = String.Empty;
                strInnerText = String.Empty;

                PInvokeAPI.OutputDebugString("Error In GetNewsBodyFromCnBlogs，ErrorMessage: " + ex.Message);

                return false;
            }
        }


        /// <summary>
        /// 从博客园博客网页上获取到此条博客的标题
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetBlogsTitleFromCnBlogs(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(strHTML);

                HtmlNode titleNode = htmlDoc.GetElementbyId("cb_post_title_url");
                if (titleNode == null)
                {
                    titleNode = htmlDoc.GetElementbyId("ctl01_lnkTitle");
                }

                if (titleNode != null)
                {
                    strOuterHtml = titleNode.OuterHtml;
                    strInnerHtml = titleNode.InnerHtml;
                    strInnerText = titleNode.InnerText;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                strOuterHtml = String.Empty;
                strInnerHtml = String.Empty;
                strInnerText = String.Empty;

                PInvokeAPI.OutputDebugString("Error In GetBlogsTitleFromCnBlogs，ErrorMessage: " + ex.Message);

                return false;
            }
        }


        /// <summary>
        /// 从博客园博客网页上获取到此条博客的内容
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetBlogsBodyFromCnBlogs(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(strHTML);

                HtmlNode bodyNode = htmlDoc.GetElementbyId("cnblogs_post_body");
                if (bodyNode != null)
                {
                    strOuterHtml = bodyNode.OuterHtml;
                    strInnerHtml = bodyNode.InnerHtml;
                    strInnerText = bodyNode.InnerText;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                strOuterHtml = String.Empty;
                strInnerHtml = String.Empty;
                strInnerText = String.Empty;

                PInvokeAPI.OutputDebugString("Error In GetBlogsBodyFromCnBlogs，ErrorMessage: " + ex.Message);

                return false;
            }
        }
    }
}