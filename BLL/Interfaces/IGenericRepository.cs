using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        T Get(int? id);

        IEnumerable<T> GetAll();

        int Add(T T);

        int Update(T T);

        int Delete(T T);
        IEnumerable<Doctor> Search(string Name);
    }
}
