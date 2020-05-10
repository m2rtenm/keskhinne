using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Keskhinne.Data;
using Keskhinne.Models;

namespace Keskhinne.Pages.Tulemused
{
    public class EditModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public EditModel(Keskhinne.Data.KeskhinneContext context)
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
           ViewData["AineID"] = new SelectList(_context.Ained, "AineID", "AineID");
           ViewData["HinneID"] = new SelectList(_context.Hinded, "HinneID", "HinneID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AineHinne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AineHinneExists(AineHinne.AineHinneID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AineHinneExists(int id)
        {
            return _context.Ainetehinded.Any(e => e.AineHinneID == id);
        }
    }
}
