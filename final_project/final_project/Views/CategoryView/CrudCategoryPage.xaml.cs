using final_project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_project.Views.NewFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrudCategoryPage : ContentPage
    {

        string url = "http://192.168.1.2:5000/v1/api/admin/category";
        HttpClient httpClient = new HttpClient();
        

        //private async void get_category()
        //{
        //    var result = await httpClient.GetStringAsync(url);
        //    var category = JsonConvert.DeserializeObject<Category_Model>(result);

        //}
        string new_color;
        string new_icon;

        public CrudCategoryPage()
        {
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent();
            Crud_Category_Icon.ItemsSource = Model.Icon.CreateIcon();
            Crud_Category_Color.ItemsSource = Model.ColorModel.CreateColor();
        }


        //public CrudCategoryPage(Category_Datum cur_category)
        //{
        //    InitializeComponent();
        //    Crud_Category_Icon.ItemsSource = Model.Icon.CreateIcon();
        //    Crud_Category_Color.ItemsSource = Model.ColorModel.CreateColor();
        //    if (cur_category != null)
        //    {
        //        ent_name.Text = cur_category.name;
        //        Crud_Category_Icon.SelectedItem = cur_category.icon;
        //        Crud_Category_Color.SelectedItem = cur_category.color;
        //    }
        //}

        private void Crud_Category_Icon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var iconList = Model.Icon.CreateIcon();
            var selectedIcon = Crud_Category_Icon.SelectedIndex;
            icon_category.Source = iconList[selectedIcon].icon;
            new_icon = iconList[selectedIcon].icon;
        }

        private void Crud_Category_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            var colorList = Model.ColorModel.CreateColor();
            var selectedColor = Crud_Category_Color.SelectedIndex;
            color_category.BackgroundColor = Color.FromHex(colorList[selectedColor].color);
            new_color = colorList[selectedColor].color;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var new_category = new Category_Datum { color = new_color, icon = new_icon, name = ent_name.Text };
            var json = JsonConvert.SerializeObject(new_category);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, data);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            var result = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Alert!", "Add Category Successfully!", "OK");
        }


    }
}   