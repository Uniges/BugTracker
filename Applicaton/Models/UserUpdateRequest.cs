﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Applicaton.Models
{
    public class UserUpdateRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
