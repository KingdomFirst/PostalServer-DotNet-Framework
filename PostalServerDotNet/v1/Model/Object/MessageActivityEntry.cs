using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Object
{
    public class MessageActivityEntry
    {
        /// <summary>
        /// The loads for a message.
        /// </summary>
        public List<MessageLoad> Loads { get; set; }

        /// <summary>
        /// The clicks for a message.
        /// </summary>
        public List<MessageClick> Clicks { get; set; }
    }
}
