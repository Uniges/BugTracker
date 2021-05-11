using BugTracker.Domain.Common;
using BugTracker.Domain.Enums;
using System;
using System.Collections.Generic;

namespace BugTracker.Domain.Entities
{
    public class Bug : BugEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public BugUrgency Urgency { get; set; }
        public BugCriticality Criticality { get; set; }
        //public ICollection<BugHistory> History { get; set; }
    }
}
