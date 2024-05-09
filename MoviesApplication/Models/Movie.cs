using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesApplication.Models
{
    public class Movie
    {
        public Movie()
        {
            clients = new List<Client>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public float Rating { get; set; }
        [Display(Name = "Download URL")]
        public string DownloadURL { get; set; }
        [Display(Name = "The image URL")]
        public string ImgURL { get; set; }

        public virtual ICollection<Client> clients { get; set; }
    }
}