using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using Xunit;

namespace MongoExample.Tests
{
	public class ProductTests
	{
		[Trait("Category", "Mongo")]
		[Fact]
		public async void Adding_A_Product_Should_Return_The_Product()
		{
			TestHelpers.DestroyAllData();

			dynamic formVars = new ExpandoObject();
			formVars.Name = "fish";

			var response = await TestHelpers.TestServerInstance.Value.HttpClient.PostAsync("/products/add", TestHelpers.DynamicToFormData(formVars));
			var result = await response.Content.ReadAsStringAsync();
			dynamic addResult = JsonConvert.DeserializeObject<ExpandoObject>(result);
			Assert.Equal(addResult.Name, "fish");
		}

		[Trait("Category", "Mongo")]
		[Fact]
		public async void Getting_All_Products_Should_Return_All_Products()
		{
			dynamic formVars = new ExpandoObject();
			formVars.Name = "alpha";
			await TestHelpers.TestServerInstance.Value.HttpClient.PostAsync("/products/add", TestHelpers.DynamicToFormData(formVars));

			formVars.Name = "omega";
			await TestHelpers.TestServerInstance.Value.HttpClient.PostAsync("/products/add", TestHelpers.DynamicToFormData(formVars));

			var response = await TestHelpers.TestServerInstance.Value.HttpClient.GetAsync("/products/");
			var result = await response.Content.ReadAsAsync<List<object>>();
			Assert.Equal(result.Count, 2);
		}
	}
}
