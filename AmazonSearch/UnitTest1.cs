using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSearch
{


	public class Tests
	{
		List<IWebElement> mouses = new List<IWebElement>();
		BrowserFactory browserFactory = new BrowserFactory();
		IWebDriver chrome;
		IWebDriver firefox;

		//create a Dictionary for fillter
		Dictionary<string, string> itemlist= new Dictionary<string, string>() {
				{ "Price_Lower_Then", "100" },{"Price_Hiegher_OR_Equal_Then", "10" },{"Free_Shipping", "true"}};
		Amazon amazon;

		[SetUp]
		public void Setup()
		{
			//create a chrome driver
			chrome = browserFactory.InitBrowser("Chrome");
			chrome = browserFactory.Drivers["Chrome"];

			//create a firefox driver
			firefox = browserFactory.InitBrowser("FireFox");
			firefox = browserFactory.Drivers["Firefox"];
		}

		[Test]
		public void ChromeTest()
		{



			amazon = new Amazon(chrome);

			//search product
			amazon.Pages.Home.SearchBar.Text = "mouse";
			amazon.Pages.Home.SearchBar.Click();

			//creat a result list after filltering
			List<Item> items =amazon.Pages.Results.GetResultBy(itemlist);

			//display search resulr
			foreach (Item item in items)
			{
				Console.WriteLine(item.Title);
				Console.WriteLine(item.Price + "\n");
				Console.WriteLine(item.Url);
			}
			Assert.Pass();
		}

		[Test]
		public void FirefoxTest()
		{
			
			amazon = new Amazon(firefox);

			//search product
			amazon.Pages.Home.SearchBar.Text = "mouse";
			amazon.Pages.Home.SearchBar.Click();

			//creat a result list after filltering
			List<Item> items = amazon.Pages.Results.GetResultBy(itemlist);


			//display search resulr
			foreach (Item item in items)
			{
				Console.WriteLine(item.Title);
				Console.WriteLine(item.Price + "\n");
				Console.WriteLine(item.Url);
			}
			Assert.Pass();
		}

		[TearDown]
		public void closeBrowser()
		{
			//close web drivers
			browserFactory.CloseAllDrivers();
		}


	}
}