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
