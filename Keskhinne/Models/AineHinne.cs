using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keskhinne.Models
{
    public class AineHinne
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AineHinneID { get; set; }
        [Required(ErrorMessage = "Tulemuse sisestamiseks peab olemas olema ka hinne!")]
        public int HinneID { get; set; }
        [Required(ErrorMessage = "Ühe aine kohta saab olla ainult üks tulemus!")]
        public int AineID { get; set; }
        public Hinne Hinne { get; set; }
        public Aine Aine { get; set; }
    }
}
