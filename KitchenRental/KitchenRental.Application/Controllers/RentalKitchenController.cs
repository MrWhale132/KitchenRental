using KitchenRental.BusinessLogic.Contracts.Services;
using KitchenRental.BusinessLogic.Models.BusinessLogicAdapters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KitchenRental.Application.Controllers
{
	public class RentalKitchenController : ControllerBase
	{
		private readonly IRentalKitchenService _rentalKitchenService;

		public RentalKitchenController(IRentalKitchenService rentalKitchenService)
		{
			_rentalKitchenService = rentalKitchenService;
		}

		[HttpGet("kitchenrental/rentalkitchens")]
		public async Task<IActionResult> GetAll()
		{
			var ktichens = await _rentalKitchenService.GetAll();

			return Ok(ktichens);
		}

		[HttpGet("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var kitchen = await _rentalKitchenService.GetById(id);

			return Ok(kitchen);
		}

		[HttpPost("kitchenrental/rentalkitchens")]
		public async Task<IActionResult> Create([FromBody] RentalKitchenBla kitchen)
		{
			await _rentalKitchenService.Create(kitchen);

			return Ok();
		}

		[HttpPut("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RentalKitchenBla kitchen)
		{
			kitchen.Id = id;
			await _rentalKitchenService.Update(kitchen);

			return Ok();
		}

		[HttpDelete("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			await _rentalKitchenService.Delete(id);

			return Ok();
		}
	}
}