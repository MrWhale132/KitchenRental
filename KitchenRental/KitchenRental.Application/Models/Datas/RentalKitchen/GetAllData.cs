using KitchenRental.Application.Models.Contracts.RentalKitchen;
using System.Collections.Generic;

namespace KitchenRental.Application.Models.Datas.RentalKitchen
{
    public class GetAllData
    {
        public IEnumerable<RentalKitchenContract> Kitchens { get; set; }
    }
}