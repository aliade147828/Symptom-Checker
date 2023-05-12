using DAL.Entities;
using WebApplication5.BLL.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication5.Data;

namespace WebApplication5.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
        
    }
}
