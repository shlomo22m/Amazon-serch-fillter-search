using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AmazonSearch
{
	public class BrowserFactory
	{
		public IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
		public IWebDriver driver;
		public IWebDriver Driver
		{
			get
			{
				if (driver == null)
					throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
				return driver;
			}
			private set
			{
				this.driver = value;
			}
		}
		public IWebDriver InitBrowser(string browserName)
		{
			switch (browserName)
			{
				case "Firefox":
					if (!Drivers.ContainsKey("FIREFOX"))
					{
						driver = new FirefoxDriver("D:\\Drivers\\");
						Drivers.Add("Firefox", driver);
					}
					break;

				case "Edge":
					if (!Drivers.ContainsKey("Edge"))
					{
						driver = new InternetExplorerDriver("D:\\Drivers\\");
						Drivers.Add("Edge", driver);
					}
					break;

				case "Chrome":
					if (!Drivers.ContainsKey("CHROME"))
					{
						driver = new ChromeDriver("D:\\Drivers\\");
						Drivers.Add("Chrome", driver);
					}
					break;
			}
			return driver;
		}

	}
}


