using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Talks.PCL.SuperSpyLib.Imp;
using Talks.PCL.SuperSpyLib;
using Talks.PCL.SuperSpyLib.Data;
using Rhino.Mocks;

namespace Talks.CodeToDiFor.MVC5Web.Tests.LibraryTests
{
    [TestClass]
    public class WhenSendingMessages_
    {

        MessageSender _sut;
        ISpyLogger loggerMock;
        ISpyDataLayer dataMock;


        [TestInitialize]
        public void When()
        {
            loggerMock = MockRepository.GenerateMock<ISpyLogger>();
            dataMock = MockRepository.GenerateMock<ISpyDataLayer>();
        }

        [TestMethod]
        public void Should_Log_Messages()
        {
            loggerMock.Expect(x => x.Log(Arg<string>.Is.Anything)).Repeat.AtLeastOnce();
            _sut = new MessageSender(loggerMock, dataMock);
            _sut.Send("test");

            loggerMock.VerifyAllExpectations();

        }

        [TestMethod]
        public void Should_Load_To_Data_Layer()
        {
            var dataPrefix = "Store in db: ";
            var data = "test";

            dataMock.Expect(x => x.update(dataPrefix + data)).Repeat.Once();
            _sut = new MessageSender(loggerMock, dataMock);
            _sut.Send(data);
            //_sut.Send("test 2");


            dataMock.VerifyAllExpectations();
        }
    }
}
