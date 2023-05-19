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

        public IEnumerable<Doctor> SearchDoctors(string name, string location, int? departmentId)
        {

            var query = ((IEnumerable<Doctor>)context.Doctor).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(d => d.UserName.Contains(name));
            }
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(d => d.Location.Contains(location));
            }
            if (departmentId != null)
            {
                query = query.Where(d => d.DNO == departmentId);
            }


            return query.ToList();
        }


    }
}
