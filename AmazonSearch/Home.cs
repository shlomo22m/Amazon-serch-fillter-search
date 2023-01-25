using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSearch
{
	public class Home
	{
		private SearchBar searchbar;
		private IWebDriver driver;
		public Home(IWebDriver driver)
		{
			this.driver = driver;
			this.driver.Navigate().GoToUrl("https://www.amazon.com/?language=en_US&currency=USD");
			this.driver.Manage().Window.Maximize();
		}

		public SearchBar SearchBar 
		{
			get
			{
				if(this.searchbar == null)
				{
					this.searchbar = new SearchBar(this.driver);
				}
				return this.searchbar;
			}
		}
	}
}
