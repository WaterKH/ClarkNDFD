using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CoreLocation;
using MapKit;
using UIKit;

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

			mapDel = new MyMapDelegate();
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

			//map.ShowsUserLocation = true;

			View = map;
        }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

            map.ShowsUserLocation = true;

            CreateWeatherPins(map);
		}

        public void CreateWeatherPins(MKMapView map)
        {
            Globals.currLocation_Lat = 34.422500;
            Globals.currLocation_Lon = -78.923056;

            var weatherDetails = REST_API.GET_NDFDGenCenter(Globals.currLocation_Lat, Globals.currLocation_Lon, 50, 50, 20).Result;
            var mapAnnotations = new List<CustomAnnotation>();

            if (weatherDetails != null)
            {
                var tempLoc = weatherDetails.Data.LocationList.Location;

                for (int i = 0; i < tempLoc.Count; ++i)
                {
                    var param = weatherDetails.Data.ParameterList.Parameters[i];

                    var tempLat = double.Parse(tempLoc[i].Point.Latitude);
                    var tempLon = double.Parse(tempLoc[i].Point.Longitude);

                    var c = new CLLocationCoordinate2D(tempLat, tempLon);

					currImage = param.Conditionsicon.Iconlink[0];
                    MyMapDelegate.mId = tempLoc[i].Locationkey;

					//TODO Fix these custom annotations pictures
					var tempAnnotation = new CustomAnnotation("Weather", c);

                    tempAnnotation.weather = param.Temperature[1].Type + ": " + param.Temperature[1].Value[0] + "\n";
                    tempAnnotation.weather += param.Temperature[0].Type + ": " + param.Temperature[0].Value[0];

                    mapAnnotations.Add(tempAnnotation);
                }
            }

            Console.WriteLine(("Adding Annotations"));
            map.AddAnnotations(mapAnnotations.ToArray());

            var coords = new CLLocationCoordinate2D(Globals.currLocation_Lat, Globals.currLocation_Lon);
            MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(100), MilesToLongitudeDegrees(100, coords.Latitude));
			map.Region = new MKCoordinateRegion(coords, span);
        }

		public class MyMapDelegate : MKMapViewDelegate
		{
			string pId = "PinAnnotation";
			public static string mId = "CustomAnnotation";

			public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
			{
				MKPinAnnotationView anView;

				if (annotation is MKUserLocation)
					return null;

				if (annotation is CustomAnnotation)
				{
					// show custom annotation
                    anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(mId);

					if (anView == null)
						anView = new MKPinAnnotationView(annotation, mId);

					anView.Image = UIImage.FromFile(currImage);
					anView.CanShowCallout = true;
                    anView.Draggable = false;
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
					var alert = new UIAlertView("Weather", customAn.Weather, null, "OK");
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
