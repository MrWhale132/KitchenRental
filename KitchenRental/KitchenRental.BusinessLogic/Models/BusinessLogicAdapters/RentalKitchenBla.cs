using System.Collections.Generic;

namespace KitchenRental.BusinessLogic.Models.BusinessLogicAdapters
{
	public  class RentalKitchenBla
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int FloorArea { get; set; }
		public int WorkingArea { get; set; }
		public double RentPricePerMinute { get; set; }
		public List<EquipmentBla> Equipments { get; set; }
	}
}