// <copyright>
// MIT License
// 
// Copyright (c) 2022 Kingdom First Solutions
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// </copyright>

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
