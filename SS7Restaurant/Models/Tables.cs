using System;
using System.ComponentModel.DataAnnotations;

namespace SS7Restaurant.Models
{
	public class Tables
	{
		[Key]
		public Guid TableId { get; set; }
		[Required]
		[MaxLength(3)]
		[Display(Name ="Table Number")]
		public string TableNumber { get; set; }
		[MaxLength(100)]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
	}
}

