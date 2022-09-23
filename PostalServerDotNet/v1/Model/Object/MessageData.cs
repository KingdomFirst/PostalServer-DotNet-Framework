using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Object
{
    /// <summary>
    /// The message data.
    /// </summary>
    public class MessageData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public MessageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public MessageDetail Details { get; set; }

        /// <summary>
        /// Gets or sets the inspection
        /// </summary>
        public MessageInspection Inspection { get; set; }

        /// <summary>
        /// Gets or sets the plain_body.
        /// </summary>
        public string PlainBody { get; set; }

        /// <summary>
        /// Gets or sets the html_body.
        /// </summary>
        public string HtmlBody { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        public List<string> Attachments { get; set; }

        /// <summary>
        /// Gets or sets the message headers.
        /// </summary>
        public MessageHeader Headers { get; set; }

        /// <summary>
        /// Gets or sets the raw_message.
        /// </summary>
        public string RawMessage { get; set; }

        /// <summary>
        /// Gets or sets the activity entries
        /// </summary>
        public MessageActivityEntry ActivityEntries { get; set; }
    }
}
