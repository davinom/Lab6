
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Reviews
    {

        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Author { get; set; }

        [StringLength(100000, MinimumLength = 10)]
        [Required]
        public string Review { get; set; }

        public int MovieID { get; set; }
    }
}
