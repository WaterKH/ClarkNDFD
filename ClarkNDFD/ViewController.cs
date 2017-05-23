using System;
using System.Collections.Generic;
using CoreLocation;
using MapKit;
using UIKit;

namespace ClarkNDFD
{
	public partial class ViewController : UIViewController
	{
        public static string currImage;

		protected ViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// Create Map
			var map = new MKMapView(UIScreen.MainScreen.Bounds);
            map.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			var mapDel = new MyMapDelegate();
			map.Delegate = mapDel;

			CLLocationManager locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
			// TODO Create an override for this DidUpdateUserLocation
            /*map.DidUpdateUserLocation += (sender, e) =>
            {
                if (map.UserLocation != null)
                {
                    CLLocationCoordinate2D coords = map.UserLocation.Coordinate;
                    MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(2), MilesToLongitudeDegrees(2, coords.Latitude));
                    map.Region = new MKCoordinateRegion(coords, span);

                    Globals.currLocation_Lat = coords.Latitude;
                    Globals.currLocation_Lon = coords.Longitude;
                }
            };*/

            map.ShowsUserLocation = true;

			View = map;

            CreateWeatherPins(map);
		}

        public List<MKPointAnnotation> CreateWeatherPins(MKMapView map)
        {
            var weatherDetails = REST_API.GET_NDFDGenCenter(Globals.currLocation_Lat, Globals.currLocation_Lon, 50, 50, 20).Result;
            var mapAnnotations = new List<MKPointAnnotation>();

            if (weatherDetails.Data != null)
            {
                var tempLoc = weatherDetails.Data.Location;

                for (int i = 0; i < tempLoc.Count; ++i)
                {
                    var tempLat = double.Parse(tempLoc[i].Point.Latitude);
                    var tempLon = double.Parse(tempLoc[i].Point.Longitude);

                    var c = new CLLocationCoordinate2D(tempLat, tempLon);

                    currImage = weatherDetails.Data.Parameters[0].Conditionsicon.Iconlink[i];

                    var tempAnnotation = new CustomAnnotation("T", c);
                }
            }

            return mapAnnotations;
        }

		class MyMapDelegate : MKMapViewDelegate
		{
			string pId = "PinAnnotation";
			string mId = "CustomAnnotation";

			public override void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
			{
                //base.DidUpdateUserLocation(mapView, userLocation);
			}

			public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
			{
				MKAnnotationView anView;

				if (annotation is MKUserLocation)
					return null;

				if (annotation is CustomAnnotation)
				{

					// show annotation
					anView = mapView.DequeueReusableAnnotation(mId);

					if (anView == null)
						anView = new MKAnnotationView(annotation, mId);

					anView.Image = UIImage.FromFile(currImage);
					anView.CanShowCallout = true;
					anView.Draggable = true;
					anView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);

				}
				else
				{

					// show pin annotation
					anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(pId);

					if (anView == null)
						anView = new MKPinAnnotationView(annotation, pId);

					((MKPinAnnotationView)anView).PinColor = MKPinAnnotationColor.Red;
					anView.CanShowCallout = true;
				}

				return anView;
			}

			public override void CalloutAccessoryControlTapped(MKMapView mapView, MKAnnotationView view, UIControl control)
			{
				var customAn = view.Annotation as CustomAnnotation;

				if (customAn != null)
				{
					var alert = new UIAlertView("Custom Annotation", customAn.Title, null, "OK");
					alert.Show();
				}
			}
		}

		public double MilesToLatitudeDegrees(double miles)
		{
			double earthRadius = 3960.0; // in miles
			double radiansToDegrees = 180.0 / Math.PI;
			return (miles / earthRadius) * radiansToDegrees;
		}

		public double MilesToLongitudeDegrees(double miles, double atLatitude)
		{
			double earthRadius = 3960.0; // in miles
			double degreesToRadians = Math.PI / 180.0;
			double radiansToDegrees = 180.0 / Math.PI;
			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (miles / radiusAtLatitude) * radiansToDegrees;
		}


		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
