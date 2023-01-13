using final_project.Components.FlyoutMenu;
using final_project.Model;
using final_project.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace final_project
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            flyout.listview.ItemSelected += OnSelectedItem;
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if (item != null) {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                flyout.listview.SelectedItem = null;
                IsPresented= false;
            }
        }
    }
}
