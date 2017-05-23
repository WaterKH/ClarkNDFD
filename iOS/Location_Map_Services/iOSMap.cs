using System;
using MapKit;
using UIKit;
using Foundation;
using CoreLocation;

namespace ClarkNDFD.iOS
{
	public class iOSMap : UIViewController
	{
		Location location = new Location ();

		public iOSMap ()
		{
			var map = new MKMapView (UIScreen.MainScreen.Bounds);

			location.GetCurrentLocation ();

			map.ShowsUserLocation = true;
			var coords = location.currentLocation.Coordinate;
			map.Region = MKCoordinateRegion.FromDistance (coords, 500, 500);

			View = map;
		}
	}
}
