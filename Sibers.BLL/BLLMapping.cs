using AutoMapper;
using Sibers.BLL.DTO;
using Sibers.Domain.Entities;

namespace Sibers.BLL
{
    public class BLLMapping : Profile
    {
        public BLLMapping()
        {
            CreateMap<Employee, EmployeeDTO>()
             .ForMember(vm => vm.EId, map => map.MapFrom(m => m.EId))
             .ForMember(vm => vm.FirstName, map => map.MapFrom(m => m.FirstName))
             .ForMember(vm => vm.LastName, map => map.MapFrom(m => m.LastName))
             .ForMember(vm => vm.Email, map => map.MapFrom(m => m.Email))
             .ForMember(vm => vm.Projects, map => map.MapFrom(m => m.Projects));
            CreateMap<EmployeeDTO, Employee>()
              .ForMember(m => m.EId, map => map.MapFrom(vm => vm.EId))
              .ForMember(m => m.FirstName, map => map.MapFrom(vm => vm.FirstName))
              .ForMember(m => m.LastName, map => map.MapFrom(vm => vm.LastName))
              .ForMember(m => m.Email, map => map.MapFrom(vm => vm.Email))
              .ForMember(m => m.Projects, map => map.MapFrom(vm => vm.Projects));

            CreateMap<Project, ProjectDTO>()
              .ForMember(vm => vm.PId, map => map.MapFrom(m => m.PId))
              .ForMember(vm => vm.ProjectName, map => map.MapFrom(m => m.ProjectName))
              .ForMember(vm => vm.ReleaseDate, map => map.MapFrom(m => m.ReleaseDate))
              .ForMember(vm => vm.StartedDate, map => map.MapFrom(m => m.StartedDate))
              .ForMember(vm => vm.Employees, map => map.MapFrom(m => m.Employees));
            CreateMap<ProjectDTO, Project>()
              .ForMember(m => m.PId, map => map.MapFrom(vm => vm.PId))
              .ForMember(m => m.ProjectName, map => map.MapFrom(vm => vm.ProjectName))
              .ForMember(m => m.ReleaseDate, map => map.MapFrom(vm => vm.ReleaseDate))
              .ForMember(m => m.StartedDate, map => map.MapFrom(vm => vm.StartedDate))
              .ForMember(m => m.Employees, map => map.MapFrom(vm => vm.Employees));
        }
    }
}
