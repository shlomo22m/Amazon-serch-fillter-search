using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSearch
{
	internal class Amazon
	{
		private Pages page;
		private IWebDriver driver;

		public Amazon(IWebDriver driver) 
		{
			this.driver = driver;
		}

		public Pages Pages
		{
			get 
			{ 
				if(this.page == null)
				{
					this.page = new Pages(this.driver);
				}
				return this.page;
			}
		
		
		}
		
	}
}

