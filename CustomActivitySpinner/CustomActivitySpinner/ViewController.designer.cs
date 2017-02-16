// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CustomActivitySpinner
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIImageView ImageView { get; set; }

		[Action ("StartPressed:")]
		partial void StartPressed (Foundation.NSObject sender);

		[Action ("StoppedPressed:")]
		partial void StoppedPressed (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}
		}
	}
}
