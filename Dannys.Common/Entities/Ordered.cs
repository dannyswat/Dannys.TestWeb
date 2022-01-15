using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public class Ordered<THeader, TLine> where THeader : IEntity where TLine : IEntity
	{
		public int SortOrder { get; set; }

		public int HeaderId { get; set; }

		public int LineId { get; set; }

		public THeader Header { get; set; }

		public TLine Line { get; set; }
	}
}
