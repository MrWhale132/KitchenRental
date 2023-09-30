using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Contracts.DataManagers;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.DataAccess.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRental.DataAccess.DataManagers
{
	public class KitchenDataManager : IKitchenDataManager
	{
		private readonly IKitchenDataAccess _kitchenDataAccess;
		private readonly IEquiptmentDataAccess _equiptmentDataAccess;
		private readonly KitchenDaoMapper _kitchenMapper;
		private readonly EquipmentDaoMapper _equipmentMapper;

		public KitchenDataManager(IKitchenDataAccess kitchenDataAccess, IEquiptmentDataAccess equiptmentDataAccess, KitchenDaoMapper mapper, EquipmentDaoMapper equipmentMapper)
		{
			_kitchenDataAccess = kitchenDataAccess;
			_equiptmentDataAccess = equiptmentDataAccess;
			_kitchenMapper = mapper;
			_equipmentMapper = equipmentMapper;
		}

		#region Kitchen

		public async Task Create(RentalKitchenBla kitchenBla)
		{
			var dto = _kitchenMapper.Map(kitchenBla);

			await _kitchenDataAccess.Create(dto);
		}

		public async Task Delete(int id)
		{
			await _kitchenDataAccess.Delete(id);
		}

		public async Task<IEnumerable<RentalKitchenBla>> GetAll()
		{
			var dtos = await _kitchenDataAccess.GetAll();

			return dtos.Select(_kitchenMapper.Map);
		}

		public async Task<RentalKitchenBla> GetById(int id)
		{
			var dto = await _kitchenDataAccess.GetById(id);

			return _kitchenMapper.Map(dto);
		}

		//TODO: patch the dto here
		public async Task Update(RentalKitchenBla kitchenBla)
		{
			var dto = _kitchenMapper.Map(kitchenBla);

			await _kitchenDataAccess.Update(dto);
		}

		public async Task EquipKitchen(int kitchenId, IEnumerable<EquipmentBla> equipmentBlas)
		{
			var equipmentDtos = equipmentBlas.Select(_equipmentMapper.Map);

			foreach (var equipment in equipmentDtos)
			{
				equipment.RentalKitchenDtoId = kitchenId;

				await _equiptmentDataAccess.Update(equipment);
			}
		}

		public async Task RemoveEquipments(int kitchenId, IEnumerable<EquipmentBla> equipmentBlas)
		{
			var equipmentDtos = equipmentBlas.Select(_equipmentMapper.Map);

			foreach (var equipment in equipmentDtos)
			{
				equipment.RentalKitchenDtoId = null;

				await _equiptmentDataAccess.Update(equipment);
			}
		}

		#endregion Kitchen

		#region Equipment

		public async Task<int> Create(EquipmentBla equipmentBla)
		{
			var dto = _equipmentMapper.Map(equipmentBla);

			return await _equiptmentDataAccess.Create(dto);
		}

		public async Task<IEnumerable<EquipmentBla>> Get(IEnumerable<int> equipmentIds)
		{
			var dtos =await _equiptmentDataAccess.Get(equipmentIds);

			return dtos.Select(_equipmentMapper.Map);
		}

		#endregion Equipment
	}
}