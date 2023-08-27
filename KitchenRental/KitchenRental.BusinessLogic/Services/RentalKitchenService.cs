using KitchenRental.BusinessLogic.Contracts;
using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Contracts.OperationResults.RentalKitchen;
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

		public async Task<RentalKitchenResultCode> Update(RentalKitchenBla kitchenBla)
		{
			var existingKitchen = await _rentalKitchenDataManager.GetById(kitchenBla.Id);

			if (existingKitchen is null)
				return RentalKitchenResultCode.NotFound;

			await _rentalKitchenDataManager.Update(kitchenBla);

			return RentalKitchenResultCode.NoContent;
		}

		public async Task<DeleteResult> Delete(int id)
		{
			var existingKitchen = await _rentalKitchenDataManager.GetById(id);

			if (existingKitchen is null)
				return DeleteResult.NotFound;

			await _rentalKitchenDataManager.Delete(id);
			_sequenceProvider.Add(id);

			return DeleteResult.NoContent;
		}
	}
}