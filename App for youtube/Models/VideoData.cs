using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_for_youtube.Models
{
    public class VideoData
    {
        public List<Video> items { get; set; }
    }
    public class Video
    {
        public string GetURL(string id)
        {
            return "https://www.youtube.com/embed/" + id + "?autoplay=1";
        }
        public string id { get; set; }
        public Snippet snippet { get; set; }
        public Statistics statistics { get; set; }

    }
    public class Statistics
    {
        public int viewCount { get; set; }
    }
    public class Snippet
    {
        public int categoryId { get; set; }
    }
}


