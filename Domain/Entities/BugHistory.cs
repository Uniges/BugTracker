using BugTracker.Domain.Common;
using BugTracker.Domain.Enums;
using System.Text.Json.Serialization;

namespace BugTracker.Domain.Entities
{
    public class BugHistory : BugEntity
    {
        public BugAction Action { get; set; }
        public string Comment { get; set; }
        public int BugId { get; set; }
        [JsonIgnore]
        public Bug Bug { get; set; }
    }
}
