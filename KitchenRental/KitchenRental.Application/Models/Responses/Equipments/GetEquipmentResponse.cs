using KitchenRental.Application.Models.Datas.Equipment;

namespace KitchenRental.Application.Models.Responses.Equipments
{
	public class GetEquipmentResponse
	{
		public int StatusCode { get; set; }
		public string StatusMessage { get; set; }
		public GetEquipmentData Data { get; set; }
	}
}