using System.Collections.Generic;

namespace KitchenRental.Application.Models.Requests.RentalKitchen
{
	public class RemoveEquipmentsRequest
	{
		public IEnumerable<int> EquipmentIds { get; set; }
	}
}