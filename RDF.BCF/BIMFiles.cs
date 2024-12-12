using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class BIMFiles
    {
        /// <summary>
        /// List files associated with topic at the moment of call
        /// </summary>
        public IEnumerable<BIMFile> Items { get { return m_files; } }

        /// <summary>
        /// Adds file to the topic by URL or local path.
        /// Can keep it as external or copy to BCF data
        /// </summary>
        public BIMFile Add(string fileURL, bool keepExternal = false) { return new BIMFile(); }

        #region IMPLEMENTATION
        ///////////////////////////////////////////////////////////////////////////////////////////
        private Project m_project;
        private Topic m_topic;
        private List<BIMFile> m_files = new List<BIMFile>();

        ///
        internal BIMFiles(Project project, Topic topic)
        {
            m_project = project;
            m_topic = topic;
        }

        #endregion IMPLEMENTATION
    }
}
