using System;
using System.IO;
using System.Net;
using System.Text;

namespace PostBlog
{
    public class DownloadBLL
    {
        /// <summary>
        /// 下载网页保存到 String 字符串
        /// </summary>
        /// <param name="strHtmlURL"></param>
        /// <param name="htmlEncode"></param>
        /// <param name="strHTML"></param>
        /// <returns></returns>
        public static bool DownloadHTML2String(String strHtmlURL, Encoding htmlEncode, ref String strHTML)
        {
            strHTML = String.Empty;

            try
            {
                HttpWebRequest rqst = WebRequest.Create(strHtmlURL) as HttpWebRequest;
                using (HttpWebResponse rsps = rqst.GetResponse() as HttpWebResponse)
                {
                    using (Stream stream = rsps.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, htmlEncode))
                        {
                            strHTML = reader.ReadToEnd();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                strHTML = String.Empty;

                return false;
            }
        }
    }
}
