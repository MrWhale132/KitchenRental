using KitchenRental.Application.Mappers;
using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Contracts.Services;
using KitchenRental.BusinessLogic.Services;
using KitchenRental.DataAccess;
using KitchenRental.DataAccess.DataManagers.RentalKitchenDataManager;
using KitchenRental.DataAccess.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KitchenRental.Application.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration config)
		{
			services.AddControllers();
			services.AddMvc(options => options.EnableEndpointRouting = false);
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.AddDbContext<DataContext>(
				options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

			return services;
		}

		public static IServiceCollection AddBuisnessLayer(this IServiceCollection services)
		{
			return services
				  .AddMappers()
				  .AddSingleton<SequenceProvider>()
				  .AddSingleton<RentalKitchenDtoBlaMapper>()
				  .AddScoped<IRentalKitchenDataManager, RentalKitchenDataManager>()
				  .AddScoped<IRentalKitchenService, RentalKitchenService>();
		}

		private static IServiceCollection AddMappers(this IServiceCollection services)
		{
			return services
				  .AddSingleton<RentalKitchenErrorCodeToHttpStatusCode>()
				  .AddSingleton<RentalKitchenRequestToBlaToResponseData>()
				  .AddSingleton<RentalKitchenDtoBlaMapper>();
		}
	}
}