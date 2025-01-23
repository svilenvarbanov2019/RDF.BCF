using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class BimSnippet
    {
        /// <summary>
        /// Type of the Snippet
        /// </summary>
        public string SnippetType { get { return Interop.BimSnippetGetSnippetType(m_handle); } set { Interop.BimSnippetSetSnippetType(m_handle, value); } }

        /// <summary>
        /// Is the BimSnippet external or within the bcfzip. (Default = false).
        /// </summary>
        public bool IsExternal { get { return Interop.BimSnippetGetIsExternal(m_handle); } set { Interop.BimSnippetSetIsExternal(m_handle, value); } }

        /// <summary>
        /// Absolute file path (file system or URI). See Files Management in documentation.
        /// </summary>
        public string Reference { get { return Interop.BimSnippetGetReference(m_handle); } set { Interop.BimSnippetSetReference(m_handle, value); } }

        /// <summary>
        /// URI to BimSnippetSchema (always external)
        /// </summary>
        public string ReferenceSchema { get { return Interop.BimSnippetGetReferenceSchema(m_handle); } set { Interop.BimSnippetSetReferenceSchema(m_handle, value); } }

        /// <summary>
        /// Remove object from BCF package. See Memory Management in documentation.
        /// </summary>
        public bool Remove() { return Interop.BimSnippetRemove(m_handle); }

        #region INTERNAL
        ///////////////////////////////////////////////////////////////////////////////////////////
        Topic m_topic;
        IntPtr m_handle;

        internal BimSnippet(Topic topic, IntPtr handle)
        {
            m_topic = topic;
            m_handle = handle;
        }

        #endregion INTERNAL
    }
}
