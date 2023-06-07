using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.DataAccess.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRental.DataAccess.DataManagers.RentalKitchenDataManager
{
	public class RentalKitchenDataManager : IRentalKitchenDataManager
	{
		private readonly DataContext _dataContext;

		public RentalKitchenDataManager(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<IEnumerable<RentalKitchenBla>> GetAll()
		{
			var dtos = await _dataContext.RentalKitchens.ToListAsync();
			return dtos.Select(dto => new RentalKitchenBla
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

		public async Task<RentalKitchenBla> GetById(int id)
		{
			var dto = await _dataContext.RentalKitchens.SingleOrDefaultAsync(x => x.Id == id);

			return new RentalKitchenBla
			{
				Id = dto.Id,
				Name = dto.Name,
				Description = dto.Description,
				Equipments = dto.Equipments,
				FloorArea = dto.FloorArea,
				RentPricePerMinute = dto.RentPricePerMinute,
				WorkingArea = dto.WorkingArea
			};
		}

		public async Task Create(RentalKitchenBla kitchenBla)
		{
			var dto = new RentalKitchenDto
			{
				Id = kitchenBla.Id,
				Name = kitchenBla.Name
			};

			_dataContext.RentalKitchens.Add(dto);

			await _dataContext.SaveChangesAsync();
		}

		public async Task Update(RentalKitchenBla kitchenBla)
		{
			var dto = new RentalKitchenDto
			{
				Id = kitchenBla.Id,
				Name = kitchenBla.Name
			};
			_dataContext.RentalKitchens.Update(dto);

			await _dataContext.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var dto = new RentalKitchenDto
			{
				Id = id
			};

			_dataContext.RentalKitchens.Remove(dto);

			await _dataContext.SaveChangesAsync();
		}
	}
}