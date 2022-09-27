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
    public class ErrorResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the sent message data
        /// </summary>
        public ErrorData Data { get; set; }

    }
}
