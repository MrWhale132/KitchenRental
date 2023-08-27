using KitchenRental.Application.Models.Contracts.RentalKitchen;
using KitchenRental.Application.Models.Requests;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using System.Linq;

namespace KitchenRental.Application.Mappers
{
    public class RentalKitchenRequestToBlaToResponseData
	{
		public RentalKitchenBla Map(CreateRentalKitchenRequest request)
		{
			return new RentalKitchenBla
			{
				Description = request.Description,
				Equipments = request.Equipments?.Select(x => new EquipmentBla { Id = x.Id, Name = x.Name }).ToList(),
				FloorArea = request.FloorArea,
				Name = request.Name,
				RentPricePerMinute = request.RentPricePerMinute,
				WorkingArea = request.WorkingArea
			};
		}

		public RentalKitchenBla Map(UpdateRentalKitchenRequest request)
		{
			return new RentalKitchenBla
			{
				Description = request.Description,
				Equipments = request.Equipments?.Select(x => new EquipmentBla { Id = x.Id, Name = x.Name }).ToList(),
				FloorArea = request.FloorArea,
				Name = request.Name,
				RentPricePerMinute = request.RentPricePerMinute,
				WorkingArea = request.WorkingArea
			};
		}

		public RentalKitchenContract Map(RentalKitchenBla bla)
		{
			if(bla is null) return null;

			return new RentalKitchenContract
			{
				Id = bla.Id,
				Description = bla.Description,
				WorkingArea = bla.WorkingArea,
				Equipments = bla.Equipments?.Select(x => new EquipmentContract { Id = x.Id, Name = x.Name }).ToList(),
				FloorArea = bla.FloorArea,
				Name = bla.Name,
				RentPricePerMinute = bla.RentPricePerMinute
			};
		}
	}
}