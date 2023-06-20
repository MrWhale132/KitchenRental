using KitchenRental.BusinessLogic.Contracts.DataAccess;
using KitchenRental.BusinessLogic.Contracts.Services;
using KitchenRental.BusinessLogic.Services;
using KitchenRental.DataAccess;
using KitchenRental.DataAccess.DataManagers.RentalKitchenDataManager;
using KitchenRental.DataAccess.Mappers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KitchenRental.Application
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
		}
	}
}