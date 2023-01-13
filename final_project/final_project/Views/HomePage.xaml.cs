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

namespace final_project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        string url = "http://192.168.1.2:5000/v1/api/admin/home";
        HttpClient httpClient = new HttpClient();
        public HomePage()
        {
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent();
            get_home_items();
        }

        private async void get_home_items()
        {

            var result = await httpClient.GetStringAsync(url);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            var home = JsonConvert.DeserializeObject<HomeModel>(result).data;

            lbl_category.Text = "Category Available: " + home.category_count.ToString();
            lbl_user.Text ="Total Member: " + home.user_count.ToString();
            lbl_product.Text = "Product Available: " + home.product_count.ToString();
            lbl_order.Text = "All Current Order: " + home.order_count.ToString();   
        }

    }
}