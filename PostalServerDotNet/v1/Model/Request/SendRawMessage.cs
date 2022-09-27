using PostalServerDotNet.v1.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Request
{
    public class SendRawMessageRequest
    {
        public string Mail_From { get; set; }

        public List<string> Rcpt_To { get; set; }

        public string Data { get; set; }

        public bool? Bounce { get; set; }
    }
}
