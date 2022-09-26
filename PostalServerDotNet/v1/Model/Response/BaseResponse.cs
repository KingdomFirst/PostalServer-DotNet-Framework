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
    public class BaseResponse
    {

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the server request completion time.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public float Time { get; set; }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ResponseFlag Flags { get; set; }
    }
}
