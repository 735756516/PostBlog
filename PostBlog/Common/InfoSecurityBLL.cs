using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace PostBlog
{
    /// <summary>
    /// 针对 www.informationsecurity.com.tw 的处理
    /// </summary>
    public class InfoSecurityBLL
    {
        /// <summary>
        /// 获取资安人文章列表前 5 页的所有文章
        /// </summary>
        /// <param name="strInfoSecurityTitleList"></param>
        /// <param name="strInfoSecurityUrlList"></param>
        /// <param name="strInfoSecurityDescList"></param>
        /// <param name="strInfoSecurityAuthorList"></param>
        /// <param name="strInfoSecurityDateTimeList"></param>
        /// <returns></returns>
        public static Int32 GetArticlesFromInfoSecurity(ref List<String> strInfoSecurityTitleList, ref List<String> strInfoSecurityUrlList, ref List<String> strInfoSecurityDescList, ref List<String> strInfoSecurityAuthorList, ref List<String> strInfoSecurityDateTimeList)
        {
            strInfoSecurityTitleList.Clear();
            strInfoSecurityUrlList.Clear();
            strInfoSecurityDescList.Clear();
            strInfoSecurityAuthorList.Clear();
            strInfoSecurityDateTimeList.Clear();

            try
            {
                Int32 nCount = -1;
                for (int i = 0; i < ConfigEntity.InfoSecurity_Article.Length; i++)
                {
                    String strHTML = String.Empty;
                    if (DownloadBLL.DownloadHTML2String(ConfigEntity.InfoSecurity_Article[i], Encoding.UTF8, ref strHTML) == true && String.IsNullOrEmpty(strHTML) == false)
                    {
                        HtmlDocument htmlDoc = new HtmlDocument();
                        htmlDoc.LoadHtml(strHTML);

                        HtmlNodeCollection titleNodes = htmlDoc.DocumentNode.SelectNodes("//a[@class='link_title_blue01']");
                        if (titleNodes == null || titleNodes.Count <= 0)
                        {
                            return -1;
                        }

                        for (int j = 0; j < titleNodes.Count; j++)
                        {
                            HtmlNode parentNode = titleNodes[j].ParentNode;
                            if (parentNode != null && parentNode.Name == "td")
                            {
                                if (parentNode.InnerHtml.Contains("<span class=\"content_gray02\">") == true)
                                {
                                    HtmlNode titleNode = null;
                                    HtmlNode dateTimeNode = null;
                                    HtmlNodeCollection childNodes = parentNode.ChildNodes;

                                    if (childNodes != null && childNodes.Count > 0)
                                    {
                                        foreach(HtmlNode node in childNodes)
                                        {
                                            if (node.Name == "a")
                                            {
                                                HtmlAttribute titleHref = node.Attributes["href"];
                                                HtmlAttribute titleNodeClass = node.Attributes["class"];
                                                if (titleNodeClass != null && titleHref != null)
                                                {
                                                    if (titleNodeClass.Value == "link_title_blue01")
                                                    {
                                                        titleNode = node;
                                                    }
                                                }
                                            }

                                            if(node.Name == "span")
                                            {
                                                HtmlAttribute dateTimeNodeClass = node.Attributes["class"];
                                                if (dateTimeNodeClass != null)
                                                {
                                                    if (dateTimeNodeClass.Value == "content_gray02")
                                                    {
                                                        dateTimeNode = node;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    if(titleNode != null && dateTimeNode != null)
                                    {
                                        try
                                        {
                                            HtmlAttribute titleNodeHref = titleNode.Attributes["href"];
                                            if(titleNodeHref!= null)
                                            {
                                                String strTitle = titleNode.InnerText.Trim();
                                                String strUrl = "http://www.informationsecurity.com.tw" + titleNodeHref.Value.Trim().Substring(2);
                                                String strDateTime = Convert.ToDateTime(dateTimeNode.InnerText.Trim()).ToString("yyyy-MM-dd HH:mm");

                                                strInfoSecurityTitleList.Add(strTitle);
                                                strInfoSecurityUrlList.Add(strUrl);
                                                strInfoSecurityDescList.Add(strTitle);
                                                strInfoSecurityAuthorList.Add("资安人");
                                                strInfoSecurityDateTimeList.Add(strDateTime);

                                                nCount++;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return nCount;
            }
            catch (Exception ex)
            {
                strInfoSecurityTitleList.Clear();
                strInfoSecurityUrlList.Clear();
                strInfoSecurityDescList.Clear();
                strInfoSecurityAuthorList.Clear();
                strInfoSecurityDateTimeList.Clear();

                PInvokeAPI.OutputDebugString("Error In GetBlogsFromInfoSecurity，ErrorMessage: " + ex.Message);

                return -1;
            }
        }


        /// <summary>
        /// 获取资安人文章的内容
        /// </summary>
        /// <param name="strHTML"></param>
        /// <param name="strOuterHtml"></param>
        /// <param name="strInnerHtml"></param>
        /// <param name="strInnerText"></param>
        /// <returns></returns>
        public static bool GetArticleBodyFromInfoSecurity(String strHTML, ref String strOuterHtml, ref String strInnerHtml, ref String strInnerText)
        {
            strOuterHtml = String.Empty;
            strInnerHtml = String.Empty;
            strInnerText = String.Empty;

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(strHTML);

            HtmlNodeCollection bodyNodes = htmlDoc.DocumentNode.SelectNodes("//span[@class='fA_D']");
            if (bodyNodes == null || bodyNodes.Count <= 0)
            {
                return false;
            }

            for (int i = 0; i < bodyNodes.Count; i++)
            {
                HtmlNode bodyNode = bodyNodes[i];
                HtmlNode parentNode = bodyNode.ParentNode;
                if (parentNode != null && parentNode.Name == "td")
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
