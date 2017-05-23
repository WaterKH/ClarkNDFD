using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ClarkNDFD
{
	public class NDFDClasses
	{
        //[XmlRootAttribute("dwml")]
		//public class NDFDXML
		//{
		//	public DWML dwml { get; set; }
		//}

        [XmlRoot("dwml")]
		public class DWML
		{
			head head { get; set; }
			public data data { get; set; }
		}

		private class head
		{
		}

		public class data
		{
            [XmlArrayAttribute("location")]
			public location[] location { get; set; }
			[XmlArrayAttribute("time-layout")]
			public timelayout[] timeLayout { get; set; }
            [XmlArrayAttribute("parameters")]
			public parameters[] parameters { get; set; }
		}
		public class location
		{
			[XmlElement ("location-key")]
			public string locationKey { get; set; }
			public point point { get; set; }
		}
		public class point
		{
			public double latitude { get; set; }
			public double longitude { get; set; }
		}

		public class timelayout
		{
			[XmlElement ("time-coordinate")]
			public string timeCoord { get; set; }
			public string summarization { get; set; }
			[XmlElement ("layout-key")]
			string layoutKey { get; set; }
			[XmlElement ("start-valid-time")]
			public List<string> startValidTime { get; set; }
			[XmlElement ("end-valid-time")]
			public List<string> endValidTime { get; set; }
		}

		public class parameters
		{
			[XmlElement ("applicable-location")]
			public string applicableLocation { get; set; }
			public List<GenericTemperatureClass> temperature { get; set; }
			[XmlElement ("wind-speed")]
			public List<GenericTemperatureClass> windSpeed { get; set; }
			public GenericTemperatureClass direction { get; set; }
			[XmlElement ("cloud-amount")]
			public GenericTemperatureClass cloudAmount { get; set; }
			[XmlElement ("probability-of-precipitation")]
			public GenericTemperatureClass probOfPrec { get; set; }
			// TODO Insert convective-hazard

			public List<GenericTemperatureClass> humidity { get; set; }
			public Weather weather { get; set; }

			[XmlElement ("conditions-icon")]
			public ConditionsIcon conditionsIcon { get; set; }
			public Hazard hazards { get; set; }
			[XmlElement ("water-state")]
			public WaterState waterState { get; set; }
		}
		public class GenericTemperatureClass
		{
			public string type { get; set; }
			public string units { get; set; }
			[XmlElement ("time-layout")]
			public string timeLayout { get; set; }

			public string name { set; get; }
			public List<int> value { get; set; }
		}
		public class Weather
		{
			[XmlElement ("time-layout")]
			public string timeLayout { get; set; }
			public string name { get; set; }
			[XmlElement ("weather-conditions")]
			public List<WeatherConditions> weatherConditions { get; set; }
		}
		public class WeatherConditions
		{
			public Value value { get; set; }
		}
		public class Value
		{
			public string coverage { get; set; }
			public string intensity { get; set; }
			[XmlElement ("weather-type")]
			public string weatherType { get; set; }
			public string qualifier { get; set; }

			public int? visibility { get; set; }
		}
		public class ConditionsIcon
		{
			public string type { get; set; }
			[XmlElement ("time-layout")]
			public string timeLayout { get; set; }

			public string name { get; set; }
			[XmlElement ("icon-link")]
			public List<string> iconLinks { get; set;}
		}
		public class Hazard
		{
			[XmlElement ("time-layout")]
			public string timeLayout { get; set; }

			public string name { get; set; }
			[XmlElement ("hazard-conditions")]
			public List<string> hazardConditions { get; set; }
		}
		public class WaterState
		{
			[XmlElement ("time-layout")]
			public string timeLayout { get; set; }

			public string name { get; set; }
			public Wave waves { get; set; }
		}
		public class Wave
		{
			public string type { get; set; }
			public string units { get; set; }

			public string name { get; set; }
			public List<int?> value { get; set; }
		}
	}
}