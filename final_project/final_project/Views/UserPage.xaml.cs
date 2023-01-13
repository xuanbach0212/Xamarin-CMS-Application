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
	public partial class UserPage : ContentPage
    {
        string url = "http://192.168.1.2:5000/v1/api/admin/user";
        HttpClient httpClient = new HttpClient();
        public UserPage ()
		{
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent ();
            get_user();

        }

        private async void get_user()
        {
            var result = await httpClient.GetStringAsync(url);
            var user = JsonConvert.DeserializeObject<User_Model>(result);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            lst_user.ItemsSource = user.data.GetRange(0,3);
            lst_staff.ItemsSource = user.data.GetRange(2, 3);
            lst_admin.ItemsSource = user.data.GetRange(4, 2);
        }

        //private async void Refresh_view_Refreshing(object sender, EventArgs e)
        //{
        //    await Task.Delay(3000);
        //    Refresh_view.IsRefreshing = false;
        //}
    }
}