using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared;
using Pckt.Shared;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.Pages.Items
{
    [Authorize]
    public class AddItemModel : PageModel
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
            [Display(Name = "Type")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            public string Type { get; set; }
        }
        private readonly WarehouseContext db;
        public AddItemModel(WarehouseContext injectContext)
        {
            db = injectContext;
        }
        public void OnGet()
        {
        }
        public async Task OnPostAsync()
        {
            ReceiptItem receiptItem = new();
            if (ModelState.IsValid)
            {
                receiptItem.Name = Input.Name;
                receiptItem.Cost = Double.Parse(Input.Cost);
                receiptItem.Count = long.Parse(Input.Count);
                receiptItem.Type = Input.Type;
            
            db.ReceiptItems.Add(receiptItem);
            db.SaveChanges();
            }
        }

    }
}
