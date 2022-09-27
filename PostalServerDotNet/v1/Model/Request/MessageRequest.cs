using PostalServerDotNet.v1.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Request
{
    public class MessageRequest
    {
        public int Id { get; set; }

        public List<string> Expansions { get; set; }
    }
}
