using KitchenRental.BusinessLogic.Contracts;
using KitchenRental.BusinessLogic.Contracts.DataManagers;
using KitchenRental.BusinessLogic.Contracts.Services;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.BusinessLogic.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Services
{
	public class RentalKitchenService : IRentalKitchenService
	{
		private readonly IKitchenDataManager _rentalKitchenDataManager;
		private readonly IEquipmentService _equipmentService;
		private readonly SequenceProvider _sequenceProvider;

		public RentalKitchenService(IKitchenDataManager rentalKitchenDataManager, SequenceProvider sequenceProvider, IEquipmentService equipmentService)
		{
			_rentalKitchenDataManager = rentalKitchenDataManager;
			_sequenceProvider = sequenceProvider;
			_equipmentService = equipmentService;
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
			var kitchen = await _rentalKitchenDataManager.GetById(kitchenBla.Id);

			if (kitchen is null)
				return RentalKitchenResultCode.NotFound;

			await _rentalKitchenDataManager.Update(kitchenBla);

			return RentalKitchenResultCode.Success;
		}

		public async Task<RentalKitchenResultCode> Delete(int id)
		{
			var kitchen = await _rentalKitchenDataManager.GetById(id);

			if (kitchen is null)
				return RentalKitchenResultCode.NotFound;

			await _rentalKitchenDataManager.Delete(id);
			_sequenceProvider.Add(id);

			return RentalKitchenResultCode.Success;
		}

		public async Task<RentalKitchenResultCode> EquipKitchen(int kitchenId, EquipKitchenRequestBla requestBla)
		{
			var kitchen =await _rentalKitchenDataManager.GetById(kitchenId);

			var equipments =await _equipmentService.Get(requestBla.EquipmentIds);

			kitchen.Equipments.AddRange(equipments);

			await _rentalKitchenDataManager.EquipKitchen(kitchenId, equipments);

			return RentalKitchenResultCode.Success;
		}

		public async Task<RentalKitchenResultCode> RemoveEquipments(int kitchenId, RemoveEquipmentsRequestBla requestBla)
		{
			var kitchen = await _rentalKitchenDataManager.GetById(kitchenId);

			var equipmentsToRemove = await _equipmentService.Get(requestBla.EquipmentIds);

			foreach (var equipment in equipmentsToRemove)
			{
				kitchen.Equipments.Remove(equipment);
			}
			
			await _rentalKitchenDataManager.RemoveEquipments(kitchenId, equipmentsToRemove);

			return RentalKitchenResultCode.Success;
		}
	}
}