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

        public async Task OnGetAsync()
        {
            AineHinne = await _context.Ainetehinded
                .Include(a => a.Aine)
                .Include(a => a.Hinne).ToListAsync();
        }
    }
}
