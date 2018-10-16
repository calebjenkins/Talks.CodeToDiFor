using Lamar;
using System;
using Talks.C2DF.BetterAppLib;
using Talks.C2DF.BetterAppLib.Console;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.Interfaces;
using nope = Talks.C2DF.NotSoSuperLib;
using external = Talks.C2DF.ExternalLoggingLib;
using Talks.C2DF.BetterAppLib.v2Features;

namespace Talks.C2DF.BetterApp
{

	public static class DependencyProfileLamar
	{
		public static ServiceRegistry GetDIConfig()
		{
			var registry = new ServiceRegistry();

			registry.Scan( scan =>
			{
				scan.WithDefaultConventions();
				scan.AssembliesFromApplicationBaseDirectory();

				scan.AddAllTypesOf<IBasePriceRule>();
				scan.AddAllTypesOf<IExtendedPriceRule>();

			});

			registry.For<ICostCalculator>().Use<CostCalculator>();
			registry.For<IEncryptHelper>().Use<nope.Lib.Encryptor>();
			//registry.For<IEncryptHelper>().Use<Encryptor>();
			registry.For<IConsole>().Use<ConsoleWriter>();
			registry.For<IMessageSendingMicroApp>().Use<SuperSendingMicroApp>();

			registry.For<external.ILogger>().Use(external.Logger.Instance()); // DI with existing instance
			registry.For<external.ILogger>().Use<external.Logger>();
			registry.For<IAppLogger>().Use<ExternalLogAdapter>(); // not yet singleton


			registry.For<IMessageSender>().Use<FedExSender>();


			//TODO: Set up Retry.. then change out Sender Imp - maybe to UPS? 
			// For<ISender>().Use<RetrySender>()
			//	.Ctor<ISender>("sender").Is<FedExSender>()
			//	.Singleton();

			registry.For<IWriter>().Use<DebugWriter>().Singleton();
			//registry.For<IAppLogger>().Use<MyLogger>().Singleton();

			return registry;
		}
	}

	// *************************
	// *		STRUCTURE MAP		*
	// *************************
	//public class DependencyProfile : Registry
	//{
	//	public DependencyProfile()
	//	{
	//		Scan(scan =>
	//		{
	//			scan.WithDefaultConventions();
	//			scan.AssembliesAndExecutablesFromApplicationBaseDirectory();

	//			scan.AddAllTypesOf<IBasePriceRule>();
	//			scan.AddAllTypesOf<IExtendedPriceRule>();
	//		});

	//		For<ICostCalculator>().Use<CostCalculator>();
	//		// For<IEncryptHelper>().Use<NotSoSuperLib.Lib.Encryptor>();
	//		For<IEncryptHelper>().Use<Encryptor>();
	//		For<IConsole>().Use<ConsoleWriter>();
	//		For<ISendingMicroApp>().Use<SuperSendingMicroApp>();

	//		// For<Ext.ILogger>().Use(Ext.Logger.Instance()); // DI with existing instance
	//		//For<Ext.ILogger>().Use<Ext.Logger>().AlwaysUnique();
	//		//For<IAppLogger>().Use<ExternalLogAdapter>().AlwaysUnique(); // not yet singleton


	//		For<IMessageSender>().Use<FedExSender>();


	//		//TODO: Set up Retry.. then change out Sender Imp - maybe to UPS? 
	//		//For<ISender>().Use<RetrySender>()
	//		//	.Ctor<ISender>("sender").Is<FedExSender>()
	//		//	.Singleton();

	//		For<IWriter>().Use<DebugWriter>().Singleton();
	//		For<IAppLogger>().Use<MyLogger>().Singleton();

	//	}
	//}
}
