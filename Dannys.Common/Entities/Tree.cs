using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public class Tree<TEntity> where TEntity : IEntity
	{
		public int SortOrder { get; set; }

		public int ParentId { get; set; }

		public int Id { get; set; }

		public TEntity Parent { get; set; }

		public TEntity Child { get; set; }
	}
}
