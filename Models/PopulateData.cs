using D2RItems.Data;
using Microsoft.EntityFrameworkCore;
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
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                foreach (var j in o2)
                {
                    Debug.WriteLine(j);
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
            //context.SaveChanges();
        }
    }
}
