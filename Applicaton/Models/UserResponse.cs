using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Applicaton.Models
{
    public class UserResponse
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
    }
}
