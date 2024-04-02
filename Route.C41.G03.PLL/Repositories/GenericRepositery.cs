using Microsoft.EntityFrameworkCore;
using Route.C41.G03.BLL.Interfaces;
using Route.C41.G03.Dal.Data;
using Route.C41.G03.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.G03.BLL.Repositories
{
    public class GenericRepositery<T> : IGenericRepositery<T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _dbContext;

        public GenericRepositery(ApplicationDbContext dbContext) // ask clr for creating object from ApplicationDbContext
        {
            _dbContext = dbContext;
        }
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();

        }

        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
           // _dbContext.Remove
            return _dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
        public T Get(int id)
        {
            ///var Employee = _dbContext.Employees.Local.Where(d=>d.Id == id).FirstOrDefault();
            ///if (Employee == null)
            ///{
            ///    Employee = _dbContext.Employees.Where(Employee => Employee.Id == id).FirstOrDefault();
            ///}
            ///return Employee;
            //return _dbContext.Employees.Find(id);
            return _dbContext.Find<T>(id); // ef core 3.1 New Feature
        }

        public IEnumerable<T> GetAll() 
            => _dbContext.Set<T>().AsNoTracking().ToList();

    }
}