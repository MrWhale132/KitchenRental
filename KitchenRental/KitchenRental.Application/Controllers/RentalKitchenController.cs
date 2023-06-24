using KitchenRental.Application.Mappers;
using KitchenRental.Application.Models.Requests;
using KitchenRental.Application.Models.Responses;
using KitchenRental.BusinessLogic.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRental.Application.Controllers
{
	public class RentalKitchenController : ControllerBase
	{
		private readonly IRentalKitchenService _rentalKitchenService;
		private readonly RentalKitchenRequestToBlaToResponseData _mapper;

		public RentalKitchenController(IRentalKitchenService rentalKitchenService, RentalKitchenRequestToBlaToResponseData mapper)
		{
			_rentalKitchenService = rentalKitchenService;
			_mapper = mapper;
		}

		[HttpGet("kitchenrental/rentalkitchens")]
		public async Task<IActionResult> GetAll()
		{
			var kitchensBla = await _rentalKitchenService.GetAll();

			var response = new RentalKitchenResponse<IEnumerable<GetRentalKitchenResponseData>>
			{
				StatusCode = 200,
				Data = kitchensBla.Select(_mapper.Map)
			};

			return new JsonResult(response) { StatusCode = 200};
		}

		[HttpGet("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var kitchenBla = await _rentalKitchenService.GetById(id);

			var response = new RentalKitchenResponse<GetRentalKitchenResponseData>
			{
				StatusCode = 200,
				Data = _mapper.Map(kitchenBla)
			};

			return new JsonResult(response) { StatusCode = 200 };
		}

		[HttpPost("kitchenrental/rentalkitchens")]
		public async Task<IActionResult> Create([FromBody] CreateRentalKitchenRequest kitchenRequest)
		{
			var kitchenBla = _mapper.Map(kitchenRequest);

			var reservedId = await _rentalKitchenService.Create(kitchenBla);

			var response = new RentalKitchenResponse<CreateRentalKitchenResponseData>
			{
				StatusCode = 201,
				Data = new CreateRentalKitchenResponseData
				{
					Id = reservedId
				}
			};

			return new JsonResult(response) { StatusCode = 201 };
		}

		[HttpPatch("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRentalKitchenRequest updateRequest)
		{
			var kitchenBla = _mapper.Map(updateRequest);
			kitchenBla.Id= id;

			await _rentalKitchenService.Update(kitchenBla);

			var response = new RentalKitchenResponse<NoDataResponse>
			{
				StatusCode = 200
			};

			return new JsonResult(response) { StatusCode = 204 };
		}

		[HttpDelete("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			await _rentalKitchenService.Delete(id);

			var response = new RentalKitchenResponse<NoDataResponse>
			{
				StatusCode = 200
			};

			return new JsonResult(response) { StatusCode = 204 };
		}
	}
}