using final_project.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ListCategoryPage : ContentPage
    {

        string url = "http://192.168.1.2:5000/v1/api/admin/category";
        HttpClient httpClient = new HttpClient();


        private async void get_category()
        {

            var result = await httpClient.GetStringAsync(url);
            var category = JsonConvert.DeserializeObject<Category_Model>(result);
            await Task.Delay(3000);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            foreach (Category_Datum cd in category.data)
            {
                cd.date = cd.date.Substring(0, 16);
            }
            lstView_Category.ItemsSource = category.data;
        }


        public ListCategoryPage()
        {
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent();
            get_category();

        }
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var result = await httpClient.GetStringAsync(url);
        //    var category = JsonConvert.DeserializeObject<Category_Model>(result);
        //    foreach (Category_Datum cd in category.data)
        //    {
        //        cd.date = cd.date.Substring(0, 16);
        //    }
        //    lstView_Category.ItemsSource = category.data;
        //}

        private void lstView_Category_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            get_category();
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            Refresh_view.IsRefreshing = false;

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var cur_category = grid.BindingContext as Category_Datum;
            bool answer = await DisplayAlert("Alert!", "Are you sure want to Delete this item ?", "Ok", "Cancel");
            if (answer)
            {
                httpClient.DefaultRequestHeaders.Add("Connection", "close");
                httpClient.DefaultRequestHeaders.ConnectionClose = true;
                await httpClient.DeleteAsync(url + "/" + cur_category.id.ToString());
                get_category();
            }
        }
    }
}