using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class Comments
    {
        /// <summary>
        /// List comments at the moment of call
        /// </summary>
        public IEnumerable<Comment> Items { get { return m_comments; } }

        /// <summary>
        /// Adds file to the topic by URL or local path.
        /// Can keep it as external or copy to BCF data
        /// </summary>
        public Comment Add(string? text) { return new Comment(); }

        #region IMPLEMENTATION
        ///////////////////////////////////////////////////////////////////////////////////////////
        private Project m_project;
        private Topic m_topic;
        private List<Comment> m_comments = new List<Comment>();

        ///
        internal Comments(Project project, Topic topic)
        {
            m_project = project;
            m_topic = topic;
        }

        #endregion IMPLEMENTATION
    }
}
