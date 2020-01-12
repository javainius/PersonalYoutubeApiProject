using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App_for_youtube.Models
{
    public class URL
    {
        [Display(Name = "Enter videos URL")]
        [Required(ErrorMessage = "* A Field is required.")]
        public string Url { get; set; }
    }
}