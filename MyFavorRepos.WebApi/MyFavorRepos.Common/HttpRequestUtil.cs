using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyFavorRepos.Common
{
    public class HttpRequestUtil
    {
        /// <summary>
        /// 根据url下载内容  之前是GB2312
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadUrl(string url)
        {
            try
            {
                //return DownloadHtml(url, Encoding.UTF8);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                Log4NetUtil.LogError(ex.Message, ex);
                return string.Empty;
            }
        }

        public static List<string> GetContent(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            List<string> list = new List<string>();
            doc.LoadHtml(html);
            string fristPath = "//a[@itemprop='name codeRepository']";
            HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(fristPath);
            if (nodeList == null)
            {
                return list;
            }
            foreach (HtmlNode node in nodeList)
            {
                list.Add(node.InnerText.Trim());
            }

            return list;
        }

        public static string GetDetail(string html, List<string> content)
        {
            string email = " Hello Alan\r\n This is your favor repos\r\n";
            HtmlDocument doc = new HtmlDocument();
            List<string> list = new List<string>();
            doc.LoadHtml(html);
            string fristPath = "//div[@class='flex-auto ']";
            HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(fristPath);
            foreach (HtmlNode node in nodeList)
            {
                if (content.Contains(node.ChildNodes["h3"].ChildNodes["a"].InnerText.Trim()))
                {
                    email += $" - {node.ChildNodes["h3"].ChildNodes["a"].InnerText.Trim()} {node.ChildNodes["p"]?.InnerText.Trim()}\r\n";
                }
            }

            return email;
        }

        /// <summary>
        /// 下载html
        /// HttpWebRequest功能比较丰富，WebClient使用比较简单
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownloadHtml(string url, Encoding encode)
        {
            string html = string.Empty;
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) =>
                //{
                //    return true; //总是接受  
                //});
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;//模拟请求

                request.Timeout = 30 * 1000;//设置30s的超时
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                //request.UserAgent = "User - Agent:Mozilla / 5.0(iPhone; CPU iPhone OS 7_1_2 like Mac OS X) App leWebKit/ 537.51.2(KHTML, like Gecko) Version / 7.0 Mobile / 11D257 Safari / 9537.53";

                request.ContentType = "text/html; charset=utf-8";// "text/html;charset=gbk";//                                              //request.Host = "search.yhd.com";

                //request.Headers.Add("Cookie", @"shshshfpa=111ea760-fabe-cb1b-0f20-918082547d13-1611801794; shshshfpb=l94fDrWcfjo%2FStmlv7nvN7g%3D%3D; user-key=63e610db-0d29-4811-b2d6-61edef3504d0; __jdu=16145975382601468227500; unpl=V2_ZzNtbRBeFBcgDRJXKRhfDGIGRwoSBBMVIAwSVXIfD1E0ABAOclRCFnUUR1ZnGFgUZwYZWEtcQxZFCEdkeBBVAWMDE1VGZxBFLV0CFSNGF1wjU00zQwBBQHcJFF0uSgwDYgcaDhFTQEJ2XBVQL0oMDDdRFAhyZ0AVRQhHZHseXABjCxRZQF5AEnQIQ1NyGl8DYwITbXJQcyVFC0BTeBhYNWYzE20AAx8RdgFEVXlUXAJnBhZVRFNBHHYPR1R%2bHlUGZAUWXENnQiV2; cn=0; __jdv=76161171|baidu-pinzhuan|t_288551095_baidupinzhuan|cpc|0f3d30c8dba7459bb52f2eb5eba8ac7d_0_c8f3d4e2c02844dfaba1d5e087beb23b|1614926942960; areaId=17; ipLoc-djd=17-1381-50718-0; PCSYCityID=CN_420000_420100_420111; TrackID=1GdRMW8gXsLAWOZ9WRxenECdyFvw-RN5whNIT6z1OCnWE1nbGQBxEgC1i10FweGyNXOyqjA12a9OwF5F9Rh00UQQfJtL5V90C4BFqhpWMtvc; thor=B4B8CB2664818C7617703847990A7701A5E0FD882B1EBDE248AAA3E77C28FB820AFC1C9293EC42E8625AED4C472392102E7164D9268D6EE350D33D5922FEEAB371BCE682AADA49C9D109D1F51DFBD6457E83A6B07E747C3F910B9EA5134037D6BB5900E4BB14996E9ECAE19502CC282E70FD773B7C3A83A0C8A94823A55C4138AC9E312314F00839C45064C9872AF1D7477C304C018835449642D333E7D7CFC6; pinId=2tfCZBvx3pARh-sYngPNJg; pin=jd_FmjVhJbXPsop; unick=jd_FmjVhJbXPsop; ceshi3.com=000; _tp=wNqgl1DABzQKuPqdS2uzVw%3D%3D; _pst=jd_FmjVhJbXPsop; __jda=122270672.16145975382601468227500.1614597538.1614926894.1615100231.10; __jdc=122270672; __jdb=122270672.76.16145975382601468227500|10.1615100231; shshshfp=cd0ef7a68d6da7471ee28b7d7f43504e; shshshsID=2e943a59672e11d257466e58b1d72e96_5_1615106874878");

                //request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                //request.Headers.Add("Referer", "http://list.yhd.com/c0-0/b/a-s1-v0-p1-price-d0-f0-m1-rt0-pid-mid0-kiphone/");

                //Encoding enc = Encoding.GetEncoding("GB2312"); // 如果是乱码就改成 utf-8 / GB2312 
                //如何自动读取cookie
                //request.CookieContainer = new CookieContainer();//1 给请求准备个container
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)//发起请求
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        Log4NetUtil.LogInfo(string.Format("抓取{0}地址返回失败,response.StatusCode为{1}", url, response.StatusCode));
                    }
                    else
                    {
                        try
                        {
                            //string sessionValue = response.Cookies["ASP.NET_SessionId"].Value;//2 读取cookie
                            StreamReader sr = new StreamReader(response.GetResponseStream(), encode);
                            html = sr.ReadToEnd();//读取数据
                            sr.Close();
                        }
                        catch (Exception ex)
                        {
                            Log4NetUtil.LogError(string.Format($"DownloadHtml抓取{url}失败"), ex);
                            html = null;
                        }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Equals("远程服务器返回错误: (306)。"))
                {
                    Log4NetUtil.LogError("远程服务器返回错误: (306)。", ex);
                    html = null;
                }
            }
            catch (Exception ex)
            {
                Log4NetUtil.LogError(string.Format("DownloadHtml抓取{0}出现异常", url), ex);
                html = null;
            }
            return html;
        }
    }
}
