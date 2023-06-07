using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.DataAccess.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace KitchenRental.DataAccess.DataManagers.RentalKitchenDataManager
{
	public class InMemoryRentalKitchenDataManager 
	{
		List<RentalKitchenDto> _inMemoryDb;

		public InMemoryRentalKitchenDataManager()
		{
			_inMemoryDb = new List<RentalKitchenDto>
			{
				new RentalKitchenDto()
				{
					Id = 0,
					Name= "First",
					Description ="First ever ktichen",
					Equipments = new List<string>
					{
						"Oven","Fridge","Turmix"
					},
					FloorArea = 10,
					RentPricePerMinute= 2,
					WorkingArea = 4
				},
				new RentalKitchenDto()
				{
					Id = 1,
					Name= "Second",
					Description ="Test Kitchen",
					Equipments = new List<string>
					{
						"Oven","Fridge","Toaster"
					},
					FloorArea = 12,
					RentPricePerMinute= 2.2,
					WorkingArea = 6
				}
			};
		}

		public IEnumerable<RentalKitchenBla> GetAll()
		{
			return _inMemoryDb.Select(dto => new RentalKitchenBla
			{
				Id = dto.Id,
				Name = dto.Name,
				Description = dto.Description,
				Equipments = dto.Equipments,
				FloorArea = dto.FloorArea,
				RentPricePerMinute = dto.RentPricePerMinute,
				WorkingArea = dto.WorkingArea
			});
		}
	}
}