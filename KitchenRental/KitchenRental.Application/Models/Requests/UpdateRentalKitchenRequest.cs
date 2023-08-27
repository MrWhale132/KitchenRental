using KitchenRental.Application.Models.Contracts.RentalKitchen;
using System.Collections.Generic;

namespace KitchenRental.Application.Models.Requests
{
    public class UpdateRentalKitchenRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int FloorArea { get; set; }
		public int WorkingArea { get; set; }
		public double RentPricePerMinute { get; set; }
		public List<EquipmentContract> Equipments { get; set; }
	}
}