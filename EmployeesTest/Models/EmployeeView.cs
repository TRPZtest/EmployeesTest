using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeesTest.Models
{
    public class EmployeeView 
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimyc { get; set; }
        public int DepartmentId { get; set; }
        public String DepartmentName { get; set; }
        public int PositionId { get; set; }
        public String PositionName { get; set; }
    }
}
