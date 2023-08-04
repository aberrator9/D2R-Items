using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using D2RItems.Data;
using D2RItems.Models;

namespace D2RItems.Models.Weapons
{
    public class IndexModel : PageModel
    {
        private readonly D2RItems.Data.D2RItemsContext _context;

        public IndexModel(D2RItems.Data.D2RItemsContext context)
        {
            _context = context;
        }

        public IList<Weapon> Weapon { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Weapon != null)
            {
                Weapon = await _context.Weapon.ToListAsync();
            }
        }
    }
}
