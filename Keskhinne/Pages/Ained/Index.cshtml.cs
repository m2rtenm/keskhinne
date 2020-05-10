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
    public class IndexModel : PageModel
    {
        private readonly Keskhinne.Data.KeskhinneContext _context;

        public IndexModel(Keskhinne.Data.KeskhinneContext context)
        {
            _context = context;
        }

        public IList<Aine> Aine { get;set; }

        public async Task OnGetAsync()
        {
            Aine = await _context.Ained.ToListAsync();
        }
    }
}
