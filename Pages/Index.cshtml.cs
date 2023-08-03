using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using D2R_Items.Services;

namespace D2R_Items.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonHelper JsonHelper;

        public IndexModel(ILogger<IndexModel> logger, JsonHelper jsonHelper)
        {
            _logger = logger;
            JsonHelper = jsonHelper;
        }

        public void OnGet()
        {
            JsonHelper.StripUnusedProperties();
        }
    }
}