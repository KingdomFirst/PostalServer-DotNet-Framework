﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Object
{
    public class MessageClick
    {
        /// <summary>
        /// The Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The ip address.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// The user agent.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// The timestamp.
        /// </summary>
        public DateTime? Timestamp { get; set; }
    }
}