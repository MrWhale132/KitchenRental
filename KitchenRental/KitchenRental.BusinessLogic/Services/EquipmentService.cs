using KitchenRental.BusinessLogic.Contracts.DataManagers;
using KitchenRental.BusinessLogic.Contracts.Services;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Services
{
	public class EquipmentService: IEquipmentService
	{
		private readonly IKitchenDataManager _equiptmentDataManager;

		public EquipmentService(IKitchenDataManager equiptmentDataManager)
		{
			_equiptmentDataManager = equiptmentDataManager;
		}

		public async Task<IEnumerable<EquipmentBla>> Get(IEnumerable<int> equipmentIds)
		{
			return await _equiptmentDataManager.Get(equipmentIds);
		}

		public async Task<int> Create(EquipmentBla equipmentBla)
		{

			return await _equiptmentDataManager.Create(equipmentBla);
		}
	}
}