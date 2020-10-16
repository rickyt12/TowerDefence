using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine;
namespace Template
{
    /// <summary>
    /// defines message types
    /// the one here is an example
    /// </summary>
    class GMsg : MessageType
    {

        /// <summary>
        /// player who score is in objectvalue
        /// </summary>
        public static readonly MessageType Scored = new MessageType("Scored");
        

    }
}
