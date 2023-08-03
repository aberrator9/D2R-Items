using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using D2R_Items.Services;

namespace D2R_Items.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonService JsonService;
        public DataAccessService DataAccess;

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonService jsonService,
            DataAccessService dataAccess)
        {
            _logger = logger;
            JsonService = jsonService;
            DataAccess = dataAccess;
        }

        public void OnGet()
        {
            JsonService.StripUnusedProperties();
            DataAccess.Query("SELECT * FROM weapons");
        }
    }
}