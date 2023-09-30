using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitchenRental.BusinessLogic.Contracts.Services
{
	public interface IEquipmentService
	{
		Task<int> Create(EquipmentBla equipmentBla);
		Task<IEnumerable<EquipmentBla>> Get(IEnumerable<int> equipmentIds);
	}
}