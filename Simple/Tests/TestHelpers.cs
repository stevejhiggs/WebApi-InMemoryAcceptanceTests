using Echo.Web;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Echo.Tests
{
	public class TestHelpers
	{
		public static Lazy<TestServer> TestServerInstance = new Lazy<TestServer>(() => TestServer.Create<Startup>());

		public static FormUrlEncodedContent DynamicToFormData(dynamic data)
		{
			var serialisedData = JsonConvert.SerializeObject(data);
			var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(serialisedData);
			return new FormUrlEncodedContent(dict);
		}
	}
}
