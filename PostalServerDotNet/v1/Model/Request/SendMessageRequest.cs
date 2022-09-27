using PostalServerDotNet.v1.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Request
{
    public class SendMessageRequest
    {
        public List<string> To { get; set; }

        public List<string> Cc { get; set; }

        public List<string> Bcc { get; set; }

        public string From { get; set; }

        public string Sender { get; set; }

        public string Subject { get; set; }

        public string Tag { get; set; }

        public string Reply_To { get; set; }

        public string Plain_Body { get; set; }

        public string Html_Body { get; set; }

        public List<MessageAttachment> Attachments { get; set; }

        public List<MessageHeader> Headers { get; set; }

        public bool? Bounce { get; set; }
    }
}
