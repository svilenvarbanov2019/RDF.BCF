using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class Extensions
    {
        /// <summary>
        /// Types of BCF enumerations 
        /// </summary>
        public enum Enum
        {
            Users,
            TopicTypes,
            TopicStatuses,
            Priorities,
            TopicLabels,
            SnippetTypes,
            Stages
        }

        /// <summary>
        /// Get elements of enumeration of given type
        /// </summary>
        public IEnumerable<string> GetEnumeration(Enum enumeration)
        {
            return new string[] { $"{enumeration}_A", $"{enumeration}_B"};
        }

        /// <summary>
        /// Modify enumeration of given type
        /// </summary>
        public void AddEnumerationElement (Enum enumeration, string elem)
        {
        }

        /// <summary>
        /// Modify elements of enumeration of given type
        /// </summary>
        public void RemoveEnumerationElement (Enum enumeration, string elem)
        {
        }

        /// <summary>
        /// Read enumerations form an XML file which follows BCF schema extensions.xsd 
        /// </summary>
        public void LoadExtensions (string filePath, bool append)
        {
        }

        #region IMPLEMENTATION
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///
        private Project m_project;

        internal Extensions(Project project)
        {
            m_project = project;
        }

        #endregion IMPLEMENTATION
    }
}
