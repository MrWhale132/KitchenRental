using System.Collections.Generic;

namespace KitchenRental.Sdk.Models.Responses
{
	public class GetAllResponseData
	{
		public IEnumerable<RentalKitchenDto> Kitchens { get; set; }
	}
}