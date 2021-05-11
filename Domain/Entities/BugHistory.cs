using BugTracker.Domain.Common;
using BugTracker.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Domain.Entities
{
    public class BugHistory
    {
        public int Id { get; set; }
        public BugAction Action { get; set; }
        public string Comment { get; set; }
        public int BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
