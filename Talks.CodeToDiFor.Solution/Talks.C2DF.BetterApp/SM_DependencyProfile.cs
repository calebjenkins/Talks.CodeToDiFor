using System;
using Talks.C2DF.BetterAppLib.Console;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp
{

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
