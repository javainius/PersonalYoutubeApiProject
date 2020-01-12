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

