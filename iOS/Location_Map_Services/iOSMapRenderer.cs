using System;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

namespace ClarkNDFD.iOS
{
	public class iOSMapRenderer : MapRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null) return;

			var map = this.Control as MKMapView;
			if (map == null) return;

			map.AddGestureRecognizer (new UILongPressGestureRecognizer (MapLongPress));

		}

		private void MapLongPress (UILongPressGestureRecognizer recognizer)
		{
			if (recognizer.State != UIGestureRecognizerState.Began) return;

			var map = this.Control as MKMapView;

			if (map == null) return;

			var pixelLocation = recognizer.LocationInView (map);
			var geoCoordinate = map.ConvertPoint (pixelLocation, map);

			// Add new Annotation(pin) with the coordinate
			Console.WriteLine (geoCoordinate.Latitude + " " + geoCoordinate.Longitude);
		}
	}
}
