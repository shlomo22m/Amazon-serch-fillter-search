﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AmazonSearch
{
	internal class Results
	{
		private string xpath = "//div[@class='a-section a-spacing-small a-spacing-top-small'";
		private IWebDriver driver;
		private Fillter fillter;
		public Results(IWebDriver driver) 
		{
			this.driver = driver;
		}


		public Fillter Fillter
		{
			get
			{
				if (this.fillter == null)
				{
					this.fillter = new Fillter(this.driver);
				}
				return this.fillter;
			}
		}
		public List<Item> GetResultBy(Dictionary<string,string> filter) 
		{
			//preform our fillter search
			foreach (var filterxpath in filter)
			{
				switch (filterxpath.Key)
				{
					case "Price_Lower_Then":
						xpath += "and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class='a-price-decimal']), descendant::span[@class='a-price-fraction']) <" + filterxpath.Value;
						break;
					case "Price_Hiegher_OR_Equal_Then":
						xpath += "and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class='a-price-decimal']),descendant::span[@class='a-price-fraction']) >=" + filterxpath.Value;
						break;
					case "Free_Shipping":
						if (filterxpath.Value == "true") xpath += " and descendant::span[contains(text(), 'FREE')]";

						else
							if (filterxpath.Value == "true") xpath += " and descendant::span[not(contains(text(), 'FREE'))]";
						break;
				}
			}
			xpath += "]";    
			

			//create a web elements list that save the result
			List<IWebElement> elements = driver.FindElements(By.XPath(xpath)).ToList();

			//list that we use to save title price and url
			List<Item> items = new List<Item>();

			foreach (IWebElement element in elements)
			{
				//the the title and the price and add it to the list
				string title = element.FindElement(By.XPath((".//span[@class='a-size-medium a-color-base a-text-normal']"))).Text;
				string price = element.FindElement(By.XPath(".//span[@class='a-price-whole']")).Text + '.' + element.FindElement(By.CssSelector(".a-price-fraction")).Text + '$';
				string url = element.FindElement(By.XPath((".//a[@class='a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']"))).GetAttribute("href");
				items.Add(new Item(title, price,url));
			}
			return items;
		}

	}
}
