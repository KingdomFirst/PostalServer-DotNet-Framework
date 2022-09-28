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
    public class MessageDeliveryData
    {
        private double? _timestamp;
        private DateTime? _timestampDateTime;


        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the output.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the sent_with_ssl flag.
        /// </summary>
        public bool? SentWithSSL { get; set; }

        /// <summary>
        /// Gets or sets the log_id.
        /// </summary>
        public string LogId { get; set; }

        /// <summary>
        /// Gets or sets the delivery time.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public float Time { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        public double? Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                _timestamp = value;
                _timestampDateTime = Utilities.UnixTimeStampToDateTime( _timestamp.Value );
            }
        }

        /// <summary>
        /// The timestamp of the detail converted to DateTime.
        /// </summary>
        public DateTime? TimestampDateTime
        {
            get
            {
                if ( _timestampDateTime == null && Timestamp != null )
                {
                    _timestampDateTime = Utilities.UnixTimeStampToDateTime( Timestamp.Value );
                }
                return _timestampDateTime;
            }
            set
            {
                _timestampDateTime = value;
            }
        }
    }
}
