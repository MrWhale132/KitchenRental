using KitchenRental.Application.Models.Datas.Equipment;

namespace KitchenRental.Application.Models.Responses.Equipments
{
	public class CreateEquipmentResponse
	{
		public int StatusCode { get; set; }
		public string StatusMessage { get; set; }
		public CreateEquipmentData Data { get; set; }
	}
}
