using StructureMap;
using System;
using Ext = Talks.C2DF.Interfaces.ExternalLibrary;
using Talks.C2DF.Interfaces;
using Talks.C2DF.BetterApp.Lib;
using Talks.C2DF.BetterApp.Lib.Logging;

namespace Talks.C2DF.BetterApp
{
	public class DependencyProfile: Registry
	{
		public DependencyProfile()
		{
			Scan(scan =>
			{
				scan.AssembliesAndExecutablesFromApplicationBaseDirectory();
				scan.WithDefaultConventions();

				scan.AddAllTypesOf<IBasePriceRule>();
				scan.AddAllTypesOf<IExtendedPriceRule>();
			});

			For<ICostCalculator>().Use<CostCalculator>();
			For<ISender>().Use<Sender>();
			For<IEncryptHelper>().Use<C2DF.NotSoSuperLib.Lib.Encryptor>();
			For<IWriter>().Use<ConsoleWriter>();
			
			For<Ext.ILogger>().Use(Ext.Logger.Instance());
			For<ILogger>().Use<ExternalLogAdapter>();
		}
	}
}
