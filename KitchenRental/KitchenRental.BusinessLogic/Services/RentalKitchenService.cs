using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Contracts.Services;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Services
{
	public class RentalKitchenService : IRentalKitchenService
	{
		private readonly IRentalKitchenDataManager _rentalKitchenDataManager;
		private readonly SequenceProvider _sequenceProvider;

		public RentalKitchenService(IRentalKitchenDataManager rentalKitchenDataManager, SequenceProvider sequenceProvider)
		{
			_rentalKitchenDataManager = rentalKitchenDataManager;
			_sequenceProvider = sequenceProvider;
		}

		public async Task<IEnumerable<RentalKitchenBla>> GetAll()
		{
			return await _rentalKitchenDataManager.GetAll();
		}

		public async Task<RentalKitchenBla> GetById(int id)
		{
			return await _rentalKitchenDataManager.GetById(id);
		}

		public async Task<int> Create(RentalKitchenBla kitchenBla)
		{
			kitchenBla.Id = _sequenceProvider.Next();
			await _rentalKitchenDataManager.Create(kitchenBla);
			return kitchenBla.Id;
		}

		public async Task Update(RentalKitchenBla kitchenBla)
		{
			await _rentalKitchenDataManager.Update(kitchenBla);
		}

		public async Task Delete(int id)
		{
			await _rentalKitchenDataManager.Delete(id);
			_sequenceProvider.Add(id);
		}
	}
}