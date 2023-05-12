using WebApplication5.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace WebApplication5.Interfaces
{
    public interface IUnitOfWork
    {

        IDepartmentRepository DepartmentRepository { get; set; }
        IDoctorRepository DoctorRepository { get; set; }
        IAppointmentRepository AppointmentRepository { get; set; }
        IRequestRepository RequestRepository { get; set; }



    }
}
