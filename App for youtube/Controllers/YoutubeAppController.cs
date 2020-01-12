using App_for_youtube.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using NReco.PhantomJS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App_for_youtube.Controllers
{
    public class YoutubeAppController : Controller
    {
        // GET: YoutubeApp
        private readonly string ApiKey = "key=AIzaSyDXf1LISKPcs3ZWSr7lHDpx4f29XGrSLmo";
        string ResultsURL = "https://www.googleapis.com/youtube/v3/search?maxResults=50&part=snippet&relatedToVideoId=TRHGPMmIkvU&type=video&key=AIzaSyDXf1LISKPcs3ZWSr7lHDpx4f29XGrSLmo";
        string InfoURL = "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyDXf1LISKPcs3ZWSr7lHDpx4f29XGrSLmo&id=";
        private readonly HttpClient client = new HttpClient();
        public ActionResult Index()
        {
           

            Task<string> clientTask = Task.Run(async () => await client.GetStringAsync(ResultsURL).ConfigureAwait(false));

            var response = clientTask.Result;

            var videos = JsonConvert.DeserializeObject<Videos>(response);

            List<string> idList = new List<string>();
            
            foreach(var item in videos.items)
            {
                idList.Add(item.id.videoId);
            }

            ////////////////////////////////

            List<Video> videosWithInfo = new List<Video>();
            
            foreach(var id in idList)
            {
                var infoURL = InfoURL;
                infoURL += id;
                clientTask = Task.Run(async () => await client.GetStringAsync(infoURL).ConfigureAwait(false));

                response = clientTask.Result;

                var videoData = JsonConvert.DeserializeObject<VideoData>(response);

                if(videoData.items[0].snippet.categoryId == 10) // because 10 is musics ID  
                {
                    videosWithInfo.Add(videoData.items[0]);
                }               
            }

            var sortedMusicVideos = videosWithInfo.OrderBy(x => x.statistics.viewCount);

            var nr1ByTheviews = sortedMusicVideos.Last<Video>();

            return View(nr1ByTheviews);
        }
        
    }
}










/*
 * public ActionResult Index()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(Code("https://www.youtube.com/watch?v=TRHGPMmIkvU"));
            var anchor = doc.GetElementbyId("content");

            var data = new Data(anchor.OuterHtml);

            return View(data);
        }






    public static string Code(string Url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return result;
        }


    public static string Run_script(string html)
        {
            string output = "";

            var phantomJS = new PhantomJS();

            phantomJS.OutputReceived += (sender, e) =>
            {
                output += e.Data;
            };

            phantomJS.RunScript(html, null);

            return output;
        }

        public ActionResult Index()
        {
            var web = new HtmlWeb();
            //var web = new HttpClient();
            var doc = web.Load("https://www.youtube.com/watch?v=TRHGPMmIkvU");

            var anchor = doc.GetElementbyId("content");

            //var data = new Data(anchor.OuterHtml);
            var navNode = doc.DocumentNode.SelectSingleNode("/html/body/ytd-app/div/ytd-page-manager/" +
                "ytd-watch-flexy/div[4]/div[1]/div/div[12]/" +
                "ytd-watch-next-secondary-results-renderer/div[2]");

            var data = new Data();

            return View(data);
        }
*/
