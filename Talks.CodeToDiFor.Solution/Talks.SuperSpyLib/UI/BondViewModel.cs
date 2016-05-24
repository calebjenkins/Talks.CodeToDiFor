using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib.UI
{
    public class BondViewModel
    {
        public string Title { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }

}
