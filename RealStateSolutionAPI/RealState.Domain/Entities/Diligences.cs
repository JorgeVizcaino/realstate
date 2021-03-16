using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Diligences : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
