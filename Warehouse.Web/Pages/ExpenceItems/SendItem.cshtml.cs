using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared;
using Pckt.Shared;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.Pages.ExpenceItems
{
    [Authorize]
    public class SendModel : PageModel
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
            [StringLength(9, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Range(1, 30, ErrorMessage = "Please enter valid integer Count")]
            public string Count { get; set; }
            [Required]
            [Display(Name = "Recepient")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            public string Recepient { get; set; }
        }
        public long ItemId { get; set; }
        ExpenceItem ExpenceItem = new();
        private readonly IDataProtector _dataProtector;
        private readonly WarehouseContext db;
        public Item SelectedItem { get; set; }
        public SendModel(IDataProtectionProvider provider, WarehouseContext injectContext)
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ExpenceItem.Name = Input.Name;
                ExpenceItem.Cost = Double.Parse(Input.Cost);
                ExpenceItem.Count = long.Parse(Input.Count);
                ExpenceItem.Recepient = Input.Recepient;
            
                db.ExpenceItems.Add(ExpenceItem);
                db.SaveChanges();
            }
            return Redirect("/index");
        }

    }
}
