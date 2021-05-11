using BugTracker.Domain.Common;
using BugTracker.Domain.Enums;

namespace BugTracker.Domain.Entities
{
    public class BugHistory : BugEntity
    {
        public BugAction Action { get; set; }
        public string Comment { get; set; }
        public int BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
