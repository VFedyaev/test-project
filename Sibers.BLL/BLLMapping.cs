using AutoMapper;
using Sibers.BLL.DTO;
using Sibers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.BLL
{
    public class BLLMapping : Profile
    {
        public BLLMapping()
        {
            CreateMap<Employee, EmployeeDTO>(MemberList.None).ReverseMap();

            CreateMap<Project, ProjectDTO>(MemberList.None).ReverseMap();
        }
    }
}
