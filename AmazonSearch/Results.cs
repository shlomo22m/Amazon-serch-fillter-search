using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSearch
{
	internal class Results
	{
		//IList<IWebElement> elements = new IList<IWebElement>();
		private string xpath = "//div[@class='a-section a-spacing-small a-spacing-top-small'";
		private IWebDriver driver;
		public Results(IWebDriver driver) 
		{
			this.driver = driver;
		}

		public void  GetResultBy(Dictionary<string,string> filter) 
		{
			//string xpath = "//div[@class='a-section a-spacing-small a-spacing-top-small'";
			foreach (var filterxpath in filter)
			{
				switch (filterxpath.Key)
				{
					case "Price_Lower_Then":
						xpath += "and descendant::span[@class = 'a-price-whole' and text() >="+ filterxpath.Value;
						break;
					case "Price_Hiegher_OR_Equal_Then":
						xpath += "and text()>="+ filterxpath.Value;
						break;
					case "Free_Shipping":
						if (filterxpath.Value == "true") xpath += "]and descendant::span[contains(text(), 'FREE')]";
						break;
				}
			}
			xpath += "]";

			 List<IWebElement> elements = driver.FindElements(By.XPath(xpath)).ToList();
			foreach (IWebElement element in elements)
			{
				Console.WriteLine(element.Text);
			}
		}

	}
}
