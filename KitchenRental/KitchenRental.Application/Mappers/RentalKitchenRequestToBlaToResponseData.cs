using KitchenRental.Application.Models.Requests;
using KitchenRental.Application.Models.Responses;
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

		public RentalKitchenDto Map(RentalKitchenBla bla)
		{
			return new RentalKitchenDto
			{
				Id = bla.Id,
				Description = bla.Description,
				WorkingArea = bla.WorkingArea,
				Equipments = bla.Equipments?.Select(x => new EquipmentDto { Id = x.Id, Name = x.Name }).ToList(),
				FloorArea = bla.FloorArea,
				Name = bla.Name,
				RentPricePerMinute = bla.RentPricePerMinute
			};
		}
	}
}