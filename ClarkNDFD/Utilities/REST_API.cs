using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace ClarkNDFD
{
	public class REST_API
	{
		public static void NOAA_GetStations()
		{
			HttpClient client = new HttpClient ();
			client.BaseAddress = new Uri (Globals.NOAABaseURI);

			client.DefaultRequestHeaders.Add ("token", Globals.NOAAKey);

			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));

			//TODO Set limit to higher
			string urlParameters = "stations";

			// List data response.
			HttpResponseMessage response = client.GetAsync (urlParameters).Result;  // Blocking call!

			if (response.IsSuccessStatusCode) {
				// Parse the response body. Blocking!
				var dataObjects = response.Content.ReadAsAsync<NOAAItem> ().Result;

				foreach(var r in dataObjects.results)
				{
					Debug.WriteLine ("{0}", r.name);	
				}
			} 
			else 
			{
				Debug.WriteLine ("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
				Debug.WriteLine (client.BaseAddress + "" + urlParameters);
			}
		}
	}
}
