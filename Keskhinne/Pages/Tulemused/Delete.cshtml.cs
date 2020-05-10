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
    public class DeleteModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public DeleteModel(Keskhinne.Data.KeskhinneContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AineHinne AineHinne { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AineHinne = await _context.Ainetehinded.FindAsync(id);

            if (AineHinne != null)
            {
                _context.Ainetehinded.Remove(AineHinne);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
