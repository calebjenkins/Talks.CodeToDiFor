// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Talks.CodeToDiFor.MVC5Web.DependencyResolution {
    using PCL.BetterSpyLib;
    using PCL.SuperSpyLib;
    using PCL.SuperSpyLib.Data;
    using PCL.SuperSpyLib.Imp;
    using StructureMap;

    public static class IoC {
        public static IContainer Initialize() {

            ObjectFactory.Initialize(x =>
                {
                    x.Scan(scan =>
                    {
                        x.For<ISpyLogger>().Use<BetterSpyLogger>().Singleton();
                        // x.For<ISpyLogger>().Use<FakeSpyLogger>();
                        //x.For<ISpyDataLayer>().Use<SpyDataLayer>();
                        //x.For<IMessageSender>().Use<MessageSender>();
                        x.For<IEncrypter>().Use<BetterEncrypter>();
                        //x.For<IShippingCalculator>().Use<ShippingCalculator>();

                         scan.AssemblyContainingType<ISpyLogger>();
                         scan.WithDefaultConventions();
                    });

                    // x.AddRegistry<DefaultRegistry>();
                });


            return ObjectFactory.Container;

            //return new Container(c => c.AddRegistry<DefaultRegistry>());


        }
    }
}