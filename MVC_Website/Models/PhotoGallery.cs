using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Website.Models
{
    public class PhotoGallery
    {
        public PhotoGallery()
        {
            PhotoList = new List<string>();
        }
        [Key]
        public Guid PhotoID  { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public List<string> PhotoList { get; set; }

    }
}