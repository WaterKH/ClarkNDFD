using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CoreLocation;
using MapKit;
using UIKit;
using ClarkNDFD._Utilities;

namespace ClarkNDFD
{
	public partial class ViewController : UIViewController
	{
        public static string currImage;
        MKMapView map;
        MyMapDelegate mapDel;

		protected ViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

        public override void LoadView()
        {
			map = new MKMapView(UIScreen.MainScreen.Bounds);
			map.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			mapDel = new MyMapDelegate(this);
			map.Delegate = mapDel;

			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();
			// TODO Create an override for this DidUpdateUserLocation
			/*map.DidUpdateUserLocation += (sender, e) =>
            {
                
            };*/

            CLLocationCoordinate2D coords = locationManager.Location.Coordinate;//map.UserLocation.Coordinate;
			MKCoordinateSpan span = new MKCoordinateSpan(Utilities.MilesToLatitudeDegrees(2), 
                                                         Utilities.MilesToLongitudeDegrees(2, coords.Latitude));
			map.Region = new MKCoordinateRegion(coords, span);

			Globals.currLocation_Lat = coords.Latitude;
			Globals.currLocation_Lon = coords.Longitude;
			

			map.ShowsUserLocation = true;

            Utilities.CreateWeatherPins(map);

			Console.WriteLine("DISPLAY MAP");
			View = map;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
