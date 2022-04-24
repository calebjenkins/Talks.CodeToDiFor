using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Talks.C2DF.BetterApp;

namespace Talks.C2DF.WebCORE
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			// Container config
			var registery = new DependencyProfileLamar();

			return WebHost.CreateDefaultBuilder(args)
				.UseLamar(registery) // register container
				.UseStartup<Startup>();
		}
	}
}
