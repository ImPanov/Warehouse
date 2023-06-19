using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Pckt.Shared;

namespace Warehouse.Web.Pages
{

    public class EditModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            public string Name { get; set; }
            [Required]
            [Display(Name = "Cost")]
            [StringLength(3, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Range(1, 500000, ErrorMessage = "Please enter valid Cost")]
            public string Cost { get; set; }
            [Required]
            [Display(Name = "Count")]
            [StringLength(9, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Range(1, 30, ErrorMessage = "Please enter valid integer Count")]
            public string Count { get; set; }
            [Required]
            [Display(Name = "Type")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            public string Type { get; set; }
        }
        public Item? SelectedItem { get; set; }
        private readonly WarehouseContext db;
        private IDataProtector _dataProtector;
        public long ItemId { get; set; }
        public EditModel(IDataProtectionProvider provider, WarehouseContext injectContext)
        {
            _dataProtector = provider.CreateProtector("Warehouse");
            db = injectContext;
        }
        public IActionResult OnGet(string itemId)
        {
            ItemId = long.Parse(_dataProtector.Unprotect(itemId));
            SelectedItem = db.Items.Find(ItemId);
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
