using final_project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_project.Views.ProductView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrudProductPage : ContentPage
    {

        string url_category = "http://192.168.1.2:5000/v1/api/admin/category";
        string url_product = "http://192.168.1.2:5000/v1/api/admin/product";
        string url_image = "http://192.168.1.2:5000/v1/api/images";
        HttpClient httpClient = new HttpClient();
        Category_Product category_name = new Category_Product();
        public CrudProductPage()
        {
            InitializeComponent();
            resultImage.Source = "image_here_icon";
            get_category();
        }
        string image_name;
        private async void get_category()
        {
            await Task.Delay(1000);
            var result = await httpClient.GetStringAsync(url_category);
            var category = JsonConvert.DeserializeObject<Category_Model>(result);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            Crud_Category.ItemsSource = category.data;
            
        }

        async void Button_Clicked(object sender, EventArgs e)
        {

            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            }); 

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);

                image_name = result.FileName;
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent( await result.OpenReadAsync()),"file", result.FileName);
                var respone = await httpClient.PostAsync(url_image, content);
            }

        }
        private void Crud_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem as Category_Datum;
            var name = selectedItem.name;
            category_name.name = selectedItem.name;

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var new_product = new Product_Datum { category = category_name, 
                name = ent_name.Text, 
                stock = int.Parse(ent_stock.Text), 
                price = int.Parse(ent_price.Text), 
                brand = ent_brand.Text, 
                status = ent_status.Text, 
                describe = ent_des.Text, 
                img = "/static/uploads/" + image_name};
            var json = JsonConvert.SerializeObject(new_product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url_product, data);
            var result = await response.Content.ReadAsStringAsync();

            
            await DisplayAlert("Alert!", "Add Product Successfully!", "OK");
        }

    }

        //async void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    Category_Product category = new new_category;
        //    var new_product = new Product_Datum { category = , name = ent_name.Text, stock = int.Parse(ent_stock.Text), price = int.Parse(ent_price.Text), brand = ent_brand.Text, status = ent_status.Text, describe = ent_des.Text, img = resultImage.Source.ToString() };
        //}

    
}