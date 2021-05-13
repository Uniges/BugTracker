using BugTracker.Domain.Common;
using System.Text.Json.Serialization;

namespace BugTracker.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
