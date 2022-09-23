using PostalServerDotNet.v1.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PostalServerDotNet.Enum;

namespace PostalServerDotNet.v1.Model.Request
{
    public class MessageRequestAllExpansions
    {
        public int Id { get; set; }

        public bool Expansions { get; set; }
    }
}
