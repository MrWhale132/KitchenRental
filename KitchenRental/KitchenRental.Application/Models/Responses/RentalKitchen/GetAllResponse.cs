using KitchenRental.Application.Models.Datas.RentalKitchen;

namespace KitchenRental.Application.Models.Responses.RentalKitchen
{
    public class GetAllResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public GetAllData Data { get; set; }
    }
}