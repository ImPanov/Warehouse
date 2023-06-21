using System.Net.Http.Json;

namespace Warehouse.Mobile
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        List<Item> items;
        public MainPage()
        {
            InitializeComponent();
            HttpClient httpClient = new HttpClient();
            items = httpClient.GetFromJsonAsync<List<Item>>("https://localhost:7189/api/Items").Result;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
    record Item (long Id, string Name, long Count, double Cost, string Type);
}