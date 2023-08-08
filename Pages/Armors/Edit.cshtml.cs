using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using D2RItems.Data;
using D2RItems.Models;

namespace D2RItems.Pages.Armors
{
    public class EditModel : PageModel
    {
        private readonly D2RItems.Data.D2RItemsContext _context;

        public EditModel(D2RItems.Data.D2RItemsContext context)
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

            var armor =  await _context.Armors.FirstOrDefaultAsync(m => m.Id == id);
            if (armor == null)
            {
                return NotFound();
            }
            Armor = armor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Armor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmorExists(Armor.Id))
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

        private bool ArmorExists(int id)
        {
          return (_context.Armors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
