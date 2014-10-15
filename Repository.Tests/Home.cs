using Microsoft.Owin.Testing;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Repository.Web;
using Repository.Web.Repositories;
using System.Collections.Generic;
using System.Net.Http;

namespace Repository.Tests
{
	[TestFixture]
	public class Home
	{
		[Category("Repository")]
		[Test]
		public async void Calling_Home_Should_Return_Objects()
		{
			var testServer = TestServer.Create<Repository.Web.Startup>();
			//We are cheating here and using the fact that unity gives back the last type registered
			UnityHelpers.GetConfiguredContainer().RegisterType<IItemRepository, TestItemRepository>();

			var response = await testServer.HttpClient.GetAsync("/home/");
			var result = await response.Content.ReadAsAsync<IList<string>>();
			Assert.AreEqual(result[0], "TestItem");
		}
	}
}
