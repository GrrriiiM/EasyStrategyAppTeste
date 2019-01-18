using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace EasyStrategy.App.Droid
{
    [Activity(Label = "EasyStrategy.App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();

            float statusBarHeigh = 0;
            var resID = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resID > 0)
            {
                statusBarHeigh = (float)Resources.GetDimensionPixelSize(resID);
            }

            var app = new App(statusBarHeigh: statusBarHeigh);

            LoadApplication(app);
        }
    }
}