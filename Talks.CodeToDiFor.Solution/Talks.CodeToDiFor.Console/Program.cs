using StructureMap;
using System;
using System.Collections.Generic;
using Talks.SuperSpyLib;
using Talks.SuperSpyLib.Data;
using Talks.SuperSpyLib.Imp;
using Talks.SuperSpyLib.Rules;
using Talks.SuperSpyLib.Rules.Shipping;

namespace Talks.CodeToDiFor.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			// Input -> MessageSender + Logger -> Shipping Calc + Shipping Rules -> Data + Encryptor 

			Console.WriteLine("\n\t* * * Message Sender * * *");
			Console.Write("\n\tMessage:");
			var input = Console.ReadLine();

			{
				var messages = DoConsoleApp_Manual_DI(input);
				//var messages = ConsoleWithSMContainer(input);

				Console.WriteLine("\n\tLogger Output:");
				foreach (var msg in messages)
				{
					Console.WriteLine("\t\t - " + msg);
				}
			}

			Console.Write("\n\tDone.");
			Console.ReadLine();
		}

		static IEnumerable<string> DoConsoleApp_Manual_DI(string input)
		{
			// Input -> MessageSender + Logger -> Shipping Calc + Shipping Rules -> Data + Encryptor 

			ILogger logger = new Logger();
			IEncrypter enc = new Encrypter(logger);
			IDataLayer data = new DataLayer(logger, enc);
			var rules = new List<IShippingRule>()
			{
				new EconomyShippingDiscountRule(),
				new ExtraLargeShippingRule(),
				new GodSaveTheQueenShippingRule()
				//new HurryHurryShippingRule(),
				//new RushOrderShippingRule()
			};

			IShippingCalculator calc = new ShippingCalculator(logger, rules);

			IMessageSender sender = new MessageSender(logger, data, calc);
			sender.Send(input);

			Console.WriteLine("\n\tRules:");
			foreach (var rule in rules)
			{
				Console.WriteLine("\t\t - " + rule.RuleName());
			}

			return logger.GetMessages();
		}

		static IEnumerable<string> ConsoleWithSMContainer(string input)
		{
			// DI //
			var container = GetContainer();
			var sender = container.GetInstance<IMessageSender>();
			sender.Send(input);

			// Collections // - Show Singleton before Collection
			var rules = container.GetAllInstances<IShippingRule>();
			Console.WriteLine("\n\tRules:");
			foreach (var rule in rules)
			{
				Console.WriteLine("\t\t - " + rule.RuleName());
			}

			return container.GetInstance<ILogger>().GetMessages();
		}
		static IContainer GetContainer()
		{
			IContainer container = new Container(); // StructureMap
			container.Configure(x =>
			{
				x.For<IMessageSender>().Use<MessageSender>();
				x.For<ILogger>().Use<Logger>(); //.Singleton();
				x.For<IEncrypter>().Use<Encrypter>();
				x.For<IShippingCalculator>().Use<ShippingCalculator>();
				x.For<IDataLayer>().Use<DataLayer>();

				x.Scan(scan =>
				{
					scan.AssemblyContainingType(typeof(ILogger));
					scan.WithDefaultConventions();
					scan.AddAllTypesOf<IShippingRule>();
					scan.AddAllTypesOf<IRule>();
				});
			});

			return container;
		}
	}
}
