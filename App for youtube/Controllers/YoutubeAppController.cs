using App_for_youtube.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App_for_youtube.Controllers
{
    public class YoutubeAppController : Controller
    {
        private readonly HttpClient client = new HttpClient();

        // GET: YoutubeApp
        public ActionResult Index()
        {
            var url = new URL();
            return View(url);
        }



        [HttpPost]
        public ActionResult Result(URL url)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", url);
            }

            string usersURL = url.Url;
            var uri = new Uri(usersURL);

            // you can check host here => uri.Host <= "www.youtube.com"

            var query = HttpUtility.ParseQueryString(uri.Query);

            var videoId = string.Empty;

            if (query.AllKeys.Contains("v"))
            {
                videoId = query["v"];
            }
            else
            {
                videoId = uri.Segments.Last();
            }

            string ResultsURL = "https://www.googleapis.com/youtube/v3/search?maxResults=50&part=snippet&type=video&key=AIzaSyDXf1LISKPcs3ZWSr7lHDpx4f29XGrSLmo&relatedToVideoId=" + videoId;
            string InfoURL = "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyDXf1LISKPcs3ZWSr7lHDpx4f29XGrSLmo&id=";

            Task<string> clientTask = Task.Run(async () => await client.GetStringAsync(ResultsURL).ConfigureAwait(false));

            var response = clientTask.Result;

            var videos = JsonConvert.DeserializeObject<Videos>(response);

            List<string> idList = new List<string>();

            foreach (var item in videos.items)
            {
                idList.Add(item.id.videoId);
            }

            ////////////////////////////////

            List<Video> videosWithInfo = new List<Video>();

            foreach (var id in idList)
            {
                var infoURL = InfoURL;
                infoURL += id;
                clientTask = Task.Run(async () => await client.GetStringAsync(infoURL).ConfigureAwait(false));

                response = clientTask.Result;

                var videoData = JsonConvert.DeserializeObject<VideoData>(response);

                if (videoData.items[0].snippet.categoryId == 10) // because 10 is musics ID  
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











