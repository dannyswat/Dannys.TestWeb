using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dannys.Common;

namespace Dannys.Customers
{
	public class Customer : IRootEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public ActionSummary Created { get; set; }

		public ActionSummary LastModified { get; set; }
	}
}
