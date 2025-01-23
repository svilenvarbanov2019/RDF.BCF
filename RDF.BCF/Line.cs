using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class Line
    {
        /// <summary>
        /// 
        /// </summary>
        public Interop.BCFPoint GetStartPoint() { Interop.BCFPoint point; if (!Interop.LineGetStartPoint(m_handle, out point)) throw new ApplicationException(Project.GetErrors()); return point; }

        /// <summary>
        /// 
        /// </summary>
        public bool SetStartPoint(Interop.BCFPoint value) { return Interop.LineSetStartPoint(m_handle, value); }

        /// <summary>
        /// 
        /// </summary>
        public Interop.BCFPoint GetEndPoint() { Interop.BCFPoint point; if (!Interop.LineGetEndPoint(m_handle, out point)) throw new ApplicationException(Project.GetErrors()); return point; }

        /// <summary>
        /// 
        /// </summary>
        public bool SetEndPoint(Interop.BCFPoint value) { return Interop.LineSetEndPoint(m_handle, value); }

        /// <summary>
        /// Remove object from BCF package. See Memory Management in documentation.
        /// </summary>
        public bool Remove() { return Interop.LineRemove(m_handle); }

        #region INTERNAL
        ///////////////////////////////////////////////////////////////////////////////////////////
        ViewPoint m_viewPoint;
        IntPtr m_handle;
        internal Project Project { get { return m_viewPoint.Project; } }

        internal Line(ViewPoint viewPoint, IntPtr handle)
        {
            m_viewPoint = viewPoint;
            m_handle = handle;
        }

        #endregion INTERNAL
    }
}
