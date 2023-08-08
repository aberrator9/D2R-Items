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

		public string NameSort { get; set; }
		public string TypeSort { get; set; }
		public string TierSort { get; set; }
		public string SocketsSort { get; set; }
		public string OneHandDmgSort { get; set; }
		public string TwoHandDmgSort { get; set; }
		public string SpeedSort { get; set; }
		public string CurrentSort { get; set; }

		public IList<Weapon> Weapons { get; set; } = default!;

		public async Task OnGetAsync(string sortOrder)
		{
			if (_context.Weapons == null)
			{
				return;
			}

			CurrentSort = sortOrder;
			NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			TypeSort = sortOrder == "Type" ? "type_desc" : "Type";
			TierSort = sortOrder == "Tier" ? "tier_desc" : "Tier";
			SocketsSort = sortOrder == "Sockets" ? "sockets_desc" : "Sockets";
			OneHandDmgSort = sortOrder == "OneHandDmg" ? "one_desc" : "OneHandDmg";
			TwoHandDmgSort = sortOrder == "TwoHandDmg" ? "two_desc" : "TwoHandDmg";
			SpeedSort = sortOrder == "Speed" ? "speed_desc" : "Speed";

			IQueryable<Weapon> weapons = from w in _context.Weapons
										 select w;

			_ = sortOrder switch
			{
				"name_desc" => weapons = weapons.OrderByDescending(w => w.Name),
				"Type" => weapons = weapons.OrderBy(w => w.Type),
				"type_desc" => weapons = weapons.OrderByDescending(w => w.Type),
				"Tier" => weapons = weapons.OrderBy(w => w.Tier),
				"tier_desc" => weapons = weapons.OrderByDescending(w => w.Tier),
				"Sockets" => weapons = weapons.OrderBy(w => w.Sockets),
				"sockets_desc" => weapons = weapons.OrderByDescending(w => w.Sockets),
				"OneHandDmg" => weapons = weapons.OrderBy(w => w.OneHandDmg),
				"one_desc" => weapons = weapons.OrderByDescending(w => w.OneHandDmg),
				"TwoHandDmg" => weapons = weapons.OrderBy(w => w.TwoHandDmg),
				"two_desc" => weapons = weapons.OrderByDescending(w => w.TwoHandDmg),
				"Speed" => weapons = weapons.OrderBy(w => w.Speed),
				"speed_desc" => weapons = weapons.OrderByDescending(w => w.Speed),
				_ => weapons = weapons.OrderBy(w => w.Name)
			};

			Weapons = await weapons.AsNoTracking().ToListAsync();
		}
	}
}
