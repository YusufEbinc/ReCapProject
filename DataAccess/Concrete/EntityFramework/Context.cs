using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public  class Context :DbContext
		
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapDatabase;Trusted_Connection=true");

		}

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
		public DbSet<CarDetailDto> CarDetailDtos { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Rental> Rentals { get; set; }
		public DbSet<Customer> Customers { get; set; }

	}
}
