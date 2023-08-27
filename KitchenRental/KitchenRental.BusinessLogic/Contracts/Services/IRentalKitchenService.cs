using KitchenRental.BusinessLogic.Contracts.OperationResults.RentalKitchen;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Contracts.Services
{
    public interface IRentalKitchenService
    {
		Task<int> Create(RentalKitchenBla kitchenBla);
		Task<DeleteResult> Delete(int id);
		Task<IEnumerable<RentalKitchenBla>> GetAll();
		Task<RentalKitchenBla> GetById(int id);
		Task<RentalKitchenResultCode> Update(RentalKitchenBla kitchenBla);
	}
}