// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace NodaTimeTest.iOS
{
	[Register ("TableViewCell")]
	partial class TableViewCell
	{
		[Outlet]
		public UIKit.UILabel EndDateLabel { get; set; }

		[Outlet]
		public UIKit.UILabel StartDateLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StartDateLabel != null) {
				StartDateLabel.Dispose ();
				StartDateLabel = null;
			}

			if (EndDateLabel != null) {
				EndDateLabel.Dispose ();
				EndDateLabel = null;
			}
		}
	}
}
