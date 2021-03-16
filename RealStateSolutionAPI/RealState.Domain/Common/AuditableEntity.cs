using System;

namespace RealState.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string ModifyBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}