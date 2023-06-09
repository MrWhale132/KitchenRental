using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.DataAccess.Mappers;
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
		private readonly RentalKitchenDtoBlaMapper _mapper;

		public RentalKitchenDataManager(DataContext dataContext, RentalKitchenDtoBlaMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}

		public async Task<IEnumerable<RentalKitchenBla>> GetAll()
		{
			var dtos = await _dataContext.RentalKitchens.ToListAsync();
			return dtos.Select(_mapper.Map);
		}

		public async Task<RentalKitchenBla> GetById(int id)
		{
			var dto = await _dataContext.RentalKitchens.SingleOrDefaultAsync(x => x.Id == id);

			return _mapper.Map(dto);
		}

		public async Task Create(RentalKitchenBla kitchenBla)
		{
			var dto = _mapper.Map(kitchenBla);

			_dataContext.RentalKitchens.Add(dto);

			await _dataContext.SaveChangesAsync();
		}

		public async Task Update(RentalKitchenBla kitchenBla)
		{
			var dto = _mapper.Map(kitchenBla);

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