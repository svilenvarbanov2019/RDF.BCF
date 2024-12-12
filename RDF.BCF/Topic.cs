using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class Topic
    {
        /// <summary>
        /// Read-only persistent topic identifier
        /// </summary>
        public Guid Guid { get { return m_guid; } }

        /// <summary>
        /// Title of the topic.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Type of the topic(Predefined list in “extensions.xml”)
        /// </summary>
        public string TopicType { get; set; }

        /// <summary>
        /// Status of the topic(Predefined list in “extensions.xml”)
        /// </summary>
        public string TopicStatus { get; set; }

        /// <summary>
        /// Description of the topic.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Date when the topic was created.
        /// ISO 8601 compatible YYYY-MM-DDThh:mm:ss format with optional time zone indicators.
        /// </summary>
        public string CreationDate { get { return "2016-04-28T16:31:12.270+02:00 todo"; } }

        /// <summary>
        /// User who created the topic.
        /// </summary>
        public string CreationAuthor { get { return "CreationAuthor todo"; } }

        /// <summary>
        /// Date when the topic was last modified.  only when Topic has been modified after creation.
        /// ISO 8601 compatible YYYY-MM-DDThh:mm:ss format with optional time zone indicators.
        /// </summary>
        public string? ModifiedDate { get { return null; } }

        /// <summary>
        /// User who modified the topic. Exists only when Topic has been modified after creation.
        /// </summary>
        public string? ModifiedAuthor { get { return null; } }

        /// <summary>
        /// BIM files, associated with the topic
        /// </summary>
        public BIMFiles BIMFiles { get { return m_topicFiles; } }

        /// <summary>
        /// The topic comments
        /// </summary>
        public Comments Comments { get { return m_comments; } }

        public Viewpoints Viewpoints { get { return m_viewpoints; } }

        #region IMPLEMENTATION
        ///////////////////////////////////////////////////////////////////////////////////////////
        Project m_project;
        Guid m_guid;
        BIMFiles m_topicFiles;
        Comments m_comments;
        Viewpoints m_viewpoints;
        
        internal Topic(Project project, string title, string topicType, string topicStatus, Guid? guid = null) 
        {
            m_project = project;
            Title = title;
            TopicType = topicType;
            TopicStatus = topicStatus;

            if (guid == null)
            {
                m_guid = Guid.NewGuid();
            }
            else
            {
                m_guid = guid.Value;
            }

            m_topicFiles = new BIMFiles(m_project, this);
            m_comments = new Comments(m_project, this);
            m_viewpoints = new Viewpoints(m_project, this);
        }

        #endregion IMPLEMENTATION
    }
}
