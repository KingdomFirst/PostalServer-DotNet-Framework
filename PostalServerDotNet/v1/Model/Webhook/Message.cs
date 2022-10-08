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

namespace PostalServerDotNet.v1.Model.Webhook
{
    /// <summary>
    /// The webhook event payload message.
    /// </summary>
    public class Message
    {
        private double? _timestamp;
        private DateTime? _timestampDateTime;

        /// <summary>
        /// The message identifier int
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The message token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The message direction
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// The message id string.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// The e-mail addresses of the recipients.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The from email address.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The message subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The timestamp of the message.
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
        /// The timestamp of the message converted to DateTime.
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

        /// <summary>
        /// The spam status for the message
        /// </summary>
        public string SpamStatus { get; set; }

        /// <summary>
        /// The tag for the message
        /// </summary>
        public string Tag { get; set; }
    }
}
