using CommonServiceLocator.NinjectAdapter;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.PCL.SuperSpyLib;
using Talks.PCL.SuperSpyLib.Data;
using Talks.PCL.SuperSpyLib.Imp;
using Talks.PCL.SuperSpyLib.Rules;
using Talks.PCL.SuperSpyLib.Rules.Shipping;

namespace Talks.CodeToDiFor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // DoConsoleApp();

            // ConsoleWithDI();

            ConsoleWithCslDI();
        }

        static void DoConsoleApp()
        {
            Console.WriteLine("\n\t* * * Spy Message Sender * * *");
            Console.Write("\n\tMessage:");
            var input = Console.ReadLine();

            ISpyLogger logger = new SpyLogger();
            IMessageSender sender = new MessageSender(logger);
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

            // Collections //
            //var rules = container.GetAll<IRule>();
            //Console.WriteLine("\tRules:");
            //foreach (var rule in rules)
            //{
            //    Console.WriteLine("\t\t - " + rule.RuleName());
            //}

            Console.Write("\n\tDI Done.");
            Console.ReadLine();
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

        static IKernel getContainer()
        {
            IKernel container = new StandardKernel();
            container.Bind<ISpyLogger>().To<SpyLogger>(); // Show collections before Singleton
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

        static IServiceLocator getCslContainer()
        {
            return new NinjectServiceLocator(getContainer());
        }

    }
}
