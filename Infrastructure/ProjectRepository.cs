using Application.Contract;
using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProjectRepository : GenericRepository<Project>,IProjectRepository
    {
        public ProjectRepository(CompanyContext context) : base(context)
        {
        }
    }
}
