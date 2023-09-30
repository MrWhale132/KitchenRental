using KitchenRental.BusinessLogic.Contracts.OperationResults.RentalKitchen;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.BusinessLogic.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Contracts.Services
{
    public interface IRentalKitchenService
    {
		Task<int> Create(RentalKitchenBla kitchenBla);
		Task<RentalKitchenResultCode> Delete(int id);
		Task<RentalKitchenResultCode> EquipKitchen(int kitchenId, EquipKitchenRequestBla requestBla);
		Task<IEnumerable<RentalKitchenBla>> GetAll();
		Task<RentalKitchenBla> GetById(int id);
		Task<RentalKitchenResultCode> RemoveEquipments(int kitchenId, RemoveEquipmentsRequestBla requestBla);
		Task<RentalKitchenResultCode> Update(RentalKitchenBla kitchenBla);
	}
}