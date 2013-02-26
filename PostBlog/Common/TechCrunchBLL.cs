using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace PostBlog
{
    /// <summary>
    /// 针对 http://techcrunch.com/
    /// </summary>
    public class TechCrunchBLL
    {
        /// <summary>
        /// 获取 TechCrunch 文章列表
        /// </summary>
        /// <param name="strTechCrunchTitleList"></param>
        /// <param name="strTechCrunchUrlList"></param>
        /// <param name="strTechCrunchDescList"></param>
        /// <param name="strTechCrunchAuthorList"></param>
        /// <param name="strTechCrunchDateTimeList"></param>
        /// <returns></returns>
        public static Int32 GetArticlesFromTechCrunch(ref List<String> strTechCrunchTitleList, ref List<String> strTechCrunchUrlList, ref List<String> strTechCrunchDescList, ref List<String> strTechCrunchAuthorList, ref List<String> strTechCrunchDateTimeList)
        {
            strTechCrunchTitleList.Clear();
            strTechCrunchUrlList.Clear();
            strTechCrunchDescList.Clear();
            strTechCrunchAuthorList.Clear();
            strTechCrunchDateTimeList.Clear();

            try
            {
                Int32 nCount = -1;
                for (int i = 0; i < ConfigEntity.TechCrunch_Article.Length; i++)
                {
                    String strHTML = String.Empty;
                    if (DownloadBLL.DownloadHTML2String(ConfigEntity.TechCrunch_Article[i], Encoding.Default, ref strHTML) == true && String.IsNullOrEmpty(strHTML) == false)
                    {
                        HtmlDocument htmlDoc = new HtmlDocument();
                        htmlDoc.LoadHtml(strHTML);

                        HtmlNodeCollection divNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@id, 'post-')]");
                        if (divNodes == null || divNodes.Count <= 0)
                        {
                            return -1;
                        }

                        for (int j = 0; j < divNodes.Count; j++)
                        {
                            HtmlNode descNode = null;
                            HtmlNode titleNode = null;
                            HtmlNode authorNode = null;
                            HtmlNode dateTimeNode = null;

                            try
                            {
                                if (divNodes[j] != null)
                                {
                                    HtmlAttribute divAttributeID = divNodes[j].Attributes["id"];
                                    if (divAttributeID != null)
                                    {
                                        titleNode = htmlDoc.GetElementbyId(divAttributeID.Value.Replace("post-", "headline-"));
                                        if (titleNode != null)
                                        {
                                            foreach (HtmlNode node in divNodes[j].ChildNodes)
                                            {
                                                if (node != null && node.Attributes["class"] != null)
                                                {
                                                    if (node.Attributes["class"].Value == "publication-info")
                                                    {
                                                        foreach (HtmlNode secondNode in node.ChildNodes)
                                                        {
                                                            if (secondNode != null && secondNode.Attributes["class"] != null)
                                                            {
                                                                if (secondNode.Attributes["class"].Value == "by-line")
                                                                {
                                                                    authorNode = secondNode;
                                                                }

                                                                if (secondNode.Attributes["class"].Value == "post-time")
                                                                {
                                                                    dateTimeNode = secondNode;
                                                                }
                                                            }
                                                        }
                                                    }

                                                    if (node.Attributes["class"].Value == "body-copy")
                                                    {
                                                        descNode = node;
                                                    }
                                                }
                                            }

                                            if (descNode != null && titleNode != null && authorNode != null && dateTimeNode != null)
                                            {
                                                String strUrl = titleNode.Attributes["href"].Value.Trim();
                                                String strTitle = titleNode.Attributes["title"].Value.Trim();
                                                String strDesc = descNode.InnerText.Trim();
                                                String strAuthor = authorNode.InnerText.Trim();
                                                String strDateTime = dateTimeNode.InnerText.Trim().Replace("posted ", "");

                                                strTechCrunchTitleList.Add(strTitle);
                                                strTechCrunchUrlList.Add(strUrl);
                                                strTechCrunchDescList.Add(strDesc);
                                                strTechCrunchAuthorList.Add(strAuthor);
                                                strTechCrunchDateTimeList.Add(strDateTime);

                                                nCount++;
                                            }
                                        }
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }

                return nCount;
            }
            catch (Exception ex)
            {
                strTechCrunchTitleList.Clear();
                strTechCrunchUrlList.Clear();
                strTechCrunchDescList.Clear();
                strTechCrunchAuthorList.Clear();
                strTechCrunchDateTimeList.Clear();

                PInvokeAPI.OutputDebugString("Error In GetArticlesFromTechCrunch，ErrorMessage: " + ex.Message);

                return -1;
            }
        }


        /// <summary>
        /// 获取 TechCrunch 文章
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetArticleBodyFromTechCrunch(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(strHTML);

            HtmlNodeCollection bodyNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='body-copy']");
            if (bodyNodes == null || bodyNodes.Count <= 0)
            {
                return false;
            }

            for (int i = 0; i < bodyNodes.Count; i++)
            {
                HtmlNode bodyNode = bodyNodes[i];
                HtmlNode parentNode = bodyNode.ParentNode;
                if (parentNode != null)
                {
                    strOuterHtml = bodyNode.OuterHtml;
                    strInnerHtml = bodyNode.InnerHtml;
                    strInnerText = bodyNode.InnerText;

                    return true;
                }
            }

            return false;
        }
    }
}
