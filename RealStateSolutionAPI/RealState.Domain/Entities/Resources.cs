using System;
using System.Collections.Generic;
using System.Text;
using RealState.Domain.Common;

namespace RealState.Domain.Entities
{
    public class Resources : AuditableEntity
    {
        public int Id { get; set; }
        public List<Photo> photos { get; set; }
        public List<FloorPlan> floorPlans { get; set; }
        public List<ThreeDRendering> threeDRenderings { get; set; }
        public List<Audios> audios { get; set; }
    }
}
