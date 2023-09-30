using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using KitchenRental.DataAccess.Mappers;
using KitchenRental.DataAccess.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRental.DataAccess.DataAccess
{
    public class KitchenDataAccess : IKitchenDataAccess
    {
        private readonly DataContext _dataContext;

        public KitchenDataAccess(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<RentalKitchenDto>> GetAll()
        {
            return await _dataContext.RentalKitchens.ToListAsync();
        }

        public async Task<RentalKitchenDto> GetById(int id)
        {
            var dto = await _dataContext.RentalKitchens.Include(x => x.Equipments).SingleOrDefaultAsync(x => x.Id == id);

            return dto;
        }

        public async Task Create(RentalKitchenDto kitchenDto)
        {
            _dataContext.RentalKitchens.Add(kitchenDto);

            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(RentalKitchenDto updateRequestDto)
        {
            var existingDto = await _dataContext.RentalKitchens.Include(x => x.Equipments).SingleOrDefaultAsync(x => x.Id == updateRequestDto.Id);

            existingDto.Name = updateRequestDto.Name == null ? existingDto.Name : updateRequestDto.Name;
            existingDto.Description = updateRequestDto.Description == null ? existingDto.Description : updateRequestDto.Description;
            existingDto.RentPricePerMinute = updateRequestDto.RentPricePerMinute == 0 ? existingDto.RentPricePerMinute : updateRequestDto.RentPricePerMinute;
            existingDto.WorkingArea = updateRequestDto.WorkingArea == 0 ? existingDto.WorkingArea : updateRequestDto.WorkingArea;
            existingDto.FloorArea = updateRequestDto.FloorArea == 0 ? existingDto.FloorArea : updateRequestDto.FloorArea;

            _dataContext.RentalKitchens.Update(existingDto);

            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var dto = new RentalKitchenDto { Id = id };

            _dataContext.RentalKitchens.Remove(dto);

            await _dataContext.SaveChangesAsync();
        }
    }
}