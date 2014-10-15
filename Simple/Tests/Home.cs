using System.Net.Http;
using NUnit.Framework;

namespace Echo.Tests
{
	[TestFixture]
	public class Home
	{
		[Category("Simple")]
		[Test]
		public async void Calling_Home_Without_An_Id_Should_Return_Hello_World()
		{
			var response = await TestHelpers.TestServerInstance.Value.HttpClient.GetAsync("/home/");
			var result = await response.Content.ReadAsAsync<string>();
			Assert.AreEqual(result, "Hello world");
		}

		[Category("Simple")]
		[Test]
		public async void Calling_Home_With_An_Id_Of_fish_Should_Return_FISH()
		{
			var response = await TestHelpers.TestServerInstance.Value.HttpClient.GetAsync("/home/fish");
			var result = await response.Content.ReadAsAsync<string>();
			Assert.AreEqual(result, "FISH");
		}

		[Category("Simple")]
		[Test]
		public async void Calling_Home_With_An_Id_Of_CHIPS_Should_Return_CHIPS()
		{
			var response = await TestHelpers.TestServerInstance.Value.HttpClient.GetAsync("/home/fish");
			var result = await response.Content.ReadAsAsync<string>();
			Assert.AreEqual(result, "FISH");
		}

		[Category("Simple")]
		[Test]
		public async void Calling_Home_With_An_Id_Of_glue_Should_Return_GLUE()
		{
			var response = await TestHelpers.TestServerInstance.Value.HttpClient.GetAsync("/home/fish");
			var result = await response.Content.ReadAsAsync<string>();
			Assert.AreEqual(result, "FISH");
		}
	}
}
