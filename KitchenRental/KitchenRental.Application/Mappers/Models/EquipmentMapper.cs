using KitchenRental.Application.Models.Contracts.RentalKitchen;
using KitchenRental.Application.Models.Requests.Equipments;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;

namespace KitchenRental.Application.Mappers.Models
{
	public class EquipmentMapper
	{
		public EquipmentBla Map(CreateEquipmentRequest request)
		{
			return new EquipmentBla
			{
				Name = request.Name,
			};
		}

		public EquipmentContract Map(EquipmentBla bla)
		{
			return new EquipmentContract
			{
				Id= bla.Id,
				Name = bla.Name,
				KitchenId = bla.KitchenId
			};
		}
	}
}