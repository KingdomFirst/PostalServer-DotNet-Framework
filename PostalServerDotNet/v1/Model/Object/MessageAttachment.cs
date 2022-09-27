using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Object
{
    public class MessageAttachment
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string Content_Type { get; set; }

        /// <summary>
        /// Gets or sets the base64 encoded data.
        /// </summary>
        public string Data { get; set; }
    }
}
