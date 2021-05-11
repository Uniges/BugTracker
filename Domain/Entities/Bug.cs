using BugTracker.Domain.Common;
using BugTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Domain.Entities
{
    public class Bug
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public BugUrgency Urgency { get; set; }
        public BugCriticality Criticality { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<BugHistory> History { get; set; }
    }
}
