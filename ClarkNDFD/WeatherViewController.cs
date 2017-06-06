using System;
using MapKit;
using UIKit;
using System.Collections.Generic;

namespace ClarkNDFD
{
    public partial class WeatherViewController : UIViewController
    {
        UITableView table;
        public string locationKey;

        public WeatherViewController(IntPtr handle) : base(handle)
        {
        }

        public override void LoadView()
        {
			base.LoadView();
			// Perform any additional setup after loading the view, typically from a nib.
			
			table = new UITableView(UIScreen.MainScreen.Bounds); // defaults to Plain style
            //List<string> tableItems = new List<string>() { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            table.Source = new TableSource(/*tableItems, */this, locationKey);
            Add(table);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

