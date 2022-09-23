using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalServerDotNet.v1.Model.Object
{
    public class MessageInspection
    {
        /// <summary>
        /// The inspected flag.
        /// </summary>
        public bool? Inspected { get; set; }

        /// <summary>
        /// The spam flag.
        /// </summary>
        public bool? Spam { get; set; }

        /// <summary>
        /// The spam score.
        /// </summary>
        public float? SpamScore { get; set; }

        /// <summary>
        /// The threat flag.
        /// </summary>
        public bool? Threat { get; set; }

        /// <summary>
        /// The threat setting.
        /// </summary>
        public string ThreatDetails { get; set; }
    }
}
