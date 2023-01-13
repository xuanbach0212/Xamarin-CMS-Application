using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using final_project.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Android.Service.Voice.VoiceInteractionSession;

namespace final_project.Droid
{
    [Activity(Label = "SplashScreen", MainLauncher =true,Theme = "@style/ThemeSplash", NoHistory = true, Icon = "@drawable/electrician_cat_logo")]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            Thread.Sleep(4000);
            //Start Activity1 Activity  
            ((App)App.Current).loading_after_logout();
        }
    }
}