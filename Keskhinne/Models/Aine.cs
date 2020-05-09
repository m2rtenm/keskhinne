using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keskhinne.Models
{
    public enum Hindamisviis
    {
        E,A,H
    }   
    public class Aine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AineID { get; set; }
        public string Nimetus { get; set; }
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "Ainekood peab olema täpselt kolm suurtähte ja neli numbrit!")]
        public string Code { get; set; }
        [Display(Name = "Hindamisviis")]
        public Hindamisviis HindamisViis { get; set; }
        public int EAP { get; set; }
        public ICollection<AineHinne> AineteHinded { get; set; }
    }
}