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
}
