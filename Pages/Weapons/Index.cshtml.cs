using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using D2RItems.Data;
using D2RItems.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace D2RItems.Models.Weapons
{
    public class IndexModel : PageModel
    {
        private readonly D2RItems.Data.D2RItemsContext _context;

        public IndexModel(D2RItems.Data.D2RItemsContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string TierSort { get; set; }
        public string SocketsSort { get; set; }
        public string OneHandDmgSort { get; set; }
        public string TwoHandDmgSort { get; set; }
        public string SpeedSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }

        [BindProperty]
        public string SelectedCharacterClass { get; set; }
        public SelectList ClassSelectList { get; set; }
        private readonly string[] characterClasses ={
            "Amazon",
            "Assassin",
            //"Barbarian",
            //"Druid",
            //"Paladin",
            //"Necro",
			"Sorceress",
            };

        [BindProperty]
        public bool ExcludeClassSpecificItems { get; set; }

        public IList<Weapon> Weapons { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString, string selectedCharacterClass, bool excludeClassSpecificItems)
        {
            if (_context.Weapons == null)
            {
                Debug.WriteLine("Weapons context null");
                return;
            }

            IQueryable<Weapon> weapons = _context.Weapons.Select(w => w);

            ClassSelectList = new SelectList(characterClasses.ToList());
            SelectedCharacterClass = selectedCharacterClass;
            ExcludeClassSpecificItems = excludeClassSpecificItems;

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";
            TierSort = sortOrder == "Tier" ? "tier_desc" : "Tier";
            SocketsSort = sortOrder == "Sockets" ? "sockets_desc" : "Sockets";
            OneHandDmgSort = sortOrder == "OneHandDmg" ? "one_desc" : "OneHandDmg";
            TwoHandDmgSort = sortOrder == "TwoHandDmg" ? "two_desc" : "TwoHandDmg";
            SpeedSort = sortOrder == "Speed" ? "speed_desc" : "Speed";

            CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Contains("*"))
                {
                    if (searchString.StartsWith("*"))
                    {
                        weapons = weapons.Where(a => a.Name.EndsWith(searchString.Substring(1, searchString.Length - 1)));
                    }
                    else if (searchString.EndsWith("*"))
                    {
                        weapons = weapons.Where(a => a.Name.StartsWith(searchString.Substring(0, searchString.Length - 1)));
                    }
                }
                else
                {
                    weapons = weapons.Where(a => a.Name.Contains(searchString));
                }
            }

            if (!string.IsNullOrEmpty(SelectedCharacterClass))
            {
                weapons = weapons.Where(a => a.Type.Contains(SelectedCharacterClass));
            }

            if (ExcludeClassSpecificItems)
            {
                // Workaround, since Contains can't be translated in 
                // weapons = weapons.Where(w => characterClasses.Any(c => w.Slot.Contains(c)));
                weapons = weapons.Where(w =>
                    !w.Type.Contains("Amazon") &&
                    !w.Type.Contains("Assassin") &&
                    !w.Type.Contains("Sorceress") &&
                    !w.Type.Contains("Paladin"));
            }

            weapons = sortOrder switch
            {
                "name_desc" =>      weapons.OrderByDescending(w => w.Name),
                "Type" =>           weapons.OrderBy(w => w.Type),
                "type_desc" =>      weapons.OrderByDescending(w => w.Type),
                "Tier" =>           weapons.OrderBy(w => w.Tier),
                "tier_desc" =>      weapons.OrderByDescending(w => w.Tier),
                "Sockets" =>        weapons.OrderByDescending(w => w.Sockets),
                "sockets_desc" =>   weapons.OrderBy(w => w.Sockets),
                "OneHandDmg" =>     weapons.OrderByDescending(w => w.OneHandDmg),
                "one_desc" =>       weapons.OrderBy(w => w.OneHandDmg),
                "TwoHandDmg" =>     weapons.OrderByDescending(w => w.TwoHandDmg),
                "two_desc" =>       weapons.OrderBy(w => w.TwoHandDmg),
                "Speed" =>          weapons.OrderBy(w => w.Speed),
                "speed_desc" =>     weapons.OrderByDescending(w => w.Speed),
                _ =>                weapons.OrderBy(w => w.Name)
            };

            Weapons = await weapons.AsNoTracking().ToListAsync();
        }
    }
}
