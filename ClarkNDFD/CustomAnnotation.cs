using System;
using CoreLocation;
using MapKit;

namespace ClarkNDFD
{
	public class CustomAnnotation : MKAnnotation
	{
		string title;
        string locationKey;
		CLLocationCoordinate2D coord;
        public string weather;

		public CustomAnnotation(string aTitle, CLLocationCoordinate2D coord, string locationKey)
		{
			this.title = aTitle;
			this.coord = coord;
            this.locationKey = locationKey;
		}

		public override string Title
		{
			get
			{
				return title;
			}
		}

        public string Weather
        {
            get
            {
                return weather;
            }
        }

		public string LocationKey
		{
			get
			{
                return locationKey;
			}
		}

		public override CLLocationCoordinate2D Coordinate
		{
			get
			{
				return coord;
			}
		}

		public override void SetCoordinate(CLLocationCoordinate2D value)
		{
			coord = value;
		}
	}
}
