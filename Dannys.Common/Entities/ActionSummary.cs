using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public class ActionSummary
	{
		public ActionSummary(string user)
        {
			By = user;
			At = DateTimeOffset.Now;
        }
		public DateTimeOffset At { get; set; }

		public string By { get; set; }
	}
}
