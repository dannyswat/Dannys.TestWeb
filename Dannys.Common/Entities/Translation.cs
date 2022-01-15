using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public class Translation<TEntity> : List<Localized<TEntity>> where TEntity : class
	{
	}

	public class Localized<TEntity> where TEntity : class
	{
		public string Locale { get; set; }

		public TEntity Content { get; set; }
	}
}
