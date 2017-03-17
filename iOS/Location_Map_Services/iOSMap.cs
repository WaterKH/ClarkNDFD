using System;
using MapKit;
using UIKit;
using Foundation;

namespace ClarkNDFD.iOS
{
	public class iOSMap : UIViewController
	{
		public iOSMap ()
		{
			var map = new MKMapView (UIScreen.MainScreen.Bounds);
			View = map;
		}
	}
}
