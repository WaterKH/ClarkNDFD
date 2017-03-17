using System;
using CoreLocation;

namespace ClarkNDFD.iOS
{
	public class Location
	{
		CLLocationManager locationManager = new CLLocationManager ();

		public void GetPresentLocation ()
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

				// Grabs the new/ current location and stores it in Globals.currLocation
				this.UpdateGlobalLocation (locationManager.Location);

			} catch (Exception ex) {
				var msg = ex.Message;
			}
		}

		public void UpdateGlobalLocation(CLLocation location)
		{
			Globals.currLocation = location.Coordinate.Latitude + "," + location.Coordinate.Longitude;
			Console.WriteLine (Globals.currLocation);
		}
	}
}
