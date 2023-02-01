using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lamar.Microsoft.DependencyInjection;
using Lamar.Microsoft;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Talks.C2DF.BetterApp;
using Microsoft.Extensions.Hosting;

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
			//var registery = new DependencyProfileLamar();

			var builder = WebHost.CreateDefaultBuilder(args);
			//builder.UseLamar(); // register container

			builder.UseStartup<Startup>();
			return builder;
		}
	}
}
