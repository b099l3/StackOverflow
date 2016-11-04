using System;
using Foundation;
using UIKit;

namespace ExpandableTableView
{
	public partial class HeaderCell : UITableViewHeaderFooterView
	{
		public static readonly NSString Key = new NSString("HeaderCell");
		public static readonly UINib Nib;

		static HeaderCell()
		{
			Nib = UINib.FromName("HeaderCell", NSBundle.MainBundle);
		}

		protected HeaderCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
