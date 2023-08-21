using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenRental.DataAccess.Models.DataTransferObjects
{
	public class RentalKitchenDto
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int FloorArea { get; set; }
		public int WorkingArea { get; set; }
		public double RentPricePerMinute { get; set; }
		public List<EquipmentDto> Equipments { get; set; } = new List<EquipmentDto>();
	}
}