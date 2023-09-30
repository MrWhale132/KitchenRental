using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.DataAccess.Models.DataTransferObjects;

namespace KitchenRental.DataAccess.Mappers
{
	public class EquipmentDaoMapper
	{
		public EquipmentDto Map(EquipmentBla equipmentBla)
		{
			return new EquipmentDto
			{
				Id = equipmentBla.Id,
				Name = equipmentBla.Name
			};
		}

		public EquipmentBla Map(EquipmentDto dto)
		{
			return new EquipmentBla
			{
				Id = dto.Id,
				Name = dto.Name,
				KitchenId = dto.RentalKitchenDtoId
			};
		}
	}
}