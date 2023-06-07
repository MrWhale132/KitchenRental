using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Contracts.DataAccess
{
	public interface IRentalKitchenDataManager
	{
		Task Create(RentalKitchenBla kitchenBla);
		Task Delete(int id);
		Task<IEnumerable<RentalKitchenBla>> GetAll();
		Task<RentalKitchenBla> GetById(int id);
		Task Update(RentalKitchenBla kitchenBla);
	}
}