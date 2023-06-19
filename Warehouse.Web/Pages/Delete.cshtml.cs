using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared;
using Pckt.Shared;

namespace Warehouse.Web.Pages
{
    public class DeleteModel : PageModel
    {

        private readonly WarehouseContext db;
        private IDataProtector _dataProtector;
        public DeleteModel(IDataProtectionProvider provider, WarehouseContext injectContext)
        {
            _dataProtector = provider.CreateProtector("Warehouse");
            db = injectContext;
        }
        long ItemId;
        public void OnGet(string itemId)
        {
            ItemId = long.Parse(_dataProtector.Unprotect(itemId));
            db.Items.Remove(db.Items.Find(ItemId));
            db.SaveChanges();
        }
        public void OnPost()
        {
        }
    }
}
