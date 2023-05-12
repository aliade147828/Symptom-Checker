using BLL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.BLL.Repositories;
using WebApplication5.Data;

namespace BLL.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
