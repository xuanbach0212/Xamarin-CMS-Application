using final_project.Model;
using final_project.Views.ProfileView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        string url = "http://192.168.1.2:5000/v1/api/admin/user/email";
        HttpClient httpClient = new HttpClient();
        public ProfilePage()
        {
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            InitializeComponent();
            var user_email = ((App)App.Current).email;
            var phone = ((App)App.Current).phone;
            var name = ((App)App.Current).name;
            if (name != null)
            {
                lbl_phone.Text = ((App)App.Current).phone;
                lbl_email.Text = ((App)App.Current).email;
                lbl_username.Text = ((App)App.Current).name;
            }
            else
            {
                lbl_email.Text = user_email;
                get_user_by_email(user_email);
            }
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;

        }

        private async void get_user_by_email(string email)
        {
            var result = await httpClient.GetStringAsync(url + "/" + email);
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            var cur_user = JsonConvert.DeserializeObject<Cur_User_Model>(result).data;
            lbl_phone.Text = cur_user.phone;
            lbl_username.Text = cur_user.name;
            ((App)App.Current).phone = cur_user.phone;
            ((App)App.Current).name = cur_user.name;

            //for (User_Datum cu in cur_user.data)
            //{
            //    lbl_username.Text = cu.name;
            //    lbl_email.Text = cu.email;
            //    lbl_phone.Text = cu.phone;
            //}
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Alert!", "Are you sure you want to log out!", "Yes", "No");
            if (answer)
            {
                ((App)App.Current).loading_after_logout();
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditProfilePage());
        }
    }
}