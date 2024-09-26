using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee:BaseEntity<int>
    { 
        //public int Id { get; set; } 
        public string Name { set; get; } 
        public int DepartmentId { set; get; }  
        public Department department { set; get; } 
       // public ICollection<Project> Projects { set; get; }

     }
}
