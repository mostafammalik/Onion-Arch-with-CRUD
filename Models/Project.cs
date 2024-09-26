using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Project:BaseEntity<int>
    { 
        //public int Id { get; set; }  
       
        public string Name { get; set; } 
        public int EmployeeId { set; get; } 
        public int DepartmentId { set; get; }
      
        public Department? department { set; get; } 
        public Employee? Employee { set; get; }

    }
}
