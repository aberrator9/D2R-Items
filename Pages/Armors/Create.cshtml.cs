using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using D2RItems.Data;
using D2RItems.Models;

namespace D2RItems.Pages.Armors
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
        public Armor Armor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Armors == null || Armor == null)
            {
                return Page();
            }

            _context.Armors.Add(Armor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
