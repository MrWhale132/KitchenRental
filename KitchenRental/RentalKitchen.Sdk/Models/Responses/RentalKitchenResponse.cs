namespace KitchenRental.Sdk.Models.Responses
{
	public class RentalKitchenResponse<TData>
	{
		public int StatusCode { get; set; }
		public TData Data { get; set; }
	}
}