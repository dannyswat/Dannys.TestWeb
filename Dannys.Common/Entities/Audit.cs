using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public class Audit<TEntity> : IEntity where TEntity : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required, StringLength(20)]
		public string Action { get; set; }

		public ActionSummary Done { get; set; }

		public int RecordId { get; set; }

		[StringLength(50)]
		public string RecordKey { get; set; }

		public TEntity Content { get; set; }
	}
}
