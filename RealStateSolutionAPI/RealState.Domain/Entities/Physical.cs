using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Physical : AuditableEntity
    {
        public int Id { get; set; }
        public double bathRooms { get; set; }
        public double bedRooms { get; set; }
        public string parcelNumber { get; set; }
        public bool isPool { get; set; }
        public int? lotSize { get; set; }
        public int squareFeet { get; set; }
        public string stories { get; set; }
        public string units { get; set; }
        public int yearBuilt { get; set; }
        public string zipYearBuilt { get; set; }
    }
}
