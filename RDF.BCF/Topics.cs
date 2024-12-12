using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class Topics
    {
        /// <summary>
        /// List of topics in the BCF data, existing to the moment of call
        /// </summary>
        public IEnumerable<Topic> Items { get { return m_topics; } }

        /// <summary>
        /// Creates new topic.
        /// Caller can assign GUID or it will generated automatically, GUID never changes after creation
        /// </summary>
        public Topic Add (string title, string topicType, string topicStatus, Guid? guid = null) { return AddTopic(title, topicType, topicStatus, guid); }

        #region IMPLEMENTATION
        ///////////////////////////////////////////////////////////////////////////////////////////
        private Project m_project;
        private List<Topic> m_topics = new List<Topic>();

        ///
        internal Topics(Project project) 
        {
            m_project = project;
        }

        private Topic AddTopic(string title, string topicType, string topicStatus, Guid? guid)
        {
            var topic = new Topic(m_project, title, topicType, topicStatus, guid);
            m_topics.Add(topic);
            return topic;
        }

        #endregion IMPLEMENTATION
    }
}
