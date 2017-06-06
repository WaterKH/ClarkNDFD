using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace ClarkNDFD
{
	public class TableSource : UITableViewSource
    {
        List<string> TableItems;
		//string CellIdentifier = "TableCell";
        Dictionary<string, List<string>> sortedTableItems;
        string[] keys;

        WeatherViewController weatherView;

        public TableSource(/*List<string> items,*/ WeatherViewController aView, string locationKey)
		{
			//TableItems = items;
            weatherView = aView;

            sortedTableItems = Globals.CreateDictionaryFromDwml(locationKey);

            keys = sortedTableItems.Keys.ToArray();
		}

        public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Length;
        }

		public override nint RowsInSection(UITableView tableview, nint section)
		{
            return sortedTableItems[keys[section]].Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            //UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            string item = sortedTableItems[keys[indexPath.Section]][indexPath.Row];//TableItems[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			//if (cell == null)
			//{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = item;

			return cell;
		}

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selectedItem = TableItems[indexPath.Row];

            // TODO Change the view to show everything
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return keys[section];
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var view = new UIView(new CoreGraphics.CGRect(0, 0, tableView.Bounds.Width, 44f));
            var label = new UILabel()
            {
                //Font = ,
                Frame = new CoreGraphics.CGRect(10, 0, tableView.Bounds.Width, 44f),
                Text = keys[section],
                BackgroundColor = UIColor.White,
            };

            view.Add(label);

            return view;
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 44f;
        }
	}
}
