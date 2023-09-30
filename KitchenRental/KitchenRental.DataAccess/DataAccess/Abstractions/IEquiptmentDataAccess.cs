using KitchenRental.DataAccess.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Contracts.DataAccess
{
	public interface IEquiptmentDataAccess
	{
		Task<int> Create(EquipmentDto equipmentDto);
		Task<IEnumerable<EquipmentDto>> Get(IEnumerable<int> equipmentIds);

		Task Update(EquipmentDto equipmentDto);
	}
}