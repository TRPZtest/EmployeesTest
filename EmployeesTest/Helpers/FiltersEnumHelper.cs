using EmployeesTest.Data.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeesTest.Helpers
{
    public static class FiltersEnumHelper
    {
        public static void GetFiltersArray<Filters>() 
        {
            var filters = Enum.GetValues(typeof(Filters)).Cast<Filters>();
        }
    }
}
