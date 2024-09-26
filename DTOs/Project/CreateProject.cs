using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Project
{
    public class CreateProject
    {
        public int Id { get; set; }
   
        public string Name { get; set; }
        public int EmployeeId { set; get; }
        public int DepartmentId { set; get; }
    }
}
