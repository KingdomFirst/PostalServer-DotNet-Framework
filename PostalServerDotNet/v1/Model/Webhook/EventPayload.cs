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
using Newtonsoft.Json;
using UAParser;

namespace PostalServerDotNet.v1.Model.Webhook
{
    /// <summary>
    /// The webhook event payload.
    /// </summary>
    public class EventPayload
    {
        private double? _timestamp;
        private DateTime? _timestampDateTime;

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the IP Address.
        /// </summary>
        [JsonProperty( PropertyName = "ip_address" )]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the User Agent.
        /// </summary>
        [JsonProperty( PropertyName = "user_agent" )]
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public Message Message { get; set; }

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
        /// Gets or sets the sent_with_ssl property.
        /// </summary>
        [JsonProperty( PropertyName = "sent_with_ssl" )]
        public bool? SentWithSsl { get; set; }

        /// <summary>
        /// The timestamp of the payload.
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
        /// The timestamp of the payload converted to DateTime.
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
        /// Gets or sets the time.
        /// </summary>
        public double? Time { get; set; }

        /// <summary>
        /// Gets or sets the original message.
        /// </summary>
        [JsonProperty( PropertyName = "original_message" )]
        public Message OriginalMessage { get; set; }
        /// <summary>
        /// Gets or sets the bounce message.
        /// </summary>
        public Message Bounce { get; set; }

        /// <summary>
        /// Gets the client os.
        /// </summary>
        /// <value>
        /// The client os.
        /// </value>
        public string ClientOs
        {
            get
            {
                var clientInfo = GetClientInfo();
                return clientInfo?.OS.Family ?? string.Empty;
            }
        }

        /// <summary>
        /// Gets the client browser.
        /// </summary>
        /// <value>
        /// The client browser.
        /// </value>
        public string ClientBrowser
        {
            get
            {
                var clientInfo = GetClientInfo();
                return clientInfo?.UA.Family ?? string.Empty;
            }
        }

        /// <summary>
        /// Gets the type of the client device.
        /// </summary>
        /// <value>
        /// The type of the client device.
        /// </value>
        public string ClientDeviceType
        {
            get
            {
                var clientInfo = GetClientInfo();
                return clientInfo?.Device.Family ?? string.Empty;
            }
        }

        /// <summary>
        /// Gets the client device brand.
        /// </summary>
        /// <value>
        /// The client device brand.
        /// </value>
        public string ClientDeviceBrand
        {
            get
            {
                var clientInfo = GetClientInfo();
                return clientInfo?.Device.Brand ?? string.Empty;
            }
        }

        private ClientInfo _clientInfo = null;
        private ClientInfo GetClientInfo()
        {
            if ( _clientInfo == null && !string.IsNullOrWhiteSpace( UserAgent ) )
            {
                var parser = Parser.GetDefault();
                _clientInfo = parser.Parse( UserAgent );
            }
            return _clientInfo;
        }
    }
}
