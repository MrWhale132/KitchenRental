using System.Collections.Generic;

namespace KitchenRental.BusinessLogic.Models.Requests
{
	public class EquipKitchenRequestBla
	{
		public IEnumerable<int> EquipmentIds { get; set; }
	}
}