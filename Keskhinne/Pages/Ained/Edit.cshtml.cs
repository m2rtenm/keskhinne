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

namespace Keskhinne.Pages.Ained
{
    public class EditModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public EditModel(Keskhinne.Data.KeskhinneContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Aine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AineExists(Aine.AineID))
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

        private bool AineExists(int id)
        {
            return _context.Ained.Any(e => e.AineID == id);
        }
    }
}
