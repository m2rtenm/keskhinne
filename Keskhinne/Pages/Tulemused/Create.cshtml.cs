using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Keskhinne.Data;
using Keskhinne.Models;

namespace Keskhinne.Pages.Tulemused
{
    public class CreateModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public CreateModel(Keskhinne.Data.KeskhinneContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AineID"] = new SelectList(_context.Ained, "AineID", "Nimetus");
        ViewData["HinneID"] = new SelectList(_context.Hinded, "HinneID", "Väärtus");
            return Page();
        }

        [BindProperty]
        public AineHinne AineHinne { get; set; }
        [BindProperty]
        public Aine Aine { get; set; }
        [BindProperty]
        public Hinne Hinne { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ainetehinded.Add(AineHinne);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
