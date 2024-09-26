using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Department:BaseEntity<int>
    { 
      //  public int Id { get; set; } 
        public string Name { get; set; } 
        public string ManagerName { set; get; } 
        public ICollection<Employee>?Employees { set; get; } 
       // public ICollection<Project>?Projects { set; get; }

    }
}
