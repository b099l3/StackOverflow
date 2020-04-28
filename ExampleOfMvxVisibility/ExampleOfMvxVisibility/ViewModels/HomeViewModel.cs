using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace ExampleOfMvxVisibility.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private bool _showThing;
        public bool ShowThing
        {
            get => _showThing;
            set => SetProperty(ref _showThing, value);
        }

        public IMvxCommand ToggleVisibilityCommand { get; }

        public HomeViewModel()
        {
            ToggleVisibilityCommand = new MvxCommand(ToggleVisibility);
        }

        public void ToggleVisibility()
        {
            ShowThing = !ShowThing;
        }
    }
}
