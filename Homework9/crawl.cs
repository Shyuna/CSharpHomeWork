using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace crawler
{
    class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private string details;
        private string crawlerUrl ;
        public string Details { get => details;}
        public string URL { get => crawlerUrl; }
        
        public SimpleCrawler(string url)
        {
            this.crawlerUrl = url;
        }
        public void startCrawl()
        {
            string startUrl = this.URL;
            this.urls.Add(startUrl, false);//加入初始页面
            new Thread(this.Crawl).Start();
        }

        private void Crawl()
        {
            this.details += "开始爬行了.... \n";
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                this.details += "爬行" + current + "页面!\n";
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(html, current);//解析,并加入新的链接
                this.details += "爬行结束\n";
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void Parse(string html, string current)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            string cur1 = "", cur2 = "";
            Regex regex1 = new Regex(@"^http[s]?://[^/]+/");
            if (Regex.IsMatch(current, @"^http[s]?://[^/]*$"))
            {
                cur1 = current;
                cur2 = current + "/";
            }
            else
            {
                cur1 = regex1.Match(current).Value.ToString();
                cur1 = cur1.Substring(0, cur1.Length - 1);

                int lastIndex = current.LastIndexOf('/');
                cur2 = current.Substring(0, lastIndex);
                cur2 = cur2.Substring(0, lastIndex);
                cur2 = cur2 + "/";
            }

            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');

                if (!Regex.IsMatch(strRef, @"^http[s]?://"))
                {
                    strRef = Regex.IsMatch(strRef, @"^/") ?
                        cur1 + strRef
                        : cur2 + strRef;
                }
                else
                {
                    if (!Regex.IsMatch(strRef, this.URL))             
                    {
                        continue;
                    }
                }

                if (Regex.IsMatch(strRef, ".css")
                    || Regex.IsMatch(strRef, ".xml")
                    || strRef.Length == 0)
                {
                    continue;
                }
                if (urls[strRef] == null) urls[strRef] = false;
                
            }
        }
    }

}
