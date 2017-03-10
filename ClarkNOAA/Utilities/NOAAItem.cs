using System;
using System.Collections.Generic;

namespace ClarkNOAA
{
	public class NOAAItem
	{
		public MetaData metadata { get; set; }
		public List<Result> results { get; set; }
	}

	public class MetaData
	{
		public ResultSet resultset { get; set; }
	}

	public class ResultSet
	{
		public int offset { get; set; }
		public int count { get; set; }
		public int limit { get; set; }
	}

	public class Result
	{
		public double elevation { get; set; }
		public string mindate { get; set; }
		public string maxdate { get; set; }
		public double latitude { get; set; }
		public string name { get; set; }
		public double datacoverage { get; set; }
		public string id { get; set; }
		public string elevationUnit { get; set; }
		public double longitude { get; set; }
	}
}
