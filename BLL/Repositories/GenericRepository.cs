using WebApplication5.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication5.Data;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.BLL.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Add(T item)
        {
            context.Set<T>().Add(item);
            return context.SaveChanges();
        }

        public  int Delete(T item)
        {
            context.Set<T>().Remove(item);
            return  context.SaveChanges();
        }

        public T Get(int? id)
            => context.Set<T>().Find(id);

        public IEnumerable<T> GetAll()
            => context.Set<T>().ToList();

        public int Update(T item)
        {
            context.Set<T>().Update(item);
            return context.SaveChanges();
        }

        public IEnumerable<Doctor> Search(string Name)
           =>  context.Set<Doctor>().Where(E => E.UserName.Contains(Name)).ToList();
    }
}
