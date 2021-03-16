using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public int Id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string zipPlus4 { get; set; }
    }
}
