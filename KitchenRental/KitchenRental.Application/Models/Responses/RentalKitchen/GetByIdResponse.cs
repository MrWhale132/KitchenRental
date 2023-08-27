using KitchenRental.Application.Models.Datas.RentalKitchen;

namespace KitchenRental.Application.Models.Responses.RentalKitchen
{
    public class GetByIdResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public GetByIdData Data { get; set; }
    }
}