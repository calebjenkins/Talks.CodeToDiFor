using Lamar;
using System;
using Talks.C2DF.BetterAppLib;
using Talks.C2DF.BetterAppLib.Console;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.Interfaces;
using external = Talks.C2DF.ExternalLoggingLib;
using nope = Talks.C2DF.NotSoSuperLib;

namespace Talks.C2DF.BetterApp
{
	public class DependencyProfileLamar : ServiceRegistry
	{
		public DependencyProfileLamar()
		{
			Scan(scan =>
			{
				scan.WithDefaultConventions();
				scan.AssembliesFromApplicationBaseDirectory();

				scan.AddAllTypesOf<IBasePriceRule>();
				scan.AddAllTypesOf<IExtendedPriceRule>();
			});

			For<ICostCalculator>().Use<CostCalculator>();
			For<IEncryptHelper>().Use<nope.Lib.Encryptor>();
			//For<IEncryptHelper>().Use<Encryptor>();
			For<IConsole>().Use<ConsoleWriter>();
			For<IMessageSendingMicroApp>().Use<SuperSendingMicroApp>();

			For<external.ILogger>().Use(external.Logger.Instance()); // DI with existing instance
			For<external.ILogger>().Use<external.Logger>();
			For<IAppLogger>().Use<ExternalLogAdapter>(); // not yet singleton


			For<IMessageSender>().Use<FedExSender>();


			//TODO: Set up Retry.. then change out Sender Imp - maybe to UPS? 
			// For<ISender>().Use<RetrySender>()
			//	.Ctor<ISender>("sender").Is<FedExSender>()
			//	.Singleton();

			For<IWriter>().Use<DebugWriter>().Singleton();
			//For<IAppLogger>().Use<MyLogger>().Singleton();
		}
	}
}
