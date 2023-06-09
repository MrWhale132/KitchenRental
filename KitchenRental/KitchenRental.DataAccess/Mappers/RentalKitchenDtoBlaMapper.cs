using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.DataAccess.Models.DataTransferObjects;

namespace KitchenRental.DataAccess.Mappers
{
	public class RentalKitchenDtoBlaMapper
	{
		public RentalKitchenBla Map(RentalKitchenDto dto)
		{
			return new RentalKitchenBla
			{
				Id = dto.Id,
				Description = dto.Description,
				Equipments = dto.Equipments,
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
				Equipments= bla.Equipments,
				FloorArea = bla.FloorArea,
				Name = bla.Name,
				RentPricePerMinute = bla.RentPricePerMinute,
				WorkingArea= bla.WorkingArea
			};
		}
	}
}