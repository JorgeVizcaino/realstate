using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Financial : AuditableEntity
    {
        public int Id { get; set; }
        public decimal? capRate { get; set; }
        public string occupancy { get; set; }
        public bool isSection8 { get; set; }
        public DateTime leaseStartDate { get; set; }
        public DateTime leaseEndDate { get; set; }
        public double listPrice { get; set; }
        public decimal? salePrice { get; set; }
        public decimal? marketValue { get; set; }
        public decimal? monthlyHoa { get; set; }
        public decimal? monthlyManagementFees { get; set; }
        public double monthlyRent { get; set; }
        public decimal? netYield { get; set; }
        public decimal? turnOverFee { get; set; }
        public decimal? rehabCosts { get; set; }
        public decimal? rehabDate { get; set; }
        public double? yearlyInsuranceCost { get; set; }
        public double yearlyPropertyTaxes { get; set; }
        public bool isCashOnly { get; set; }
    }
}
