using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Object
{
    /// <summary>
    /// The message status details.
    /// </summary>
    public class MessageStatus
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the last delivery attempt.
        /// </summary>
        public double LastDeliveryAttempt { get; set; }

        /// <summary>
        /// Gets or sets the held.
        /// </summary>
        public bool? Held { get; set; }

        /// <summary>
        /// Gets or sets the hold expiry.
        /// </summary>
        public int? HoldExpiry { get; set; }
    }
}
