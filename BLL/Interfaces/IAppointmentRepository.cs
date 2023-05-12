using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.BLL.Interfaces;

namespace BLL.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllWithDocotr(string id = null);

    }
}
