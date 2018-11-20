using SkiaSharp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GameOfLie
{
    public partial class App : Application
    {
        public static SKPaint DeadPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };
        public static SKPaint AlivePaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.WhiteSmoke
        };

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(License.Key);
            InitializeComponent();
            if(Device.RuntimePlatform == Device.Android ||
                Device.RuntimePlatform == Device.iOS)
            {
                MainPage = new StartupRoom();
            }
            else
            {
                MainPage = new GameRoom();
            }
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
