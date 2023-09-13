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
		public string SelectedClass { get; set; }
		public SelectList ClassSelectList { get; set; }
		private readonly string[] classes ={
			//"Amazon",
			//"Assassin",
			"Barbarian",
			"Druid",
			"Paladin",
			"Necro",
			//"Sorceress",
			};

		public IList<Armor> Armors { get; set; } = default!;

		public async Task OnGetAsync(string sortOrder, string searchString, string selectedClass)
		{
			if (_context.Armors == null)
			{
				Debug.WriteLine("Armors context null");
				return;
			}

			ClassSelectList = new SelectList(classes.ToList());
            SelectedClass = selectedClass;
			Debug.WriteLine("Selected class is " + SelectedClass);

			CurrentSort = sortOrder;
			NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			SlotSort = sortOrder == "Slot" ? "slot_desc" : "Slot";
			TierSort = sortOrder == "Tier" ? "tier_desc" : "Tier";
			SocketsSort = sortOrder == "Sockets" ? "sockets_desc" : "Sockets";
			ClassSort = sortOrder == "Class" ? "class_desc" : "Class";
			WeightSort = sortOrder == "Weight" ? "weight_desc" : "Weight";
			ReqStrSort = sortOrder == "ReqStr" ? "req_str_desc" : "ReqStr";

			CurrentFilter = searchString;

			IQueryable<Armor> armors = from a in _context.Armors
									   select a;

			if (!String.IsNullOrEmpty(searchString))
			{
				if (searchString.Contains("*"))
				{
					if (searchString.StartsWith("*"))
					{
                        armors = _context.Armors.Where(a => a.Name.EndsWith(searchString.Substring(1, searchString.Length - 1)));
                    }
					else if (searchString.EndsWith("*"))
					{
                        armors = _context.Armors.Where(a => a.Name.StartsWith(searchString.Substring(0, searchString.Length - 1)));
					}
				}
				else
				{
					armors = armors.Where(a => a.Name.Contains(searchString));
				}
			}

			if(!String.IsNullOrEmpty(SelectedClass))
			{
			    armors = armors.Where(a=>a.Slot.Contains(SelectedClass));
			}

			switch (sortOrder)
			{
				case "name_desc":
					armors = armors.OrderByDescending(a => a.Name);
					break;
				case "Slot":
					armors = armors.OrderBy(a => a.Slot);
					break;
				case "slot_desc":
					armors = armors.OrderByDescending(a => a.Slot);
					break;
				case "Tier":
					armors = armors.OrderBy(w => w.Tier);
					break;
				case "tier_desc":
					armors = armors.OrderByDescending(a => a.Tier);
					break;
				case "Sockets":
					armors = armors.OrderByDescending(a => a.Sockets);
					break;
				case "sockets_desc":
					armors = armors.OrderBy(a => a.Sockets);
					break;
				case "Weight":
					armors = armors.OrderBy(a => a.Weight);
					break;
				case "weight_desc":
					armors = armors.OrderByDescending(a => a.Weight);
					break;
				case "ReqStr":
					armors = armors.OrderBy(w => w.ReqStr);
					break;
				case "req_str_desc":
					armors = armors.OrderByDescending(w => w.ReqStr);
					break;
				case "Class":
					armors = armors.OrderByDescending(w => w.Class);
					break;
				case "class_desc":
					armors = armors.OrderBy(w => w.Class);
					break;
				default:
					armors = armors.OrderBy(w => w.Name);
					break;
			}

			Armors = await armors.AsNoTracking().ToListAsync();
		}
	}
}
