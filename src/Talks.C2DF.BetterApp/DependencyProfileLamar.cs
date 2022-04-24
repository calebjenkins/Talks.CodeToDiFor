using Lamar;
using System;
using Talks.C2DF.BetterAppLib;
using Talks.C2DF.BetterAppLib.Console;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.BetterAppLib.v2Features;
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

				// Pricing Rules
				scan.AddAllTypesOf<IBasePriceRule>();
				scan.AddAllTypesOf<IExtendedPriceRule>();
			});

			//For<ICostCalculator>().Use<CostCalculator>();		// Not needed, follows conventions

			For<IEncryptHelper>().Use<nope.Lib.Encryptor>();	// Bad Lib, no DI - no logging
			//For<IEncryptHelper>().Use<Encryptor>();				// Better Lib, uses DI
			//For<IEncryptHelper>().Use<BetterEncryptor>();		// Better Encryptor

			For<IConsole>().Use<ConsoleWriter>();
			For<IMessageSendingMicroApp>().Use<SuperSendingMicroApp>();

			// ** Logging ** 
			//For<external.ILogger>().Use(external.Logger.Instance()); // DI with existing instance - is singleton
			For<external.ILogger>().Use<external.Logger>();
			For<IAppLogger>().Use<ExternalLogAdapter>();			// not yet singleton

			For<IMessageSender>().Use<FedExSender>();
			//For<IMessageSender>().Use<UpsSender>();

			//TODO: Set up Retry.. then change out Sender Imp - maybe to UPS? 
			//For<IMessageSender>().Use<RetrySender>()
			//  .Ctor<IMessageSender>("sender").Is<FedExSender>()
			//  .Singleton();

			For<IWriter>().Use<DebugWriter>().Singleton();
			//For<IAppLogger>().Use<MyLogger>().Singleton();
		}
	}
}
