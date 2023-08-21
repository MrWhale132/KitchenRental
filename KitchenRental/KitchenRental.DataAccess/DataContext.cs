using KitchenRental.DataAccess.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace KitchenRental.DataAccess
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<RentalKitchenDto> RentalKitchens { get; set; }
		public DbSet<EquipmentDto> Equipments { get; set; }

	}
}