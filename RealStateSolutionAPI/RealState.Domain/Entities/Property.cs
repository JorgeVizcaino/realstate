using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Property : AuditableEntity
    {
        public int PropertyId { get; set; }
        public int accountId { get; set; }
        public int? buyerAccountId { get; set; }
        public int? buyerUserId { get; set; }
        public int? externalId { get; set; }
        public int? programId { get; set; }
        public bool isDwellCertified { get; set; }
        public bool isAllowOffer { get; set; }
        public bool isAllowPreview { get; set; }
        public bool isFeatured { get; set; }
        public bool isRentGuaranteed { get; set; }
        public bool allowRentGuaranteedOptout { get; set; }
        public bool isSecuritized { get; set; }
        public bool isHot { get; set; }
        public bool isNew { get; set; }
        public bool? isBargain { get; set; }
        public bool isDiligenceVaultUnlocked { get; set; }
        public bool? isPropertyManagerOfferRetain { get; set; }
        public bool? isHoa { get; set; }
        public bool hasAudio { get; set; }
        public bool hasDiligenceVaultDocuments { get; set; }
        public int market { get; set; }
        public int? daysOnMarket { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string propertyName { get; set; }
        public string description { get; set; }
        public string highlights { get; set; }
        public string mainImageUrl { get; set; }
        public string personalProperties { get; set; }
        public string diligenceVaultSummary { get; set; }
        public string featuredReason { get; set; }
        public string status { get; set; }
        public string allowedFundingTypes { get; set; }
        public string allowableSaleTypes { get; set; }
        public string visibility { get; set; }
        public string priceVisibility { get; set; }
        public string propertyType { get; set; }
        public string certificationLevel { get; set; }
        public DateTime? escrowClosingDate { get; set; }
        public Address address { get; set; }
        public Financial financial { get; set; }
        public Physical physical { get; set; }
        public Score score { get; set; }
        public Valuation valuation { get; set; }
        public Resources resources { get; set; }
        public string manager { get; set; }
        public string seller { get; set; }
        public string sellerBroker { get; set; }
        public string hoa { get; set; }
        public Lease lease { get; set; }
        public List<Diligences> diligences { get; set; }
        public GoogleMapOption googleMapOption { get; set; }
        public int? inspectionType { get; set; }
    }
}
