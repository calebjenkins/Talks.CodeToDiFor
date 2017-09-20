using CommonServiceLocator.NinjectAdapter;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using CommonServiceLocator.StructureMapAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			DoConsoleApp();

			//ConsoleWithDI();

			//ConsoleWithCslDI();

			// ConsoleWithSM_CSL_DI();
		}

		static void DoConsoleApp()
		{
			Console.WriteLine("\n\t* * * Spy Message Sender * * *");
			Console.Write("\n\tMessage:");
			var input = Console.ReadLine();

			ISpyLogger logger = new SpyLogger();
			IEncrypter enc = new Encrypter(logger);
			ISpyDataLayer data = new SpyDataLayer(logger, enc);

			IMessageSender sender = new MessageSender(logger, data);
			sender.Send(input);


			Console.WriteLine("\tLogger Output:");
			var msgs = logger.GetMessages();
			foreach (var msg in msgs)
			{
				Console.WriteLine("\t\t - " + msg);
			}

			Console.Write("\n\tDone.");
			Console.ReadLine();
		}

		static void ConsoleWithDI()
		{
			// DI //
			var container = getContainer();
			var senderDI = container.Get<IMessageSender>();


			var loggerDI = container.Get<ISpyLogger>();
			Console.WriteLine("\n\t* * * Spy Message Sender with DI * * *");
			Console.Write("\n\tDI Message:");
			var inputDI = Console.ReadLine();

			senderDI.Send(inputDI);

			Console.WriteLine("\tDI Logger Output:");
			var msgsDI = loggerDI.GetMessages();

			foreach (var msg in msgsDI)
			{
				Console.WriteLine("\t\t - " + msg);
			}

			// Collections // - Show Singleton before Collection
			var rules = container.GetAll<IRule>();
			Console.WriteLine("\tRules:");
			foreach (var rule in rules)
			{
				Console.WriteLine("\t\t - " + rule.RuleName());
			}

			//Console.Write("Shipping Rule:");
			//var r = container.Get<IRule>();
			//Console.WriteLine(r.RuleName());

			Console.Write("\n\tDI Done.");
			Console.ReadLine();
		}
		static IKernel getContainer()
		{
			IKernel container = new StandardKernel();
			container.Bind<ISpyLogger>().To<SpyLogger>().InSingletonScope(); // Singleton
			container.Bind<IEncrypter>().To<Encrypter>();
			container.Bind<ISpyDataLayer>().To<SpyDataLayer>();
			container.Bind<IMessageSender>().To<MessageSender>();
			container.Bind<IShippingCalculator>().To<ShippingCalculator>();


			// James Bond Rules // 
			container.Bind<IRule>().To<JamesBondRule>();
			container.Bind<IRule>().To<FavoriteBondRule>();
			container.Bind<IRule>().To<WorstBondRule>();
			container.Bind<IRule>().To<BestJamesBondRule>();
			container.Bind<IRule>().To<NewestBondRule>();

			// Shipping Rules
			container.Bind<IShippingRule>().To<EconomyShippingDiscountRule>();
			container.Bind<IShippingRule>().To<ExtraLargeShippingRule>();
			container.Bind<IShippingRule>().To<GodSaveTheQueenShippingRule>();
			container.Bind<IShippingRule>().To<HurryHurryShippingRule>();
			container.Bind<IShippingRule>().To<RushOrderShippingRule>();


			return container;
		}

		static void ConsoleWithCslDI()
		{
			// DI //
			var container = getCslContainer();
			var senderDI = container.GetInstance<IMessageSender>();


			var loggerDI = container.GetInstance<ISpyLogger>();
			Console.WriteLine("\n\t* * * Spy Message Sender with DI via CSL Adapter * * *");
			Console.Write("\n\tCSL DI Message:");
			var inputDI = Console.ReadLine();

			senderDI.Send(inputDI);

			Console.WriteLine("\tDI Logger Output:");
			var msgsDI = loggerDI.GetMessages();

			foreach (var msg in msgsDI)
			{
				Console.WriteLine("\t\t - " + msg);
			}

			// Collections //
			var rules = container.GetAllInstances<IRule>();
			Console.WriteLine("\tRules:");
			foreach (var rule in rules)
			{
				Console.WriteLine("\t\t - " + rule.RuleName());
			}

			Console.Write("\n\tDI Done.");
			Console.ReadLine();
		}
		static IServiceLocator getCslContainer()
		{
			return new NinjectServiceLocator(getContainer());
		}

		static void ConsoleWithSM_CSL_DI()
		{
			// DI //
			var container = getCslSmContainer();
			var senderDI = container.GetInstance<IMessageSender>();


			var loggerDI = container.GetInstance<ISpyLogger>();
			Console.WriteLine("\n\t* * * Spy Message Sender with DI via CSL Adapter with StructureMap * * *");
			Console.Write("\n\tCSL DI Message:");
			var inputDI = Console.ReadLine();

			senderDI.Send(inputDI);

			Console.WriteLine("\tDI Logger Output:");
			var msgsDI = loggerDI.GetMessages();

			foreach (var msg in msgsDI)
			{
				Console.WriteLine("\t\t - " + msg);
			}

			// Collections //
			var rules = container.GetAllInstances<IRule>();
			Console.WriteLine("\tRules:");
			foreach (var rule in rules)
			{
				Console.WriteLine("\t\t - " + rule.RuleName());
			}

			Console.Write("\n\tDI Done.");
			Console.ReadLine();
		}
		static IServiceLocator getCslSmContainer()
		{
			IContainer container = new Container(); // StructureMap
			container.Configure(x =>
			{
				x.For<ISpyLogger>().Use<SpyLogger>().Singleton();

				x.Scan(scan =>
					{
					 scan.AssemblyContainingType(typeof(ISpyLogger));
					 scan.WithDefaultConventions();
					 scan.AddAllTypesOf<IShippingRule>();
					 scan.AddAllTypesOf<IRule>();
				 });
			});

			return new StructureMapServiceLocator(container);
		}
	}
}
