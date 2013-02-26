using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text;

namespace PostBlog
{
    /// <summary>
    /// 针对 www.cioage.com 的处理
    /// </summary>
    public class CIOAgeBLL
    {
        /// <summary>
        /// 从 CIOAge 网页上获取到文章信息
        /// </summary>
        /// <param name="strCIOAgeHomePageTitleList"></param>
        /// <param name="strCIOAgeHomePageUrlList"></param>
        /// <param name="strCIOAgeHomePageDescList"></param>
        /// <param name="strCIOAgeHomePageAuthorList"></param>
        /// <param name="strCIOAgeHomePageDateTimeList"></param>
        /// <returns></returns>
        public static Int32 GetHomePageBlogsFromCIOAge(ref List<String> strCIOAgeHomePageTitleList, ref List<String> strCIOAgeHomePageUrlList, ref List<String> strCIOAgeHomePageDescList, ref List<String> strCIOAgeHomePageAuthorList, ref List<String> strCIOAgeHomePageDateTimeList)
        {
            strCIOAgeHomePageTitleList.Clear();
            strCIOAgeHomePageUrlList.Clear();
            strCIOAgeHomePageDescList.Clear();
            strCIOAgeHomePageAuthorList.Clear();
            strCIOAgeHomePageDateTimeList.Clear();

            try
            {
                Int32 nCount = -1;
                for (int i = 0; i < ConfigEntity.CIOAge_HomePage.Length; i++)
                {
                    String strHTML = String.Empty;
                    if (DownloadBLL.DownloadHTML2String(ConfigEntity.CIOAge_HomePage[i], Encoding.Default, ref strHTML) == true && String.IsNullOrEmpty(strHTML) == false)
                    {
                        HtmlDocument htmlDoc = new HtmlDocument();
                        htmlDoc.LoadHtml(strHTML);

                        HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//a[@target='_blank']");
                        if (nodes.Count <= 0)
                        {
                            return -1;
                        }

                        for (int j = 0; j < nodes.Count; j++)
                        {
                            HtmlAttribute attribute = nodes[j].Attributes["href"];
                            if (attribute != null)
                            {
                                String strAttributeValue = attribute.Value;
                                for (int z = 0; z < ConfigEntity.CIOAge_HomePage_Filter.Length; z++)
                                {
                                    if (strAttributeValue.Contains(ConfigEntity.CIOAge_HomePage_Filter[z]) == true)
                                    {
                                        if (String.IsNullOrEmpty(nodes[j].InnerText) == false && nodes[j].InnerText.Length >= 4)
                                        {
                                            nCount++;

                                            strCIOAgeHomePageTitleList.Add(nodes[j].InnerText);
                                            strCIOAgeHomePageUrlList.Add(strAttributeValue);
                                            strCIOAgeHomePageDescList.Add(nodes[j].InnerText);
                                            strCIOAgeHomePageAuthorList.Add("CIOAge.com");
                                            strCIOAgeHomePageDateTimeList.Add(strAttributeValue.Substring(strAttributeValue.IndexOf("/art/") + 5, 6).Insert(4, "-"));

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return nCount;
            }
            catch(Exception ex)
            {
                strCIOAgeHomePageTitleList.Clear();
                strCIOAgeHomePageUrlList.Clear();
                strCIOAgeHomePageDescList.Clear();
                strCIOAgeHomePageAuthorList.Clear();
                strCIOAgeHomePageDateTimeList.Clear();

                PInvokeAPI.OutputDebugString("Error In GetHomePageBlogsFromCIOAge，ErrorMessage: " + ex.Message);

                return -1;
            }
        }


        /// <summary>
        /// 从 CIOAge 网页上获取到此条文章的标题
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetArticleTitleFromCIOAge(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(strHTML);

            HtmlNodeCollection parentNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='zh_left_3_1']");
            if (parentNodes.Count <= 0)
            {
                return false;
            }
            HtmlNode parentNode = parentNodes[0];
            HtmlNode node = parentNode.SelectSingleNode("//span[@class='font_1']");
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


        /// <summary>
        /// 从 CIOAge 网页上获取到此条文章的内容
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetArticleBodyFromCIOAge(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(strHTML);

            HtmlNodeCollection parentNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='zh_left_3_4']");
            if (parentNodes.Count <= 0)
            {
                return false;
            }
            HtmlNode parentNode = parentNodes[0];
            HtmlNode node = parentNode;
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
    }
}
