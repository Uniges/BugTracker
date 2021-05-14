using AutoMapper;
using BugTracker.Applicaton.Models;
using BugTracker.Domain.Entities;

namespace BugTracker.Applicaton
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BugInputRequest, Bug>();
        }
    }
}
