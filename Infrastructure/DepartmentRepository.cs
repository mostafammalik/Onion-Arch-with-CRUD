using Application.Contract;
using AutoMapper;
using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
       
        public DepartmentRepository(CompanyContext context) : base(context)
        {

        } 
        

    }
}
