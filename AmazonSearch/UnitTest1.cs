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
		BrowserFactory chromedriver = new BrowserFactory();
		IWebDriver drive1;
		Amazon amazon;
		new Dictionary<string, string> itemfilter = new Dictionary<string, string>();



		[SetUp]
		public void Setup()
		{
			
			drive1 = chromedriver.InitBrowser("Chrome");
			amazon = new Amazon(drive1);
			itemfilter.Add("Price_Lower_Then", "100");
			itemfilter.Add("Price_Hiegher_OR_Equal_Then", "50");
			itemfilter.Add("Free_Shipping", "true");

		}

		[Test]
		public void Test1()
		{

			amazon.Pages.Home.SearchBar.Text = "mouse";
			amazon.Pages.Home.SearchBar.Click();
			amazon.Pages.Results.GetResultBy(itemfilter);

		}
	}
}