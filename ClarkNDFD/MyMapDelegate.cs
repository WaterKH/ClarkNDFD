using System;
using MapKit;
using UIKit;

namespace ClarkNDBC
{
	public class MyMapDelegate : MKMapViewDelegate
	{
		string pId = "PinAnnotation";
		public static string mId = "CustomAnnotation";
		ViewController viewContr;

		public MyMapDelegate(ViewController aView)
		{
			viewContr = aView;
		}

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

				//anView.Image = UIImage.FromFile(currImage);
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
				
                // TODO Fix this icon for the user's location
				anView.CanShowCallout = true;
			}

			return anView;
		}

		public override void CalloutAccessoryControlTapped(MKMapView mapView, MKAnnotationView view, UIControl control)
		{
			var customAn = view.Annotation as CustomAnnotation;

			if (customAn != null)
			{
				//var alert = new UIAlertView("Weather", customAn.Weather, null, "OK");
				//alert.Show();

				WeatherViewController weather = viewContr.Storyboard.InstantiateViewController("WeatherViewController") as WeatherViewController;

				weather.locationKey = customAn.LocationKey;

				if (weather != null)
				{
					viewContr.NavigationController.PushViewController(weather, true);
				}
			}
		}
	}
}
