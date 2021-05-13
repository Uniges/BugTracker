using BugTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Applicaton.Models
{
    public class BugRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public BugUrgency Urgency { get; set; }
        public BugCriticality Criticality { get; set; }
        public string Comment { get; set; }
    }
}
