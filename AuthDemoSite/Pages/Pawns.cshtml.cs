using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthDemoSite.Pages
{
    [Authorize(Policy = "RequirePawnRole")]
    public class PawnsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
