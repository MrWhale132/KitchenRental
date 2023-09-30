using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.DataAccess.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRental.DataAccess.DataAccess
{
    public class EquiptmentDataAccess : IEquiptmentDataAccess
    {
        private readonly DataContext _dataContext;

        public EquiptmentDataAccess(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<EquipmentDto>> Get(IEnumerable<int> equipmentIds)
        {
            var daos = await _dataContext.Equipments.Where(dao => equipmentIds.Contains(dao.Id)).ToListAsync();

            return daos;
        }

        public async Task<int> Create(EquipmentDto equipmentDto)
        {
            _dataContext.Equipments.Add(equipmentDto);

            await _dataContext.SaveChangesAsync();

            return equipmentDto.Id;
        }

		public async Task Update(EquipmentDto equipmentDto)
		{
            _dataContext.Equipments.Update(equipmentDto);

			await _dataContext.SaveChangesAsync();
		}
	}
}