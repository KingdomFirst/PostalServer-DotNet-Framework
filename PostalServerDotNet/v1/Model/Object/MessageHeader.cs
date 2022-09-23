using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Object
{
    public class MessageHeader
    {
        public List<string> Received { get; set; }

        public List<string> Date { get; set; }

        public List<string> From { get; set; }

        public List<string> To { get; set; }

        public List<string> MessageId { get; set; }

        public List<string> Subject { get; set; }

        public List<string> MimeVersion { get; set; }

        public List<string> ContentType { get; set; }

        public List<string> ContentTransferEncoding { get; set; }

        public List<string> DkimSignature { get; set; }

        public List<string> XPostalMsgId { get; set; }
    }
}
