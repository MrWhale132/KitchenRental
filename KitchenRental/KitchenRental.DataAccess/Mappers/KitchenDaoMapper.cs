using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.DataAccess.Models.DataTransferObjects;
using System.Linq;

namespace KitchenRental.DataAccess.Mappers
{
	public class KitchenDaoMapper
	{
		public RentalKitchenBla Map(RentalKitchenDto dto)
		{
			if (dto is null) return null;

			return new RentalKitchenBla
			{
				Id = dto.Id,
				Description = dto.Description,
				Equipments = dto.Equipments?.Select(x => new EquipmentBla { Id = x.Id, Name = x.Name, KitchenId = x.RentalKitchenDtoId }).ToList(),
				FloorArea = dto.FloorArea,
				Name = dto.Name,
				RentPricePerMinute = dto.RentPricePerMinute,
				WorkingArea = dto.WorkingArea
			};
		}

		public RentalKitchenDto Map(RentalKitchenBla bla)
		{
			return new RentalKitchenDto
			{
				Id = bla.Id,
				Description = bla.Description,
				Equipments = bla.Equipments?.Select(x => new EquipmentDto { Id = x.Id, Name = x.Name }).ToList(),
				FloorArea = bla.FloorArea,
				Name = bla.Name,
				RentPricePerMinute = bla.RentPricePerMinute,
				WorkingArea = bla.WorkingArea
			};
		}
	}
}