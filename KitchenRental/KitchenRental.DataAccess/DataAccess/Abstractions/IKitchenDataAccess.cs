using KitchenRental.DataAccess.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Contracts.DataAccess
{
	public interface IKitchenDataAccess
	{
		Task Create(RentalKitchenDto kitchenDto);
		Task Delete(int id);
		Task<IEnumerable<RentalKitchenDto>> GetAll();
		Task<RentalKitchenDto> GetById(int id);
		Task Update(RentalKitchenDto kitchenDto);
	}
}