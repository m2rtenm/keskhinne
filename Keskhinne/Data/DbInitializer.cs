using Keskhinne.Data;
using Keskhinne.Models;
using System;
using System.Linq;

namespace Keskhinne.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KeskhinneContext context){
            context.Database.EnsureCreated();

            if (context.Hinded.Any())
            {
                return;
            }
            
            var hinded = new Hinne[]
            {
                new Hinne{Väärtus = "1"},
                new Hinne{Väärtus = "2"},
                new Hinne{Väärtus = "3"},
                new Hinne{Väärtus = "4"},
                new Hinne{Väärtus = "5"},
                new Hinne{Väärtus = "A"},
            };

            context.Hinded.AddRange(hinded);
            context.SaveChanges();

            var ained = new Aine[]
            {
                new Aine{Nimetus = "Tarkvara arhitektuur ja disain", Code = "IDU0550", HindamisViis = Hindamisviis.E, EAP = 6},
                new Aine{Nimetus = "Kriitiline mõtlemine, eetika ja teaduslik kirjaoskus", Code = "MNF5510", HindamisViis = Hindamisviis.A, EAP = 6},
                new Aine{Nimetus = "IT projektijuhtimine", Code = "ITB8806", HindamisViis = Hindamisviis.E, EAP = 6}
            };

            context.Ained.AddRange(ained);
            context.SaveChanges();

            var ainetehinded = new AineHinne[]
            {
                new AineHinne{HinneID = 5, AineID = 1},
                new AineHinne{HinneID = 6, AineID = 2},
                new AineHinne{HinneID = 5, AineID = 3}
            };

            context.Ainetehinded.AddRange(ainetehinded);
            context.SaveChanges();
        }
    }
}