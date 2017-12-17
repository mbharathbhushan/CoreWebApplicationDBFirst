using CoreWebApplicationDBFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApplicationDBFirst.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(EmployeeDBContext employeeDBContext) : base(employeeDBContext)
        {
        }

        //public override async Task<Employee> Get(Func<Employee,bool> predicate)
        //{
        //    return await employeeDBContext.Set<Employee>().AsNoTracking().Include(x => x.add)
        //}

    }
}
