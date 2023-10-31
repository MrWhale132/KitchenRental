using KitchenRental.Sdk.Models.Requests;
using KitchenRental.Sdk.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KitchenRental.Sdk
{
	public class KitchenRentalApi : IKitchenRentalApi
	{
		public HttpClient HttpClient { get; set; }

		public KitchenRentalApi()
		{
			HttpClient = new HttpClient { BaseAddress = new Uri("https://localhost:2001") };
		}

		public async Task<IEnumerable<RentalKitchenDto>> GetAll()
		{
			var uri = new Uri("kitchenrental/rentalkitchens", UriKind.Relative);
			var reqesut = new HttpRequestMessage(HttpMethod.Get, uri);
			var response = await HttpClient.SendAsync(reqesut);

			if (response != null
			&& response.StatusCode == HttpStatusCode.OK)
			{
				var json = await response.Content.ReadAsStringAsync();
				var payload = JsonConvert.DeserializeObject<RentalKitchenResponse<GetAllResponseData>>(json);
				return payload.Data.Kitchens;
			}

			throw new HttpRequestException();
		}

		public async Task<RentalKitchenDto> GetById(int id)
		{
			var uri = new Uri($"kitchenrental/rentalkitchens/{id}", UriKind.Relative);
			var reqesut = new HttpRequestMessage(HttpMethod.Get, uri);
			var response = await HttpClient.SendAsync(reqesut);

			if (response != null
			&& response.StatusCode == HttpStatusCode.OK)
			{
				var json = await response.Content.ReadAsStringAsync();
				var payload = JsonConvert.DeserializeObject<RentalKitchenResponse<GetByIdResponseData>>(json);
				return payload.Data.Kitchen;
			}

			throw new HttpRequestException();
		}

		public async Task<int> Create(CreateRentalKitchenRequest createRequest)
		{
			var uri = new Uri("kitchenrental/rentalkitchens", UriKind.Relative);
			var reqesut = new HttpRequestMessage(HttpMethod.Post, uri);
			reqesut.Content = JsonContent.Create(createRequest);
			var response = await HttpClient.SendAsync(reqesut);

			if (response != null
			&& response.StatusCode == HttpStatusCode.Created)
			{
				var json = await response.Content.ReadAsStringAsync();
				var payload = JsonConvert.DeserializeObject<RentalKitchenResponse<CreateRentalKitchenResponseData>>(json);
				return payload.Data.ReservedId;
			}

			throw new HttpRequestException();
		}

		public async Task Update(int id, UpdateRentalKitchenRequest updateRequest)
		{
			var uri = new Uri($"kitchenrental/rentalkitchens/{id}", UriKind.Relative);
			var reqesut = new HttpRequestMessage(HttpMethod.Patch, uri);
			reqesut.Content = JsonContent.Create(updateRequest);
			var response = await HttpClient.SendAsync(reqesut);

			if (response != null
			&& response.StatusCode == HttpStatusCode.NoContent)
			{
				return;
			}

			throw new HttpRequestException();
		}

		public async Task Delete(int id)
		{
			var uri = new Uri($"kitchenrental/rentalkitchens/{id}", UriKind.Relative);
			var reqesut = new HttpRequestMessage(HttpMethod.Delete, uri);
			var response = await HttpClient.SendAsync(reqesut);

			if (response != null
			&& response.StatusCode == HttpStatusCode.NoContent)
			{
				return;
			}

			throw new HttpRequestException();
		}
	}
}