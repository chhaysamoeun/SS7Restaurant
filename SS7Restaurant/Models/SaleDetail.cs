using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS7Restaurant.Models
{
	public class SaleDetail
	{
		[Key]
		public Guid SaleDetailId { get; set; }
        [ForeignKey("Sale")]
        public Guid SaleId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
		public double Price { get; set; }
		public int Qty { get; set; }
		public double Amount { get; set; }

		public Sale Sale { get; set; }
		public Product Product { get; set; }
	}
}

