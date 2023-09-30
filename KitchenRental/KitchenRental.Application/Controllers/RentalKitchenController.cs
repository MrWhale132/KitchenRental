using Azure;
using KitchenRental.Application.Mappers.ErrorCodes;
using KitchenRental.Application.Mappers.Models;
using KitchenRental.Application.Models.Datas.RentalKitchen;
using KitchenRental.Application.Models.Requests.RentalKitchen;
using KitchenRental.Application.Models.Responses.RentalKitchen;
using KitchenRental.BusinessLogic.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRental.Application.Controllers
{
	public class RentalKitchenController : ControllerBase
	{
		private readonly ILogger<RentalKitchenController> _logger;
		private readonly IRentalKitchenService _rentalKitchenService;
		private readonly KitchenMapper _mapper;
		private readonly KitchenServiceResultCodeToHttpStatusCode _toHttpStatusCode;

		public RentalKitchenController(IRentalKitchenService rentalKitchenService, KitchenMapper mapper, ILogger<RentalKitchenController> logger, KitchenServiceResultCodeToHttpStatusCode toHttpStatusCode)
		{
			_rentalKitchenService = rentalKitchenService;
			_mapper = mapper;
			_logger = logger;
			_toHttpStatusCode = toHttpStatusCode;
		}

		[HttpGet("kitchenrental/rentalkitchens")]
		public async Task<IActionResult> GetAll()
		{
			//var dynamoDbClient = new AmazonDynamoDBClient();

			//Console.WriteLine($"Hello Amazon Dynamo DB! Following are some of your tables:");
			//Console.WriteLine();

			//// You can use await and any of the async methods to get a response.
			//// Let's get the first five tables.
			//var test = await dynamoDbClient.ListTablesAsync(
			//	new ListTablesRequest()
			//	{
			//		Limit = 5
			//	});

			//foreach (var table in test.TableNames)
			//{
			//	Console.WriteLine($"\tTable: {table}");
			//	Console.WriteLine();
			//}


			_logger.LogInformation($"{nameof(GetAll)} started processing");

			var kitchensBla = await _rentalKitchenService.GetAll();

			var response = new GetAllResponse
			{
				StatusCode = 200,
				Data = new GetAllData
				{
					Kitchens = kitchensBla.Select(_mapper.Map)
				}
			};

			_logger.LogInformation($"{nameof(GetAll)} finished processing");

			return new JsonResult(response) { StatusCode = 200 };
		}

		[HttpGet("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var kitchenBla = await _rentalKitchenService.GetById(id);

			var response = new GetByIdResponse
			{
				StatusCode = 200,
				Data = new GetByIdData
				{
					Kitchen = _mapper.Map(kitchenBla)
				}
			};

			return new JsonResult(response) { StatusCode = 200 };
		}

		[HttpPost("kitchenrental/rentalkitchens")]
		public async Task<IActionResult> Create([FromBody] CreateRentalKitchenRequest kitchenRequest) //TODO: map the request into a requestBla instead
		{
			var kitchenBla = _mapper.Map(kitchenRequest);

			var reservedId = await _rentalKitchenService.Create(kitchenBla);

			var response = new CreateResponse
			{
				StatusCode = 201,
				Data = new CreateData
				{
					ReservedId = reservedId
				}
			};

			return new JsonResult(response) { StatusCode = 201 };
		}

		[HttpPatch("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRentalKitchenRequest updateRequest) // same here
		{
			var kitchenBla = _mapper.Map(updateRequest);
			kitchenBla.Id = id;

			var resultCode = await _rentalKitchenService.Update(kitchenBla);

			var response = new UpdateResponse
			{
				StatusCode = (int)_toHttpStatusCode.Map(resultCode),
				ResultCode = (int)resultCode
			};

			return new JsonResult(response) { StatusCode = response.StatusCode };
		}

		[HttpDelete("kitchenrental/rentalkitchens/{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var resultCode = await _rentalKitchenService.Delete(id);

			var response = new DeleteResponse
			{
				StatusCode = (int)_toHttpStatusCode.Map(resultCode),
				ResultCode = (int)resultCode
			};

			return new JsonResult(response) { StatusCode = response.StatusCode };
		}

		[HttpPost("kitchenrental/rentalkitchens/{kitchenId}/equipments")]
		public async Task<IActionResult> EquipKitchen([FromRoute] int kitchenId, [FromBody] EquipKitchenRequest request)
		{
			var requestBla = _mapper.Map(request);

			var resultCode = await _rentalKitchenService.EquipKitchen(kitchenId, requestBla);

			var response = new EquipKitchenResponse
			{
				StatusCode = (int)_toHttpStatusCode.Map(resultCode),
				ResultCode = (int)resultCode
			};

			return new JsonResult(response) { StatusCode = response.StatusCode };
		}

		[HttpDelete("kitchenrental/rentalkitchens/{kitchenId}/equipments")]
		public async Task<IActionResult> RemoveEquipments([FromRoute] int kitchenId, [FromBody] RemoveEquipmentsRequest request)
		{
			var requestBla = _mapper.Map(request);

			var resultCode = await _rentalKitchenService.RemoveEquipments(kitchenId, requestBla);

			var response = new EquipKitchenResponse
			{
				StatusCode = (int)_toHttpStatusCode.Map(resultCode),
				ResultCode = (int)resultCode
			};

			return new JsonResult(response) { StatusCode = response.StatusCode };
		}
	}
}