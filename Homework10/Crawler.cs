using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerForm {
  class Crawler {
    public event Action<Crawler> CrawlerStopped;
    public event Action<Crawler, string, string> PageDownloaded;

    //所有已下载和待下载URL，key是URL，value表示是否下载成功
    private Dictionary<string, bool> urls = new Dictionary<string, bool>();

    //待下载队列
    private Queue<string> pending = new Queue<string>();

    //URL检测表达式，用于在HTML文本中查找URL
    private readonly string urlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";

    //URL解析表达式
    public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
    public string HostFilter { get; set; } //主机过滤规则
    public string FileFilter { get; set; } //文件过滤规则
    public int MaxPage { get; set; } //最大下载数量
    public string StartURL { get; set; } //起始网址
    public Encoding HtmlEncoding { get; set; } //网页编码
    public Dictionary<string, bool> DownloadedPages { get => urls; } //已下载网页
    public int DownloadNum { get; set; }//当前序号

    private static readonly object NumLock = new object();
    private static readonly object DataLock = new object();
    private static readonly object AddLock = new object();


    public Crawler() {
      MaxPage = 25;
      HtmlEncoding = Encoding.UTF8;
      DownloadNum = 1;
    }

    public void Start() {
      urls.Clear();
      pending.Clear();
      pending.Enqueue(StartURL);
      List<Task> tasks = new List<Task>();
      while (urls.Count < MaxPage) {
                if (pending.Count > 0)
                {
                    string url = pending.Dequeue();

                    try
                    {
                        Task task = Task.Run(() => DownloadAndParse(url));
                        tasks.Add(task);

                    }
                    catch (AggregateException e)
                    {
                        MessageBox.Show(
                            $"Exception type {e.GetType()} from {e.Source}");
                    }
                }        
      }

            Task.WaitAll(tasks.ToArray());
            CrawlerStopped(this);  
    }

        private void DownloadAndParse(string url)
        {
            try
            {
                string html = DownLoad(url); // 下载
                urls[url] = true;
                lock (DataLock)
                {
                PageDownloaded(this, url, "success");
                }
                Parse(html, url);//解析,并加入新的链接
                
            }
            catch (Exception ex)
            {
                PageDownloaded(this, url, "  Error:" + ex.Message);              
            }

        }

    private string DownLoad(string url) {
      WebClient webClient = new WebClient();
      webClient.Encoding = Encoding.UTF8;
      string html = webClient.DownloadString(url);
      
      lock (NumLock)
            {
              DownloadNum++;
              string fileName = DownloadNum.ToString();
              File.WriteAllText(fileName, html, Encoding.UTF8);
            }
      return html;
    }

    private void Parse(string html, string pageUrl) {
      var matches = new Regex(urlDetectRegex).Matches(html);
      foreach (Match match in matches) {
          Task task1 = Task.Run(() =>
          {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "") return;
                linkUrl = FixUrl(linkUrl, pageUrl);//转绝对路径
                                                   //解析出host和file两个部分，进行过滤
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";
                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter))
                {
                  lock (AddLock)
                  {
                      if (!urls.ContainsKey(linkUrl))
                      {
                          pending.Enqueue(linkUrl);
                          urls.Add(linkUrl, false);
                      }
                  }
                    
                }
           });
        
      }
    }


    //将相对路径转为绝对路径
    static private string FixUrl(string url, string pageUrl) {
      if (url.Contains("://")) {
        return url;
      }
      if (url.StartsWith("//")) {
        return "http:" + url;
      }
      if (url.StartsWith("/")) {
        Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
        String site = urlMatch.Groups["site"].Value;
        return site.EndsWith("/") ? site + url.Substring(1) : site + url;
      }

      if (url.StartsWith("../")) {
        url = url.Substring(3);
        int idx = pageUrl.LastIndexOf('/');
        return FixUrl(url, pageUrl.Substring(0, idx));
      }

      if (url.StartsWith("./")) {
        return FixUrl(url.Substring(2), pageUrl);
      }

      int end = pageUrl.LastIndexOf("/");
      return pageUrl.Substring(0, end) + "/" + url;
    }
  }

   
}
