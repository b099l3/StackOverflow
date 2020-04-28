using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ExampleOfMvxVisibility.Droid
{
    [Activity(
        Label = "BottlingCalculator",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenAppCompatActivity<MvxAppCompatSetup<App>, App>
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}