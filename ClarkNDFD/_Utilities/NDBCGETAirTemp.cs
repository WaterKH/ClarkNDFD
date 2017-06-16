using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ClarkNDBC
{
    public class NDBCGETAirTemp
    {
		[XmlRoot(ElementName = "GenericMetaData", Namespace = "http://www.opengis.net/gml")]
		public class GenericMetaData
		{
			[XmlElement(ElementName = "description", Namespace = "http://www.opengis.net/gml")]
			public string Description { get; set; }
		}

		[XmlRoot(ElementName = "metaDataProperty", Namespace = "http://www.opengis.net/gml")]
		public class MetaDataProperty
		{
			[XmlElement(ElementName = "GenericMetaData", Namespace = "http://www.opengis.net/gml")]
			public GenericMetaData GenericMetaData { get; set; }
			[XmlAttribute(AttributeName = "title", Namespace = "http://www.w3.org/1999/xlink")]
			public string Title { get; set; }
			[XmlElement(ElementName = "version", Namespace = "http://www.opengis.net/gml")]
			public string Version { get; set; }
			[XmlAttribute(AttributeName = "href", Namespace = "http://www.w3.org/1999/xlink")]
			public string Href { get; set; }
			[XmlElement(ElementName = "name", Namespace = "http://www.opengis.net/gml")]
			public Name Name { get; set; }
		}

		[XmlRoot(ElementName = "Envelope", Namespace = "http://www.opengis.net/gml")]
		public class Envelope
		{
			[XmlElement(ElementName = "lowerCorner", Namespace = "http://www.opengis.net/gml")]
			public string LowerCorner { get; set; }
			[XmlElement(ElementName = "upperCorner", Namespace = "http://www.opengis.net/gml")]
			public string UpperCorner { get; set; }
			[XmlAttribute(AttributeName = "srsName")]
			public string SrsName { get; set; }
		}

		[XmlRoot(ElementName = "boundedBy", Namespace = "http://www.opengis.net/gml")]
		public class BoundedBy
		{
			[XmlElement(ElementName = "Envelope", Namespace = "http://www.opengis.net/gml")]
			public Envelope Envelope { get; set; }
		}

		[XmlRoot(ElementName = "TimePeriod", Namespace = "http://www.opengis.net/gml")]
		public class TimePeriod
		{
			[XmlElement(ElementName = "beginPosition", Namespace = "http://www.opengis.net/gml")]
			public string BeginPosition { get; set; }
			[XmlElement(ElementName = "endPosition", Namespace = "http://www.opengis.net/gml")]
			public string EndPosition { get; set; }
		}

		[XmlRoot(ElementName = "samplingTime", Namespace = "http://www.opengis.net/om/1.0")]
		public class SamplingTime
		{
			[XmlElement(ElementName = "TimePeriod", Namespace = "http://www.opengis.net/gml")]
			public TimePeriod TimePeriod { get; set; }
		}

		[XmlRoot(ElementName = "member", Namespace = "http://www.opengis.net/gml")]
		public class Member
		{
			[XmlAttribute(AttributeName = "href", Namespace = "http://www.w3.org/1999/xlink")]
			public string Href { get; set; }
		}

		[XmlRoot(ElementName = "Process", Namespace = "http://www.opengis.net/om/1.0")]
		public class Process
		{
			[XmlElement(ElementName = "member", Namespace = "http://www.opengis.net/gml")]
			public Member Member { get; set; }
		}

		[XmlRoot(ElementName = "procedure", Namespace = "http://www.opengis.net/om/1.0")]
		public class Procedure
		{
			[XmlElement(ElementName = "Process", Namespace = "http://www.opengis.net/om/1.0")]
			public Process Process { get; set; }
		}

		[XmlRoot(ElementName = "component", Namespace = "http://www.opengis.net/swe/1.0.1")]
		public class Component
		{
			[XmlAttribute(AttributeName = "href", Namespace = "http://www.w3.org/1999/xlink")]
			public string Href { get; set; }
		}

		[XmlRoot(ElementName = "CompositePhenomenon", Namespace = "http://www.opengis.net/swe/1.0.1")]
		public class CompositePhenomenon
		{
			[XmlElement(ElementName = "name", Namespace = "http://www.opengis.net/gml")]
			public string Name { get; set; }
			[XmlElement(ElementName = "component", Namespace = "http://www.opengis.net/swe/1.0.1")]
			public Component Component { get; set; }
			[XmlAttribute(AttributeName = "dimension")]
			public string Dimension { get; set; }
			[XmlAttribute(AttributeName = "id", Namespace = "http://www.opengis.net/gml")]
			public string Id { get; set; }
		}

		[XmlRoot(ElementName = "observedProperty", Namespace = "http://www.opengis.net/om/1.0")]
		public class ObservedProperty
		{
			[XmlElement(ElementName = "CompositePhenomenon", Namespace = "http://www.opengis.net/swe/1.0.1")]
			public CompositePhenomenon CompositePhenomenon { get; set; }
		}

		[XmlRoot(ElementName = "name", Namespace = "http://www.opengis.net/gml")]
		public class Name
		{
			[XmlAttribute(AttributeName = "codeSpace")]
			public string CodeSpace { get; set; }
			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "Point", Namespace = "http://www.opengis.net/gml")]
		public class Point
		{
			[XmlElement(ElementName = "name", Namespace = "http://www.opengis.net/gml")]
			public string Name { get; set; }
			[XmlElement(ElementName = "pos", Namespace = "http://www.opengis.net/gml")]
			public string Pos { get; set; }
		}

		[XmlRoot(ElementName = "pointMembers", Namespace = "http://www.opengis.net/gml")]
		public class PointMembers
		{
			[XmlElement(ElementName = "Point", Namespace = "http://www.opengis.net/gml")]
			public Point Point { get; set; }
		}

		[XmlRoot(ElementName = "MultiPoint", Namespace = "http://www.opengis.net/gml")]
		public class MultiPoint
		{
			[XmlElement(ElementName = "pointMembers", Namespace = "http://www.opengis.net/gml")]
			public PointMembers PointMembers { get; set; }
			[XmlAttribute(AttributeName = "srsName")]
			public string SrsName { get; set; }
		}

		[XmlRoot(ElementName = "location", Namespace = "http://www.opengis.net/gml")]
		public class Location
		{
			[XmlElement(ElementName = "MultiPoint", Namespace = "http://www.opengis.net/gml")]
			public MultiPoint MultiPoint { get; set; }
		}

		[XmlRoot(ElementName = "FeatureCollection", Namespace = "http://www.opengis.net/gml")]
		public class FeatureCollection
		{
			[XmlElement(ElementName = "metaDataProperty", Namespace = "http://www.opengis.net/gml")]
			public MetaDataProperty MetaDataProperty { get; set; }
			[XmlElement(ElementName = "boundedBy", Namespace = "http://www.opengis.net/gml")]
			public BoundedBy BoundedBy { get; set; }
			[XmlElement(ElementName = "location", Namespace = "http://www.opengis.net/gml")]
			public Location Location { get; set; }
		}

		[XmlRoot(ElementName = "featureOfInterest", Namespace = "http://www.opengis.net/om/1.0")]
		public class FeatureOfInterest
		{
			[XmlElement(ElementName = "FeatureCollection", Namespace = "http://www.opengis.net/gml")]
			public FeatureCollection FeatureCollection { get; set; }
		}

		[XmlRoot(ElementName = "Text", Namespace = "http://www.opengis.net/swe/2.0")]
		public class Text
		{
			[XmlElement(ElementName = "value", Namespace = "http://www.opengis.net/swe/2.0")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "definition")]
			public string Definition { get; set; }
		}

		[XmlRoot(ElementName = "field", Namespace = "http://www.opengis.net/swe/2.0")]
		public class Field
		{
			[XmlElement(ElementName = "Text", Namespace = "http://www.opengis.net/swe/2.0")]
			public Text Text { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
			[XmlElement(ElementName = "Vector", Namespace = "http://www.opengis.net/swe/2.0")]
			public Vector Vector { get; set; }
			[XmlElement(ElementName = "Time", Namespace = "http://www.opengis.net/swe/2.0")]
			public Time Time { get; set; }
			[XmlElement(ElementName = "Quantity", Namespace = "http://www.opengis.net/swe/2.0")]
			public Quantity Quantity { get; set; }
		}

		[XmlRoot(ElementName = "uom", Namespace = "http://www.opengis.net/swe/2.0")]
		public class Uom
		{
			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }
			[XmlAttribute(AttributeName = "href", Namespace = "http://www.w3.org/1999/xlink")]
			public string Href { get; set; }
		}

		[XmlRoot(ElementName = "Quantity", Namespace = "http://www.opengis.net/swe/2.0")]
		public class Quantity
		{
			[XmlElement(ElementName = "uom", Namespace = "http://www.opengis.net/swe/2.0")]
			public Uom Uom { get; set; }
			[XmlElement(ElementName = "value", Namespace = "http://www.opengis.net/swe/2.0")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "definition")]
			public string Definition { get; set; }
			[XmlAttribute(AttributeName = "referenceFrame")]
			public string ReferenceFrame { get; set; }
		}

		[XmlRoot(ElementName = "coordinate", Namespace = "http://www.opengis.net/swe/2.0")]
		public class Coordinate
		{
			[XmlElement(ElementName = "Quantity", Namespace = "http://www.opengis.net/swe/2.0")]
			public Quantity Quantity { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "Vector", Namespace = "http://www.opengis.net/swe/2.0")]
		public class Vector
		{
			[XmlElement(ElementName = "coordinate", Namespace = "http://www.opengis.net/swe/2.0")]
			public List<Coordinate> Coordinate { get; set; }
			[XmlAttribute(AttributeName = "definition")]
			public string Definition { get; set; }
			[XmlAttribute(AttributeName = "referenceFrame")]
			public string ReferenceFrame { get; set; }
		}

		[XmlRoot(ElementName = "Time", Namespace = "http://www.opengis.net/swe/2.0")]
		public class Time
		{
			[XmlElement(ElementName = "uom", Namespace = "http://www.opengis.net/swe/2.0")]
			public Uom Uom { get; set; }
			[XmlElement(ElementName = "value", Namespace = "http://www.opengis.net/swe/2.0")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "definition")]
			public string Definition { get; set; }
		}

		[XmlRoot(ElementName = "DataRecord", Namespace = "http://www.opengis.net/swe/2.0")]
		public class DataRecord
		{
			[XmlElement(ElementName = "field", Namespace = "http://www.opengis.net/swe/2.0")]
			public List<Field> Field { get; set; }
		}

		[XmlRoot(ElementName = "elementType", Namespace = "http://www.opengis.net/swe/2.0")]
		public class ElementType
		{
			[XmlElement(ElementName = "DataRecord", Namespace = "http://www.opengis.net/swe/2.0")]
			public DataRecord DataRecord { get; set; }
			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "TextEncoding", Namespace = "http://www.opengis.net/swe/2.0")]
		public class TextEncoding
		{
			[XmlAttribute(AttributeName = "decimalSeparator")]
			public string DecimalSeparator { get; set; }
			[XmlAttribute(AttributeName = "tokenSeparator")]
			public string TokenSeparator { get; set; }
			[XmlAttribute(AttributeName = "blockSeparator")]
			public string BlockSeparator { get; set; }
		}

		[XmlRoot(ElementName = "encoding", Namespace = "http://www.opengis.net/swe/2.0")]
		public class Encoding
		{
			[XmlElement(ElementName = "TextEncoding", Namespace = "http://www.opengis.net/swe/2.0")]
			public TextEncoding TextEncoding { get; set; }
		}

		[XmlRoot(ElementName = "DataStream", Namespace = "http://www.opengis.net/swe/2.0")]
		public class DataStream
		{
			[XmlElement(ElementName = "elementType", Namespace = "http://www.opengis.net/swe/2.0")]
			public ElementType ElementType { get; set; }
			[XmlElement(ElementName = "encoding", Namespace = "http://www.opengis.net/swe/2.0")]
			public Encoding Encoding { get; set; }
			[XmlElement(ElementName = "values", Namespace = "http://www.opengis.net/swe/2.0")]
			public string Values { get; set; }
		}

		[XmlRoot(ElementName = "result", Namespace = "http://www.opengis.net/om/1.0")]
		public class Result
		{
			[XmlElement(ElementName = "DataStream", Namespace = "http://www.opengis.net/swe/2.0")]
			public DataStream DataStream { get; set; }
		}

		[XmlRoot(ElementName = "Observation", Namespace = "http://www.opengis.net/om/1.0")]
		public class Observation
		{
			[XmlElement(ElementName = "description", Namespace = "http://www.opengis.net/gml")]
			public string Description { get; set; }
			[XmlElement(ElementName = "samplingTime", Namespace = "http://www.opengis.net/om/1.0")]
			public SamplingTime SamplingTime { get; set; }
			[XmlElement(ElementName = "procedure", Namespace = "http://www.opengis.net/om/1.0")]
			public Procedure Procedure { get; set; }
			[XmlElement(ElementName = "observedProperty", Namespace = "http://www.opengis.net/om/1.0")]
			public ObservedProperty ObservedProperty { get; set; }
			[XmlElement(ElementName = "featureOfInterest", Namespace = "http://www.opengis.net/om/1.0")]
			public FeatureOfInterest FeatureOfInterest { get; set; }
			[XmlElement(ElementName = "result", Namespace = "http://www.opengis.net/om/1.0")]
			public Result Result { get; set; }
		}

		[XmlRoot(ElementName = "member", Namespace = "http://www.opengis.net/om/1.0")]
		public class Member2
		{
			[XmlElement(ElementName = "Observation", Namespace = "http://www.opengis.net/om/1.0")]
			public Observation Observation { get; set; }
		}

		[XmlRoot(ElementName = "ObservationCollection", Namespace = "http://www.opengis.net/om/1.0")]
		public class ObservationCollection
		{
			[XmlElement(ElementName = "metaDataProperty", Namespace = "http://www.opengis.net/gml")]
			public List<MetaDataProperty> MetaDataProperty { get; set; }
			[XmlElement(ElementName = "boundedBy", Namespace = "http://www.opengis.net/gml")]
			public BoundedBy BoundedBy { get; set; }
            [XmlArrayItem(ElementName = "member", Namespace = "http://www.opengis.net/om/1.0")]
			public List<Member2> Member2 { get; set; }
			/*[XmlAttribute(AttributeName = "om", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Om { get; set; }
			[XmlAttribute(AttributeName = "gml", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Gml { get; set; }
			[XmlAttribute(AttributeName = "swe", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Swe { get; set; }
			[XmlAttribute(AttributeName = "swe2", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Swe2 { get; set; }
			[XmlAttribute(AttributeName = "xlink", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Xlink { get; set; }
			[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Xsi { get; set; }*/
			[XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
			public string SchemaLocation { get; set; }
		}
	}

}

