using KitchenRental.DataAccess.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace KitchenRental.DataAccess
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<RentalKitchenDto> RentalKitchens { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<RentalKitchenDto>()
				.Property(p => p.Equipments)
				.HasConversion(
					toDb => string.Join(',', toDb),
					fromDb => fromDb.Split(',', StringSplitOptions.None).ToList());
		}
	}
}