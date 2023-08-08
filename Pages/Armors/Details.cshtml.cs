﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly D2RItems.Data.D2RItemsContext _context;

        public DetailsModel(D2RItems.Data.D2RItemsContext context)
        {
            _context = context;
        }

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
    }
}
