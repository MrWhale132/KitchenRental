using KitchenRental.Application.Models.Datas.RentalKitchen;

namespace KitchenRental.Application.Models.Responses.RentalKitchen
{
    public class CreateResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public CreateData Data { get; set; }
    }
}