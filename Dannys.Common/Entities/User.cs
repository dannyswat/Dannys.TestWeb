using Dannys.Common.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public class User : IRootEntity
	{
		[Key]
		public int Id { get; set; }

		[Required, StringLength(50)]
		public string UserName { get; set; }

		[JsonIgnore]
		public Password Password { get; set; }

		public string EmailAddress { get; set; }
		public bool EmailVerified { get; set; }

		public PhoneNumber PhoneNumber { get; set; }
		public bool PhoneVerified { get; set; }

		public ActionSummary Created { get; set; }
		public ActionSummary LastModified { get; set; }
	}
}
