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
    public class SendData
    {
        /// <summary>
        /// Gets or sets the message id.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public string Messages { get; set; }

    }
}
