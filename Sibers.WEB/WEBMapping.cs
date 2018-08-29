using AutoMapper;
using Sibers.BLL.DTO;
using Sibers.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibers.WEB
{
    public class WEBMapping : Profile
    {
        public WEBMapping()
        {
            CreateMap<EmployeeDTO, EmployeeViewModel>(MemberList.None).ReverseMap();

            CreateMap<ProjectDTO, ProjectViewModel>(MemberList.None).ReverseMap();
        }
    }
}