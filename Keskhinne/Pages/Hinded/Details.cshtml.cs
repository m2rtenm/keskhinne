using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Keskhinne.Data;
using Keskhinne.Models;

namespace Keskhinne.Pages.Hinded
{
    public class DetailsModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public DetailsModel(Keskhinne.Data.KeskhinneContext context)
        {
            _context = context;
        }

        public Hinne Hinne { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hinne = await _context.Hinded.FirstOrDefaultAsync(m => m.HinneID == id);

            if (Hinne == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
