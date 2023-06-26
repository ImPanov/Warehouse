using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pckt.Shared;

namespace Warehouse.Web.Pages.ExpenceItems
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IDataProtector _dataProtector;
        private WarehouseContext db;
        public List<ProtectItem>? ProtectItems;
        public IndexModel(ILogger<IndexModel> logger, WarehouseContext injectContext, IDataProtectionProvider provider)
        {
            _logger = logger;
            _dataProtector = provider.CreateProtector("Warehouse");
            db = injectContext;
        }

        public void OnGet()
        {
            ProtectItems = db.ExpenceItems.Select(c => new ProtectItem
            {
                ProtectId = _dataProtector.Protect(c.Id.ToString()),
                Id = (int)c.Id,
                Cost = c.Cost,
                Count = c.Count,
                Name = c.Name,
                Recepient = c.Recepient,
                IsPay = c.IsPay,
                
            }).ToList();
        }
    }
    public record ProtectItem
    {
        public int Id { get; set; }
        public string ProtectId { get; set; }

        public string Name { get; set; } = null!;

        public long Count { get; set; }

        public double Cost { get; set; }

        public string? IsPay { get; set; }
        public string Recepient { get; set; } = null!;
    }
}