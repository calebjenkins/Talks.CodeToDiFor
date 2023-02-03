using Lamar;
using Talks.C2DF.BetterAppLib;
using Talks.C2DF.BetterAppLib.Console;
using Talks.C2DF.BetterAppLib.v2Features;
using Talks.C2DF.Interfaces;
using ExtLog = Talks.C2DF.ExternalLoggingLib;
using Nope = Talks.C2DF.NotSoSuperLib;

namespace Talks.C2DF.BetterApp;

public class DependencyProfileLamar : ServiceRegistry
{
	public DependencyProfileLamar()
	{
		Scan(scan =>
		{
			// scan.WithDefaultConventions();
			scan.AssembliesFromApplicationBaseDirectory();

			// Pricing Rules
			scan.AddAllTypesOf<IBasePriceRule>();
			scan.AddAllTypesOf<IExtendedPriceRule>();
		});

		// ** Logging ** 
		//For<ExtLog.ILogger>().Use(ExtLog.Logger.Instance()); // DI with existing instance - is singleton
		//For<ExtLog.ILogger>().Add<ExtLog.WhackyLogger>();
		For<IAppLogger>().Use<ExternalLogAdapter>();        // not yet singleton

		For<ICostCalculator>().Add<CostCalculator>();		// Not needed, follows conventions
		For<IEncryptHelper>().Add<Nope.Lib.Encryptor>();	// Bad Lib, no DI - no logging
		//For<IEncryptHelper>().Use<Encryptor>();			// Better Lib, uses DI
		//For<IEncryptHelper>().Use<BetterEncryptor>();		// Better Encryptor

		For<IConsole>().Add<ConsoleWriter>();
		For<IMessageSendingMicroApp>().Add<SuperSendingMicroApp>();

		For<IMessageSender>().Add<FedExSender>();
		//For<IMessageSender>().Use<UpsSender>();

		//TODO: Set up Retry.. then change out Sender Imp - maybe to UPS? 
		//For<IMessageSender>().Use<RetrySender>()
		//  .Ctor<IMessageSender>("sender").Is<FedExSender>()
		//  .Singleton();

		For<IWriter>().Add<DebugWriter>().Singleton();
		For<IAppLogger>().Add<MyLogger>().Singleton();
	}
}
