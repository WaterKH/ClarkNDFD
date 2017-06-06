using System;
using System.Collections.Generic;

namespace ClarkNDFD
{
	public class Globals
	{
		public static string iOSGoogleMapsKey = "AIzaSyAKEsSLSp-14mZD3QoCkyg82IyhHT5Lmuc";

        public static double currLocation_Lat;
        public static double currLocation_Lon;

        public static string[] test = { "Hello", "World" };

        public static Dwml dwml;


        public static Dictionary<string, List<string>> CreateDictionaryFromDwml(string locationKey)
        {
            var dict = new Dictionary<string, List<string>>();
            var param = new Parameters();

            foreach(var p in dwml.Data.ParameterList.Parameters)
            {
                if(p.Applicablelocation == locationKey)
                {
                    param = p;
                    break;
                }
            }

            #region Temperature
            foreach(var temp in param.Temperature)
            {
                var time = temp.Timelayout;

                var values = CreateTimeValues(time, temp.Value);

                dict.Add(temp.Name, values);
            }
            #endregion

            #region WindSpeed
            foreach(var wind in param.Windspeed)
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
            foreach(var conHaz in param.Convectivehazard)
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
            foreach(var hum in param.Humidity)
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

            foreach(var wea in param.Weather.Weatherconditions)
            {
                var values = CreateWeatherValues(weatherTime, wea.Value);

                foreach(var v in values)
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
            */


            return dict;
        }

        public static List<string> CreateTimeValues(string time, List<string> values)
        {
			var timeLayouts = new Timelayout();
            var newList = new List<string>();

			foreach (var compTime in dwml.Data.TimelayoutList.Timelayout)
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

			foreach (var compTime in dwml.Data.TimelayoutList.Timelayout)
			{
				if (compTime.Layoutkey == time)
				{
					timeLayouts = compTime;
					break;
				}
			}

            foreach(var val in values)
            {
                string intensity = "";

                if(val.Intensity != "none")
                {
                    intensity = " " + val.Intensity + " ";
                }

                string t = val.Coverage + " of" + intensity + val.Weathertype;

                newList.Add(t);
            }

            return newList;
        }
	}
}
