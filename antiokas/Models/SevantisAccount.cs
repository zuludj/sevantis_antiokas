using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace antiokas.Models
{
    public class SevantisAccount
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"\d{6,10}" , ErrorMessage ="Account # must be 6-10 digits")]
        [Display(Name ="Account #")]
        public string  AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Surname")]
        public string LastName { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0},{1}", this.FirstName, this.LastName);
            }
        }

        [DataType(DataType.Currency)]
        public decimal Credit { get; set; }

        public virtual ApplicationUser User { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}