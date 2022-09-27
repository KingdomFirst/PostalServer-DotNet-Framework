using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Object
{
    public class MessageDetail
    {
        /// <summary>
        /// The e-mail addresses of the recipients.
        /// </summary>
        public string RcptTo { get; set; }

        /// <summary>
        /// The from email address.
        /// </summary>
        public string MailFrom { get; set; }

        /// <summary>
        /// The message subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The message id string.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// The timestamp of the message.
        /// </summary>
        public double? Timestamp { get; set; }

        /// <summary>
        /// The timestamp of the message converted to DateTime.
        /// </summary>
        public DateTime? TimestampDateTime { get; set; }

        /// <summary>
        /// The direction of the message.
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// The size of the message.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// The bounces for the message
        /// </summary>
        public int Bounce { get; set; }

        /// <summary>
        /// The bounces for the Id 
        /// </summary>
        public int BounceForId { get; set; }

        /// <summary>
        /// The tag for the message
        /// </summary>
        public string Tag { get; set; }

        public int ReceivedWithSSL { get; set; }
    }
}
