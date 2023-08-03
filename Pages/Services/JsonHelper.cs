using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace D2R_Items.Services;

public class JsonHelper
{
    private readonly string[] Strings = { "weapons", "armor", "rune", "sets", "uniqueitems" };

    public void StripUnusedProperties()
    {
        // TODO
    }
}