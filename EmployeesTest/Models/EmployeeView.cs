using EmployeesTest.Data.Db.Enteties;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeesTest.Models
{
    public class EmployeeView 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Patronimyc { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [DisplayName("Відділ")]
        public String DepartmentName { get; set; }
        [Required]
        public int PositionId { get; set; }
        [DisplayName("Позиція")]
        public String PositionName { get; set; }       
    }
}
