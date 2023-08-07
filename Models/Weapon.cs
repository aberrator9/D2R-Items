using System.ComponentModel.DataAnnotations;

namespace D2RItems.Models;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tier { get; set; }
    public string Type { get; set; }
    public int Sockets { get; set; }
    public int OneHandDmg { get; set; }
    public int TwoHandDmg { get; set; }
    public int Speed { get; set; }

    public static IDictionary<string, string[]> WeaponTypeTags = new Dictionary<string, string[]>()
    {
        {"axe", new string[] { "Axe" }},
        {"bow", new string[] { "Bow"}},
        {"club", new string[] { "Club"}},
        {"h2h2", new string[] { "Katar [Assassin only]", "Assassin only" }},
        {"hamm", new string[] { "Hammer" }},
        {"jave", new string[] { "Javelin" }},
        {"knif", new string[] { "Knife" }},
        {"mace", new string[] { "Mace" }},
        {"pole", new string[] { "Polearm" }},
        {"scep", new string[] { "Scepter" }},
        {"spea", new string[] { "Spear" }},
        {"staf", new string[] { "Staff" }},
        {"swor", new string[] { "Sword" }},
        {"taxe", new string[] { "Throwing Axe" }},
        {"tkni", new string[] { "Throwing Knife" }},
        {"wand", new string[] { "Wand" }},
        {"xbow", new string[] { "Crossbow" }},
        {"h2h", new string[] { "Katar [Assassin only]", "Assassin only" }},
        {"abow", new string[] { "Bow [Amazon only]", "Amazon only" }},
        {"ajav", new string[] { "Javelin [Amazon only]", "Amazon only" }},
        {"aspe", new string[] { "Spear [Amazon only]", "Amazon only" }},
        {"tpot", new string[] { "Throwing Potion", "tag" }},
        {"orb", new string[] { "Orb [Sorceress only]", "Sorceress only" }},
    };
}
