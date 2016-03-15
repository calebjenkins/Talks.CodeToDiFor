using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talks.SuperSpyLib.Imp;
using Xunit;

namespace Talks.SuperSpyLibTests
{
    public class When_Messages_Sent_Through_Sender
    {
       // [Fact]
        public void Should_return_string_collection()
        {
            Encrypter enc = new Encrypter();
            IList<string> input = new List<string>();
            string confirm = "new message";
            var results = enc.Encrypt(input, confirm);
            var msg = results.First();

            // Assert.NotNull(results);
            // Assert.Same(confirm, msg);

        }
    }
}
