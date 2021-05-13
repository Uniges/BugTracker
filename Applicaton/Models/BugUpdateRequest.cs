using BugTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Applicaton.Models
{
    public class BugUpdateRequest
    {
        public int BugId { get; set; }
        public BugStatus BugStatus { get; set; }
        public string Comment { get; set; }
    }
}
