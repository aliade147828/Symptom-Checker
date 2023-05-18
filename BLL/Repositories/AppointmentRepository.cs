using BLL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.BLL.Repositories;
using WebApplication5.Data;

namespace BLL.Repositories
{
    public class AppointmentRepository :GenericRepository<Appoinment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext context;

        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Appoinment> GetAllWithDocotr(string id = null)
        {
            if (id == null)
                return context.Appoinments.Include(a => a.Doctor).ToList();
            else
                return context.Appoinments.Where(a => a.DoctorId == id).Include(a => a.Doctor).ToList();

        }
    }
}
