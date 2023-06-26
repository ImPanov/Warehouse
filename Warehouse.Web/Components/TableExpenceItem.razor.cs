using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection;
using Pckt.Shared;
using System.Text.Json;

namespace Warehouse.Web.Components
{
    
    public partial class TableExpenceItem : ComponentBase
    {
        public ProtectItem[]? expenceItems { get; set; }
        [Inject]
        HttpClient _httpClient { get; set; }
        IDataProtector _dataProtect { get; set; }
        
        public TableExpenceItem()
        {
        }

        protected override void OnInitialized()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            _dataProtect =provider.CreateProtector("Warehouse");
            HttpResponseMessage response = _httpClient.GetAsync("/api/expenceitems").Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            expenceItems = response.Content.ReadFromJsonAsync<ExpenceItem[]>().Result.Select(c => new ProtectItem
            {
                ProtectId = _dataProtect.Protect(c.Id.ToString()),
                Id = (int)c.Id,
                Cost = c.Cost,
                Count = c.Count,
                Name = c.Name,
                Recepient = c.Recepient,
                IsPay = ( (c.IsPay ?? "No") == "No" ? false : true ),

            }).ToArray();
        }
        
            
    }
    public record ProtectItem
    {
        public int Id;
        public string ProtectId;
        public string Name;
        public long Count;
        public double Cost;
        public bool IsPay;
        public string Recepient;
    }
}
