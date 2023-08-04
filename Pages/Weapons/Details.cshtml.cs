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
    public class DetailsModel : PageModel
    {
        private readonly D2RItems.Data.D2RItemsContext _context;

        public DetailsModel(D2RItems.Data.D2RItemsContext context)
        {
            _context = context;
        }

      public Weapon Weapon { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Weapon == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapon.FirstOrDefaultAsync(m => m.Id == id);
            if (weapon == null)
            {
                return NotFound();
            }
            else 
            {
                Weapon = weapon;
            }
            return Page();
        }
    }
}
