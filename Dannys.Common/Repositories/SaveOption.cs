using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public enum SaveOption
	{
		/// <summary>
		/// Default behavior
		/// </summary>
		Default = 0,
		/// <summary>
		/// Write to storage when SaveChanges() is called
		/// </summary>
		ManualSave = 1,
		/// <summary>
		/// Write to storage directly
		/// </summary>
		AutoSave = 2
	}
}
