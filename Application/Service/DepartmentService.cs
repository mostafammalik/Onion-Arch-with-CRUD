using Application.Contract;
using AutoMapper;
using DTOs.Department;
using DTOs.Employee;
using DTOs.Shared;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository ,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<CreateDepartmentDTO> CreateAsync(CreateDepartmentDTO entity)
        {
            if (entity != null)
            {
                bool Exist = (await _departmentRepository.GetAllAsync()).Any(p => p.Name == entity.Name);
                if (Exist)
                {
                    return new CreateDepartmentDTO();
                }
                else
                {
                    Department CreatedDeparment = _mapper.Map<Department>(entity);
                    _departmentRepository.CreatAsync(CreatedDeparment);
                    return _mapper.Map<CreateDepartmentDTO>(CreatedDeparment);
                }
            } 
            else
            {
                return new CreateDepartmentDTO();
            }

        }

        public async Task<CreateDepartmentDTO> DeleteAsync(CreateDepartmentDTO entity)
        { 
            var deletedDepartment =_mapper.Map<Department>(entity);

            var deleted =await _departmentRepository.DeleteAsync(deletedDepartment);


            var deletedDTO=  _mapper.Map<CreateDepartmentDTO>(deletedDepartment); 
            return deletedDTO;
        }

        public  async Task<List<GetAllDepartments>> GetAllAsync()
        {
            var Departments = (await _departmentRepository.GetAllAsync())
                .Select(d =>new GetAllDepartments() { Id=d.Id,Name=d.Name ,ManagerName =d.ManagerName }).ToList();
      
            return Departments;
        }

        public async Task<Pagenation<GetAllDepartments>> GetAllPaginatedAsync(int pageNumber, int Count)
        {
            var pages = (await _departmentRepository.GetAllAsync())
                .Skip((pageNumber - 1) * Count)
                .Take(pageNumber)
                .ToList();
            var data= _mapper.Map<List<GetAllDepartments>>(pages);
            var c = (await _departmentRepository.GetAllAsync()).Count();
            Pagenation<GetAllDepartments> pagenation = new() 
            { 
                Entity=data,
                Count=c

            };
            return pagenation;
        }

        public async Task<List<GetAllDepartments>> SearchByNameAsync(string Search)
        {
            var department = (await _departmentRepository.GetAllAsync())
                .Where(d => d.Name.Contains(Search))
                .ToList();
            //var department2 = (await _departmentRepository.GetAllAsync()).Where(d => d.Name.Contains(Search)).ToList(); 
            var Data =_mapper.Map<List<GetAllDepartments>>(department);
            return Data;
        }

        public async Task<CreateDepartmentDTO> UpdateAsync(CreateDepartmentDTO entity)
        {
            var updatedDepartment = _mapper.Map<Department>(entity);
            var result= (await _departmentRepository.UpdateAsync(updatedDepartment));
            var CreatedDepartment = _mapper.Map<CreateDepartmentDTO>(result);
            return CreatedDepartment;
             
        }
    }
}
