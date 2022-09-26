using PostalServerDotNet.v1.Model.Object;
using PostalServerDotNet.v1.Model.Request;
using PostalServerDotNet.v1.Model.Response;
using RestSharp;
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
                        _Expansions = true
                    };
                    AddRequestJsonBody( request, reqBody );
                }
                else
                {
                    var reqBody = new MessageRequest
                    {
                        Id = MessageId
                    };
                    reqBody._Expansions = Expansions.Select( e => e.ToString().ToLower() ).ToList();
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

            return Execute<MessageResponse>( request );
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
            return Execute<MessageDeliveriesResponse>( request );
        }
    }
}
