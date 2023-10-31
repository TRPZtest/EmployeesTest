using EmployeesTest.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeesTest.Models
{
    public class EmployeesListView
    {
        public EmployeeView[] Employees { get; set; }     
        public Filters? Filter { get; set; }
        public Filters[] Filters { get; set; }
        [Display(Name = "Поле для пошуку")]
        public string FilterValue { get; set; }
    }
}
