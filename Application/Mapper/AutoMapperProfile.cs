using AutoMapper;
using DTOs.Department;
using DTOs.Employee;
using DTOs.Project;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class AutoMapperProfile:Profile
    { 
        public AutoMapperProfile()
        {

            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();
            //CreateMap<Department, CreateDepartmentDTO>().ReverseMap();
            CreateMap<Department,GetAllDepartments>().ReverseMap();

            CreateMap<Employee, CreateEmployee>().ReverseMap();
            CreateMap<Employee, GetAllEmployee>().ReverseMap();

            CreateMap<Project, CreateProject>().ReverseMap();
            CreateMap<Project, GetAllProjects>().ReverseMap();
        }
    }
}
