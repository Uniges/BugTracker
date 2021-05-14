using BugTracker.Domain.Enums;

namespace BugTracker.Applicaton.Models
{
    public class BugUpdateRequest
    {
        public int BugId { get; set; }
        public BugStatus BugStatus { get; set; }
        public string Comment { get; set; }
    }
}
