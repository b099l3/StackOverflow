using System;

using UIKit;

namespace CustomActivitySpinner
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var images = new UIImage[40];
            for (int i = 0; i < 40; i++)
            {
                images[i] = UIImage.FromBundle($"Frame{i}");
            }
            ImageView.Image = images[0];
            ImageView.AnimationImages = images;
            ImageView.AnimationDuration = 2;
        }


        partial void StartPressed(Foundation.NSObject sender)
        {
            ImageView.StartAnimating();
        }

        partial void StoppedPressed(Foundation.NSObject sender)
        {
            ImageView.StopAnimating();
        }
    }
}
