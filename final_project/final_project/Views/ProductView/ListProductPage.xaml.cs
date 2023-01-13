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
using static System.Net.WebRequestMethods;

namespace final_project.Views.ProductView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListProductPage : ContentPage
    {
        string url = "http://192.168.1.2:5000/v1/api/admin/product";
        HttpClient httpClient = new HttpClient();
        string prefix = "http://192.168.1.2:5000";
        public ListProductPage()
        {
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent();
            get_product();
        }

        private async void get_product()
        {
            await Task.Delay(2000);
            var result = await httpClient.GetStringAsync(url);
            var product = JsonConvert.DeserializeObject<Product_Model>(result);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            foreach (Product_Datum cd in product.data)
            {
                cd.img = "http://192.168.1.2:5000" + cd.img.Substring(25);
                cd.date = cd.date.Substring(0, 16);
                if (cd.status == "active")
                {
                    cd.status = "#4caf50";
                }
                else
                {
                    cd.status = "#f44336";
                }
            }
            lstView_Product.ItemsSource = product.data;

        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var cur_product = grid.BindingContext as Product_Datum;
            var id = cur_product.id;
            Navigation.PushAsync(new ProductDetailPage(id));
        }

        async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var cur_product = grid.BindingContext as Product_Datum;
            bool answer = await DisplayAlert("Alert!", "Are you sure want to Delete this item ?", "Ok", "Cancel");
            if (answer)
            {
                await httpClient.DeleteAsync(url + "/" + cur_product.id.ToString());
                get_product();
            }
        }

        private async void Refresh_view_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            get_product();
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            Refresh_view.IsRefreshing = false;
        }
    }
}