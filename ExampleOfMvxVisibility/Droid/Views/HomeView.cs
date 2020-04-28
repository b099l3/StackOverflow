using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace ExampleOfMvxVisibility.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "View for HomeViewModel",
              Theme = "@style/MainTheme")]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
        }
    }
}
