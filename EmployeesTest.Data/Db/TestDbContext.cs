using EmployeesTest.Data.Db.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTest.Data.Db
{
    public class TestDbContext : AppDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Вантажник" },
                new Position { Id = 2, Name = "Водій"},
                new Position { Id = 3, Name = "Бухгалтер"}
            );

            modelBuilder.Entity<Department>().HasData(
               new Position { Id = 1, Name = "Відділ логістики" },
               new Position { Id = 2, Name = "Фінансовий відділ" }             
           );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Іван",
                    LastName = "Петров",
                    Patronimyc = "Олександрович",
                    DepartmentId = 1, 
                    PositionId = 1 
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Марія",
                    LastName = "Іванова",
                    Patronimyc = "Миколаївна",
                    DepartmentId = 2,
                    PositionId = 3
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Петро",
                    LastName = "Сидоров",
                    Patronimyc = "Іванович",
                    DepartmentId = 1,
                    PositionId = 2
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Оксана",
                    LastName = "Коваль",
                    Patronimyc = "Михайлівна",
                    DepartmentId = 2, 
                    PositionId = 3 
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Андрій",
                    LastName = "Захарчук",
                    Patronimyc = "Ярославович",
                    DepartmentId = 1,
                    PositionId = 1 
                });
        }
    }
}
