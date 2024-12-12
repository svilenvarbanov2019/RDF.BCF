using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class Comment
    {
        /// <summary>
        /// The comment text, must not be empty if provided
        /// </summary>
        public string? Text {  get; set; }

        /// <summary>
        /// Reference to the viewpoint
        /// </summary>
        public Viewpoint? Viewpoint { get; set; }
    }
}
