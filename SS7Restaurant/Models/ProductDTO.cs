using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace SS7Restaurant.Models
{
	public class ProductDTO
	{
        [Key]
        public Guid ProductId { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }

        public Category Category { get; set; }
    }
}

