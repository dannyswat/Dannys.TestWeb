using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.DataModels
{
	public class Address
	{
		[Required, StringLength(60)]
		public string AddressField1 { get; set; }

		[StringLength(60)]
		public string AddressField2 { get; set; }

		[StringLength(50)]
		public string CityOrLocality { get; set; }

		[StringLength(50)]
		public string StateOrProvince { get; set; }

		[StringLength(12)]
		public string PostalCode { get; set; }

		[Required, StringLength(2)]
		public string Country { get; set; }
	}
}
