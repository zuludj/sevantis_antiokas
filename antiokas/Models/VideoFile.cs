using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace antiokas.Models
{
    public class VideoFile
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType Cover { get; set; }
        public FileType FileType { get; set; }
        public int VideoId { get; set; }

        public virtual Video Video
        {
            get; set;
        }


    }

}