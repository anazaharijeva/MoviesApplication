using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesApplication.Models
{
    public class MoviesDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
  
        public float Rating { get; set; }
       
        public string DownloadURL { get; set; }
        public string ImgURL { get; set; }

    }
}