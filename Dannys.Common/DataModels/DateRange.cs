using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.DataModels
{
	/// <summary>
	/// Date range. Will change DateTime to DateOnly in .NET 6
	/// </summary>
	public class DateRange
	{
		public DateTime From { get; set; }

		public DateTime Until { get; set; }
	}
}
