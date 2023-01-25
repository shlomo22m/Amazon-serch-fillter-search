using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
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
		IWebDriver edge;
		Amazon amazon;
		new Dictionary<string, string> itemfilter = new Dictionary<string, string>();



		[SetUp]
		public void Setup()
		{
			chrome = browserFactory.InitBrowser("Chrome");
			//edge = browserFactory.InitBrowser("Edge");
			edge = browserFactory.Drivers["Chrome"];
			amazon = new Amazon(chrome);


		}

		[Test]
		public void Test1()
		{
			
			//search product
			amazon.Pages.Home.SearchBar.Text = "mouse";
			amazon.Pages.Home.SearchBar.Click();

			//creat a result list after filltering
			List<Item> items =amazon.Pages.Results.GetResultBy(new Dictionary<string, string>() {
				{ "Price_Lower_Then", "100" },{"Price_Hiegher_OR_Equal_Then", "50" },{"Free_Shipping", "true"}});

			foreach (Item item in items)
			{
				Console.WriteLine(item.Title);
				Console.WriteLine(item.Price + "\n");
			}
			Assert.Pass();

		}



	}
}