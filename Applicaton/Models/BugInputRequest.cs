using BugTracker.Domain.Enums;

namespace BugTracker.Applicaton.Models
{
    public class BugInputRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BugUrgency Urgency { get; set; }
        public BugCriticality Criticality { get; set; }
        public string Comment { get; set; }
    }
}
