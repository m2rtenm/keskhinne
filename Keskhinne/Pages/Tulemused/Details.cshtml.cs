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
    public class DetailsModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public DetailsModel(Keskhinne.Data.KeskhinneContext context)
        {
            _context = context;
        }

        public AineHinne AineHinne { get; set; }
        public Aine Aine { get; set; }
        public Hinne Hinne { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AineHinne = await _context.Ainetehinded
                .Include(a => a.Aine)
                .Include(a => a.Hinne).FirstOrDefaultAsync(m => m.AineHinneID == id);

            if (AineHinne == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
