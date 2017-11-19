using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace GSharp.Modules.LeagueOfLegend
{
    public class LeagueOfLegend : GModule
    {
        public static string[] _SummonerDTO;
        [GCommand("결과")]
        public static string[] DTO
        {
            get
            {
                return _SummonerDTO;
            }
        }

        HttpWebResponse wRes;
        [GCommand("{0}유저의 프로필 조회 KEY {1}")]
        public static void IsGameSerch(string name, string key)
        {
            string resResult;
            string url = "https://kr.api.riotgames.com/lol/summoner/v3/summoners/by-name/" + name + "?api_key=" + key;
            Uri urls = new Uri(url);

            HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(urls);
            wReq.Method = "GET";

            wReq.ServicePoint.Expect100Continue = false;

            try
            {
                using (HttpWebResponse wRes = (HttpWebResponse)wReq.GetResponse())
                {
                    Stream respPostStream = wRes.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("utf-8"), true);

                    resResult = readerPost.ReadToEnd();
                }
                string[] ret = resResult.Split(',');
                _SummonerDTO = ret;
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
