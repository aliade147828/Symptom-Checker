using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.BLL.Interfaces
{
    public interface IDoctorRepository:IGenericRepository<Doctor>
    {
        public IEnumerable<Doctor> SearchDoctors(string name, string location, int? departmentId);
    }
}
