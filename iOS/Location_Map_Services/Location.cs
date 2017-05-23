using System;
using CoreLocation;

namespace ClarkNDFD.iOS
{
	public class Location
	{
		CLLocationManager locationManager = new CLLocationManager ();
		public CLLocation currentLocation;

		public void GetCurrentLocation ()
		{
			locationManager.RequestWhenInUseAuthorization ();
			try {
				locationManager.UpdatedLocation += (object sender, CLLocationUpdatedEventArgs e) => {
					
				};
				if (CLLocationManager.LocationServicesEnabled) {
					locationManager.StartMonitoringSignificantLocationChanges ();
				} else {
					Console.WriteLine ("Location services not enabled, please enable this in your Settings");
				}
				locationManager.StartUpdatingLocation ();
				//var location = locationManager.Location.Coordinate;

				// Grabs the new/ current location and stores it
				currentLocation = locationManager.Location;

			} catch (Exception ex) {
				var msg = ex.Message;
			}
		}
	}
}
