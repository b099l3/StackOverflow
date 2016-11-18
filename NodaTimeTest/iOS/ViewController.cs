using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using NodaTime;
using System.Linq;
using System.Globalization;

namespace NodaTimeTest.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var items = NodaTimeHelper.GetDateTimeZones();
			Picker.Model = new PickerViewModel<DateTimeZone>(items)
			{
				ItemPicked = (UIPickerView pickerView, nint row, nint component) =>
				{
					var selectedDTZ = items[(int)pickerView.SelectedRowInComponent(0)];
					var dtzTableSource = Table.Source as DateTimeZoneTableSource<List<LocalDateTime>>;
					if (dtzTableSource != null)
					{
						dtzTableSource.TableItems = GetStartEndDatesForTimeZone(selectedDTZ);
					}            
					Table.ReloadData();
				}
			};

			Picker.Select(444, 0, true); //select london
			Table.Source = new DateTimeZoneTableSource<List<LocalDateTime>>(GetStartEndDatesForTimeZone(items[444])); //london
			Table.RegisterNibForCellReuse(UINib.FromName(TableViewCell.Key, NSBundle.MainBundle), TableViewCell.Key);
		}

		private List<List<LocalDateTime>> GetStartEndDatesForTimeZone(DateTimeZone dtz)
		{
			var ListOfStartEndDatesForTZ = new List<List<LocalDateTime>>();
			for (int i = 0; i < 100; i++)
			{
				ListOfStartEndDatesForTZ.Add(NodaTimeHelper.GetDaylightSavingTransitions(dtz, DateTime.UtcNow.Year + i).ToList());
			}
			return ListOfStartEndDatesForTZ;
		}
	}


	public class PickerViewModel<T> : UIPickerViewModel
	{
		List<T> Items;
		public Action<UIPickerView, nint , nint> ItemPicked;

		public PickerViewModel(List<T> items)
		{
			Items = items;
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return Items.Count;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			var dtz = Items[(int)row] as DateTimeZone;
			var title = string.Empty;
			if (dtz != null)
			{
				title = dtz.Id;
			}
			return title;
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			if (ItemPicked != null)
			{
				ItemPicked.Invoke(pickerView, row, component);
			}
		}
	}


	public class DateTimeZoneTableSource<T> : UITableViewSource
	{
		public List<T> TableItems;
		public DateTimeZoneTableSource(List<T> tableItems)
		{
			TableItems = tableItems;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 88f;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(TableViewCell.Key, indexPath) as TableViewCell;
			var rowData = TableItems[indexPath.Row] as List<LocalDateTime>;
			if (rowData != null)
			{
				cell.ContentView.BackgroundColor = indexPath.Row % 2 == 0 ? UIColor.LightGray : UIColor.DarkGray;
				cell.StartDateLabel.Text = rowData.Count > 0 ? rowData[0].ToString("MM dd yyyy \tHH:mm:ss", CultureInfo.InvariantCulture) : "No Start date";
				cell.EndDateLabel.Text = rowData.Count > 1 ? rowData[1].ToString("MM dd yyyy \tHH:mm:ss", CultureInfo.InvariantCulture) : "No End date";
			}
			return cell;
		}
	}
}
