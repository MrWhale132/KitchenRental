using KitchenRental.BusinessLogic.Contracts.OperationResults.RentalKitchen;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.BusinessLogic.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Contracts.DataManagers
{
	public interface IKitchenDataManager
	{
		#region Kitchen

		Task Create(RentalKitchenBla kitchenBla);
		Task Delete(int id);
		Task<IEnumerable<RentalKitchenBla>> GetAll();
		Task<RentalKitchenBla> GetById(int id);
		Task Update(RentalKitchenBla kitchenBla);
		Task EquipKitchen(int kitchenId, IEnumerable<EquipmentBla> equipmentBlas);
		Task RemoveEquipments(int kitchenId, IEnumerable<EquipmentBla> equipmentBlas);

		#endregion

		#region Equipment

		Task<int> Create(EquipmentBla equipmentBla);
		Task<IEnumerable<EquipmentBla>> Get(IEnumerable<int> equipmentIds);

		#endregion
	}
}