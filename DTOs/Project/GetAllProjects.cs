using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Project
{
    public class GetAllProjects
    {
        public string? Name { get; set; }
        public string? ManagerName { set; get; }
        public string? DepartmentName { set; get; }
    }
}
