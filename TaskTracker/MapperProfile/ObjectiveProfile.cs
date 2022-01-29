using AutoMapper;
using TaskTracker.Domain.Entities;
using TaskTracker.Models.Objective;

namespace TaskTracker.MapperProfile
{
    public class ObjectiveProfile : Profile
    {
        public ObjectiveProfile()
        {
            CreateMap<Objective, CreateObjectiveViewModel>();
            CreateMap<Objective, EditObjectiveViewModel>();
            CreateMap<Objective, ListObjectiveViewModel>();
        }
    }
}
