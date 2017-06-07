using System;
using MapKit;
using System.Collections.Generic;
using CoreLocation;
using System.Threading.Tasks;
using UIKit;
using RestSharp;
using Foundation;

namespace ClarkNDFD._Utilities
{
    public class Utilities
    {
		public static async void CreateWeatherPins(MKMapView map)
		{
			//Globals.currLocation_Lat = 34.422500;
			//Globals.currLocation_Lon = -78.923056;

			var weatherDetails = await REST_API.GET_NDFDGenCenter(Globals.currLocation_Lat, Globals.currLocation_Lon, 5, 5, 2.5);

			Globals.dwml = weatherDetails;

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

					//currImage = param.Conditionsicon.Iconlink[0];
					MyMapDelegate.mId = tempLoc[i].Locationkey;

					//TODO Fix these custom annotations pictures
					var tempAnnotation = new CustomAnnotation("Weather", c, tempLoc[i].Locationkey);

					tempAnnotation.weather = param.Temperature[1].Type + ": " + param.Temperature[1].Value[0] + "\n";
					tempAnnotation.weather += param.Temperature[0].Type + ": " + param.Temperature[0].Value[0];

					mapAnnotations.Add(tempAnnotation);
				}
			}

            if (mapAnnotations.Count > 0)
            {
                Console.WriteLine(("Adding Annotations"));
                map.AddAnnotations(mapAnnotations.ToArray());
            }

			var coords = new CLLocationCoordinate2D(Globals.currLocation_Lat, Globals.currLocation_Lon);
			MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(25), MilesToLongitudeDegrees(25, coords.Latitude));
			map.Region = new MKCoordinateRegion(coords, span);

            Console.WriteLine("Finished");
		}

        public static List<string[]> CreateTableElements(string locationKey)
        {
            var list = new List<string[]>();

			var param = new Parameters();
            var times = new List<string>();
            var hourlyTemps = new Temperature();
            var appTemps = new Temperature();
            var winds = new Windspeed();
            var clouds = new Cloudamount();
            var humiditys = new Humidity();

			foreach (var p in Globals.dwml.Data.ParameterList.Parameters)
			{
				if (p.Applicablelocation == locationKey)
				{
					param = p;
					break;
				}
			}

            foreach(var t in Globals.dwml.Data.TimelayoutList.Timelayout)
            {
                if(t.Layoutkey == param.Conditionsicon.Timelayout)
                {
                    times = t.Startvalidtime;
                    break;
                }
            }

            foreach(var aT in param.Temperature)
            {
                if(aT.Type == "hourly")
                {
                    hourlyTemps = aT;
                }
                else if(aT.Type == "apparent")
                {
                    appTemps = aT;
                }
            }

            foreach(var w in param.Windspeed)
            {
                if(w.Type == "sustained")
                {
                    winds = w;
                    break;
                }
            }

            foreach (var h in param.Humidity)
            {
                if(h.Type == "relative")
                {
                    humiditys = h;
                    break;
                }
            }

            clouds = param.Cloudamount;

            for (int i = 0; i < param.Conditionsicon.Iconlink.Count; i++)
            {
                string[] values = new string[7];
                // TODO Change this to limit to 24 hour forecast

                values[0] = times[i];
                values[1] = param.Conditionsicon.Iconlink[i];
                values[2] = appTemps.Value[i];
                values[3] = appTemps.Value[i];
                values[4] = appTemps.Value[i];
                values[5] = winds.Value[i];
                values[6] = humiditys.Value[i];

                list.Add(values);
            }

            return list;
        }

		/*public static Dictionary<string, List<string>> CreateDictionaryFromDwml(string locationKey)
		{
			var dict = new Dictionary<string, List<string>>();
			var param = new Parameters();

			foreach (var p in Globals.dwml.Data.ParameterList.Parameters)
			{
				if (p.Applicablelocation == locationKey)
				{
					param = p;
					break;
				}
			}

			#region Temperature
			foreach (var temp in param.Temperature)
			{
				var time = temp.Timelayout;

				var values = CreateTimeValues(time, temp.Value);

				dict.Add(temp.Name, values);
			}
			#endregion

			#region WindSpeed
			foreach (var wind in param.Windspeed)
			{
				var time = wind.Timelayout;

				var values = CreateTimeValues(time, wind.Value);

				dict.Add(wind.Name, values);
			}
			#endregion

			#region Direction
			var dir = param.Direction;
			var dirTime = dir.Timelayout;

			var dirValues = CreateTimeValues(dirTime, dir.Value);

			dict.Add(dir.Name, dirValues);
			#endregion

			#region CloudAmount
			var cloudAmt = param.Cloudamount;
			var cloudAmtTime = cloudAmt.Timelayout;

			var cloudAmtValues = CreateTimeValues(cloudAmtTime, cloudAmt.Value);

			dict.Add(cloudAmt.Name, cloudAmtValues);
			#endregion

			#region Probability of Precipiation
			var probPrec = param.Probabilityofprecipitation;
			var probPrecTime = probPrec.Timelayout;

			var probPrecValues = CreateTimeValues(probPrecTime, probPrec.Value);

			dict.Add(probPrec.Name, probPrecValues);
			#endregion

			#region Convective Hazard
			foreach (var conHaz in param.Convectivehazard)
			{
				if (conHaz.Severecomponent != null)
				{
					var time = conHaz.Severecomponent.Timelayout;

					var values = CreateTimeValues(time, conHaz.Severecomponent.Value);

					dict.Add(conHaz.Severecomponent.Name, values);
				}
			}
			#endregion

			#region Humidity
			foreach (var hum in param.Humidity)
			{
				var time = hum.Timelayout;

				var values = CreateTimeValues(time, hum.Value);

				dict.Add(hum.Name, values);
			}
			#endregion

			#region Weather
			var weather = param.Weather;
			var weatherTime = weather.Timelayout;
			var weatherValues = new List<string>();

			foreach (var wea in param.Weather.Weatherconditions)
			{
				var values = CreateWeatherValues(weatherTime, wea.Value);

				foreach (var v in values)
				{
					weatherValues.Add(v);
				}

			}

			dict.Add(weather.Name, weatherValues);
			#endregion
			/*
            #region Hazards
            var hazard = param.Hazards;
            var hazardTime = hazard.Timelayout;

            foreach(var haz in param.Hazards.Hazardconditions)
            {
                var values = CreateWeatherValues(weatherTime, haz.Value);

                dict.Add(hazard.Name, values);
            }
            #endregion



			return dict;
		}

		public static List<string> CreateTimeValues(string time, List<string> values)
		{
			var timeLayouts = new Timelayout();
			var newList = new List<string>();

			foreach (var compTime in Globals.dwml.Data.TimelayoutList.Timelayout)
			{
				if (compTime.Layoutkey == time)
				{
					timeLayouts = compTime;
					break;
				}
			}

			for (int i = 0; i < timeLayouts.Startvalidtime.Count; i++)
			{
				string t = values[i] + " " + timeLayouts.Startvalidtime[i];
				//+ " " + timeLayouts.Endvalidtime[i];

				newList.Add(t);
			}

			return newList;
		}

		public static List<string> CreateWeatherValues(string time, List<Value> values)
		{
			var newList = new List<string>();
			var timeLayouts = new Timelayout();

			foreach (var compTime in Globals.dwml.Data.TimelayoutList.Timelayout)
			{
				if (compTime.Layoutkey == time)
				{
					timeLayouts = compTime;
					break;
				}
			}

			foreach (var val in values)
			{
				string intensity = "";

				if (val.Intensity != "none")
				{
					intensity = " " + val.Intensity + " ";
				}

				string t = val.Coverage + " of" + intensity + val.Weathertype;

				newList.Add(t);
			}

			return newList;
		}*/

		public static double MilesToLatitudeDegrees(double miles)
		{
			double earthRadius = 3960.0; // in miles
			double radiansToDegrees = 180.0 / Math.PI;
			return (miles / earthRadius) * radiansToDegrees;
		}

		public static double MilesToLongitudeDegrees(double miles, double atLatitude)
		{
			double earthRadius = 3960.0; // in miles
			double degreesToRadians = Math.PI / 180.0;
			double radiansToDegrees = 180.0 / Math.PI;
			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (miles / radiusAtLatitude) * radiansToDegrees;
		}

		public static async Task<UIImage> LoadImage(string imageUrl)
		{
            // Todo make async
            string imageBaseUrl = "http://forecast.weather.gov/images/wtf/";
            string imageRequest = imageUrl.Substring(imageBaseUrl.Length - 1);

            var client = new RestClient(imageBaseUrl);
            var request = new RestRequest(imageRequest);

            var contentsTask = client.DownloadData(request);

			// await! control returns to the caller and the task continues to run on another thread
			//var contents = await contentsTask;

			// load from bytes
            return UIImage.LoadFromData(NSData.FromArray(contentsTask));
		}
    }
}
