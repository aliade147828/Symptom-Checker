using WebApplication5.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Interfaces;
using BLL.Interfaces;

namespace BLL.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IDoctorRepository DoctorRepository { get; set; }
        public IAppointmentRepository AppointmentRepository { get; set ; }
        public IRequestRepository RequestRepository { get ; set; }

        public UnitOfWork(IDoctorRepository doctorRepository, 
            IDepartmentRepository departmentRepository,
            IAppointmentRepository appointmentRepository,
            IRequestRepository requestRepository)
        {
            DoctorRepository = doctorRepository;
            DepartmentRepository = departmentRepository;
            AppointmentRepository = appointmentRepository;
            RequestRepository = requestRepository;

        }
    }
}
