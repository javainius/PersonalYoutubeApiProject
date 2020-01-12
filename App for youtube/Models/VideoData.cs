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


/*
{
 "kind": "youtube#videoListResponse",
 "etag": "\"OOFf3Zw2jDbxxHsjJ3l8u1U8dz4/wvgbdrbgf9jQ3A4qonGLE6ki7Os\"",
 "pageInfo": {
  "totalResults": 1,
  "resultsPerPage": 1
 },
 "items": [
  {
   "kind": "youtube#video",
   "etag": "\"OOFf3Zw2jDbxxHsjJ3l8u1U8dz4/qlx4LbM0mjXN1Yensjcs7ZiqGSk\"",
   "id": "TRHGPMmIkvU",
   "snippet": {
    "publishedAt": "2016-12-21T15:00:08.000Z",
    "channelId": "UCPg6jj8aU_NBQIVQGLDpvEQ",
    "title": "\"Man 20-keli\": Karolis Vyšniauskas ir Benas Aleksandravičius",
    "description": "Žinių radijo laidoje \"Man 20-keli\" Karolis Vyšniauskas kalbina muzikantą Beną Aleksandravičių.",
    "thumbnails": {
     "default": {
      "url": "https://i.ytimg.com/vi/TRHGPMmIkvU/default.jpg",
      "width": 120,
      "height": 90
     },
     "medium": {
      "url": "https://i.ytimg.com/vi/TRHGPMmIkvU/mqdefault.jpg",
      "width": 320,
      "height": 180
     },
     "high": {
      "url": "https://i.ytimg.com/vi/TRHGPMmIkvU/hqdefault.jpg",
      "width": 480,
      "height": 360
     },
     "standard": {
      "url": "https://i.ytimg.com/vi/TRHGPMmIkvU/sddefault.jpg",
      "width": 640,
      "height": 480
     },
     "maxres": {
      "url": "https://i.ytimg.com/vi/TRHGPMmIkvU/maxresdefault.jpg",
      "width": 1280,
      "height": 720
     }
    },
    "channelTitle": "Žinių radijas",
    "tags": [
     "Žinių radijas",
     "radijo",
     "stotis",
     "politika",
     "verslas",
     "Vilnius",
     "Lietuva",
     "Lietuvoje",
     "Benas Aleksandravičius",
     "Karolis Vyšniauskas",
     "Man 20-keli"
    ],
    "categoryId": "25",
    "liveBroadcastContent": "none",
    "localized": {
     "title": "\"Man 20-keli\": Karolis Vyšniauskas ir Benas Aleksandravičius",
     "description": "Žinių radijo laidoje \"Man 20-keli\" Karolis Vyšniauskas kalbina muzikantą Beną Aleksandravičių."
    },
    "defaultAudioLanguage": "lt"
   },
   "contentDetails": {
    "duration": "PT32M40S",
    "dimension": "2d",
    "definition": "hd",
    "caption": "false",
    "licensedContent": true,
    "projection": "rectangular"
   },
   "statistics": {
    "viewCount": "15576",
    "likeCount": "124",
    "dislikeCount": "9",
    "favoriteCount": "0",
    "commentCount": "5"
   }
  }
 ]
}
*/