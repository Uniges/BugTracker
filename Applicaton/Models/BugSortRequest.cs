using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Applicaton.Dto
{
    public class BugSortRequest
    {
        public string FieldName { get; set; }
        public bool IsSortByDesc { get; set; }
    }
}
