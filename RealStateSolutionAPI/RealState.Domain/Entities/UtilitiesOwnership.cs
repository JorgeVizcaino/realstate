using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class UtilitiesOwnership : AuditableEntity
    {
        public int Id { get; set; }
        public string electric { get; set; }
        public string gas { get; set; }
        public string water { get; set; }
        public string garbage { get; set; }
        public string pool { get; set; }
        public string landscaping { get; set; }
        public string pestControl { get; set; }
    }
}
