using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class ApplianceOwnership : AuditableEntity
    {
        public int Id { get; set; }
        public string refrigerator { get; set; }
        public string dishwasher { get; set; }
        public string washer { get; set; }
        public string dryer { get; set; }
        public string microwave { get; set; }
        public string stove { get; set; }
    }
}
