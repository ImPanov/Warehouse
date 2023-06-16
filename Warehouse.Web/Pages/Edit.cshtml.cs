using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pckt.Shared;

namespace Warehouse.Web.Pages
{
   
    public class EditModel : PageModel
    { 
        public Item SelectedItem { get; set; }
        private readonly WarehouseContext db;
        private IDataProtector _dataProtector;
        public EditModel(IDataProtectionProvider provider, WarehouseContext injectContext)
        {
            _dataProtector = provider.CreateProtector("Warehouse");
            db = injectContext;
        }
        public IActionResult OnGet(string itemId)
        {
            long ItemId = long.Parse(_dataProtector.Unprotect(itemId));
            SelectedItem = db.Items.Find(ItemId);
            
            return Page();
        }
    }
}
