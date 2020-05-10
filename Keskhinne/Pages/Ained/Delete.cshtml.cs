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
    public class DeleteModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public DeleteModel(Keskhinne.Data.KeskhinneContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Aine Aine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aine = await _context.Ained.FirstOrDefaultAsync(m => m.AineID == id);

            if (Aine == null)
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

            Aine = await _context.Ained.FindAsync(id);

            if (Aine != null)
            {
                _context.Ained.Remove(Aine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
