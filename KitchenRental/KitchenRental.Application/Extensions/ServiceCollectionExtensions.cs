using KitchenRental.Application.Mappers.ErrorCodes;
using KitchenRental.Application.Mappers.Models;
using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Contracts.DataManagers;
using KitchenRental.BusinessLogic.Contracts.Services;
using KitchenRental.BusinessLogic.Services;
using KitchenRental.DataAccess;
using KitchenRental.DataAccess.DataAccess;
using KitchenRental.DataAccess.DataManagers;
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
			services.AddSwaggerGen();

			services.AddDbContext<DataContext>(
				options =>
				{
					options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
					options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
				});

			return services;
		}

		public static IServiceCollection AddBuisnessLayer(this IServiceCollection services)
		{
			return services
				  .AddMappers()
				  .AddSingleton<SequenceProvider>()
				  .AddScoped<IEquiptmentDataAccess, EquiptmentDataAccess>()
				  .AddScoped<IKitchenDataAccess, KitchenDataAccess>()
				  .AddScoped<IKitchenDataManager, KitchenDataManager>()
				  .AddScoped<IEquipmentService, EquipmentService>()
				  .AddScoped<IRentalKitchenService, RentalKitchenService>();
		}

		private static IServiceCollection AddMappers(this IServiceCollection services)
		{
			return services
				  .AddSingleton<EquipmentServiceResultCodeToHttpStatusCode>()
				  .AddSingleton<KitchenServiceResultCodeToHttpStatusCode>()
				  .AddSingleton<EquipmentMapper>()
				  .AddSingleton<KitchenMapper>()
				  .AddSingleton<EquipmentDaoMapper>()
				  .AddSingleton<KitchenDaoMapper>();
		}
	}
}