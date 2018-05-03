using System.ComponentModel.DataAnnotations;
using System.Web;

namespace antiokas.Models
{
    public class UploadFileModel
    {
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name ="Select Video")]
        public HttpPostedFileBase VideoFiles { get; set; }
    }
}