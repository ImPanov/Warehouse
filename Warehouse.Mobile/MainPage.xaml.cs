using System.Net.Http.Json;
using System.Text.Json;

namespace Warehouse.Mobile
{
    public partial class MainPage : ContentPage
    {
        List<Item> items;
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async Task<List<Item>> GetItemsAsync()
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7189/api/Items");
            HttpResponseMessage response = _client.GetAsync("/api/Items").Result;
                string content = await response.Content.ReadAsStringAsync();
                items = JsonSerializer.Deserialize<List<Item>>(content);
            return items;
        }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            int countItem = int.Parse(countItems.Text);
            string nameItem = selectItem.SelectedItem.ToString();
            Item selectedItem = items.Where(c => c.name==nameItem).Select(c=>c).Single();
            price.Text=(selectedItem.cost * 1.2 * countItem).ToString();
        }

        private void loadItem_Clicked(object sender, EventArgs e)
        {
            List<string> @strings = new List<string>();

            items = GetItemsAsync().Result;
            foreach (var item in items)
            {
                @strings.Add(item.name.ToString());
            }
            selectItem.ItemsSource = @strings;
            selectItem.SelectedItem = selectItem.Items[0];
        }
    }
    record Item (long id, string name, long count, double cost, string type);
}