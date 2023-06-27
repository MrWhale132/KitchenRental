using KitchenRental.Application.Models.Requests;
using KitchenRental.Application.Models.Responses;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;

namespace KitchenRental.Application.Mappers
{
	public class RentalKitchenRequestToBlaToResponseData
	{
		public RentalKitchenBla Map(CreateRentalKitchenRequest request)
		{
			return new RentalKitchenBla
			{
				Description = request.Description,
				Equipments = request.Equipments,
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
				Equipments = request.Equipments,
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
				Equipments = bla.Equipments,
				FloorArea = bla.FloorArea,
				Name = bla.Name,
				RentPricePerMinute = bla.RentPricePerMinute
			};
		}
	}
}