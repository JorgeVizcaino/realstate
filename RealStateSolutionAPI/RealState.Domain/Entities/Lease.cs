using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Lease : AuditableEntity
    {
        public int Id { get; set; }
        public LeaseSummary leaseSummary { get; set; }
        public UtilitiesOwnership utilitiesOwnership { get; set; }
        public ApplianceOwnership applianceOwnership { get; set; }
    }
}
