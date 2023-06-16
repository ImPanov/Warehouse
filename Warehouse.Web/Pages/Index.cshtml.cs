using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pckt.Shared;

namespace Warehouse.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public IDataProtector _dataProtector;
    private WarehouseContext db;
    public List<ProtectItem>? ProtItems;
    public IndexModel(ILogger<IndexModel> logger, WarehouseContext injectContext, IDataProtectionProvider provider)
    {
        _logger = logger;
        _dataProtector = provider.CreateProtector("Warehouse");
        db = injectContext;
    }

    public void OnGet()
    {
        ProtItems = db.Items.Select(c => new ProtectItem {
            ProtectId = _dataProtector.Protect(c.Id.ToString()),
            Id = (int)c.Id,
            Cost = c.Cost,
            Count = c.Count,
            Name = c.Name,
            Type = c.Type
        }).ToList();
    }
}
public record ProtectItem
{
    public int Id { get; set; }
    public string ProtectId { get; set; }

    public string Name { get; set; } = null!;

    public long Count { get; set; }

    public long Cost { get; set; }

    public string Type { get; set; } = null!;
}

