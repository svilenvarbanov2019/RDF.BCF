using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class ClippingPlane
    {
        /// <summary>
        /// 
        /// </summary>
        public Interop.BCFPoint GetLocation() { Interop.BCFPoint point; if (!Interop.ClippingPlaneGetLocation(m_handle, out point)) throw new ApplicationException(Project.GetErrors()); return point; }

        /// <summary>
        /// 
        /// </summary>
        public bool SetLocation(Interop.BCFPoint value) { return Interop.ClippingPlaneSetLocation(m_handle, value); }

        /// <summary>
        /// The Direction vector points in the invisible direction meaning the half-space that is clipped
        /// </summary>
        public Interop.BCFPoint GetDirection() { Interop.BCFPoint point; if (!Interop.ClippingPlaneGetDirection(m_handle, out point)) throw new ApplicationException(Project.GetErrors()); return point; }

        /// <summary>
        /// The Direction vector points in the invisible direction meaning the half-space that is clipped
        /// </summary>
        public bool SetDirection(Interop.BCFPoint value) { return Interop.ClippingPlaneSetDirection(m_handle, value); }

        /// <summary>
        /// Remove object from BCF package. See Memory Management in documentation.
        /// </summary>
        public bool Remove() { return Interop.ClippingPlaneRemove(m_handle); }

        #region INTERNAL
        ///////////////////////////////////////////////////////////////////////////////////////////
        ViewPoint m_viewPoint;
        IntPtr m_handle;

        internal Project Project { get { return m_viewPoint.Project; } }

        internal ClippingPlane(ViewPoint viewPoint, IntPtr handle)
        {
            m_viewPoint = viewPoint;
            m_handle = handle;
        }

        #endregion INTERNAL
    }
}
