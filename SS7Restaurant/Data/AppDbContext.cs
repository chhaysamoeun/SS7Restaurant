using System;
using Microsoft.EntityFrameworkCore;
using SS7Restaurant.Models;

namespace SS7Restaurant.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			:base(options)
		{
		}
		public DbSet<Customer> Customer { get; set; }
	}
}

