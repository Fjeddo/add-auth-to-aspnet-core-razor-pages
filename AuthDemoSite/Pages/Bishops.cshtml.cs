using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthDemoSite.Pages
{
    [Authorize(Policy = "RequireBishopRole")]
    public class BishopsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
