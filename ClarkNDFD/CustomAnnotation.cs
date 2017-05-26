using System;
using CoreLocation;
using MapKit;

namespace ClarkNDFD
{
	public class CustomAnnotation : MKAnnotation
	{
		string title;
		CLLocationCoordinate2D coord;
        public string weather;

		public CustomAnnotation(string title, CLLocationCoordinate2D coord)
		{
			this.title = title;
			this.coord = coord;
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
