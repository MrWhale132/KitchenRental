using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Contracts.Services
{
    public interface IRentalKitchenService
    {
		Task Create(RentalKitchenBla kitchenBla);
		Task Delete(int id);
		Task<IEnumerable<RentalKitchenBla>> GetAll();
		Task<RentalKitchenBla> GetById(int id);
		Task Update(RentalKitchenBla kitchenBla);
	}
}