using KitchenRental.Application.Mappers.ErrorCodes;
using KitchenRental.Application.Mappers.Models;
using KitchenRental.Application.Models.Datas.Equipment;
using KitchenRental.Application.Models.Requests.Equipments;
using KitchenRental.Application.Models.Responses.Equipments;
using KitchenRental.BusinessLogic.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRental.Application.Controllers
{
	public class EquipmentController : ControllerBase
	{
		private readonly ILogger<EquipmentController> _logger;
		private readonly IEquipmentService _rentalKitchenService;
		private readonly EquipmentMapper _mapper;
		private readonly EquipmentServiceResultCodeToHttpStatusCode _toHttpStatusCode;

		public EquipmentController(ILogger<EquipmentController> logger, IEquipmentService rentalKitchenService, EquipmentMapper mapper, EquipmentServiceResultCodeToHttpStatusCode toHttpStatusCode)
		{
			_logger = logger;
			_rentalKitchenService = rentalKitchenService;
			_mapper = mapper;
			_toHttpStatusCode = toHttpStatusCode;
		}

		[HttpGet("kitchenrental/equipments")]
		public async Task<IActionResult> Get([FromQuery] string equipmentIds)
		{
			var ids = equipmentIds.Split(',').Select(int.Parse);

			var equipments = await _rentalKitchenService.Get(ids);

			var response = new GetEquipmentResponse
			{
				StatusCode = 200,
				Data = new GetEquipmentData
				{
					Equipments = equipments.Select(_mapper.Map)
				}
			};

			return new JsonResult(response) { StatusCode = response.StatusCode };
		}


		[HttpPost("kitchenrental/equipments")]
		public async Task<IActionResult> Create([FromBody] CreateEquipmentRequest equipmentRequest)
		{
			var bla = _mapper.Map(equipmentRequest);

			var generatedId = await _rentalKitchenService.Create(bla);

			var response = new CreateEquipmentResponse
			{
				StatusCode = 200,
				Data = new CreateEquipmentData
				{
					EquipmentId = generatedId
				}
			};

			return new JsonResult(response) { StatusCode = response.StatusCode };
		}
	}
}