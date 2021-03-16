using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class ThreeDRendering : AuditableEntity
    {
        public int ThreeDRenderingId { get; set; }
        public string guid { get; set; }
        public string resourceType { get; set; }
        public bool isPublic { get; set; }
        public string description { get; set; }
        public string filename { get; set; }
        public string sizeInByte { get; set; }
        public string contentType { get; set; }
        public string url { get; set; }
        public string urlMedium { get; set; }
        public string urlSmall { get; set; }
        public string textContent { get; set; }
    }
}
