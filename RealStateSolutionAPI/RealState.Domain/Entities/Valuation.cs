using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Valuation : AuditableEntity
    {
        public int id { get; set; }
        public string avmBpoValue { get; set; }
        public string avmBpoAdjValue { get; set; }
        public DateTime? avmBpoDate { get; set; }
        public string rsAvmValue { get; set; }
        public DateTime? rsAvmDate { get; set; }
        public double? rsBpoMergeValue { get; set; }
    }
}
