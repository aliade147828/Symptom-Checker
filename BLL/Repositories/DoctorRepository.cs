using DAL.Entities;
using WebApplication5.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace WebApplication5.BLL.Repositories
{
    public class DoctorRepository :GenericRepository<Doctor>,IDoctorRepository
    {
        private readonly ApplicationDbContext context;

        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }


      
      
    }
}
