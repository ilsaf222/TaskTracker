using AutoMapper;
using TaskTracker.Domain.Entities;
using TaskTracker.Models.Project;

namespace TaskTracker.MapperProfile
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ListProjectVIewModel>();
            CreateMap<Project, ListFullInfoProjectViewModel>();
        }
    }
}
