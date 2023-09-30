using KitchenRental.Application.Models.Contracts.RentalKitchen;
using System.Collections.Generic;

namespace KitchenRental.Application.Models.Datas.Equipment
{
	public class GetEquipmentData
	{
		public IEnumerable<EquipmentContract> Equipments { get; set; }
	}
}