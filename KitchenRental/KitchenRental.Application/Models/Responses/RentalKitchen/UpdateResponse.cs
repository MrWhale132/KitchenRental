using KitchenRental.Application.Models.Datas.RentalKitchen;

namespace KitchenRental.Application.Models.Responses.RentalKitchen
{
    public class UpdateResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public UpdateData Data { get; set; }
    }
}