﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Department
{
    public class GetAllDepartments
    {
        public int Id { get; set; }
      
        public string? Name { get; set; }
   
        public string? ManagerName { set; get; }

    }
}
