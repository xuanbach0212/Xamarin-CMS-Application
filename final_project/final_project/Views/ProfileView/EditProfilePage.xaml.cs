using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_project.Views.ProfileView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
            lbl_phone.Text = ((App)App.Current).phone;
            lbl_username.Text = ((App)App.Current).name;
            lbl_email.Text = ((App)App.Current).email;
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            ((App)App.Current).phone = lbl_phone.Text;
            ((App)App.Current).name = lbl_username.Text;
            ((App)App.Current).email = lbl_email.Text;
            DisplayAlert("Alert!", "Update profile information successfully!", "Ok");
        }
    }
}