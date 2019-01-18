using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EasyStrategy.App
{
    public partial class App : Application
    {
        public static double ScreenHeight { get; private set; }
        public static double ScreenWidth { get; private set; }

        public static App Instance { get; private set; }

        public App(double statusBarHeigh = 0)
        {
            InitializeComponent();

            App.Instance = this;

            ScreenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
            ScreenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;

            ScreenHeight = ScreenHeight - (statusBarHeigh / DeviceDisplay.MainDisplayInfo.Density);

            this.Resources.Add("ScreenHeight", ScreenHeight);
            this.Resources.Add("ScreenHeight0_2", ScreenHeight / 2);
            this.Resources.Add("ScreenHeight0_3", ScreenHeight / 3);
            this.Resources.Add("ScreenHeight0_4", ScreenHeight / 4);
            this.Resources.Add("ScreenHeight0_10", ScreenHeight / 10);
            this.Resources.Add("ScreenWidth", ScreenWidth);
            this.Resources.Add("ScreenWidth0_2", ScreenWidth / 2);
            this.Resources.Add("ScreenWidth0_3", ScreenWidth / 3);
            this.Resources.Add("ScreenWidth0_4", ScreenWidth / 4);
            this.Resources.Add("ScreenWidth0_10", ScreenWidth / 10);

            MainPage = new MainPage();
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
