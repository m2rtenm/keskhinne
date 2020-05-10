using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Keskhinne.Data;
using Keskhinne.Models;

namespace Keskhinne.Pages.Tulemused
{
    public class IndexModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public IndexModel(Keskhinne.Data.KeskhinneContext context)
        {
            _context = context;
        }

        public IList<AineHinne> AineHinne { get;set; }
        public Aine Aine { get; set; }
        public Hinne Hinne { get; set; }
        public IList<AineHinne> ArvutatudAineHinne { get; set; }
        [ViewData] public double Kaalutud { get; set; }
        [ViewData] public int KoguEAP { get; set; }
        private double _sumEAP;
        private double _sumEAPHinne;

        public async Task OnGetAsync()
        {
            AineHinne = await _context.Ainetehinded
                .Include(a => a.Aine)
                .Include(a => a.Hinne).AsNoTracking().ToListAsync();
            KoguEAP = AineHinne.Sum(ainehinne => ainehinne.Aine.EAP);
            ArvutatudAineHinne = _context.Ainetehinded.Include(a => a.Hinne).Include(a => a.Aine).Where(a => a.Aine.HindamisViis != Hindamisviis.A).ToList();
            _sumEAP = ArvutatudAineHinne.Sum(item => item.Aine.EAP);
            _sumEAPHinne = ArvutatudAineHinne.Sum(item => (item.Aine.EAP * int.Parse(item.Hinne.Väärtus)));
            Kaalutud = Math.Round((_sumEAPHinne / _sumEAP),3);
        }
    }
}
