using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpStorage.WebClient.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("/file-storage");
        }
    }
}
