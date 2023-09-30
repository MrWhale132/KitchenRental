using System.Collections.Generic;

namespace KitchenRental.Application.Models.Requests.RentalKitchen
{
	public class EquipKitchenRequest
	{
		public IEnumerable<int> EquipmentIds { get; set; }
	}
}