using System;
using Talks.C2DF.BetterApp;
using Talks.C2DF.BetterApp.Lib;
using Talks.C2DF.BetterApp.Lib.Console;
using Talks.C2DF.Interfaces;
using nope = Talks.C2DF.NotSoSuperLib;
using external = Talks.C2DF.Interfaces.ExternalLibrary;
using System.Collections.Generic;
using Talks.C2DF.BetterApp.Lib.Rules;
using Talks.C2DF.BetterApp.Lib.Logging;
using StructureMap;

namespace Talks.CodeToDiFor.ConsoleApp
{
	class Program
	{

	//	Application -> Sender -> Cost Calc -> Encryptor -> Send (with Retry)
	//  <- SendResponse

		static void Main(string[] args)
		{
			TraditionalConsoleApp();
			//CompositeRootConsoleApp();
			//DIConsoleApp();
		}

		static void TraditionalConsoleApp()
		{
			var app = new nope.NotSoGreatConsoleApp();
			app.Run();
		}

		static void CompositeRootConsoleApp()
		{
			var app = AppComposite();
			app.Run();
		}

		#region CompositonRoot

			static SuperApplicationConsoleApp AppComposite()
			{
				IEncryptHelper crypto = new nope.Lib.Encryptor();
				external.ILogger logger = new external.Logger(); // Not singleton
				ILogger myLogger = new ExternalLogAdapter(logger);
				ISender sender = new Sender(crypto, logger);

				var basePriceRules = getBasePriceRules();
				var extPriceRules = getExtendedPriceRules();

				ICostCalculator calc = new CostCalculator(basePriceRules, extPriceRules, myLogger);
				ISuperApplication senderApp = new SuperApplication(calc, sender);

			IConsole writer = new ConsoleWriter();

				return new SuperApplicationConsoleApp(senderApp, writer);
			}

			static IList<IBasePriceRule> getBasePriceRules()
			{
				return new List<IBasePriceRule>()
				{
					new GodSaveQueenBasePriceRule(),
					new LargerSizedBasePriceRule(),
					new MediumSizedBasePriceRule(),
					new SmallSizeBasePriceRule()
				};
			}

			static IList<IExtendedPriceRule> getExtendedPriceRules()
			{
				return new List<IExtendedPriceRule>()
				{
					new ReallyUrgentMessageExtendedPriceRule(),
					new SpecialDealExtendedPriceRule(),
					new UrgentMessageExtendedPriceRule()
				};
			}

		#endregion

		static void DIConsoleApp()
		{
			IContainer container = new Container(new DependencyProfile());
			var app = container.GetInstance<SuperApplicationConsoleApp>();
			app.Run();
		}
	}
}
