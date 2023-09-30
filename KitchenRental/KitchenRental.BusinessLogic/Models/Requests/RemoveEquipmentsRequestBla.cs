using System.Collections.Generic;

namespace KitchenRental.BusinessLogic.Models.Requests
{
	public class RemoveEquipmentsRequestBla
	{
		public IEnumerable<int> EquipmentIds { get; set; }
	}
}