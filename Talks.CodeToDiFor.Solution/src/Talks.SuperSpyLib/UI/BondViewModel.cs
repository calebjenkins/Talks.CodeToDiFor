using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib.UI
{
    public class BondViewModel
    {
        public BondViewModel()
        {
            Messages = new List<string>();
        }

        public string Title { get; set; }
        public IList<string> Messages { get; set; }
    }
}
