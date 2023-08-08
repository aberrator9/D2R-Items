using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using D2RItems.Data;
using D2RItems.Models;

namespace D2RItems.Pages.Armors
{
    public class DeleteModel : PageModel
    {
        private readonly D2RItems.Data.D2RItemsContext _context;

        public DeleteModel(D2RItems.Data.D2RItemsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Armor Armor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Armors == null)
            {
                return NotFound();
            }

            var armor = await _context.Armors.FirstOrDefaultAsync(m => m.Id == id);

            if (armor == null)
            {
                return NotFound();
            }
            else 
            {
                Armor = armor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Armors == null)
            {
                return NotFound();
            }
            var armor = await _context.Armors.FindAsync(id);

            if (armor != null)
            {
                Armor = armor;
                _context.Armors.Remove(Armor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
