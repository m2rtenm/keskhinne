using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Keskhinne.Data;
using Keskhinne.Models;

namespace Keskhinne.Pages.Hinded
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
            return Page();
        }

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

            _context.Hinded.Add(Hinne);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
