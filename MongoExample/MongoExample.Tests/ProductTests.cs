using MongoExample.Web.Storage;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;

namespace MongoExample.Tests
{
	[TestFixture]
	public class ProductTests
	{
		[Category("Mongo")]
		[Test]
		public async void Adding_A_Product_Should_Return_The_Product()
		{
			MongoConnection.Configure("mongodb://localhost", "owinMongoTest");
			TestHelpers.DestroyAllData();

			dynamic formVars = new ExpandoObject();
			formVars.Name = "fish";

			var response = await TestHelpers.TestServerInstance.Value.HttpClient.PostAsync("/products/add", TestHelpers.DynamicToFormData(formVars));
			var result = await response.Content.ReadAsStringAsync();
			dynamic addResult = JsonConvert.DeserializeObject<ExpandoObject>(result);
			Assert.AreEqual(addResult.Name, "fish");
		}

		[Category("Mongo")]
		[Test]
		public async void Getting_All_Products_Should_Return_All_Products()
		{
			MongoConnection.Configure("mongodb://localhost", "owinMongoTest");
			TestHelpers.DestroyAllData();

			dynamic formVars = new ExpandoObject();
			formVars.Name = "alpha";
			await TestHelpers.TestServerInstance.Value.HttpClient.PostAsync("/products/add", TestHelpers.DynamicToFormData(formVars));

			formVars.Name = "omega";
			await TestHelpers.TestServerInstance.Value.HttpClient.PostAsync("/products/add", TestHelpers.DynamicToFormData(formVars));

			var response = await TestHelpers.TestServerInstance.Value.HttpClient.GetAsync("/products/");
			var result = await response.Content.ReadAsAsync<List<object>>();
			Assert.AreEqual(result.Count, 2);
		}
	}
}
