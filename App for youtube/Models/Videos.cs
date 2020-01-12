using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_for_youtube.Models
{
    public class Videos
    {
        public List<Item> items {get; set;}
    }
    public class Item
    {
        public Id id { get; set; }
       
    }
    public class Id
    {
        public string videoId { get; set; }
    }
}

/*[JSON].items.[1].id.videoId


    {
 "kind": "youtube#searchListResponse",
 "etag": "\"OOFf3Zw2jDbxxHsjJ3l8u1U8dz4/pVr64WIfyg17SeyviDDIKYgxBSI\"",
 "nextPageToken": "CDIQAA",
 "regionCode": "LT",
 "pageInfo": {
  "totalResults": 83,
  "resultsPerPage": 50
 },
 "items": [
  {
   "kind": "youtube#searchResult",
   "etag": "\"OOFf3Zw2jDbxxHsjJ3l8u1U8dz4/tfNZFTJAvSK-tiOpm9-Mn-aGM3w\"",
   "id": {
    "kind": "youtube#video",
    "videoId": "ohPPnkivhSo"
   },
   "snippet": {
    "publishedAt": "2020-01-06T13:26:01.000Z",
    "channelId": "UCPg6jj8aU_NBQIVQGLDpvEQ",
    "title": "Žinių radijas tiesiogiai",
    "description": "",
    "thumbnails": {
     "default": {
      "url": "https://i.ytimg.com/vi/ohPPnkivhSo/default_live.jpg",
      "width": 120,
      "height": 90
     },
     "medium": {
      "url": "https://i.ytimg.com/vi/ohPPnkivhSo/mqdefault_live.jpg",
      "width": 320,
      "height": 180
     },
     "high": {
      "url": "https://i.ytimg.com/vi/ohPPnkivhSo/hqdefault_live.jpg",
      "width": 480,
      "height": 360
     }
    },
    "channelTitle": "Žinių radijas",
    "liveBroadcastContent": "live"
   }
  },
  */