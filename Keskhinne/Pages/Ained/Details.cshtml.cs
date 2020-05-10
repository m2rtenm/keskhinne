using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Keskhinne.Data;
using Keskhinne.Models;

namespace Keskhinne.Pages.Ained
{
    public class DetailsModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public DetailsModel(Keskhinne.Data.KeskhinneContext context)
        {
            _context = context;
        }

        public Aine Aine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Aine = await _context.Ained.FirstOrDefaultAsync(m => m.AineID == id);
            Aine = await _context.Ained.Include(a => a.AineteHinded).ThenInclude(ah => ah.Aine).FirstOrDefaultAsync(m => m.AineID == id);

            if (Aine == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
