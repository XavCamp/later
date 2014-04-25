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
		public string ID { get; set; }
		public string Message { get; set; }
		public DateTime Deadline { get; set; }
	}
}