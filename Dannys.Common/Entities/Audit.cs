using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public class Audit<TEntity> : IEntity where TEntity : IEntity
	{
		public int Id { get; set; }

		public string Action { get; set; }

		public ActionSummary Done { get; set; }

		public int RecordId { get; set; }

		public string RecordKey { get; set; }

		public TEntity Content { get; set; }
	}
}
