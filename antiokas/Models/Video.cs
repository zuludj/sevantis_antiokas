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
        [Display(Name = "Video Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Production Studio")]
        public string ProductionHouse { get; set; }

        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<VideoFile> VideoFiles { get; set; }
        public virtual ICollection<Cover> Covers { get; set; }

    }
}