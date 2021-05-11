using AutoMapper;
using BugTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Applicaton
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Bug, BugDto>();
        }
    }
}
