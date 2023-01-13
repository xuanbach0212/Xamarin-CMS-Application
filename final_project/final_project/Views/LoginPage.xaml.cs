using final_project.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class LoginPage : ContentPage
    {
        string url = "http://192.168.1.2:5000/v1/api/app-user/auth";
        HttpClient httpClient = new HttpClient();

        public LoginPage()
        {
            InitializeComponent();
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var cur_user = new Auth { email = txt_email.Text , password = txt_password.Text  };
            var json = JsonConvert.SerializeObject(cur_user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();
            httpClient.DefaultRequestHeaders.Add("Connection", "close");
            httpClient.DefaultRequestHeaders.ConnectionClose = true;
            await Task.Delay(1000);
            var status = JsonConvert.DeserializeObject<Auth_Model>(result).status;
            
            if (status == 200)
            {
                ((App)App.Current).email = txt_email.Text;
                await DisplayAlert("Alert!", "Welcome to CatMS!", "Ok");
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                httpClient.DefaultRequestHeaders.Add("Connection", "close");
                httpClient.DefaultRequestHeaders.ConnectionClose = true;
                await DisplayAlert("Alert!", "User not register or wrong password", "Ok");
            }


        }


    }
}