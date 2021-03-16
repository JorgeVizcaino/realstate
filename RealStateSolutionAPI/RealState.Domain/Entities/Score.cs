using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Score : AuditableEntity
    {
        public int Id { get; set; }
        public int? conditionScore { get; set; }
        public string crimeScore { get; set; }
        public int neighborhoodScore { get; set; }
        public decimal? overallScore { get; set; }
        public decimal? qualityScore { get; set; }
        public string schoolScore { get; set; }
        public string charterSchoolScore { get; set; }
        public string floodRiskScore { get; set; }
        public decimal? walkabilityScore { get; set; }
    }
}
