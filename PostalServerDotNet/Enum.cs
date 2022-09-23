using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet
{
    public class Enum
    {
        /// <summary>
        /// When to send the auto-response text.
        /// </summary>
        public enum MessageExpansion
        {
            ALL,
            STATUS,
            DETAILS,
            INSPECTION,
            PLAINBODY,
            HTMLBODY,
            ATTACHMENTS,
            HEADERS,
            RAWMESSAGE,
            ACTIVITYENTRIES
        }
    }
}
