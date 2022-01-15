using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.DataModels
{
	/// <summary>
	/// Time range. Will change DateTime to TimeOnly in .NET 6
	/// </summary>
	public class TimeSlot
	{
		public DateTime From { get; set; }

		public DateTime Until { get; set; }
	}
}
