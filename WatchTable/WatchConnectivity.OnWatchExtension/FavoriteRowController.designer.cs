// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WatchConnectivity.OnWatchExtension
{
	[Register ("FavoriteRowController")]
	partial class FavoriteRowController
	{
		[Outlet]
		public WatchKit.WKInterfaceLabel RowLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RowLabel != null) {
				RowLabel.Dispose ();
				RowLabel = null;
			}
		}
	}
}
