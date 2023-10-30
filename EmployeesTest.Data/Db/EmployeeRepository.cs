using EmployeesTest.Data.Db.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Employee[]> GetAllEmployees()
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

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee is not null)
                _context.Employees.Remove(employee);
        }

        public void UpdateEmplyee(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
