using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Warehouse.Web.Pages
{
    public class EditModel : PageModel
    {
        public IActionResult OnGet(int itemId)
        {
            return Page();
        }
    }
}
