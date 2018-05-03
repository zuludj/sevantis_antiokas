using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace antiokas.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Video Title")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int ReleaseYear { get; set; }

        [Required]
        [Display(Name = "Production Studio")]
        public string ProductionHouse { get; set; }
        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public byte[] Cover { get; set; }
        public string ImageUrl { get; set; }

        public byte[] VideoFile { get; set; }
        public string VideoUrl { get; set; }
        public FileType FileType { get; set; }

        public string Description { get; set; }
    }
}