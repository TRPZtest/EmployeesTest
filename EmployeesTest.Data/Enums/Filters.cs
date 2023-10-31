using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeesTest.Data.Enums
{
    public enum Filters
    {
        [Description("LastName")]
        LastName,
        [Display(Name = "Department")]
        Department,
        [Display(Name = "Position")]
        Position
    }
}
