using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Department
{
    public class CreateDepartmentDTO
    {
        public int Id { get; set; }
        [DisplayName("Department Name")]
        [MinLength(3)]
        public string? Name { get; set; }
        [DisplayName("Manager Name")]
        [MinLength(3)]
        public string? ManagerName { set; get; }
       
    }
}
