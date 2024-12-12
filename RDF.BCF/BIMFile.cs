using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDF.BCF
{
    public class BIMFile
    {
        /// <summary>
        /// Is the IFC file external or within the bcfzip.
        /// </summary>
        public bool IsExternal { get; }

        /// <summary>
        /// URI to BIM file. 
        /// IsExternal=false “..\example.ifc“ (within bcfzip)
        /// IsExternal = true “https://.../example.ifc“
        /// </summary>
        public string Reference { get { return "../example.ifc"; } }

        /// <summary>
        /// The BIM file related to this topic. For IFC files this is the first item in the FILE_NAME entry in the IFC file's header.
        /// </summary>
        public string? FileName { get; }

        /// <summary>
        /// Date of the BIM file. For IFC files this is the second entry of the FILE_NAME entry in the IFC file's header. 
        /// When the timestamp given in the header does not provide timezone, it is interpreted as UTC.
        /// </summary>
        public string? Date {  get; }
        
        /// <summary>
        /// IfcGuid. Reference to the project to which this topic is related in the IFC file
        /// </summary>
        public string? IfcProject { get; set; }

        /// <summary>
        /// Yes IfcGuid Reference to the spatial structure element, e.g.IfcBuildingStorey, to which this topic is related
        /// </summary>
        public string? IfcSpatialStructureElement { get; set; }
    }
}
