using PostalServerDotNet.v1.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Response
{
    /// <summary>
    /// The api response retrieving a single message.
    /// </summary>
    public class MessageDeliveriesResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the message delivery data
        /// </summary>
        public List<MessageDeliveryData> Data { get; set; }
    }
}
