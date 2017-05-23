using System;
using System.IO;
using System.Threading.Tasks;
using RestSharp;

namespace ClarkNDFD
{
	public class REST_API
	{
		readonly static string NDFDURL = "http://graphical.weather.gov/xml/sample_products/browser_interface";
		
        public static async Task<Dwml> GET_NDFDGenCenter(double centerPointLat, double centerPointLon,
		                                                 double distLat, double distLon, double resSquare)
		{
			Console.WriteLine ("ENTER GET - NDFDXML");

			string action = "/ndfdXMLclient.php";

			// Client creation
			var client = new RestClient ();
			client.BaseUrl = new Uri (NDFDURL);
			client.AddHandler ("text/xml", new RestSharp.Deserializers.XmlDeserializer ());

            // Request creation
            var request = new RestRequest (action);
			request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer ();
			request.RequestFormat = DataFormat.Xml;

			// Parameter Inputs
			request.AddQueryParameter ("centerPointLat", centerPointLat.ToString());
			request.AddQueryParameter ("centerPointLon", centerPointLon.ToString ());
			request.AddQueryParameter ("distanceLat", distLat.ToString());
			request.AddQueryParameter ("distanceLon", distLon.ToString ());
			request.AddQueryParameter ("resolutionSquare", resSquare.ToString ());
			request.AddQueryParameter ("Unit", "e");
			//request.AddQueryParameter ("startTime", startTime.ToString ("o"));
			//request.AddQueryParameter ("endTime", endTime.ToString ("o"));

			// Taken from Settings.cs
			foreach(var kv in Settings.AllSettings)
			{
				if(kv.Value)
				{
					request.AddQueryParameter (kv.Key, kv.Key);
				}
			}

            Console.WriteLine(client.BuildUri(request).AbsoluteUri);
			// Generate response
            var response = ExecuteAsync<Dwml> (request, client).Result;

			Console.WriteLine ("EXITING GET - NDFDXML");
            return response;
		}

		public static Task<T> ExecuteAsync<T> (RestRequest request, RestClient client) where T : new()
		{
			Console.WriteLine ("EXECUTING ASYNC");
			var taskCompletionSource = new TaskCompletionSource<T> ();
			client.ExecuteAsync<T> (request, (response) => taskCompletionSource.SetResult (response.Data));
			Console.WriteLine ("FINISHED EXECUTING ASYNC");
			return taskCompletionSource.Task;
		}
	}
}
