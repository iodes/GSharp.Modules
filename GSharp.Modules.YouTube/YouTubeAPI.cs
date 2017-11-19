using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace GSharp.Modules.YouTube
{
    public class YouTubeAPI : GModule
    {
        private static string url = "https://www.googleapis.com/youtube/v3/search";
        private static string sub_url = "key=AIzaSyCWXp5SQT1e_IqshiK2D3GHRGpIPfsFQ8M&part=snippet&maxResults=5&" + "fields=items(id(kind, videoId),snippet(title, publishedAt))&order=viewCount&q=";
        private static HttpWebRequest request;
        private static HttpWebResponse response;
        private static string result;

        [GCommand("검색한 결과 목록")]
        public static List<object> Title
        {
            get
            {
                return _title;
            }
        }
        private static List<object> _title = null;

        public static List<string> VideoId
        {
            get
            {
                return _videoId;
            }
            set
            {
                _videoId = value;
            }
        }
        private static List<string> _videoId = null;

        public static List<string> VideoType
        {
            get
            {
                return _videoType;
            }
            set
            {
                _videoType = value;
            }
        }
        private static List<string> _videoType = null;

        [GCommand("유투브에서 {0} 검색")]
        public static void searchVideo(string word)
        {
            var titleList = new List<object>();
            var videoTypeList = new List<string>();
            var videoIdList = new List<string>();

            Uri uri = new Uri(url + "?" + sub_url + word);
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            using (response = (HttpWebResponse)request.GetResponse())
            {
                var stReadData = response.GetResponseStream();
                var srReadData = new StreamReader(stReadData, Encoding.UTF8);
                result = srReadData.ReadToEnd();
            }

            var jsonObject = JObject.Parse(result.ToString());
            foreach (JObject json in jsonObject["items"])
            {
                titleList.Add(json["snippet"]["title"].Value<string>());
                videoTypeList.Add(json["id"]["kind"].Value<string>());
                videoIdList.Add(json["id"]["videoId"].Value<string>());

            }

            _videoId = videoIdList;
            _videoType = videoTypeList;
            _title = titleList;
        }

        [GCommand("{0} 유투브로 보기")]
        public static void showVideo(string selected)
        {
            int index = Title.IndexOf(selected);
            string sub_url = VideoId[index];
            string type = VideoType[index];

            if (type.Equals("youtube#video"))
            {
                string url = "https://youtube.com/embed/" + sub_url;
                Process.Start(url);
            }
        }
    }
}