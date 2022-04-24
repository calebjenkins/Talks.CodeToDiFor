using System;
using Talks.C2DF.BetterApp;
using Talks.C2DF.Interfaces;
using nope = Talks.C2DF.NotSoSuperLib;
using external = Talks.C2DF.ExternalLoggingLib;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.BetterAppLib;
using Talks.C2DF.BetterAppLib.Console;
using System.Collections.Generic;
using Talks.C2DF.BetterAppLib.Rules;
using Lamar;

namespace Talks.C2DF.ConsoleApp
{
	class Program
	{

		//	Application -> Sender -> Cost Calc -> Encryptor -> Send (with Retry)
		//  <- SendResponse

		static void Main(string[] args)
		{
			//TraditionalConsoleApp();
			// CompositeRootConsoleApp();
			DIConsoleApp();
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

			IAppLogger myLogger = new ExternalLogAdapter(logger);
			IMessageSender sender = new FedExSender(crypto, myLogger);

			var basePriceRules = getBasePriceRules();
			var extPriceRules = getExtendedPriceRules();

			ICostCalculator calc = new CostCalculator(basePriceRules, extPriceRules, myLogger);
			IMessageSendingMicroApp senderApp = new SuperSendingMicroApp(calc, sender, myLogger);

			IConsole writer = new ConsoleWriter();

			return new SuperApplicationConsoleApp(senderApp, writer);
		}

		static IList<IBasePriceRule> getBasePriceRules()
		{
			return new List<IBasePriceRule>()
				{
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
					new UrgentMessageExtendedPriceRule(),
					new GodSaveQueenExtendedPriceRule()
				};
		}

		#endregion

		static void DIConsoleApp()
		{
			IContainer container = new Container(new DependencyProfileLamar());
			var app = container.GetInstance<SuperApplicationConsoleApp>();
			app.Run();
		}
	}
}
