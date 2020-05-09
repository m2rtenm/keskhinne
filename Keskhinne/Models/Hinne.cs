using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keskhinne.Models
{
    public class Hinne
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HinneID { get; set; }
        public string Väärtus { get; set; }
        public ICollection<AineHinne> AineteHinded { get; set; }
    }
}