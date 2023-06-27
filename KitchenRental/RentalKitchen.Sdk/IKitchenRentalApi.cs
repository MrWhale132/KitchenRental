using KitchenRental.Sdk.Models.Requests;
using KitchenRental.Sdk.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.Sdk
{
	public interface IKitchenRentalApi
	{
		Task<IEnumerable<RentalKitchenDto>> GetAll();
		Task<RentalKitchenDto> GetById(int id);
		Task<int> Create(CreateRentalKitchenRequest createRequest);
		Task Update(int id, UpdateRentalKitchenRequest updateRequest);
		Task Delete(int id);
	}
}