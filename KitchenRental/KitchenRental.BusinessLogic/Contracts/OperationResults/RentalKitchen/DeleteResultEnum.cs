namespace KitchenRental.BusinessLogic.Contracts.OperationResults.RentalKitchen
{
	public enum DeleteResult
	{
		Success = 200,
		NoContent = 204,
		BadRequest = 400,
		NotFound = 404,
		Failed = -1
	}
}