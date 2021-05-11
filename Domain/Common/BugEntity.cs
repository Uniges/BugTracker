using BugTracker.Domain.Entities;
using System;

namespace BugTracker.Domain.Common
{
    public abstract class BugEntity : BaseEntity
    {
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
