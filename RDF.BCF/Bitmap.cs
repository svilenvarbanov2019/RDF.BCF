using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class Bitmap
    {
        /// <summary>
        /// Format of the bitmap (png or jpg)
        /// </summary>
        public Interop.BCFBitmapFormat Format { get { return Interop.BitmapGetFormat(m_handle); } set { Interop.BitmapSetFormat(m_handle, value); } }

        /// <summary>
        /// Absolute file path (file system or URI). See Files Management in documentation.
        /// </summary>
        public string Reference { get { return Interop.BitmapGetReference(m_handle); } set { Interop.BitmapSetReference(m_handle, value); } }

        /// <summary>
        /// The height of the bitmap in the model, in meters
        /// </summary>
        public double Height { get { return Interop.BitmapGetHeight(m_handle); } set { Interop.BitmapSetHeight(m_handle, value); } }

        /// <summary>
        /// Location of the center of the bitmap in world coordinates
        /// </summary>
        public Interop.BCFPoint GetLocation() { Interop.BCFPoint point; if (!Interop.BitmapGetLocation(m_handle, out point)) throw new ApplicationException(Project.GetErrors()); return point; }

        /// <summary>
        /// Location of the center of the bitmap in world coordinates
        /// </summary>
        public bool SetLocation(Interop.BCFPoint value) { return Interop.BitmapSetLocation(m_handle, value); }

        /// <summary>
        /// Normal vector of the bitmap
        /// </summary>
        public Interop.BCFPoint GetNormal() { Interop.BCFPoint point; if (!Interop.BitmapGetNormal(m_handle, out point)) throw new ApplicationException(Project.GetErrors()); return point; }

        /// <summary>
        /// Normal vector of the bitmap
        /// </summary>
        public bool SetNormal(Interop.BCFPoint value) { return Interop.BitmapSetNormal(m_handle, value); }

        /// <summary>
        /// Up vector of the bitmap
        /// </summary>
        public Interop.BCFPoint GetUp() { Interop.BCFPoint point; if (!Interop.BitmapGetUp(m_handle, out point)) throw new ApplicationException(Project.GetErrors()); return point; }

        /// <summary>
        /// Up vector of the bitmap
        /// </summary>
        public bool SetUp(Interop.BCFPoint value) { return Interop.BitmapSetUp(m_handle, value); }

        /// <summary>
        /// Remove object from BCF package. See Memory Management in documentation.
        /// </summary>
        public bool Remove() { return Interop.BitmapRemove(m_handle); }

        #region INTERNAL
        ///////////////////////////////////////////////////////////////////////////////////////////
        ViewPoint m_viewPoint;
        IntPtr m_handle;
        internal IntPtr Handle { get { return m_handle; } }

        internal Project Project { get { return m_viewPoint.Project; } }

        internal Bitmap(ViewPoint viewPoint, IntPtr handle)
        {
            m_viewPoint = viewPoint;
            m_handle = handle;
        }

        #endregion INTERNAL    
    }
}
