using System.ComponentModel.DataAnnotations;

namespace D2RItems.Models;

public class Armor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tier { get; set; }
    public string Slot { get; set; }
    public int Sockets { get; set; }
    [Display(Name = "Max AC")]
    public int Class { get; set; }
    public int Weight { get; set; }
    [Display(Name = "Req Str")]
	public int ReqStr { get; set; }
}
