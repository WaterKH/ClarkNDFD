using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ClarkNDFD
{
    #region Data Classes
    [XmlRoot(ElementName = "location")]
	public class Location
	{
		[XmlElement(ElementName = "location-key")]
		public string Locationkey { get; set; }
		[XmlElement(ElementName = "point")]
		public Point Point { get; set; }
	}

	#region Location SubClasses
	[XmlRoot(ElementName = "point")]
	public class Point
	{
		[XmlAttribute(AttributeName = "latitude")]
		public string Latitude { get; set; }
		[XmlAttribute(AttributeName = "longitude")]
		public string Longitude { get; set; }
	}
    #endregion

    [XmlRoot(ElementName = "moreWeatherInformation")]
	public class MoreWeatherInformation
	{
		[XmlAttribute(AttributeName = "applicable-location")]
		public string Applicablelocation { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "parameters")]
	public class Parameters
	{
		[XmlElement(ElementName = "temperature")]
		public List<Temperature> Temperature { get; set; }
		[XmlElement(ElementName = "wind-speed")]
		public List<Windspeed> Windspeed { get; set; }
		[XmlElement(ElementName = "direction")]
		public Direction Direction { get; set; }
		[XmlElement(ElementName = "cloud-amount")]
		public Cloudamount Cloudamount { get; set; }
		[XmlElement(ElementName = "probability-of-precipitation")]
		public Probabilityofprecipitation Probabilityofprecipitation { get; set; }
		[XmlElement(ElementName = "convective-hazard")]
		public List<Convectivehazard> Convectivehazard { get; set; }
		[XmlElement(ElementName = "humidity")]
		public List<Humidity> Humidity { get; set; }
		[XmlElement(ElementName = "weather")]
		public Weather Weather { get; set; }
		[XmlElement(ElementName = "conditions-icon")]
		public Conditionsicon Conditionsicon { get; set; }
		[XmlElement(ElementName = "hazards")]
		public Hazards Hazards { get; set; }
		[XmlElement(ElementName = "water-state")]
		public Waterstate Waterstate { get; set; }
		[XmlAttribute(AttributeName = "applicable-location")]
		public string Applicablelocation { get; set; }
	}

	#region Parameters SubClasses
    // TODO Can we make these all one class and just make these generic?
	[XmlRoot(ElementName = "temperature")]
	public class Temperature
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "units")]
		public string Units { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "wind-speed")]
	public class Windspeed
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "units")]
		public string Units { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "direction")]
	public class Direction
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "units")]
		public string Units { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "cloud-amount")]
	public class Cloudamount
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "units")]
		public string Units { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "probability-of-precipitation")]
	public class Probabilityofprecipitation
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "units")]
		public string Units { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "outlook")]
	public class Outlook
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "convective-hazard")]
	public class Convectivehazard
	{
		[XmlElement(ElementName = "outlook")]
		public Outlook Outlook { get; set; }
		[XmlElement(ElementName = "severe-component")]
		public Severecomponent Severecomponent { get; set; }
	}

	[XmlRoot(ElementName = "severe-component")]
	public class Severecomponent
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "units")]
		public string Units { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "humidity")]
	public class Humidity
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public List<string> Value { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "units")]
		public string Units { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "value")]
	public class Value
	{
		[XmlElement(ElementName = "visibility")]
		public string Visibility { get; set; }
		[XmlAttribute(AttributeName = "coverage")]
		public string Coverage { get; set; }
		[XmlAttribute(AttributeName = "intensity")]
		public string Intensity { get; set; }
		[XmlAttribute(AttributeName = "weather-type")]
		public string Weathertype { get; set; }
		[XmlAttribute(AttributeName = "qualifier")]
		public string Qualifier { get; set; }
		[XmlAttribute(AttributeName = "additive")]
		public string Additive { get; set; }
	}

	[XmlRoot(ElementName = "weather-conditions")]
	public class Weatherconditions
	{
		[XmlElement(ElementName = "value")]
		public List<Value> Value { get; set; }
	}

	[XmlRoot(ElementName = "weather")]
	public class Weather
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "weather-conditions")]
		public List<Weatherconditions> Weatherconditions { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "conditions-icon")]
	public class Conditionsicon
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "icon-link")]
		public List<string> Iconlink { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "hazards")]
	public class Hazards
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "hazard-conditions")]
		public List<string> Hazardconditions { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}

	[XmlRoot(ElementName = "waves")]
	public class Waves
	{
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "units")]
		public string Units { get; set; }
	}

	[XmlRoot(ElementName = "water-state")]
	public class Waterstate
	{
		[XmlElement(ElementName = "waves")]
		public Waves Waves { get; set; }
		[XmlAttribute(AttributeName = "time-layout")]
		public string Timelayout { get; set; }
	}
	#endregion

	[XmlRoot(ElementName = "time-layout")]
	public class Timelayout
	{
		[XmlElement(ElementName = "layout-key")]
		public string Layoutkey { get; set; }
		[XmlElement(ElementName = "start-valid-time")]
		public List<string> Startvalidtime { get; set; }
		[XmlElement(ElementName = "end-valid-time")]
		public List<string> Endvalidtime { get; set; }
		[XmlAttribute(AttributeName = "time-coordinate")]
		public string Timecoordinate { get; set; }
		[XmlAttribute(AttributeName = "summarization")]
		public string Summarization { get; set; }
	}
    #endregion

    #region Head Classes
    [XmlRoot(ElementName = "product")]
	public class Product
	{
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "field")]
		public string Field { get; set; }
		[XmlElement(ElementName = "category")]
		public string Category { get; set; }
		[XmlElement(ElementName = "creation-date")]
		public Creationdate Creationdate { get; set; }
		[XmlAttribute(AttributeName = "srsName")]
		public string SrsName { get; set; }
		[XmlAttribute(AttributeName = "concise-name")]
		public string Concisename { get; set; }
		[XmlAttribute(AttributeName = "operational-mode")]
		public string Operationalmode { get; set; }
	}

    #region Product SubClasses
    [XmlRoot(ElementName = "creation-date")]
	public class Creationdate
	{
		[XmlAttribute(AttributeName = "refresh-frequency")]
		public string Refreshfrequency { get; set; }
		[XmlText]
		public string Text { get; set; }
	}
    #endregion

    [XmlRoot(ElementName = "production-center")]
	public class Productioncenter
	{
		[XmlElement(ElementName = "sub-center")]
		public string Subcenter { get; set; }
	}

	[XmlRoot(ElementName = "source")]
	public class Source
	{
		[XmlElement(ElementName = "more-information")]
		public string Moreinformation { get; set; }
		[XmlElement(ElementName = "production-center")]
		public Productioncenter Productioncenter { get; set; }
		[XmlElement(ElementName = "disclaimer")]
		public string Disclaimer { get; set; }
		[XmlElement(ElementName = "credit")]
		public string Credit { get; set; }
		[XmlElement(ElementName = "credit-logo")]
		public string Creditlogo { get; set; }
		[XmlElement(ElementName = "feedback")]
		public string Feedback { get; set; }
	}
    #endregion

    #region Dwml Classes
    [XmlRoot(ElementName = "head")]
	public class Head
	{
		[XmlElement(ElementName = "product")]
		public Product Product { get; set; }
		[XmlElement(ElementName = "source")]
		public Source Source { get; set; }
	}

	[XmlRoot(ElementName = "data")]
	public class Data
	{
		[XmlElement(ElementName = "location")]
		public List<Location> Location { get; set; }
		[XmlElement(ElementName = "moreWeatherInformation")]
		public List<MoreWeatherInformation> MoreWeatherInformation { get; set; }
		[XmlElement(ElementName = "time-layout")]
		public List<Timelayout> Timelayout { get; set; }
		[XmlElement(ElementName = "parameters")]
		public List<Parameters> Parameters { get; set; }
	}
    #endregion

    [XmlRoot(ElementName = "dwml")]
	public class Dwml
	{
		[XmlElement(ElementName = "head")]
		public Head Head { get; set; }
		[XmlElement(ElementName = "data")]
		public Data Data { get; set; }
		[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsd { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string NoNamespaceSchemaLocation { get; set; }
	}
}
