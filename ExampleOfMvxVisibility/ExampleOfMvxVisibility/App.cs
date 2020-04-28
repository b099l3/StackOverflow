using MvvmCross.ViewModels;
using ExampleOfMvxVisibility.ViewModels;

namespace ExampleOfMvxVisibility
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<HomeViewModel>();
        }
    }
}

