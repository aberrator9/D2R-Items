using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using D2RItems.Data;
using D2RItems.Models;

namespace D2RItems.Models.Weapons
{
    public class CreateModel : PageModel
    {
        private readonly D2RItems.Data.D2RItemsContext _context;

        public CreateModel(D2RItems.Data.D2RItemsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Weapon Weapon { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Weapon == null || Weapon == null)
            {
                return Page();
            }

            _context.Weapon.Add(Weapon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
