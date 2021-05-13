using BugTracker.Domain.Common;
using BugTracker.Domain.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BugTracker.Domain.Entities
{
    public class Bug : BugEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public BugUrgency Urgency { get; set; }
        public BugCriticality Criticality { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<BugHistory> History { get; set; }
    }
}
