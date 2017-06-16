using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace ClarkNDBC
{
	public class TableSource : UITableViewSource
    {
        //List<string> TableItems;
        //string CellIdentifier = "TableCell";
        //Dictionary<string, List<string>> sortedTableItems;
        List<string[]> TableItems;
        //string[] keys;

        WeatherViewController weatherView;

        public TableSource(/*List<string[]> items,*/ WeatherViewController aView, string locationKey)
		{
            weatherView = aView;
            //TableItems = _Utilities.Utilities.CreateTableElements(locationKey);

            //sortedTableItems = _Utilities.Utilities.CreateDictionaryFromDwml(locationKey);

            //keys = sortedTableItems.Keys.ToArray();
		}

        /*public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Length;
        }*/

		public override nint RowsInSection(UITableView tableview, nint section)
		{
            return TableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            var cell = new WeatherCell();
            var items = TableItems[indexPath.Row];

            cell.UpdateCell(items);

			//cell.TextLabel.Text = item;

			return cell;
		}

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //var selectedItem = sortedTableItems[keys[indexPath.Section]][indexPath.Row];
            var selectedCell = (WeatherCell)tableView.CellAt(indexPath);
            // TODO Change the view to show aditional things


            tableView.DeselectRow(indexPath, true);
        }

        /*public override string TitleForHeader(UITableView tableView, nint section)
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
        }*/
	}
}
