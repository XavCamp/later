using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Later.Models
{
	public class Capsule
	{
		[Key]
		[MaxLength(50)]
		public string ID { get; private set; }

		[Required]
		public string Message { get; private set; }

		public DateTime Deadline { get; private set; }
	}
}