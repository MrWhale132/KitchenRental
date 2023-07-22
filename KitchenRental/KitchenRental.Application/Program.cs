using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

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
			var builder = WebHost.CreateDefaultBuilder(args);

			builder.ConfigureLogging(logger =>
			{
				logger.ClearProviders();
				logger.AddNLog();
			});

			builder.UseStartup<Startup>();

			return builder;
		}
	}
}