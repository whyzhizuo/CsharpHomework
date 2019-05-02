using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace topic1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "https://www.baidu.com/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);//加入初始页面

            new Thread(myCrawler.Crawl).Start();
        }

        private void Crawl()
        {
            Console.WriteLine("Begin crawl");
            while(true)
            {
                string current = null;
                //使用Parallel的ForEach方法
                List<string> list = new List<string>();
                for (int i = 0; i < urls.Keys.Count; i++) list.Add(urls.Keys.Count);
                ParallelLoopResult loopResult=Parallel.ForEach(
                    list,(string s, ParallelLoopState state) =>
                    {
                    if ((bool)urls[s]) state.Break();
                        current = s;
                    });
                
                if (current == null || count > 10) break;

                Console.WriteLine("Crawl" + current);

                string html = DownLoad(current);

                urls[current] = true;
                count++;

                Parse(html);
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef= "(href | HREF) [] * = [] * [""'][^""'#>] + [""']";
            MatchCollection matches = new Regex(strRef).Matches(html);

            List<Match> list = new List<Match>();
            for (int i = 0; i < matches.Count; i++) list.Add(matches.Count);
            ParallelLoopResult loopResult = Parallel.ForEach(
                list, (Match m,ParallelLoopState state) =>
                {
                    strRef = m.Value.Substring(m.Value.IndexOf('=') + 1).Trim('"', '\",'#','','>');

                if (strRef.Length == 0)
                    {
                        state.Break();
                    }

                    if (urls[strRef] == null) urls[strRef] = false;
                });
            
        }
    }
}
