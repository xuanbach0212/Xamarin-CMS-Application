using final_project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_project.Views.OrderView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOrder1Page : ContentPage
    {
        string url = "http://192.168.1.2:5000/v1/api/admin/order";
        HttpClient httpClient = new HttpClient();
        public ListOrder1Page()
        {
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent();
            get_order();
        }
        private async void get_order()
        {
            var result = await httpClient.GetStringAsync(url);
            var product = JsonConvert.DeserializeObject<Order_Model>(result);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;

            foreach (Datum_Order cd in product.data)
            {
                cd.date = cd.date.Substring(0, 16);
            }
            lst_order.ItemsSource = product.data;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var cur_order = grid.BindingContext as Datum_Order;
            var id = cur_order.id;

            Navigation.PushAsync(new OrderDetailPage(id));
        }

        private async void Refresh_view_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            get_order();
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            Refresh_view.IsRefreshing = false;
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var cur_order = grid.BindingContext as Datum_Order;
            bool answer = await DisplayAlert("Alert!", "Are you sure want to Delete this item ?", "Ok", "Cancel");
            if (answer)
            {
                await httpClient.DeleteAsync(url + "/" + cur_order.id.ToString());
                get_order();
            }
        }
    }
}