using EmployeesTest.Data.Db.Enteties;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesTest.Models
{
    public class EditEmployeeView : EmployeeView
    {
        public Department[] Departments { get; set; }
        public Position[] Positions { get; set; }
    }
}
