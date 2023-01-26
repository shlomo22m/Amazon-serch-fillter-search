using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSearch
{
	internal class Item
	{
		private string title;
		private string price;
		private string url;

		public Item(string title, string price,string url)
		{
			this.title = title;
			this.price = price;
			this.url = url;

		}

		public string Title
		{
			get
			{
				return this.title;
			}
		}
		public string Price
		{
			get
			{
				return this.price;
			}
		}

		public string Url
		{
			get
			{
				return this.url;
			}
		}
	}
}
