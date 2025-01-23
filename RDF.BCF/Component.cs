using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class Component
    {
        /// <summary>
        /// The IfcGuid of the component. Required if AuthoringToolId is not provided.
        /// </summary>
        public string IfcGuid { get { return Interop.ComponentGetIfcGuid(m_handle); } set { Interop.ComponentSetIfcGuid(m_handle, value); } }

        /// <summary>
        /// System specific identifier of the component in the originating BIM tool.
        /// </summary>
        public string AuthoringToolId { get { return Interop.ComponentGetAuthoringToolId(m_handle); } set { Interop.ComponentSetAuthoringToolId(m_handle, value); } }

        /// <summary>
        /// Name of the system in which the component is originated
        /// </summary>
        public string OriginatingSystem { get { return Interop.ComponentGetOriginatingSystem(m_handle); } set { Interop.ComponentSetOriginatingSystem(m_handle, value); } }

        /// <summary>
        /// Remove the compoment reference from the list where it's used. See Memory Management in documentation
        /// </summary>
        public bool Remove() { return Interop.ViewPointComponentRemove(m_handle); }

        #region INTERNAL
        ///////////////////////////////////////////////////////////////////////////////////////////
        Project m_project;
        IntPtr m_handle;

        internal IntPtr Handle { get { return m_handle; } }

        internal Component(Project project, IntPtr handle)
        {
            m_project = project;
            m_handle = handle;
        }

        #endregion INTERNAL    
    }
}
