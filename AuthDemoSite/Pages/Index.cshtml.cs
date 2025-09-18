using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthDemoSite.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
    }

    public SignOutResult OnGetLogout()
    {
        return SignOut(new AuthenticationProperties {RedirectUri = "/"});
    }
}
