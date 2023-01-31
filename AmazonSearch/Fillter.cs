using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSearch
{
	internal class Fillter
	{
		private IWebDriver driver;

		public Fillter(IWebDriver driver)
		{
			this.driver = driver;
		}

		public string Minprice
		{
			set
			{
				this.driver.FindElement(By.Id("low-price")).SendKeys(value);
			}
			
	    }

		public string Maxprice
		{
			set
			{
				this.driver.FindElement(By.Id("high-price")).SendKeys(value);
			}

		}

		public void Click()
		{
			//click to search
			this.driver.FindElement(By.Id("a-autoid-1-announce")).Click();
		}

	}
}
