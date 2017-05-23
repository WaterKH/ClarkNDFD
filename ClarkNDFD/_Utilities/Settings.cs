using System;
using System.Collections.Generic;

namespace ClarkNDFD
{
	public class Settings
	{
		#region Text To Use in REST_API.cs
		public readonly static string MaximumTemperature = "maxt";
		public readonly static string MinimumTemperature = "mint";
		public readonly static string ThreeHourlyTemperature = "temp";
		public readonly static string DewpointTemperature = "dew";
		public readonly static string ApparentTemperature = "appt";
		public readonly static string TwelveHourProbOfPrecipitation = "pop12";
		public readonly static string LiquidPrecipitationAmount = "qpf";
		public readonly static string SnowfallAmount = "snow";
		public readonly static string CloudCoverAmount = "sky";
		public readonly static string RelativeHumidity = "rh";
		public readonly static string WindSpeed = "wspd";
		public readonly static string WindDirection = "wdir";
		public readonly static string Weather = "wx";
		public readonly static string WeatherIcons = "icons";
		public readonly static string WaveHeight = "waveh";
		public readonly static string WindGust = "wgust";
		public readonly static string ConvectiveHazardOutlook = "conhazo";
		public readonly static string ProbabilityOfDamagingThunderstormWinds = "ptstmwinds";
		public readonly static string ProbabilityOfExtremeThunderstormWinds = "pxtstmwinds";
		public readonly static string ProbabilityOfSevereThunderstorms = "ptotsvrtstm";
		public readonly static string ProbabilityOfExtremeSevereThunderstorms = "pxtotsvrtstm";
		public readonly static string WatchesWarningsAndAdvisories = "wwa";
		public readonly static string MaximumRelativeHumidity = "maxrh";
		public readonly static string MinimumRelativeHumidity = "minrh";
		#endregion

		#region Used If True in REST_API.cs
		public static bool isMaxTemp = true;
		public static bool isMinTemp = true;
		public static bool isThreeHourTemp = true;
		public static bool isDewTemp = false;
		public static bool isAppTemp = true;
		public static bool isProbOfPrec = true;
		public static bool isPrecAmt = false;
		public static bool isSnowfall = false;
		public static bool isCloudAmt = true;
		public static bool isRelHum = true;
		public static bool isWindSpd = true;
		public static bool isWindDir = true;
		public static bool isWeather = true;
		public static bool isWeaIcon = true;
		public static bool isWaveHght = true;
		public static bool isWindGust = true;
		public static bool isHazOutlook = true;
		public static bool isProbDmgThnd = true;
		public static bool isProbExtThnd = true;
		public static bool isProbSevThnd = true;
		public static bool isProbExtSevThnd = true;
		public static bool isWWA = true;
		public static bool isMaxRelHum = true;
		public static bool isMinRelHum = true;
		#endregion

		public static Dictionary<string, bool> AllSettings = new Dictionary<string, bool> () {
			{ MaximumTemperature, isMaxTemp }, 
			{ MinimumTemperature, isMinTemp },
			{ ThreeHourlyTemperature, isThreeHourTemp },
			{ DewpointTemperature, isDewTemp },
			{ ApparentTemperature, isAppTemp },
			{ TwelveHourProbOfPrecipitation, isProbOfPrec },
			{ LiquidPrecipitationAmount, isPrecAmt },
			{ SnowfallAmount, isSnowfall },
			{ CloudCoverAmount, isCloudAmt },
			{ RelativeHumidity, isRelHum },
			{ WindSpeed, isWindSpd },
			{ WindDirection, isWindDir },
			{ Weather, isWeather },
			{ WeatherIcons, isWeaIcon },
			{ WaveHeight, isWaveHght },
			{ WindGust, isWindGust },
			{ ConvectiveHazardOutlook, isHazOutlook },
			{ ProbabilityOfDamagingThunderstormWinds, isProbDmgThnd },
			{ ProbabilityOfExtremeThunderstormWinds, isProbExtThnd },
			{ ProbabilityOfSevereThunderstorms, isProbSevThnd },
			{ ProbabilityOfExtremeSevereThunderstorms, isProbExtSevThnd },
			{ WatchesWarningsAndAdvisories, isWWA },
			{ MaximumRelativeHumidity, isMaxRelHum },
			{ MinimumRelativeHumidity, isMinRelHum }
		};

	}
}
