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
using System;
using System.Collections.Generic;
using System.Linq;
using static PostalServerDotNet.Enum;

namespace PostalServerDotNet.v1
{
    public partial class Client
    {
        /// <summary>
        /// Get all details about a message.
        /// </summary>
        /// <param name="MessageId">The id of the message</param>
        /// <param name="Expansions">The expansions to include in the request.</param>
        /// <returns></returns>
        public MessageResponse GetMessageDetails( int MessageId, List<MessageExpansion> Expansions = null )
        {
            var request = new RestRequest( "messages/message", Method.POST );
            if ( Expansions != null && Expansions.Count > 0 )
            {
                if ( Expansions.Any( e => e == MessageExpansion.ALL ) )
                {
                    var reqBody = new MessageRequestAllExpansions
                    {
                        Id = MessageId,
                        Expansions = true
                    };
                    AddRequestJsonBody( request, reqBody );
                }
                else
                {
                    var reqBody = new MessageRequest
                    {
                        Id = MessageId
                    };
                    reqBody.Expansions = Expansions.Select( e => e.ToString().ToLower() ).ToList();
                    AddRequestJsonBody( request, reqBody );
                }
            }
            else
            {
                var reqBody = new MessageRequest
                {
                    Id = MessageId
                };
                AddRequestJsonBody( request, reqBody );
            }
            var response = Execute<MessageResponse>( request );

            return response;
        }

        /// <summary>
        /// Get the deliveries which have been attempted for this message.
        /// </summary>
        /// <param name="MessageId">The id of the message</param>
        /// <returns></returns>
        public MessageDeliveriesResponse GetMessageDeliveries( int MessageId )
        {
            var request = new RestRequest( "messages/deliveries", Method.POST );
            var reqBody = new MessageRequest
            {
                Id = MessageId
            };
            AddRequestJsonBody( request, reqBody );
            var response = Execute<MessageDeliveriesResponse>( request );
            foreach ( var delivery in response.Data )
            {
                if ( delivery.Timestamp != null && delivery.Timestamp > 0 )
                {
                    delivery.TimestampDateTime = UnixTimeStampToDateTime( delivery.Timestamp.Value );
                }
            }

            return response;
        }
    }
}
