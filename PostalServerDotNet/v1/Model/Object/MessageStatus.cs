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
    /// The message status details.
    /// </summary>
    public class MessageStatus
    {
        private double? _lastDeliveryAttempt;
        private DateTime? _lastDeliveryAttemptDateTime;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the last delivery attempt.
        /// </summary>
        public double? LastDeliveryAttempt 
        {
            get
            {
                return _lastDeliveryAttempt;
            }
            set
            {
                _lastDeliveryAttempt = value;
                _lastDeliveryAttemptDateTime = Utilities.UnixTimeStampToDateTime( _lastDeliveryAttempt.Value );
            }
        }

        /// <summary>
        /// Gets or sets the held.
        /// </summary>
        public bool? Held { get; set; }

        /// <summary>
        /// Gets or sets the hold expiry.
        /// </summary>
        public int? HoldExpiry { get; set; }

        /// <summary>
        /// Gets or sets the last delivery attempt DateTime.
        /// </summary>
        public DateTime? LastDeliveryAttemptDateTime
        {
            get 
            {
                if ( _lastDeliveryAttemptDateTime == null && LastDeliveryAttempt != null ) 
                {
                    _lastDeliveryAttemptDateTime = Utilities.UnixTimeStampToDateTime( LastDeliveryAttempt.Value );
                }
                return _lastDeliveryAttemptDateTime;
            }
            set 
            {
                _lastDeliveryAttemptDateTime = value; 
            }
        }
    }
}
