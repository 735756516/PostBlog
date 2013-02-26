using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text;

namespace PostBlog
{
    /// <summary>
    /// 针对 www.cppblog.com 的处理
    /// </summary>
    public class CppBlogBLL
    {
        /// <summary>
        /// 获取 C++ 博客首页文章信息
        /// 返回 -1 表示失败
        /// </summary>
        /// <param name="strBlogTitleList"></param>
        /// <param name="strBlogUrlList"></param>
        /// <param name="strBlogDescList"></param>
        /// <param name="strBlogAuthorList"></param>
        /// <param name="strBlogDateTimeList"></param>
        /// <returns></returns>
        public static Int32 GetHomePageBlogsFromCppBlog(ref List<String> strBlogTitleList, ref List<String> strBlogUrlList, ref List<String> strBlogDescList, ref List<String> strBlogAuthorList, ref List<String> strBlogDateTimeList)
        {
            strBlogTitleList.Clear();
            strBlogUrlList.Clear();
            strBlogDescList.Clear();
            strBlogAuthorList.Clear();
            strBlogDateTimeList.Clear();

            try
            {
                Int32 nCount = -1;
                for (int i = 0; i < ConfigEntity.CppBlog_HomePage.Length; i++)
                {
                    String strHTML = String.Empty;
                    if (DownloadBLL.DownloadHTML2String(ConfigEntity.CppBlog_HomePage[i], Encoding.UTF8, ref strHTML) == true && String.IsNullOrEmpty(strHTML) == false)
                    {
                        HtmlDocument htmlDoc = new HtmlDocument();
                        htmlDoc.LoadHtml(strHTML);

                        HtmlNodeCollection parentNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='post']");
                        if (parentNodes.Count <= 0)
                        {
                            return -1;
                        }
                        HtmlNode parentNode = parentNodes[0];
                        HtmlNodeCollection titleList = parentNode.SelectNodes("//h3");
                        HtmlNodeCollection descList = parentNode.SelectNodes("//h4");
                        HtmlNodeCollection footerList = parentNode.SelectNodes("//p[@class='postfoot']");
                        HtmlNodeCollection authorList = parentNode.SelectNodes("//a[@class='clsSubText']");

                        if (titleList != null && descList != null && footerList != null)
                        {
                            if (titleList.Count == descList.Count && descList.Count == footerList.Count)
                            {
                                for (int j = 0; j < titleList.Count; j++)
                                {
                                    nCount++;

                                    strBlogTitleList.Add(titleList[j].InnerText.Trim());
                                    strBlogUrlList.Add(titleList[j].FirstChild.Attributes["href"].Value.ToString().Trim());
                                    strBlogDescList.Add(descList[j].InnerText.Trim());
                                    strBlogAuthorList.Add(authorList[j].InnerHtml.Trim());
                                    strBlogDateTimeList.Add(authorList[j].PreviousSibling.InnerText.Substring(0, 16).Trim());
                                }
                            }
                        }
                    }
                }

                return nCount;
            }
            catch(Exception ex)
            {
                strBlogTitleList.Clear();
                strBlogUrlList.Clear();
                strBlogDescList.Clear();
                strBlogAuthorList.Clear();
                strBlogDateTimeList.Clear();

                PInvokeAPI.OutputDebugString("Error In GetHomePageBlogsFromCppBlog，ErrorMessage: " + ex.Message);

                return -1;
            }
        }


        /// <summary>
        /// 从 C++ 博客网页上获取到此条博客的标题
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetBlogsTitleFromCppBlog(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(strHTML);

                HtmlNodeCollection parentNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='post']");
                if (parentNodes.Count <= 0)
                {
                    return false;
                }
                HtmlNode parentNode = parentNodes[0];
                HtmlNode node = parentNode.SelectSingleNode("//a[@id='viewpost1_TitleUrl']");
                if (node != null)
                {
                    strOuterHtml = node.OuterHtml;
                    strInnerHtml = node.InnerHtml;
                    strInnerText = node.InnerText;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                strOuterHtml = String.Empty;
                strInnerHtml = String.Empty;
                strInnerText = String.Empty;

                PInvokeAPI.OutputDebugString("Error In GetBlogsTitleFromCppBlog，ErrorMessage: " + ex.Message);

                return false;
            }
        }


        /// <summary>
        /// 从 C++ 博客网页上获取到此条博客的内容
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetBlogsBodyFromCppBlog(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(strHTML);

                HtmlNodeCollection parentNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='post']");
                if(parentNodes.Count <= 0)
                {
                    return false;
                }
                HtmlNode parentNode = parentNodes[0];
                HtmlNode titleNode = parentNode.SelectSingleNode("//a[@id='viewpost1_TitleUrl']");
                if (titleNode != null)
                {
                    /* 移除标题，这样在 parentNode 中也会被移除 */
                    titleNode.Remove();
                }

                HtmlNode footerNode = parentNode.SelectSingleNode("//div[@class='postfoot']");
                if (footerNode != null)
                {
                    /* 移除页脚，这样在 parentNode 中也会被移除 */
                    footerNode.Remove();
                }
                else
                {
                    footerNode = parentNode.SelectSingleNode("//div[@class='postDesc']");
                    if (footerNode != null)
                    {
                        /* 移除页脚，这样在 parentNode 中也会被移除 */
                        footerNode.Remove();
                    }
                    else
                    {
                        footerNode = parentNode.SelectSingleNode("//p[@class='postfoot']");
                        if (footerNode != null)
                        {
                            /* 移除页脚，这样在 parentNode 中也会被移除 */
                            footerNode.Remove();
                        }
                        else
                        {
                            footerNode = parentNode.SelectSingleNode("//p[@class='postDesc']");
                            if (footerNode != null)
                            {
                                /* 移除页脚，这样在 parentNode 中也会被移除 */
                                footerNode.Remove();
                            }
                        }
                    }
                }

                if (parentNode != null)
                {
                    strOuterHtml = parentNode.OuterHtml;
                    strInnerHtml = parentNode.InnerHtml;
                    strInnerText = parentNode.InnerText;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                strOuterHtml = String.Empty;
                strInnerHtml = String.Empty;
                strInnerText = String.Empty;

                PInvokeAPI.OutputDebugString("Error In GetBlogsBodyFromCppBlog，ErrorMessage: " + ex.Message);

                return false;
            }
        }
    }
}
