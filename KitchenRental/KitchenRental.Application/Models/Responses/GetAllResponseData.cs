using System.Collections.Generic;

namespace KitchenRental.Application.Models.Responses
{
	public class GetAllResponseData
	{
		public IEnumerable<RentalKitchenDto> Kitchens { get; set; }
	}
}