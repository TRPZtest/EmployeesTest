using EmployeesTest.Data.Db.Enteties;
using EmployeesTest.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTest.Data.Db
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Employee[]> GetAllAsync()
        {
            var employees = await _context.Employees
                .Include(x => x.Position)
                .Include(x => x.Department)
                .AsNoTracking()
                .ToArrayAsync();

            return employees;
        }

        public async Task<Position[]> GetAllPositionsAcync()
        {
            var positions = await _context.Positions
                .AsNoTracking()
                .ToArrayAsync();

            return positions;
        }

        public async Task<Department[]> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments
                .AsNoTracking()
                .ToArrayAsync();

            return departments;
        }

        public void Delete(Employee employee)
        {          
           _context.Employees.Remove(employee);
        }

        public async Task<Employee> FindAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            return employee;
        }

        public void UpdateEmplyee(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Employee[]> GetWithFilter(Filters? filter, string filterValue)
        {
            var employees = _context.Employees
                    .Include(x => x.Position)
                    .Include(x => x.Department)
                    .AsNoTracking();

            if (filter == Filters.LastName)
                employees = employees.Where(x => x.LastName.Contains(filterValue, StringComparison.CurrentCultureIgnoreCase));

            if (filter == Filters.Department)
                employees = employees.Where(x => x.Department.Name.Contains(filterValue, StringComparison.CurrentCultureIgnoreCase));

            if (filter == Filters.Position)
                employees = employees.Where(x => x.Position.Name.Contains(filterValue, StringComparison.CurrentCultureIgnoreCase));          

            var employeesArray = await employees.ToArrayAsync();

            return employeesArray;
        }
    }
}
