using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class LeaseSummary : AuditableEntity
    {
        public int Id { get; set; }
        public string occupancy { get; set; }
        public string leasingStatus { get; set; }
        public decimal? marketedRent { get; set; }
        public string paymentStatus { get; set; }
        public DateTime leaseStartDate { get; set; }
        public DateTime leaseEndDate { get; set; }
        public double monthlyRent { get; set; }
        public double? securityDepositAmount { get; set; }
        public bool? hasPet { get; set; }
        public decimal? petFeeAmount { get; set; }
        public bool isPetsDeposit { get; set; }
        public double? petsDepositAmount { get; set; }
        public bool? isLeaseConcessions { get; set; }
        public bool isRentersInsuranceRequired { get; set; }
        public bool isSection8 { get; set; }
        public bool isTenantBackgroundChecked { get; set; }
        public bool isTenantIncomeAbove3x { get; set; }
        public bool? isTenantMayTerminateEarly { get; set; }
        public bool? isTenantPurchaseOption { get; set; }
    }
}
