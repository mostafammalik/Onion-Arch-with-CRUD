using DTOs.Department;
using DTOs.Employee;
using DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IDepartmentService
    {
        Task<CreateDepartmentDTO> CreateAsync(CreateDepartmentDTO entity);
        Task<CreateDepartmentDTO> DeleteAsync(CreateDepartmentDTO entity);

        Task<CreateDepartmentDTO> UpdateAsync(CreateDepartmentDTO entity);
        Task<List<GetAllDepartments>> GetAllAsync();
        Task<Pagenation<GetAllDepartments>> GetAllPaginatedAsync(int pageNumber, int Count);
        Task<List<GetAllDepartments>> SearchByNameAsync(string Search); 
        
    }
}
