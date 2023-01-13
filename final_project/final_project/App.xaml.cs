using final_project.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_project
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
            //loading();
        }

        public async void loading()
        {
            await Task.Delay(5000);
            MainPage = new LoginPage();
        }

        public async void loading_after_logout()
        {
            MainPage = new LoadingPage();
            await Task.Delay(5000);
            MainPage = new LoginPage();
        }

        public string email { get; set; }
        public string phone { get; set; }
        public string name { get; set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
