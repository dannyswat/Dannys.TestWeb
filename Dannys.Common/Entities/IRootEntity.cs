using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public interface IRootEntity : IEntity
	{
		ActionSummary Created { get; set; }
		ActionSummary LastModified { get; set; }
	}
}
