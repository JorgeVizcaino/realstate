using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class GoogleMapOption : AuditableEntity
    {
        public int Id { get; set; }
        public bool hasStreetView { get; set; }
        public int povHeading { get; set; }
        public int povPitch { get; set; }
        public double povLatitude { get; set; }
        public double povLongitude { get; set; }
    }
}
