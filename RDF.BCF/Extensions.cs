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
        /// Get elements of enumeration of given type
        /// </summary>
        public List<string> GetElements(Interop.BCFEnumeration enumeration)
        {
            var list = new List<string>();
            UInt16 index = 0;
            string elem;
            while (""!=(elem = Interop.EnumerationElementGet(m_project.Handle, enumeration, index++))){
                list.Add(elem);
            }
            return list;
        }

        /// <summary>
        /// Add element to the enumeration of given type
        /// </summary>
        public bool AddElement (Interop.BCFEnumeration enumeration, string elem)
        {
            return Interop.EnumerationElementAdd(m_project.Handle, enumeration, elem);
        }

        /// <summary>
        /// Remove element from the enumeration of given type
        /// </summary>
        public bool RemoveElement (Interop.BCFEnumeration enumeration, string elem)
        {
            return Interop.EnumerationElementRemove(m_project.Handle, enumeration, elem);
        }

        #region INTERNAL
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///
        private Project m_project;

        internal Extensions(Project project)
        {
            m_project = project;
        }

        #endregion INTERNAL
    }
}
