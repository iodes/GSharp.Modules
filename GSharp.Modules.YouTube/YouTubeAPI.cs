using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using GSharp.Modules.YouTube.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GSharp.Modules.YouTube
{
    public class YouTubeAPI : GModule
    {
        #region 상수
        private const string url = "https://www.googleapis.com/youtube/v3/search";
        private const string sub_url = "key=AIzaSyCWXp5SQT1e_IqshiK2D3GHRGpIPfsFQ8M&part=snippet&maxResults=5&" + "fields=items(id(kind, videoId),snippet(title, publishedAt))&order=viewCount&q=";
        #endregion

        #region 변수
        public static List<YouTubeVideo> lastResult;
        #endregion

        [GCommand("유투브에서 {0} 검색")]
        public static List<object> SearchVideo(string word)
        {
            lastResult = new List<YouTubeVideo>();

            var request = WebRequest.Create(new Uri($"{url}?{sub_url}{word}"));
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                var stReadData = response.GetResponseStream();
                var srReadData = new StreamReader(stReadData, Encoding.UTF8);

                var jsonObject = JObject.Parse(srReadData.ReadToEnd());
                foreach (JObject json in jsonObject["items"])
                {
                    lastResult.Add(new YouTubeVideo
                    {
                        ID = json["id"]["videoId"].Value<string>(),
                        Type = json["id"]["kind"].Value<string>(),
                        Title = json["snippet"]["title"].Value<string>()
                    });
                }
            }

            return lastResult.Select(x => x.Title).ToList<object>();
        }

        [GCommand("{0} 유투브로 보기")]
        public static void ShowVideo(string selected)
        {
            int index = lastResult.Select(x => x.Title).ToList().IndexOf(selected);
            string sub_url = lastResult[index].ID;
            string type = lastResult[index].Type;

            if (type.Equals("youtube#video"))
            {
                string url = "https://youtube.com/embed/" + sub_url;
                Process.Start(url);
            }
        }
    }
}