using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using D2RItems.Data;
using D2RItems.Models;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace D2RItems.Pages.Armors
{
	public class IndexModel : PageModel
	{
		private readonly D2RItems.Data.D2RItemsContext _context;

		public IndexModel(D2RItems.Data.D2RItemsContext context)
		{
			_context = context;
		}

		public string NameSort { get; set; }
		public string TierSort { get; set; }
		public string SlotSort { get; set; }
		public string SocketsSort { get; set; }
		public string ClassSort { get; set; }
		public string WeightSort { get; set; }
		public string ReqStrSort { get; set; }
		public string CurrentSort { get; set; }
		public string CurrentFilter { get; set; }

		[BindProperty]
		public string SelectedCharacterClass { get; set; }
		public SelectList ClassSelectList { get; set; }
		private readonly string[] characterClasses ={
			//"Amazon",
			//"Assassin",
			"Barbarian",
			"Druid",
			"Paladin",
			"Necro",
			//"Sorceress",
			};

		[BindProperty]
		public bool ExcludeClassSpecificItems { get; set; }

		public IList<Armor> Armors { get; set; } = default!;

		public async Task OnGetAsync(string sortOrder, string searchString, string selectedCharacterClass, bool excludeClassSpecificItems)
		{
			if (_context.Armors == null)
			{
				Debug.WriteLine("Armors context null");
				return;
			}

			IQueryable<Armor> armors = _context.Armors.Select(a => a);

			ClassSelectList = new SelectList(characterClasses.ToList());
			SelectedCharacterClass = selectedCharacterClass;
			ExcludeClassSpecificItems = excludeClassSpecificItems;

			CurrentSort = sortOrder;
			NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			SlotSort = sortOrder == "Slot" ? "slot_desc" : "Slot";
			TierSort = sortOrder == "Tier" ? "tier_desc" : "Tier";
			SocketsSort = sortOrder == "Sockets" ? "sockets_desc" : "Sockets";
			ClassSort = sortOrder == "Class" ? "class_desc" : "Class";
			WeightSort = sortOrder == "Weight" ? "weight_desc" : "Weight";
			ReqStrSort = sortOrder == "ReqStr" ? "req_str_desc" : "ReqStr";

			CurrentFilter = searchString;

			if (!String.IsNullOrEmpty(searchString))
			{
				if (searchString.Contains("*"))
				{
					if (searchString.StartsWith("*"))
					{
						armors = armors.Where(a => a.Name.EndsWith(searchString.Substring(1, searchString.Length - 1)));
					}
					else if (searchString.EndsWith("*"))
					{
						armors = armors.Where(a => a.Name.StartsWith(searchString.Substring(0, searchString.Length - 1)));
					}
				}
				else
				{
					armors = armors.Where(a => a.Name.Contains(searchString));
				}
			}

			if (!string.IsNullOrEmpty(SelectedCharacterClass))
			{
				armors = armors.Where(a => a.Slot.Contains(SelectedCharacterClass));
			}

			if (ExcludeClassSpecificItems)
			{
				// Workaround, since Contains can't be translated in 
				// armors = armors.Where(a => characterClasses.Any(c => a.Slot.Contains(c)));
				armors = armors.Where(a =>
					!a.Slot.Contains("Barbarian") &&
					!a.Slot.Contains("Druid") &&
					!a.Slot.Contains("Necro") &&
					!a.Slot.Contains("Paladin"));
			}

            armors = sortOrder switch
            {
                "name_desc" =>      armors.OrderByDescending(a => a.Name),
                "Slot" =>           armors.OrderBy(a => a.Slot),
                "slot_desc" =>      armors.OrderByDescending(a => a.Slot),
                "Tier" =>           armors.OrderBy(w => w.Tier),
                "tier_desc" =>      armors.OrderByDescending(a => a.Tier),
                "Sockets" =>        armors.OrderByDescending(a => a.Sockets),
                "sockets_desc" =>   armors.OrderBy(a => a.Sockets),
                "Weight" =>         armors.OrderBy(a => a.Weight),
                "weight_desc" =>    armors.OrderByDescending(a => a.Weight),
                "ReqStr" =>         armors.OrderBy(w => w.ReqStr),
                "req_str_desc" =>   armors.OrderByDescending(w => w.ReqStr),
                "Class" =>          armors.OrderByDescending(w => w.Class),
                "class_desc" =>     armors.OrderBy(w => w.Class),
                _ =>                armors.OrderBy(w => w.Name)
            };

            Armors = await armors.AsNoTracking().ToListAsync();
		}
	}
}
