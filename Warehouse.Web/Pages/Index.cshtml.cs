using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pckt.Shared;

namespace Warehouse.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private WarehouseContext db;
    public List<Item> items;
    public IndexModel(ILogger<IndexModel> logger, WarehouseContext injectContext)
    {
        _logger = logger;
        db = injectContext;
    }

    public void OnGet()
    {
        items = db.Items.ToList();
    }
}

