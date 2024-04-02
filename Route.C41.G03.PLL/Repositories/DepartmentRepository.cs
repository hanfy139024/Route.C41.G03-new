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
    public class DepartmentRepository : GenericRepositery<Department>,IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            
        }
        //private readonly ApplicationDbContext _dbContext;

        //public DepartmentRepository(ApplicationDbContext dbContext) // ask clr for creating object from ApplicationDbContext
        //{
        //    _dbContext = dbContext;
        //}
        //public int Add(Department entity)
        //{
        //   _dbContext.Add(entity);
        //   return _dbContext.SaveChanges();

        //}

        //public int Delete(Department entity)
        //{
        //    _dbContext.Remove(entity);
        //    return _dbContext.SaveChanges();
        //}

        //public Department Get(int id)
        //{
        //    ///var department = _dbContext.Departments.Local.Where(d=>d.Id == id).FirstOrDefault();
        //    ///if (department == null)
        //    ///{
        //    ///    department = _dbContext.Departments.Where(department => department.Id == id).FirstOrDefault();
        //    ///}
        //    ///return department;
        //    //return _dbContext.Departments.Find(id);
        //    return _dbContext.Find<Department>(id); // ef core 3.1 New Feature
        //}

        //public IEnumerable<Department> GetAll()
        //{
        //    return _dbContext.Departments.AsNoTracking().ToList();
        //}

        //public int Update(Department entity)
        //{
        //    _dbContext.Update(entity);
        //    return _dbContext.SaveChanges();
        //}
    }
}
