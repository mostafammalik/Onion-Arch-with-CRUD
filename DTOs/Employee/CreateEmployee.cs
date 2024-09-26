using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Employee
{
    public class CreateEmployee
    {

        public int Id { get; set; }
        [DisplayName("Employee Name")]
        [MinLength(3)]
        public string Name { set; get; }
        [DisplayName("Net Salary")]
        [Range(1000,100000)]
        public int Salary { set; get; }
        public int DepartmentId { set; get; }
    }
}
