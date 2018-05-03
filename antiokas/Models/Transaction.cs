using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace antiokas.Models
{
    public class Transaction
    {
        
        public int Id { get; set; }
        [Required]
        public string VideoAsset { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public int SevanticAccountId { get; set; }
        public virtual SevantisAccount SevantisAccount { get; set; }
    }
}