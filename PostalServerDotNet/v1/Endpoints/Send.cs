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

using PostalServerDotNet.v1.Model.Object;
using PostalServerDotNet.v1.Model.Request;
using PostalServerDotNet.v1.Model.Response;
using RestSharp;
using System.Collections.Generic;

namespace PostalServerDotNet.v1
{
    public partial class Client
    {

        /// <summary>
        /// Sends a message. https://apiv1.postalserver.io/controllers/send/message.html
        /// </summary>
        /// <param name="From">The e-mail address for the From header</param>
        /// <param name="To">The e-mail addresses of the recipients (max 50)</param>
        /// <param name="Cc">The e-mail addresses of any CC contacts (max 50)</param>
        /// <param name="Bcc">The e-mail addresses of any BCC contacts (max 50)</param>
        /// <param name="Sender">The e-mail address for the Sender header</param>
        /// <param name="Subject">The subject of the e-mail</param>
        /// <param name="Tag">The tag of the e-mail</param>
        /// <param name="ReplyTo">Set the reply-to address for the mail</param>
        /// <param name="PlainBody">The plain text body of the e-mail</param>
        /// <param name="HtmlBody">The HTML body of the e-mail</param>
        /// <param name="Attachments">An array of attachments for this e-mail</param>
        /// <param name="Headers">A hash of additional headers</param>
        /// <param name="Bounce">Is this message a bounce?</param>
        /// <returns></returns>
        public SendResponse SendMessage( string From, List<string> To, List<string> Cc = null, List<string> Bcc = null, string Sender = null, string Subject = null, string Tag = null, string ReplyTo = null, string PlainBody = null, string HtmlBody = null, List<MessageAttachment> Attachments = null, List<MessageHeader> Headers = null, bool Bounce = false )
        {
            var request = new RestRequest( "send/message", Method.POST );

            var reqBody = new SendMessageRequest
            {
                To = To,
                Cc = Cc,
                Bcc = Bcc,
                From = From,
                Sender = Sender,
                Subject = Subject,
                Tag = Tag,
                ReplyTo = ReplyTo,
                PlainBody = PlainBody,
                HtmlBody = HtmlBody,
                Attachments = Attachments,
                Headers = Headers,
                Bounce = Bounce
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<SendResponse>( request );
        }

        /// <summary>
        /// Send message from raw Base64 encoded RFC2822 formatted message. https://apiv1.postalserver.io/controllers/send/raw.html
        /// </summary>
        /// <param name="MailFrom">The address that should be logged as sending the message.</param>
        /// <param name="RcptTo">The addresses this message should be sent to.</param>
        /// <param name="Data">The base64 encoded RFC2822 message to send.</param>
        /// <param name="Bounce">Is this message a bounce?</param>
        /// <returns></returns>
        public SendResponse SendRawMessage( string MailFrom, List<string> RcptTo, string Data, bool? Bounce = false )
        {
            var request = new RestRequest( "send/raw", Method.POST );

            var reqBody = new SendRawMessageRequest
            {
                MailFrom = MailFrom,
                RcptTo = RcptTo,
                Data = Data,
                Bounce = Bounce
            };

            AddRequestJsonBody( request, reqBody );
            return Execute<SendResponse>( request );
        }
    }
}
