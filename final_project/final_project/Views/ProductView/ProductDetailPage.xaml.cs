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
	public partial class ProductDetailPage : ContentPage
	{
        string url = "http://192.168.1.2:5000/v1/api/admin/product";
        HttpClient httpClient = new HttpClient();
        public ProductDetailPage(string id)
		{
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent ();
            get_product_by_id(id);

        }

        private async void get_product_by_id(string id)
        {
            var result = await httpClient.GetStringAsync(url + "/" + id);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            var cur_product = JsonConvert.DeserializeObject<Cur_Product_Model>(result).data;
            img.Source = "http://192.168.1.2:5000" + cur_product.img;
            lbl_name.Text = "Name: " + cur_product.name;
            lbl_price.Text ="$ " + cur_product.price.ToString();
            lbl_brand.Text = "Brand: " +  cur_product.brand;
            lbl_category.Text ="Category: " +  cur_product.category.name;
            lbl_des.Text = cur_product.describe;
            lbl_date.Text ="Date: " + cur_product.date.Substring(0, 16);
            lbl_stock.Text ="Stock: "+cur_product.stock.ToString();

            //for (User_Datum cu in cur_user.data)
            //{
            //    lbl_username.Text = cu.name;
            //    lbl_email.Text = cu.email;
            //    lbl_phone.Text = cu.phone;
            //}
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
			Navigation.PopAsync();
        }
    }
}