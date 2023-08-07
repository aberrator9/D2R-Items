using D2RItems.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace D2RItems.Models;

public class PopulateData
{
	public PopulateData(IWebHostEnvironment webHostEnvironment)
	{
		WebHostEnvironment = webHostEnvironment;
	}

	public IWebHostEnvironment WebHostEnvironment { get; }

	public static void Initialize(IServiceProvider serviceProvider)
	{
		Debug.WriteLine("In initialize");

		using (var context = new D2RItemsContext(
			serviceProvider.GetRequiredService<
				DbContextOptions<D2RItemsContext>>()))
		{
			if (context == null || context.Weapon == null)
			{
				throw new ArgumentNullException("Null D2RItemsContext");
			}

			if (context.Weapon.Any())
			{
				return;
			}

			// read JSON directly from a file
			using (StreamReader file = File.OpenText(@"c:\users\qbdth\repos\d2r-items\wwwroot\data\weapons.json"))
			using (JsonTextReader reader = new JsonTextReader(file))
			{
				Debug.WriteLine("File was loaded" + file);
				JObject weaponsJson = (JObject)JToken.ReadFrom(reader);

				foreach (var item in weaponsJson)
				{
					Debug.WriteLine((string)item.Value["name"]);

					int twoHandDmg = 0;
					if (item.Value["2handmaxdam"] != null)
					{
						twoHandDmg = (int)item.Value["2handmaxdam"];
					}
					else if (item.Value["maxmisdam"] != null)
					{
						twoHandDmg = (int)item.Value["maxmisdam"];
					}

					string tier = "Normal";
					if (item.Key == (string)item.Value["ubercode"])
					{
						tier = "Exceptional";
					}
					else if(item.Key == (string)item.Value["ultracode"]) 
					{ 
						tier = "Elite"; 
					}


					context.Weapon.Add(
						new Weapon()
						{
							Name = (string)item.Value["name"],
							Tier = tier,
							Type = Weapon.WeaponTypeTags[(string)item.Value["type"]][0],
							Sockets = item.Value["gemsockets"] == null ? 0 : (int)item.Value["gemsockets"],
							OneHandDmg = item.Value["maxdam"] == null ? 0 : (int)item.Value["maxdam"],
							TwoHandDmg = twoHandDmg,
							Speed = item.Value["speed"] == null ? 0 : (int)item.Value["speed"]
						});
				}
			}

			//context.Weapon.AddRange(

			//    // Map each parameter to a new Weapon
			//    new Weapon()
			//    {
			//        Name = "The Crungis",
			//        Tier = "Elite",
			//        Type = "Boulder",
			//        Sockets = 5,
			//        OneHandDmg = 15,
			//        TwoHandDmg = 150
			//    }
			//    );
			context.SaveChanges();
		}
	}
}
