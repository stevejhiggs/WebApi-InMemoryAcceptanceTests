using Microsoft.Owin.Testing;
using MongoExample.Web.App_Start;
using MongoExample.Web.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MongoExample.Tests
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

		public static bool DestroyAllData()
		{
			return MongoConnection.Client.GetServer().DropDatabase(MongoConnection.DatabaseName).Ok;
		}
	}
}
