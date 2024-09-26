using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Employee
{
    public class GetAllEmployee
    {
        public string? Name { set; get; }  
        public int Salary { set; get; } 
        public string? DepartmentName { set; get; } 
        public string? ProjectName { set; get; }
    }
}
