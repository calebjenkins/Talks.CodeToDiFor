using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.PCL.SuperSpyLib;
using Talks.PCL.SuperSpyLib.Imp;

namespace Talks.CodeToDiFor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t* * * Spy Message Sender * * *");
            Console.Write("\n\tMessage:");
            var input = Console.ReadLine();

            ISpyLogger logger = new SpyLogger();

            IMessageSender sender = new MessageSender(logger);
            sender.Send(input);


            Console.WriteLine("\tLogger Output:");
            var msgs = logger.GetMessages();
            foreach(var msg in msgs)
            {
                Console.WriteLine("\t\t - " + msg);
            }

            Console.Write("\n\tDone.");
            Console.ReadLine();

        }
    }
}
