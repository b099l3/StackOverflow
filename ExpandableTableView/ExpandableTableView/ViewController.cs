using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CoreGraphics;

namespace ExpandableTableView
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

			var DataDic = new Dictionary<string, List<string>>
			{
				{ "Faces", new List<string> { "\ud83d\ude01","\ud83d\ude02","\ud83d\ude03","\ud83d\ude21","\ud83d\ude2d","\ud83d\ude3a","\ud83d\ude4e","\ud83d\ude0d","\ud83d\ude24"} },
				{ "Animals", new List<string> { "\ud83d\udc2f", "\ud83d\udc30", "\ud83d\udc2e", "\ud83d\udc37", "\ud83d\udc38", "\ud83d\udc28", "\ud83d\udc27", "\ud83d\udc19", "\ud83d\udc1d", "\ud83d\udc20" } },
				{ "Weapons", new List<string> { "\ud83d\udd28","\ud83d\udd2a","\ud83d\udd2b","\ud83d\udd27","\ud83d\udd29","\ud83d\udd25" } },
				{ "Food", new List<string> { "\ud83c\udf53","\ud83c\udf52","\ud83c\udf4f","\ud83c\udf4e","\ud83c\udf4c","\ud83c\udf4d","\ud83c\udf47","\ud83c\udf51", } },
				{ "Weather", new List<string> { "\ud83c\udf24","⛅","\ud83c\udf25","\ud83c\udf26","☁️","\ud83c\udf27","⛈","\ud83c\udf29","\ud83c\udf28","❄️" } }
			};

			//create the data
			var list = new List<ExpandableTableModel<string>>();
			foreach (var section in DataDic)
			{
				var sectionData = new ExpandableTableModel<string>()
				{
					Title = section.Key
				};
				foreach (var row in section.Value)
				{
					sectionData.Add(row);
				}

				list.Add(sectionData);
			}

			Table.Source = new ExpandableTableSource<string>(list, Table);
		}
	}

	public class ExpandableTableSource<T> : UITableViewSource
	{
		List<ExpandableTableModel<T>> TableItems;
		private bool[] _isSectionOpen;
		private EventHandler _headerButtonCommand;

		public ExpandableTableSource(List<ExpandableTableModel<T>> items, UITableView tableView)
		{
			TableItems = items;
			_isSectionOpen = new bool[items.Count];

			tableView.RegisterNibForCellReuse(UINib.FromName(TableViewCell.Key, NSBundle.MainBundle), TableViewCell.Key);
			tableView.RegisterNibForHeaderFooterViewReuse(UINib.FromName(HeaderCell.Key, NSBundle.MainBundle), HeaderCell.Key);

			_headerButtonCommand = (sender, e) =>
			{
				var button = sender as UIButton;
				var section = button.Tag;
				_isSectionOpen[(int)section] = !_isSectionOpen[(int)section];
				tableView.ReloadData();

				// Animate the section cells
				var paths = new NSIndexPath[RowsInSection(tableView, section)];
				for (int i = 0; i < paths.Length; i++)
				{
					paths[i] = NSIndexPath.FromItemSection(i, section);
				}

				tableView.ReloadRows(paths, UITableViewRowAnimation.Automatic);
			};
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return TableItems.Count;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _isSectionOpen[(int)section] ? TableItems[(int)section].Count : 0;
		}

		public override nfloat GetHeightForHeader(UITableView tableView, nint section)
		{
			return 44f;
		}

		public override nfloat EstimatedHeightForHeader(UITableView tableView, nint section)
		{
			return 44f;
		}

		public override UIView GetViewForHeader(UITableView tableView, nint section)
		{
			HeaderCell header = tableView.DequeueReusableHeaderFooterView(HeaderCell.Key) as HeaderCell;
			header.label.Text = ((ExpandableTableModel<T>)TableItems[(int)section]).Title;
			foreach (var view in header.Subviews)
			{
				if (view is HiddenHeaderButton)
				{
					view.RemoveFromSuperview();
				}
			}
			var hiddenButton = CreateHiddenHeaderButton(header.Bounds, section);
			header.AddSubview(hiddenButton);
			return header;
		}

		private HiddenHeaderButton CreateHiddenHeaderButton(CGRect frame, nint tag)
		{
			var button = new HiddenHeaderButton(frame);
			button.Tag = tag;
			button.TouchUpInside += _headerButtonCommand;
			return button;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(TableViewCell.Key, indexPath) as TableViewCell;
			if (typeof(T) == typeof(string))
			{
				var rowData = TableItems[indexPath.Section][indexPath.Row] as string;
				if (rowData != null)
				{
					cell.label.Text = rowData;
				}
			}
			return cell;
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.CellAt(indexPath) as TableViewCell;
		}
	}

	public class HiddenHeaderButton : UIButton
	{
		public HiddenHeaderButton(CGRect frame) : base(frame)
		{

		}
	}

	public class ExpandableTableModel<T> : List<T>
	{
		public string Title { get; set; }
		public ExpandableTableModel(IEnumerable<T> collection) : base(collection) { }
		public ExpandableTableModel() : base() { }
	}
}
