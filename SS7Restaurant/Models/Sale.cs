using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS7Restaurant.Models
{
	public class Sale
	{
		[Key]
		public Guid SaleId { get; set; }
		[ForeignKey("Customer")]
		public Guid CustomerId { get; set; }
        [ForeignKey("Tables")]
        public Guid TableId { get; set; }
		[MaxLength(20)]
		public string InvoiceNumber { get; set; }
		[Display(Name ="Issue Date")]
		[DataType(DataType.Date)]
		public DateTime IssueDate { get; set; }
		public double Total { get; set; }
		public int Discount { get; set; }
		public double GrandTotal { get; set; }

		public Customer Customer { get; set; }
		public Tables Tables { get; set; }
	}
}

