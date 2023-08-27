using KitchenRental.Application.Models.Datas.RentalKitchen;

namespace KitchenRental.Application.Models.Responses.RentalKitchen
{
	public class DeleteResponse
	{
		public int StatusCode { get; set; }
		public string StatusMessage { get; set; }
		public DeleteData Data { get; set; }
	}
}