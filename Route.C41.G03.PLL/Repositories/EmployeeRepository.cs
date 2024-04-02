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
    internal class EmployeeRepository : GenericRepositery<Employee>, IEmployeeRepository
    {
        // private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
           : base(dbContext)
        {
            // dbContext = dbContext;
        }

        public IEquatable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
           return _dbContext.Employees.Where(E => E.Address.ToLower() == address.ToLower());                                                                                                                              
        }
    }
}